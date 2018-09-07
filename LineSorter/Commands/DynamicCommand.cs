using System;
using Microsoft.VisualStudio.Shell;
using System.ComponentModel.Design;

namespace LineSorter.Commands
{
    public class DynamicCommand : OleMenuCommand
    {
        #region Var
        private Predicate<int> Match { get; }
        #endregion

        #region Init
        public DynamicCommand(EventHandler InvokeHandler, EventHandler ChangeHandler, EventHandler BeforeQueryStatusHandler, CommandID CmdID, Predicate<int> Match) : base(InvokeHandler, ChangeHandler, BeforeQueryStatusHandler, CmdID) =>
            this.Match = Match ?? throw new ArgumentNullException(nameof(Match));

        public DynamicCommand(EventHandler InvokeHandler, CommandID CmdID, Predicate<int> Match) : this(InvokeHandler, null, null, CmdID, Match) { }
        public DynamicCommand(EventHandler InvokeHandler, EventHandler BeforeQueryStatusHandler, CommandID CmdID, Predicate<int> Match) : this(InvokeHandler, null, BeforeQueryStatusHandler, CmdID, Match) { }
        #endregion

        #region Functions
        public override bool DynamicItemMatch(int CmdID)
        {
            if (Match(CmdID))
            {
                MatchedCommandId = CmdID;
                return true;
            }
            MatchedCommandId = 0;
            return false;
        }
        #endregion
    }
}
