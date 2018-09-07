using System;
using System.Linq;
using LineSorter.Helpers;
using System.Collections.Generic;
using Microsoft.VisualStudio.Shell;

namespace LineSorter.Commands
{
    internal sealed class CommandRandomSort : BaseCommand<CommandRandomSort>
    {
        #region Var
        private static Random Rand { get; } = new Random();
        #endregion

        #region Init
        static CommandRandomSort()
        {
            CommandID = 0x0104;
            CommandSet = new Guid("e9f69e2b-6313-4c2b-9765-1ddd6439d519");
        }
        #endregion

        #region Functions
        protected override void Execute(OleMenuCommand Button) =>
            Shuffle(TextSelection.GetSelection(Package, out bool newLine)).ReplaceSelection(newLine);

        private static IEnumerable<T> Shuffle<T>(IEnumerable<T> Source)
        {
            T[] data = Source.ToArray();
            for (int i = data.Length - 1; i > -1; --i)
            {
                int newIndex = Rand.Next(i + 1);
                yield return data[newIndex];
                data[newIndex] = data[i];
            }
        }
        #endregion
    }
}
