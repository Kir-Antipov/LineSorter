using EnvDTE;
using System;
using Microsoft;
using System.Linq;
using System.Windows;
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
        public static IEnumerable<string> GetSelection(out bool WasNewLine)
        {
            IVsTextManager2 textManager = ServiceProvider.GetService(typeof(SVsTextManager)) as IVsTextManager2;
            Assumes.Present(textManager);
            textManager.GetActiveView2(1, null, (uint)_VIEWFRAMETYPE.vftCodeWindow, out IVsTextView view);
            view.GetSelectedText(out string selectedText);
            WasNewLine = selectedText.EndsWith(Environment.NewLine);
            return selectedText.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim(new char[] { ' ', '\t' }));
        }
        public static IEnumerable<string> GetSelection(IServiceProvider ServiceProvider, out bool WasNewLine)
        {
            TextSelection.ServiceProvider = ServiceProvider;
            return GetSelection(out WasNewLine);
        }

        public static void ReplaceSelection(this IEnumerable<string> Selections, bool WasNewLine)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            DTE dte = ServiceProvider?.GetService(typeof(DTE)) as DTE;            
            if (dte is null) return;
            // `((EnvDTE.TextSelection)dte.ActiveDocument.Selection).Text =  value` is really slow!
            // So I use this small 'hack':
            // Saving current clipboard state:
            IDataObject obj = Clipboard.GetDataObject();
            // Loading text to clipboard:
            Clipboard.SetText(string.Join("\r\n", Selections) + (WasNewLine ? "\r\n" : string.Empty));
            // Pasting text from clipboard (and formating it):
            dte.ExecuteCommand("Edit.Paste");
            // Now we return everything as it was)
            Clipboard.SetDataObject(obj);
        }
        public static void ReplaceSelection(this IEnumerable<string> Selections) => ReplaceSelection(Selections, ServiceProvider, false);
        public static void ReplaceSelection(this IEnumerable<string> Selections, IServiceProvider ServiceProvider, bool WasNewLine)
        {
            TextSelection.ServiceProvider = ServiceProvider;
            ReplaceSelection(Selections, WasNewLine);
        }
        #endregion
    }
}
