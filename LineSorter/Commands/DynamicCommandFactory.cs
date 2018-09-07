using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.Shell;
using System.ComponentModel.Design;

namespace LineSorter.Commands
{
    public class DynamicCommandFactory
    {
        #region Var
        private Guid Group { get; }
        private int CurrentCmdID { get; set; }
        private OleMenuCommandService Service { get; }
        private List<MenuCommandWrapper> _commands { get; }
        public IEnumerable<MenuCommandWrapper> Commands => _commands;
        #endregion

        #region Init
        public DynamicCommandFactory(OleMenuCommandService Service, Guid Group, int StartID)
        {
            this.Group = Group;
            CurrentCmdID = StartID;
            this.Service = Service;
            _commands = new List<MenuCommandWrapper>();
        }
        public DynamicCommandFactory(OleMenuCommandService Service, Guid Group) : this(Service, Group, 0x1000) { }
        #endregion

        #region Functions
        public MenuCommandWrapper Create(EventHandler Invoke, string Text)
        {
            MenuCommandWrapper wrapper = MenuCommandWrapper.Create(Invoke, new CommandID(Group, CurrentCmdID++), IsValid, Text);
            _commands.Add(wrapper);
            Service.AddCommand(wrapper);
            return wrapper;
        }
        public MenuCommandWrapper Create(Action Invoke, string Text) => Create((sender, e) => Invoke(), Text);
        public MenuCommandWrapper Create(Action<OleMenuCommand> Invoke, string Text) => Create((sender, e) => Invoke((OleMenuCommand)sender), Text);

        private bool IsValid(int CmdID) => CmdID > CurrentCmdID - _commands.Count && CmdID < CurrentCmdID;

        public void Clear() => Clear(true);
        private void Clear(bool Delete)
        {
            foreach (OleMenuCommand cmd in _commands)
                Service.RemoveCommand(cmd);
            CurrentCmdID -= _commands.Count;
            if (Delete)
                _commands.Clear();
        }

        public bool Delete<T>(Func<MenuCommandWrapper, T> Extractor, T Value)
        {
            int length = _commands.Count;
            for (int i = 0; i < length; i++)
                if (Extractor(_commands[i]).Equals(Value))
                {
                    Clear(false);
                    _commands.RemoveAt(i);
                    --length;
                    for (int j = 0; j < length; j++)
                    {
                        _commands[j].ChangeCmdID(CurrentCmdID++);
                        Service.AddCommand(_commands[j]);
                    }
                    return true;
                }
            return false;
        }
        public bool Delete(string Name) => Delete(cmd => cmd.Text, Name);
        public bool Delete(int CmdID) => Delete(cmd => cmd.CommandID.ID, CmdID);
        #endregion
    }
}
