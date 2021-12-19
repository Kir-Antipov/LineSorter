using System;
using System.Linq;
using System.Collections.Generic;

namespace LineSorter.Helpers
{
    public enum NewlineType
    {
        Undefined,
        LF,
        CRLF,
        CR,
        LFCR,
        // RS // If someone will need it - uncomment!
    }

    public static class NewlineTypeExtensions
    {
        #region Var
        private static Dictionary<NewlineType, string> Representations { get; } = new Dictionary<NewlineType, string> {
            { NewlineType.LF, "\n" },
            { NewlineType.CRLF, "\r\n" },
            { NewlineType.CR, "\r" },
            { NewlineType.LFCR, "\n\r" },
            // { NewlineType.RS, ((char)30).ToString() }, // If someone will need it - uncomment!
            { NewlineType.Undefined, Environment.NewLine }
        };

        private static Lazy<HashSet<char>> CommandChars { get; } = new Lazy<HashSet<char>>(() => new HashSet<char>(Representations.SelectMany(x => x.Value)));
        #endregion

        #region Functions
        public static string AsString(this NewlineType Type) => Representations.ContainsKey(Type) ? Representations[Type] : Representations[NewlineType.Undefined];

        public static NewlineType GetNewlineType(this string ToTest)
        {
            string data = new string(ToTest.SkipWhile(x => !CommandChars.Value.Contains(x)).Take(2).Where(CommandChars.Value.Contains).ToArray());
            return Representations.ContainsValue(data) ? Representations.First(x => x.Value == data).Key : NewlineType.Undefined;
        }
        #endregion
    }
}
