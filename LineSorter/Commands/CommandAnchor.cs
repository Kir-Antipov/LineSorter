using EnvDTE;
using System;
using System.Linq;
using LineSorter.Export;
using LineSorter.Options;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Threading;
using Microsoft.VisualStudio.Shell.Interop;

namespace LineSorter.Commands
{
    internal sealed class CommandAnchor : BaseCommand<CommandAnchor>
    {
        #region Init
        static CommandAnchor()
        {
            CommandID = 0x0106;
            CommandSet = new Guid("e9f69e2b-6313-4c2b-9765-1ddd6439d519");
        }

        protected override void AfterInit()
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            if (VSPackage.Loader.Settings.LoadOnInit)
            {
                VSPackage.Loader.RefreshAssemblies();
                foreach (IUserSort sort in VSPackage.Loader.Sorts.Where(x => VSPackage.Loader.Settings.Loaded.Contains(x.Guid)))
                    CommandUserSort.Instance.AddSort(sort);
            }
        }
        #endregion

        #region Functions
        protected override void Execute(OleMenuCommand Button) { }
        #endregion
    }
}
