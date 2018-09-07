using System.IO;
using System.Xml.Serialization;

namespace LineSorter.Options
{
    public class Settings
    {
        #region Var
        public string[] Loaded { get; set; }
        public bool LoadOnInit { get; set; }
        public bool LoadOnCreate { get; set; }
        #endregion

        #region Functions
        public void Save(string Path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, this);
                File.WriteAllText(Path, writer.ToString());
            }
        }
        public static Settings Read(string Path)
        {
            if (!File.Exists(Path))
                return createNew();
            try
            {
                using (StringReader reader = new StringReader(File.ReadAllText(Path)))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                    Settings settings = (Settings)serializer.Deserialize(reader);
                    if (!settings.LoadOnInit)
                    {
                        settings.Loaded = new string[0];
                        settings.Save(Path);
                    }
                    return settings;
                }
            } catch {
                return createNew();
            }

            Settings createNew()
            {
                Settings result = new Settings { Loaded = new string[0], LoadOnCreate = true, LoadOnInit = true };
                result.Save(Path);
                return result;
            }
        }
        #endregion
    }
}
