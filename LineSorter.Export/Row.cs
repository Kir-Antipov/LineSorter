using System;

namespace LineSorter.Export
{
    [Serializable]
    public class Row
    {
        #region Var
        public string Initial { get; }
        public string Cleared { get; }
        #endregion

        #region Init
        public Row(string Initial)
        {
            this.Initial = Initial;
            Cleared = Initial.Trim(' ', '\t');
        }
        public Row() : this(string.Empty) { }
        #endregion

        #region Functions
        public static explicit operator string(Row A) => A.Initial;
        public static explicit operator Row(string A) => new Row(A);

        public override string ToString() => Cleared;
        public override int GetHashCode() => Initial.GetHashCode();
        public override bool Equals(object obj) => obj is Row r && r.Initial == Initial;
        #endregion
    }
}
