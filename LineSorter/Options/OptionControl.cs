using System.IO;
using System.Linq;
using System.Drawing;
using LineSorter.Export;
using LineSorter.Helpers;
using System.Globalization;
using System.Windows.Forms;
using System.Collections.Generic;

namespace LineSorter.Options
{
    public partial class OptionControl : UserControl
    {
        #region Var
        private bool Initialized { get; }
        private List<string> Selected { get; set; }

        public Color SelectedSort { get; set; } = Color.LightGreen;
        public Color NotSelectedSort { get; set; } = Color.LightPink;

        private static ResourceManager<OptionControl> Manager { get; } = ResourceManager<OptionControl>.Instance;
        #endregion

        #region Init
        static OptionControl()
        {
            CultureInfo en = new CultureInfo("en");
            CultureInfo ru = new CultureInfo("ru-RU");
            Manager["OptionControl", en] = "General";
            Manager["OptionControl", ru] = "Общие";
            Manager["groupAutoLoad", en] = "Autoload";
            Manager["groupAutoLoad", ru] = "Автозагрузка";
            Manager["groupLines", en] = "Empty lines processing";
            Manager["groupLines", ru] = "Обработка пустых строк";
            Manager["groupUserSort", en] = "Custom sorts";
            Manager["groupUserSort", ru] = "Пользовательские сортировки";
            Manager["checkLoadOnInit", en] = "Load custom sorts at startup";
            Manager["checkLoadOnInit", ru] = "Загружать пользовательские сортировки при запуске";
            Manager["checkLoadOnCreate", en] = "Load custom sorts on creating";
            Manager["checkLoadOnCreate", ru] = "Загружать пользовательские сортировки при создании";
            Manager["checkRemove", en] = "Delete empty lines";
            Manager["checkRemove", ru] = "Удалять пустые строки";
            Manager["checkAsLine", en] = "Process as ordinary strings";
            Manager["checkAsLine", ru] = "Обрабатывать как обычные строки";
            Manager["checkAsMask", en] = "Use as mask (fixed anchor)";
            Manager["checkAsMask", ru] = "Использовать как маску (неподвижный якорь)";
            Manager["checkAsGroupMarker", en] = "Use as separator";
            Manager["checkAsGroupMarker", ru] = "Использовать как разделитель";
            Manager["buttDelete", en] = "Delete";
            Manager["buttDelete", ru] = "Удалить";
            Manager["buttUse.Use", en] = "Use";
            Manager["buttUse.Use", ru] = "Использовать";
            Manager["buttUse.DontUse", en] = "Don't use";
            Manager["buttUse.DontUse", ru] = "Не использовать";
            Manager["Question", en] = "Confirmation required";
            Manager["Question", ru] = "Требуется подтверждение";
            Manager["Question.Question", en] = "Are you sure you want to delete this sort?\r\n\r\nThe action is irreversible!";
            Manager["Question.Question", ru] = "Вы уверены, что хотите удалить данную сортировку?\r\n\r\nДействие необратимо!";
        }

        public OptionControl()
        {
            InitializeComponent();
            Selected = new List<string>(VSPackage.Loader.Settings.Loaded);
            checkLoadOnInit.Checked = VSPackage.Loader.Settings.LoadOnInit;
            checkLoadOnCreate.Checked = VSPackage.Loader.Settings.LoadOnCreate;
            groupLines.Controls.OfType<RadioButton>().First(x => x.Name.EndsWith(VSPackage.Loader.Settings.EmptyLineAction.ToString())).Checked = true;
            Manager.Localize(this);
            Initialized = true;
        }
        #endregion

        #region Functions
        public void RefreshData()
        {
            VSPackage.Loader.RefreshAssemblies();
            Selected = new List<string>(VSPackage.Loader.Settings.Loaded);
            RefreshGrid();
        }
        private void RefreshGrid()
        {
            gridSorts.Rows.Clear();
            foreach (IUserSort sort in VSPackage.Loader.Sorts)
                SetBackColor(gridSorts.Rows[gridSorts.Rows.Add(sort.Guid, sort)], Selected.Contains(sort.Guid) ? SelectedSort : NotSelectedSort);
            int height = gridSorts.Rows.Cast<DataGridViewRow>().Sum(x => x.Height + 1) + gridSorts.ColumnHeadersHeight + 1;
            if (height < 22)
                height = 22;
            else
                if (height > 255)
                    height = 255;
            gridSorts.Height = height;
            groupUserSort.Height = height + 28;
            gridSorts.ClearSelection();
        }

        private void Add(IUserSort Sort, DataGridViewRow Row)
        {
            Selected.Add(Sort.Guid);
            Commands.CommandUserSort.Instance.AddSort(Sort);
            SetBackColor(Row, SelectedSort);
        }
        private void Delete(IUserSort Sort, DataGridViewRow Row)
        {
            Selected.Remove(Sort.Guid);
            Commands.CommandUserSort.Instance.Factory.Delete(x => x.GetParameter<string>("Guid"), Sort.Guid);
            SetBackColor(Row, NotSelectedSort);
        }

        private void SetBackColor(DataGridViewRow Row, Color Color)
        {
            foreach (DataGridViewCell cell in Row.Cells)
                cell.Style.BackColor = Color;
        }

        private void UpdateSettings()
        {
            if (Initialized)
            {
                VSPackage.Loader.Settings.LoadOnInit = checkLoadOnInit.Checked;
                VSPackage.Loader.Settings.LoadOnCreate = checkLoadOnCreate.Checked;
                VSPackage.Loader.Settings.EmptyLineAction = (EmptyLineAction)System.Enum.Parse(typeof(EmptyLineAction), groupLines.Controls.OfType<RadioButton>().FirstOrDefault(x => x.Checked)?.Name.Replace("check", string.Empty) ?? "Remove");
                VSPackage.Loader.Settings.Save(SortsLoader.SettingsPath);
            }
        }
        #endregion

        #region Actions
        private void StateChanged(object sender, System.EventArgs e) => UpdateSettings();

        private void OptionControl_VisibleChanged(object sender, System.EventArgs e)
        {
            // Refresh sizes
            checkLoadOnCreate.AutoSize = checkLoadOnInit.AutoSize = false;
            checkLoadOnCreate.AutoSize = checkLoadOnInit.AutoSize = true;

            RefreshData();
        }

        private void GridSorts_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo info = gridSorts.HitTest(e.X, e.Y);
                if (info.RowIndex > -1)
                {
                    gridSorts.ClearSelection();
                    gridSorts.Rows[info.RowIndex].Selected = true;
                }
            }
        }

        private void GridSorts_Leave(object sender, System.EventArgs e) => gridSorts.ClearSelection();

        private void GridStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DataGridViewRow row = gridSorts.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();
            if (row == null)
                gridStrip.Hide();
            else
                buttUse.Text = Selected.Contains(((IUserSort)row.Cells[1].Value).Guid) ? Manager["buttUse.DontUse"] : Manager["buttUse.Use"];
        }

        private void ButtUse_Click(object sender, System.EventArgs e)
        {
            DataGridViewRow row = gridSorts.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();
            if (row == null)
                return;
            IUserSort sort = (IUserSort)row.Cells[1].Value;
            if (Selected.Contains(sort.Guid))
                Delete(sort, row);
            else
                Add(sort, row);
            VSPackage.Loader.Settings.Loaded = Selected.ToArray();
            VSPackage.Loader.Settings.Save(SortsLoader.SettingsPath);
            gridSorts.ClearSelection();
        }

        private void ButtDelete_Click(object sender, System.EventArgs e)
        {
            DataGridViewRow row = gridSorts.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();
            if (row == null || MessageBox.Show(Manager["Question.Question"], Manager["Question"], MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                return;
            IUserSort sort = (IUserSort)row.Cells[1].Value;
            Delete(sort, row);
            string file = VSPackage.Loader.SortFiles.FirstOrDefault(x => x.Value == sort).Key;
            AssemblyLoader.Unload(file);
            if (File.Exists(file))
                File.Delete(file);
            RefreshData();
        }
        #endregion

    }
}
