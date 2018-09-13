using System.ComponentModel;

namespace LineSorter.Export
{
    public enum EmptyLineAction
    {
        DependsOnSettings,
        Remove,
        AsLine,
        AsMask,

        [Browsable(false)]
        AsGroupMarker
    }
}
