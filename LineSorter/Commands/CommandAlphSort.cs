using System;
using System.Linq;
using LineSorter.Export;
using LineSorter.Helpers;
using Microsoft.VisualStudio.Shell;

namespace LineSorter.Commands
{
    internal sealed class CommandAlphSort : BaseCommand<CommandAlphSort>
    {
        #region Init
        static CommandAlphSort()
        {
            CommandID = 0x0102;            
            CommandSet = new Guid("e9f69e2b-6313-4c2b-9765-1ddd6439d519");
        }
        #endregion

        #region Functions
        protected override void Execute(OleMenuCommand Button) =>
            TextSelection.GetSelection(Package, out int[] poses, out bool newLine).Select(x => (Row)x).OrderBy(x => x.Cleared).ThenBy(x => x.Cleared.Length).Select(x => (string)x).ReplaceSelection(poses, newLine);
        #endregion
    }
}
