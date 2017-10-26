using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace AmmPlayer.PlayerItems
{
    public class TrackListsManager
    {
        public static string PlayListsStoreFile
        {
            get
            {
                var listFile = Path.Combine(Path.GetDirectoryName(Assembly.GetCallingAssembly().Location), "plist.xml");
                return listFile;
            }
        }

        public static TrackLists Load()
        {
            if (!File.Exists(PlayListsStoreFile))
                return new TrackLists()
                {
                    Lists = new List<PlayList>(),
                };
            using (var s = File.OpenRead(PlayListsStoreFile))
            {
                var ds = new XmlSerializer(typeof(TrackLists)).Deserialize(s);
                return ds as TrackLists;
            }
        }

        public static void Save(TrackLists lists)
        {
            using (var s = File.OpenWrite(PlayListsStoreFile))
            {
                new XmlSerializer(typeof(TrackLists)).Serialize(s, lists);
            }
        }
    }
}