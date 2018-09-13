using EnvDTE;
using System;
using Microsoft;
using System.Linq;
using System.Windows;
using LineSorter.Export;
using System.Collections.Generic;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.TextManager.Interop;

namespace LineSorter.Helpers
{
    public static class TextSelection
    {
        #region Var
        public static IServiceProvider ServiceProvider { get; set; }
        #endregion

        #region Functions
        public static IEnumerable<string> GetSelection(EmptyLineAction Action, out int[] EmptyLinePositions, out bool WasNewLine)
        {
            IVsTextManager2 textManager = ServiceProvider.GetService(typeof(SVsTextManager)) as IVsTextManager2;
            Assumes.Present(textManager);
            textManager.GetActiveView2(1, null, (uint)_VIEWFRAMETYPE.vftCodeWindow, out IVsTextView view);
            view.GetSelectedText(out string selectedText);
            WasNewLine = selectedText.EndsWith("\n");
            IEnumerable<string> result = selectedText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            int lastIndex = ((string[])result).Length - 1;
            EmptyLinePositions = result.Select((x, i) => new { Line = x, Index = i }).Where(x => string.IsNullOrWhiteSpace(x.Line)).Select(x => x.Index).ToArray();
            if (Action == EmptyLineAction.DependsOnSettings)
                Action = VSPackage.Loader.Settings.EmptyLineAction;
            result = Action == EmptyLineAction.AsLine ? result.Where((x, i) => !(string.IsNullOrEmpty(x) && i == lastIndex)) : result.Where(x => !string.IsNullOrWhiteSpace(x));
            return result;
        }
        public static IEnumerable<string> GetSelection(IServiceProvider ServiceProvider, out int[] EmptyLinePositions, out bool WasNewLine)
        {
            TextSelection.ServiceProvider = ServiceProvider;
            return GetSelection(VSPackage.Loader.Settings.EmptyLineAction, out EmptyLinePositions, out WasNewLine);
        }
        public static IEnumerable<string> GetSelection(IServiceProvider ServiceProvider, EmptyLineAction Action, out int[] EmptyLinePositions, out bool WasNewLine)
        {
            TextSelection.ServiceProvider = ServiceProvider;
            return GetSelection(Action, out EmptyLinePositions, out WasNewLine);
        }

        public static void ReplaceSelection(this IEnumerable<string> Selections, EmptyLineAction Action, int[] EmptyLinePositions, bool WasNewLine)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            if (Action == EmptyLineAction.DependsOnSettings)
                Action = VSPackage.Loader.Settings.EmptyLineAction;
            DTE dte = ServiceProvider?.GetService(typeof(DTE)) as DTE;            
            if (dte is null) return;
            switch (Action)
            {
                case EmptyLineAction.AsMask:
                    int i = 0;
                    Selections = Selections.SelectMany(x => {
                        List<string> result = new List<string>();
                        while(EmptyLinePositions.Contains(i))
                        {
                            result.Add(string.Empty);
                            i++;
                        }
                        result.Add(x);
                        i++;
                        return result;
                    });
                    break;
                default:
                    break;
            }
            // `((EnvDTE.TextSelection)dte.ActiveDocument.Selection).Text =  value` is really slow!
            // So I use this small 'hack':
            // Saving current clipboard state:
            IDataObject obj = Clipboard.GetDataObject();
            // Loading text to clipboard:
            Clipboard.SetText(string.Join(Environment.NewLine, Selections) + (WasNewLine ? Environment.NewLine : string.Empty));
            // Pasting text from clipboard (and formatting it):
            dte.ExecuteCommand("Edit.Paste");
            // Now we return everything as it was)
            Clipboard.SetDataObject(obj);
        }
        public static void ReplaceSelection(this IEnumerable<string> Selections, IServiceProvider ServiceProvider, int[] EmptyLinePositions, bool WasNewLine)
        {
            TextSelection.ServiceProvider = ServiceProvider;
            ReplaceSelection(Selections, VSPackage.Loader.Settings.EmptyLineAction, EmptyLinePositions, WasNewLine);
        }
        public static void ReplaceSelection(this IEnumerable<string> Selections, IServiceProvider ServiceProvider, EmptyLineAction Action, int[] EmptyLinePositions, bool WasNewLine)
        {
            TextSelection.ServiceProvider = ServiceProvider;
            ReplaceSelection(Selections, Action, EmptyLinePositions, WasNewLine);
        }
        public static void ReplaceSelection(this IEnumerable<string> Selections, int[] EmptyLinePositions, bool WasNewLine) => ReplaceSelection(Selections, VSPackage.Loader.Settings.EmptyLineAction, EmptyLinePositions, WasNewLine);
        #endregion
    }
}
