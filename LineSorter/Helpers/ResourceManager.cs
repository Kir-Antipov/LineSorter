using System.Globalization;
using System.Collections.Generic;

namespace LineSorter.Helpers
{
    // You can ask me: why did I do this if there is a ComponentResourceManager
    // And I'll answer: this sh*t does not work with [assembly: NeutralResourcesLanguage(...)]
    // Argh
    public class ResourceManager<T>
    {
        #region Var
        public static ResourceManager<T> Instance { get; } = new ResourceManager<T>();
        private static CultureInfo Invariant { get; } = new CultureInfo(string.Empty);
        private static Dictionary<CultureInfo, Dictionary<string, string>> Strings { get; } = new Dictionary<CultureInfo, Dictionary<string, string>> { { Invariant, new Dictionary<string, string>() } };
        #endregion

        #region Init
        private ResourceManager() { }
        #endregion

        #region Functions
        public string this[string Key]
        {
            get => Get(Key);
            set => Set(Key, value);
        }
        public string this[string Key, CultureInfo Culture]
        {
            get => Get(Key, Culture);
            set => Set(Key, value, Culture);
        }

        public static void Set(string Key, string Value, CultureInfo Culture)
        {
            if (!Strings.ContainsKey(Culture))
                Strings.Add(Culture, new Dictionary<string, string>());
            Strings[Culture][Key] = Value;
        }
        public static void Set(string Key, string Value) => Set(Key, Value, Invariant);

        public static string Get(string Key, CultureInfo Culture)
        {
            while (!Strings.ContainsKey(Culture) && !Culture.IsNeutralCulture && !string.IsNullOrEmpty(Culture.Name))
                Culture = Culture.Parent;
            if (!Strings.ContainsKey(Culture))
                Culture = Invariant;
            return Strings[Culture].ContainsKey(Key) ? Strings[Culture][Key] : null;
        }
        public static string Get(string Key) => Get(Key, CultureInfo.CurrentUICulture);
        #endregion
    }
}
