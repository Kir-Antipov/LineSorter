using System;
using Microsoft.VisualStudio.Shell;
using System.ComponentModel.Design;
using Task = System.Threading.Tasks.Task;

namespace LineSorter.Commands
{
    public abstract class BaseCommand<T> where T : BaseCommand<T>, new()
    {
        #region Var
        public string Text
        {
            get => Command.Text;
            set => ChangeText(value);
        }
        private string _text { get; set; }
        protected AsyncPackage Package { get; set; }
        protected OleMenuCommand Command { get; set; }
        public static T Instance { get; private set; }
        public static int CommandID { get; internal set; }
        public static Guid CommandSet { get; internal set; }
        protected IServiceProvider ServiceProvider => Package;
        protected IAsyncServiceProvider AsyncServiceProvider => Package;
        #endregion

        #region Init
        public static async Task InitializeAsync(AsyncPackage Package)
        {
            Instance = new T();
            Instance.Init(Package, await Package.GetServiceAsync((typeof(IMenuCommandService))) as OleMenuCommandService);
        }
        private void Init(AsyncPackage Package, OleMenuCommandService CommandService)
        {
            this.Package = Package ?? throw new ArgumentNullException(nameof(Package));
            Command = new OleMenuCommand((sender, e) => { ThreadHelper.ThrowIfNotOnUIThread(); Execute((OleMenuCommand)sender); }, new CommandID(CommandSet, CommandID));
            (CommandService ?? throw new ArgumentNullException(nameof(CommandService))).AddCommand(Command);
        }
        #endregion

        #region Functions
        protected abstract void Execute(OleMenuCommand Button);

        private void ChangeText(string NewText)
        {
            if (ServiceProvider.GetService(typeof(IMenuCommandService)) is OleMenuCommandService commandService)
            {
                commandService.RemoveCommand(Command);
                void change(object sender, EventArgs e)
                {
                    OleMenuCommand command = (OleMenuCommand)sender;
                    command.Text = NewText;
                    command.BeforeQueryStatus -= change;
                }
                Command.BeforeQueryStatus += change;
                commandService.AddCommand(Command);
            }
        }
        #endregion
    }
}
