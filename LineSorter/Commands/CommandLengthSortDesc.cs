using System;
using System.Linq;
using LineSorter.Helpers;
using Microsoft.VisualStudio.Shell;

namespace LineSorter.Commands
{
    internal sealed class CommandLengthSortDesc : BaseCommand<CommandLengthSortDesc>
    {
        #region Init
        static CommandLengthSortDesc()
        {
            CommandID = 0x0101;
            CommandSet = new Guid("e9f69e2b-6313-4c2b-9765-1ddd6439d519");
        }
        #endregion

        #region Functions
        protected override void Execute(OleMenuCommand Button)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            TextSelection.GetSelection(Package, out bool newLine).OrderByDescending(x => x.Length).ThenByDescending(x => x).ReplaceSelection(newLine);
        }
        #endregion
    }
}
