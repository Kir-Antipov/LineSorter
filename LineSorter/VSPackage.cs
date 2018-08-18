using System;
using System.Threading;
using LineSorter.Commands;
using Microsoft.VisualStudio.Shell;
using System.Runtime.InteropServices;
using System.Diagnostics.CodeAnalysis;
using Task = System.Threading.Tasks.Task;

namespace LineSorter
{
    [Guid(PackageGuidString)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
    public sealed class VSPackage : AsyncPackage
    {
        #region Var
        public const string PackageGuidString = "7fb18e2a-1a51-4dbb-b676-a3514e44823d";
        #endregion

        #region Functions
        protected override async Task InitializeAsync(CancellationToken CancellationToken, IProgress<ServiceProgressData> Progress)
        {
            await JoinableTaskFactory.SwitchToMainThreadAsync(CancellationToken);

            await CommandLengthSort.InitializeAsync(this);
            await CommandLengthSortDesc.InitializeAsync(this);
            await CommandAlphSort.InitializeAsync(this);
            await CommandAlphSortDesc.InitializeAsync(this);
        }
        #endregion
    }
}
