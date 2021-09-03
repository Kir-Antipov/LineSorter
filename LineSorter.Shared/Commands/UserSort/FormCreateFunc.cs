using System;
using System.IO;
using System.Linq;
using System.Drawing;
using LineSorter.Export;
using System.Reflection;
using LineSorter.Helpers;
using System.Globalization;
using System.Windows.Forms;
using System.CodeDom.Compiler;
using KE.VSIX.DotNetCompilerPlatform;

namespace LineSorter.Commands.UserSort
{
    public partial class FormCreateFunc : Form
    {
        #region Var
        private string SavePath { get; }
        private Graphics Measure { get; }
        private string[] DefaultNamespaces { get; } = new string[] {
            "System",
            "System.Linq",
            "System.Text",
            "LineSorter.Export",
            "System.Windows.Forms",
            "System.ComponentModel",
            "System.Threading.Tasks",
            "System.Collections.Generic",
            "System.Text.RegularExpressions"
        };
        private string[] DefaultAssemblies { get; } = new string[] {
            "System",
            "System.Xml",
            "System.Web", // Ha-ha, funny joke, Roslyn... (vbc.exe doesn't work without this reference)
            "System.Core",
            "System.Data",
            "System.Net.Http",
            "System.Xml.Linq",
            "System.Windows.Forms",
            "System.Data.DataSetExtensions",
            CommandUserSort.ExportFile
        };
        public new IUserSort DialogResult { get; private set; }
        private static ResourceManager<FormCreateFunc> Manager { get; } = ResourceManager<FormCreateFunc>.Instance;
        #endregion

        #region Init
        static FormCreateFunc()
        {
            CultureInfo en = new CultureInfo("en");
            CultureInfo ru = new CultureInfo("ru-RU");
            Manager["FormCreateFunc", en] = "Creating a custom sort"; 
            Manager["FormCreateFunc", ru] = "Создание пользовательской сортировки";
            Manager["labelLang", en] = "Language:";
            Manager["labelLang", ru] = "Язык:";
            Manager["labelFunc", en] = "Function type:";
            Manager["labelFunc", ru] = "Тип функции:";
            Manager["labelT", en] = "`T` is:";
            Manager["labelT", ru] = "`T` является:";
            Manager["labelEmpty", en] = "Empty Lines:";
            Manager["labelEmpty", ru] = "Пустые линии:";
            Manager["labelName", en] = "Name:";
            Manager["labelName", ru] = "Название:";
            Manager["buttCompile", en] = "Compile";
            Manager["buttCompile", ru] = "Компилировать";
            Manager["buttCancel", en] = "Cancel";
            Manager["buttCancel", ru] = "Отмена";
            Manager["comboFunc.Items.0", en] = "Comparer (Func<T, T, int>)";
            Manager["comboFunc.Items.0", ru] = "Компаратор (Func<T, T, int>)";
            Manager["comboFunc.Items.1", en] = "Full implementation (Func<IEnumerable<T>, IEnumerable<T>>)";
            Manager["comboFunc.Items.1", ru] = "Полная реализация (Func<IEnumerable<T>, IEnumerable<T>>)";
            Manager["comboLines.Items.0", en] = "Depends on global settings";
            Manager["comboLines.Items.0", ru] = "Аналогично глобальным настройкам";
            Manager["comboLines.Items.1", en] = "Remove";
            Manager["comboLines.Items.1", ru] = "Удалять";
            Manager["comboLines.Items.2", en] = "As ordinary strings";
            Manager["comboLines.Items.2", ru] = "Как обычные строки";
            Manager["comboLines.Items.3", en] = "As mask";
            Manager["comboLines.Items.3", ru] = "В качестве маски";
            Manager["Error", en] = "Error!";
            Manager["Error", ru] = "Ошибка!";
            Manager["Error.NoName", en] = "Please specify the function name!";
            Manager["Error.NoName", ru] = "Пожалуйста, укажите имя функции!";
            Manager["Success", en] = "Success!";
            Manager["Success", ru] = "Успех!";
            Manager["Success.Compile", en] = "Your method has been compiled successfully!";
            Manager["Success.Compile", ru] = "Ваш метод был успешно скомпилирован!";
            Manager["Test", en] = "Test";
            Manager["Test", ru] = "Тест";
            Manager["Test.Question", en] = "Do you want to test your method?";
            Manager["Test.Question", ru] = "Хотите протестировать Ваш метод?";
            Manager["Question", en] = "Did the sorting succeed?";
            Manager["Question", ru] = "Сортировка удалась?";
            Manager["Question.Question", en] = "Do you want to save the created method and exit the editor?";
            Manager["Question.Question", ru] = "Вы хотите сохранить созданный метод и выйти из редактора?";
        }

        public FormCreateFunc(string SavePath)
        {
            InitializeComponent();
            this.SavePath = SavePath;
            comboLang.SelectedIndex = 0;
            comboFunc.SelectedIndex = 0;
            comboType.SelectedIndex = 0;
            comboLines.SelectedIndex = 0;
            Measure = Graphics.FromImage(new Bitmap(textMain.Width, textMain.MaximumSize.Height));
            Manager.Localize(this);          
        }
        public FormCreateFunc() : this(string.Empty) { } 
        #endregion

        #region Functions
        private void Compile()
        {
            string name = textName.Text;
            if (string.IsNullOrWhiteSpace(name))
            {
                ShowError(Manager["Error.NoName"]);
                return;
            }
            bool isCSharp = comboLang.SelectedIndex == 0;
            bool isString = comboType.SelectedIndex == 0;
            bool isCompare = comboFunc.SelectedIndex == 0;
            string emptyLineAction = ((EmptyLineAction)comboLines.SelectedIndex).ToString();
            string userCode = $"{(isCSharp ? textBefore.Text : (isCompare ? $"{textBefore.Text} Implements IComparer(Of {(isString ? "String" : "Row")}).Compare" : (isString ? ($"{textBefore.Text} Implements IUserSort.Sort") : textBefore.Text)))}{Environment.NewLine}{textMain.Text}{Environment.NewLine}{textAfter.Text}";
            if (isCSharp)
            {
                if (isCompare)
                {
                    userCode = $@"  public IEnumerable<string> Sort(IEnumerable<string> Source) 
                                    {{
                                        UserComparer comparer = new UserComparer();
                                        return {(isString ? "Source.OrderBy(x => x, comparer)" : "Source.Select(x => (Row)x).OrderBy(x => x, comparer).Select(x => (string)x)")};
                                    }}

                                    private class UserComparer : IComparer<{(isString ? "string" : "Row")}>
                                    {{
                                        {userCode}
                                    }}";
                }
                else
                    if (!isString)
                    userCode = $@"  public IEnumerable<string> Sort(IEnumerable<string> Source) {{ return Sort(Source.Select(x => (Row)x)).Select(x => (string)x); }}
                                    {userCode}";


            }
            else
            {
                if (isCompare)
                {
                    userCode = $@"  Public Function Sort(Source As IEnumerable(Of String)) As IEnumerable(Of String) Implements IUserSort.Sort
                                        Dim comparer = New UserComparer()
                                        Return {(isString ? "Source.OrderBy(Of String)(Function(x) x, comparer)" : "Source.Select(Function(x) CType(x, Row)).OrderBy(Of Row)(Function(x) x, comparer).Select(Function(x) CType(x, String))")}
                                    End Function

                                    Private Class UserComparer
                                        Implements IComparer(Of {(isString ? "String" : "Row")})
                                            {userCode}
                                    End Class";
                }
                else
                    if (!isString)
                    userCode = $@"  Public Function Sort(Source As IEnumerable(Of String)) As IEnumerable(Of String) Implements IUserSort.Sort
                                        Return Sort(Source.Select(Function(x) CType(x, Row))).Select(Function(x) CType(x, String))
                                    End Function

    {userCode}";
            }
            string namespaces = string.Join(Environment.NewLine, DefaultNamespaces.Select(x => isCSharp ? $"using {x};" : $"Imports {x}"));
            string guid = Guid.NewGuid().ToString();
            string resultCode = isCSharp ?
                $@"{namespaces}
                namespace _{guid.Replace('-', '_')}_
                {{
                    [System.Serializable]
                    public class Wrapper : IUserSort
                    {{
                        public string Guid {{ get {{ return ""{guid}""; }} }}
                        public string Name {{ get {{ return ""{name}""; }} }} 
                        public EmptyLineAction EmptyLineAction {{ get {{ return EmptyLineAction.{emptyLineAction}; }} }}
                        {userCode}
                        public override string ToString()
                        {{
                            return Name;
                        }}
                    }}
                }}"
                :
                $@"{namespaces}
                Namespace _{guid.Replace('-', '_')}_
                    <System.Serializable()> Public Class Wrapper
                        Implements IUserSort
                        Public ReadOnly Property Guid As String Implements IUserSort.Guid
                            Get
                                Return ""{guid}""
                            End Get
                        End Property
                        Public ReadOnly Property Name As String Implements IUserSort.Name
                            Get
                                Return ""{name}""
                            End Get
                        End Property
                        Public ReadOnly Property EmptyLineAction As EmptyLineAction Implements IUserSort.EmptyLineAction
                            Get
                                Return EmptyLineAction.{emptyLineAction}
                            End Get
                        End Property
                        {userCode}
                        Public Overrides Function ToString() As String
                            Return Name
                        End Function
                    End Class
                End Namespace";

            CompilerParameters options = new CompilerParameters {
                GenerateExecutable = false,
                GenerateInMemory = false,
                OutputAssembly = Path.Combine(SavePath, $"{guid}.dll")
            };
            foreach (string a in DefaultAssemblies.Select(x => x.EndsWith(".dll", StringComparison.OrdinalIgnoreCase) || x.EndsWith(".exe", StringComparison.OrdinalIgnoreCase) ? x : $"{x}.dll"))
                options.ReferencedAssemblies.Add(a);

            CodeDomProvider provider = CodeProvider.Create(isCSharp ? Language.CSharp : Language.VB, VSPackage.PathData);
            CompilerResults results = provider.CompileAssemblyFromSource(options, resultCode);

            if (results.Errors.HasErrors)
            {
                ShowError(string.Join(Environment.NewLine + Environment.NewLine, results.Errors.Cast<CompilerError>().Where(x => !x.IsWarning).Select(x => x.ErrorText)));
            }
            else
            {
                try
                {
                    DialogResult = AssemblyLoader.Load(results.PathToAssembly).LoadInterface<IUserSort>();
                    ShowSuccess(Manager["Success.Compile"]);
                    if (ShowQuestion(Manager["Test"], Manager["Test.Question"]) == System.Windows.Forms.DialogResult.Yes)
                        using (FormTestFunc test = new FormTestFunc(DialogResult))
                            test.ShowDialog();
                    if (ShowQuestion(Manager["Question"], Manager["Question.Question"]) == System.Windows.Forms.DialogResult.No)
                    {
                        File.Delete(results.PathToAssembly);
                        DialogResult = null;
                        return;
                    }
                }
                catch (ReflectionTypeLoadException e)
                {
                    ShowError(string.Join(Environment.NewLine, (object[])e.LoaderExceptions));
                }
                catch (Exception e)
                {
                    ShowError(e.Message);
                }
                Close();
            }
        }
        private void RefreshSettings()
        {
            if (comboLang.SelectedIndex == 0)
            {
                string type = comboType.SelectedIndex == 0 ? "string" : "Row";
                textBefore.Freezed = textAfter.Freezed = false;
                textBefore.Text = comboFunc.SelectedIndex == 0 ? $"public int Compare({type} A, {type} B) {{" : textBefore.Text = $"public IEnumerable<{type}> Sort(IEnumerable<{type}> Source) {{";
                textAfter.Text = "}";
                textAfter.Freezed = textBefore.Freezed = true;
            }
            else
            {
                string type = comboType.SelectedIndex == 0 ? "String" : "Row";
                textBefore.Freezed = textAfter.Freezed = false;
                textBefore.Text = comboFunc.SelectedIndex == 0 ? $"Public Function Compare(A As {type}, B As {type}) As Integer" : $"Public Function Sort(Source As IEnumerable(Of {type})) As IEnumerable(Of {type})";
                textAfter.Text = "End Function";
                textAfter.Freezed = textBefore.Freezed = true;
            }
        }

        private void ShowError(string Text) => MessageBox.Show(Text, Manager["Error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
        private void ShowSuccess(string Text) => MessageBox.Show(Text, Manager["Success"], MessageBoxButtons.OK, MessageBoxIcon.Information);
        private DialogResult ShowQuestion(string Title, string Text) => MessageBox.Show(Text, Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        #endregion

        #region Actions
        private void ButtCompile_Click(object sender, EventArgs e) => Compile();
        private void PanelBack_Click(object sender, EventArgs e) => textMain.Focus();
        private void RefreshSettings(object sender, EventArgs e) => RefreshSettings();

        private void ButtCancel_Click(object sender, EventArgs e)
        {
            DialogResult = null;
            Close();
        }
        private void TextMain_TextChanged(object sender, EventArgs e)
        {
            if (textMain.AutoHeight)
            {
                float textHeight = Measure.MeasureString(textMain.Text.EndsWith("\n") ? textMain.Text + " " : textMain.Text, textMain.Font).Height;
                textHeight = textHeight >= textMain.MinimumSize.Height && textHeight <= textMain.MaximumSize.Height ? (float)(Math.Floor(textHeight) + Math.Floor(textHeight / 100)) : textHeight < textMain.MinimumSize.Height ? textMain.MinimumSize.Height : textMain.MaximumSize.Height;
                textMain.Height = panelBack.Height = (int)textHeight;
                textAfter.Top = textMain.Height + textMain.Top;
                buttCompile.Top = buttCancel.Top = textAfter.Top + textAfter.Height + 6;
                Height = buttCancel.Top + buttCancel.Height + 45;
            }
        }

        public new IUserSort ShowDialog()
        {
            base.ShowDialog();
            return DialogResult;
        }

        private void FormCreateFunc_Load(object sender, EventArgs e) => ControlBox = ShowIcon = MinimizeBox = MaximizeBox = false;

        private void TextMain_Enter(object sender, EventArgs e) => AcceptButton = null;
        private void TextMain_Leave(object sender, EventArgs e) => AcceptButton = buttCompile;
        #endregion
    }
}
