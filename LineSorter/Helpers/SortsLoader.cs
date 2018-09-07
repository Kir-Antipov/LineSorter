using System;
using System.IO;
using System.Linq;
using System.Text;
using LineSorter.Export;
using LineSorter.Options;
using LineSorter.Commands;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace LineSorter.Helpers
{
    public class SortsLoader
    {
        #region Var
        public Settings Settings { get; set; }
        public List<IUserSort> Sorts { get; set; }
        public string[] ProcessedFiles { get; set; }
        public static string SettingsPath { get; set; }
        public Dictionary<string, IUserSort> SortFiles { get; set; }
        #endregion

        #region Init
        static SortsLoader() => SettingsPath = Path.Combine(VSPackage.Path, "settings.xml");

        public SortsLoader()
        {
            ProcessedFiles = new string[0];
            Sorts = new List<IUserSort>();
            SortFiles = new Dictionary<string, IUserSort>();
            Settings = Settings.Read(SettingsPath);
        }
        #endregion

        #region Functions
        public void RefreshAssemblies()
        {
            string[] files = Directory.GetFiles(CommandUserSort.SavePath);
            foreach (string file in files.Where(x => !ProcessedFiles.Contains(x) && !x.EndsWith("LineSorter.Export.dll")))
            {
                IUserSort sort = LoadSort(file);
                if (sort != null)
                {
                    SortFiles[file] = sort;
                    Sorts.Add(sort);
                }
            }
            foreach (string file in ProcessedFiles.Where(x => !files.Contains(x)))
            {
                Sorts.Remove(SortFiles[file]);
                SortFiles.Remove(file);
            }
            ProcessedFiles = files;
        }

        private IUserSort LoadSort(string Path)
        {
            if (File.Exists(Path))
            {
                try
                {
                    int index = Path.LastIndexOf('\\');
                    if (index == -1)
                        index = Path.LastIndexOf('/');
                    string name = Path.Substring(index + 1, Path.Length - index - 1).Split('.')[0];
                    IUserSort sort = AssemblyLoader.Load(Path).LoadInterface<IUserSort>();
                    return sort;
                }
                catch
                {
                    return null;
                }
            }
            return null;
        }
        #endregion
    }
}
