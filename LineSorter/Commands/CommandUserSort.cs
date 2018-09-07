using System;
using System.IO;
using System.Linq;
using LineSorter.Export;
using System.Reflection;
using LineSorter.Helpers;
using LineSorter.Options;
using System.Collections.Generic;
using LineSorter.Commands.UserSort;
using Microsoft.VisualStudio.Shell;

namespace LineSorter.Commands
{
    internal sealed class CommandUserSort : BaseCommand<CommandUserSort>
    {
        #region Var
        public static string SavePath { get; }
        public static string ExportFile { get; }

        private DynamicCommandFactory _factory;
        public DynamicCommandFactory Factory => _factory ?? (_factory = new DynamicCommandFactory(Service, CommandSet, CommandAnchor.CommandID + 1));
        #endregion

        #region Init
        static CommandUserSort()
        {
            CommandID = 0x0105;
            CommandSet = new Guid("e9f69e2b-6313-4c2b-9765-1ddd6439d519");
            SavePath = Path.Combine(VSPackage.Path, "UserSort\\");
            ExportFile = Path.Combine(SavePath, "LineSorter.Export.dll");
            if (!Directory.Exists(SavePath))
                Directory.CreateDirectory(SavePath);
        }
        #endregion

        #region Functions
        protected override void Execute(OleMenuCommand Button)
        {
            IUserSort sort;
            using (FormCreateFunc create = new FormCreateFunc(SavePath))
                sort = create.ShowDialog();
            if (sort != null && VSPackage.Loader.Settings.LoadOnCreate)
            {
                VSPackage.Loader.Settings.Loaded = new List<string>(VSPackage.Loader.Settings.Loaded) { sort.Guid }.ToArray();
                VSPackage.Loader.Settings.Save(SortsLoader.SettingsPath);
                AddSort(sort);
            }
        }

        public void AddSort(IUserSort Sort)
        {
            MenuCommandWrapper wrapper = Factory.Create(() => Sort.Sort(TextSelection.GetSelection(Package, out bool was)).ReplaceSelection(was), Sort.Name);
            wrapper.SetParameter("Guid", Sort.Guid);
        }
        #endregion
    }
}
