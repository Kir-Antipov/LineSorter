using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace LineSorter.Commands.UserSort
{
    public class LangBox : RichTextBox, IDisposable
    {
        #region Var
        [Browsable(true), Category("Theme")]
        public Color KeywordColor { get; set; } = Color.SteelBlue;
        [Browsable(true), Category("Theme")]
        public Color ClassColor { get; set; } = Color.LightSeaGreen;
        [Browsable(true), Category("Theme")]
        public Color StringColor { get; set; } = Color.Firebrick;
        [Browsable(true), Category("Theme")]
        public Color CommentColor { get; set; } = Color.YellowGreen;
        [Browsable(true), Category("Theme")]
        public Color NumericColor { get; set; } = Color.MediumSeaGreen;
        [Browsable(true), Category("Theme")]
        public bool Freezed { get => _freezed; set { if (value) Freeze(); else if (value != _freezed) Timer.Start(); _freezed = value; } }
        private bool _freezed = false;
        [Browsable(true), Category("Theme")]
        public bool AutoHeight { get; set; } = true;
        [Browsable(true), Category("Theme")]
        public int TabSize { get; set; } = 4;
        [Browsable(true), Category("Theme")]
        public int Interval { get; set; } = 1000;
        private readonly object _lock = new object();


        private Timer Timer { get; }
        private Token[] Tokens { get; }
        private bool WasChanged { get; set; } = true;

        private class Token
        {
            public Color Color { get; }
            public Regex Regex { get; }
            private static char[] WhitespaceSymbols { get; } = new char[] { ' ', ',', '.', '(', ')', '_', '[', ']', '<', '>', ';', '=', '@', '$', '\n', '\r', '\t'};
            public bool NeedWhitespace { get; }

            public Token(Regex Regex, Color Color, bool NeedWhitespace)
            {
                this.Regex = Regex;
                this.Color = Color;
                this.NeedWhitespace = NeedWhitespace;
            }

            public IEnumerable<Match> Find(string Text) => NeedWhitespace ? Regex.Matches(Text).Cast<Match>().Where(x => (x.Index == 0 || IsSeparator(Text[x.Index - 1])) && (x.Index + x.Length - 1 == Text.Length - 1 || IsSeparator(Text[x.Index + x.Length]))) : Regex.Matches(Text).Cast<Match>();
            private bool IsSeparator(char Char) => WhitespaceSymbols.Contains(Char);
        }
        #endregion

        #region Init
        public LangBox()
        {
            Tokens = new Token[] {
                new Token(new Regex("namespace|unchecked|continue|delegate|checked|decimal|default|public|static|using|finally|foreach|double|object|params|return|sizeof|string|switch|typeof|unsafe|ushort|break|catch|const|false|fixed|float|sbyte|short|throw|ulong|while|bool|byte|case|char|else|goto|lock|long|null|true|uint|void|Void|for|int|new|out|ref|try|as|do|if|in|is|ByVal|ByRef|As|Of|Optional|ParamArray|If|Else|And|Or|Xor|False|True|And|AndAlso|Is|IsNot|Like|Mod|OrElse|Then|Sub|End|Function|Public|Return|CType"), KeywordColor, true),
                new Token(new Regex("IEnumerable|Random|Boolean|Regex|Match|MatchCollection|Int16|Int32|Int64|Integer|String|Char|Decimal|Double|Float|Delegate|Action|Row"), ClassColor, true),
                new Token(new Regex("([-]+)?[0-9]+"), NumericColor, true),
                new Token(new Regex("\".*\""), StringColor, false),
                new Token(new Regex("@\".*\"", RegexOptions.Singleline), StringColor, false),
                new Token(new Regex("/*.*/", RegexOptions.Singleline), CommentColor, false),
                new Token(new Regex("//.*"), CommentColor, false),
                new Token(new Regex("''.*"), CommentColor, false)
            };
            TextChanged += (s, e) => WasChanged = true;            
            Timer = new Timer { Interval = Interval };
            Timer.Tick += Timer_Tick;
            Timer.Start();
            Disposed += (s, e) => Timer.Dispose();
        }
        #endregion

        #region Functions
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (WasChanged)
            {
                UpdateSelection();
                WasChanged = false;
                Timer.Interval = Interval;
            }
        }
        private void SwitchKeyword(int Start, int Length, bool IsKeword, Color Color = default(Color))
        {
            Select(Start, Length);
            if (IsKeword)
            {
                SetStyle(FontStyle.Bold);
                SelectionColor = Color;
            }
            else
            {
                SetStyle(FontStyle.Regular);
                SelectionColor = ForeColor;
            }
            WasChanged = false;
            void SetStyle(FontStyle Style) => SelectionFont = new Font(SelectionFont, Style);
        }

        public void UpdateSelection()
        {
            lock (_lock)
            {
                Font = new Font(Font.FontFamily, Font.Size, FontStyle.Regular, GraphicsUnit.Point);
                SelectionColor = ForeColor;
                int start = SelectionStart;
                int length = SelectionLength;
                SwitchKeyword(0, Text.Length, false);
                foreach (Token token in Tokens)
                    foreach (Match match in token.Find(Text))
                        SwitchKeyword(match.Index, match.Length, true, token.Color);
                SwitchKeyword(start, length, false);
                ZoomFactor = 1.0f;
            }
        }
        private void Freeze()
        {
            Timer.Stop();
            UpdateSelection();
        }
        #endregion

        #region Rewrite some logic
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        protected override void WndProc(ref Message Msg)
        {
            base.WndProc(ref Msg);
            // Mouse Wheel
            if (Msg.Msg == 0x020A)
            {
                if (ModifierKeys == Keys.Control)
                    SendMessage(Handle, 0x04E1, IntPtr.Zero, IntPtr.Zero);
            }
        }
        protected override bool ProcessCmdKey(ref Message Msg, Keys KeyData)
        {
            if ((Msg.Msg == 0x100 || Msg.Msg == 0x104) && KeyData == Keys.Tab || KeyData == (Keys.Tab | Keys.Shift))
            {
                lock (_lock)
                {
                    if (KeyData.HasFlag(Keys.Shift))
                    {
                        int firstStart = SelectionStart;
                        int last = firstStart + SelectionLength - 1;
                        int removed = 0;
                        while (last > -1 && Text[last] == 32 && removed++ < TabSize)
                            Text = Text.Remove(last--, 1);
                        SelectionStart = firstStart - removed;
                    }
                    else
                        SelectedText += new string(' ', TabSize);
                }
                return true;
            }
            return base.ProcessCmdKey(ref Msg, KeyData);
        }
        #endregion
    }
}
