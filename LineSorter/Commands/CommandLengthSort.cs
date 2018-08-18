using System;
using System.Linq;
using LineSorter.Helpers;
using Microsoft.VisualStudio.Shell;

namespace LineSorter.Commands
{
    internal sealed class CommandLengthSort : BaseCommand<CommandLengthSort>
    {
        #region Init
        static CommandLengthSort()
        {
            CommandID = 0x0100;
            CommandSet = new Guid("e9f69e2b-6313-4c2b-9765-1ddd6439d519");
        }
        #endregion

        #region Functions
        protected override void Execute(OleMenuCommand Button)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            TextSelection.GetSelection(Package, out bool newLine).OrderBy(x => x.Length).ThenBy(x => x).ReplaceSelection(newLine);
        }
        #endregion
    }
}
