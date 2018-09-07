using System;
using LineSorter.Export;
using LineSorter.Helpers;
using System.Globalization;
using System.Windows.Forms;

namespace LineSorter.Commands.UserSort
{
    public partial class FormTestFunc : Form
    {
        #region Var
        private IUserSort Sorter { get; }
        private static ResourceManager<FormTestFunc> Manager { get; } = ResourceManager<FormTestFunc>.Instance;
        #endregion

        #region Init
        static FormTestFunc()
        {
            CultureInfo en = new CultureInfo("en");
            CultureInfo ru = new CultureInfo("ru-RU");
            Manager["FormTestFunc", en] = "Sorting function test";
            Manager["FormTestFunc", ru] = "Тест функции сортировки";
            Manager["labelTest", en] = "Test:";
            Manager["labelTest", ru] = "Тест:";
            Manager["labelResult", en] = "Result:";
            Manager["labelResult", ru] = "Результат:";
            Manager["buttDone", en] = "Done";
            Manager["buttDone", ru] = "Готово";
        }

        public FormTestFunc() => InitializeComponent();
        public FormTestFunc(IUserSort Sorter) : this()
        {
            textTest.Text = 
@"using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using Antlr4.Runtime;
using System.Data;
using Microsoft.CodeAnalysis;
using System.Reflection;
using System;
using System.Text;
using System.Drawing;
using System.Numerics;
using System.Linq;
using System.Xml.Linq;
using System.Collections;
using Antlr4;
using Microsoft.CodeAnalysis.Text;
using Antlr4.Runtime.Misc;";
            this.Sorter = Sorter;
            foreach (Control x in new Control[] { this, labelTest, labelResult, buttDone })
                x.Text = Manager[x.Name];
            Sort();
        }
        #endregion

        #region Actions
        private void Sort()
        {
            bool wasNewLine = textTest.Text.EndsWith("\n");
            textResult.Text = string.Join(Environment.NewLine, Sorter.Sort(textTest.Text.Split(new string[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries))) + (wasNewLine ? Environment.NewLine : string.Empty);
        }
        private void ButtDone_Click(object sender, EventArgs e) => Close();
        private void TextTest_TextChanged(object sender, EventArgs e) => Sort();
        #endregion
    }
}
