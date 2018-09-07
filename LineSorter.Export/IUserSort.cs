using System.Collections.Generic;

namespace LineSorter.Export
{
    public interface IUserSort
    {
        string Guid { get; }
        string Name { get; }
        IEnumerable<string> Sort(IEnumerable<string> Source);
    }
}
