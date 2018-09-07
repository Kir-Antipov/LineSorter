using System.Windows.Forms;
using Microsoft.VisualStudio.Shell;
using System.Runtime.InteropServices;

namespace LineSorter.Options
{
    [Guid(VSPackage.PackageGuidString)]
    public class OptionPageGrid : DialogPage
    {
        #region Var
        protected override IWin32Window Window => new OptionControl();
        #endregion
    }
}
