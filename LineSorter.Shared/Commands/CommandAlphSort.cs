using System.Linq;
using KE.VSIX.Commands;
using LineSorter.Export;
using LineSorter.Helpers;
using Microsoft.VisualStudio.Shell;

namespace LineSorter.Commands
{
    [CommandID("e9f69e2b-6313-4c2b-9765-1ddd6439d519", 0x0102)]
    internal sealed class CommandAlphSort : BaseCommand<CommandAlphSort>
    {
        protected override void Execute(OleMenuCommand Button) =>
            TextSelection.GetSelection(Package, out int[] poses, out NewlineType newlineType, out bool newLine)
                .Select(x => (Row)x)
                    .OrderBy(x => x.Cleared)
                    .ThenBy(x => x.Cleared.Length)
                .Select(x => (string)x)
            .ReplaceSelection(poses, newlineType, newLine);
    }
}
