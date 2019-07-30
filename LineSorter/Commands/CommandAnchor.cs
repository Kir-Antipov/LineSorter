using System.Linq;
using KE.VSIX.Commands;
using LineSorter.Export;
using Microsoft.VisualStudio.Shell;

namespace LineSorter.Commands
{
    [CommandID("e9f69e2b-6313-4c2b-9765-1ddd6439d519", 0x0106)]
    internal sealed class CommandAnchor : BaseCommand<CommandAnchor>
    {
        #region Init
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
