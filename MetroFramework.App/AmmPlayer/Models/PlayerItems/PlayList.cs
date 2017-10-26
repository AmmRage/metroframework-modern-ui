using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AmmPlayer.PlayerItems
{
    public class PlayList
    {
        public string Name { get; private set; }

        public List<TrackInfo> Tracks { get; private set; }

        /// <summary>
        /// build play list from dir
        /// </summary>
        /// <param name="dir"></param>
        public PlayList(string dir, string name)
        {
            this.Name = name;
            if (Directory.Exists(dir))
                this.Tracks.AddRange(new DirectoryInfo(dir).GetFiles("*.*", SearchOption.AllDirectories).Select(f => new TrackInfo(f)));
        }

        /// <summary>
        /// build play list from tracks
        /// </summary>
        /// <param name="tracks"></param>
        public PlayList(IEnumerable<FileInfo> tracks, string name)
        {
            this.Name = name;
            this.Tracks.AddRange(tracks.Select(f => new TrackInfo(f)));
        }

    }
}