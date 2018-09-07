using System;
using System.Linq;
using LineSorter.Export;
using LineSorter.Helpers;
using Microsoft.VisualStudio.Shell;

namespace LineSorter.Commands
{
    internal sealed class CommandAlphSortDesc : BaseCommand<CommandAlphSortDesc>
    {
        #region Init
        static CommandAlphSortDesc()
        {
            CommandID = 0x0103;            
            CommandSet = new Guid("e9f69e2b-6313-4c2b-9765-1ddd6439d519");
        }
        #endregion

        #region Functions
        protected override void Execute(OleMenuCommand Button) =>
            TextSelection.GetSelection(Package, out bool newLine).Select(x => (Row)x).OrderByDescending(x => x.Cleared).ThenByDescending(x => x.Cleared.Length).Select(x => (string)x).ReplaceSelection(newLine);
        #endregion
    }
}
