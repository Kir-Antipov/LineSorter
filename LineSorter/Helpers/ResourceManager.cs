﻿using System.Globalization;
using System.Windows.Forms;
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
        public string this[Control Control]
        {
            get => Get(Control.Name);
            set => Set(Control.Name, value);
        }
        public string this[string Key, CultureInfo Culture]
        {
            get => Get(Key, Culture);
            set => Set(Key, value, Culture);
        }
        public string this[Control Control, CultureInfo Culture]
        {
            get => Get(Control.Name, Culture);
            set => Set(Control.Name, value, Culture);
        }

        public void Localize(Control Container)
        {
            string text = Get(Container.Name);
            if (text != null)
                Container.Text = text;
            if (Container.ContextMenuStrip != null)
                Localize(Container.ContextMenuStrip);
            foreach (Control x in Container.Controls)
                Localize(x);
            if (Container is ComboBox combo)
                LocalizeItems(combo);
        }
        private void Localize(ToolStrip Container)
        {
            string text = Get(Container.Name);
            if (text != null)
                Container.Text = text;
            foreach (ToolStripItem x in Container.Items)
            {
                text = Get(x.Name);
                if (text != null)
                    x.Text = text;
            }
        }

        public void LocalizeItems(ComboBox Box)
        {
            int count = Box.Items.Count;
            for (int i = 0; i < count; ++i)
                Box.Items[i] = Get($"{Box.Name}.Items.{i}") ?? Box.Items[i];
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
