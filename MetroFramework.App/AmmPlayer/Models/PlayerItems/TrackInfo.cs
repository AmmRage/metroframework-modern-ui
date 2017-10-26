using System;
using System.IO;
using System.Linq;
using TagLib.Matroska;

namespace AmmPlayer.PlayerItems
{
    public enum MediaType
    {
        Musical,
        Text,
        Unknown,
    }

    public class TrackInfo
    {
        private static readonly string[] MusicalExtensions = new[] { ".mp3"};
        private static readonly string[] TextExtensions = new[] { ".shu", ".txt" };

        public string Name;
        public string Fullname;
        public string Artist;
        public TimeSpan? Duration;

        public MediaType TrackType;

        public TrackInfo(FileInfo fi)
        {
            this.Name = Path.GetFileNameWithoutExtension(fi.FullName);
            this.Fullname = fi.FullName;

            if (MusicalExtensions.All(e => !e.Equals(fi.Extension, StringComparison.CurrentCultureIgnoreCase)) &&
                TextExtensions.All(e => !e.Equals(fi.Extension, StringComparison.CurrentCultureIgnoreCase)))
            {
                this.TrackType = MediaType.Unknown;
                return;
            }

            if(MusicalExtensions.Any(e => e.Equals(fi.Extension, StringComparison.CurrentCultureIgnoreCase)))
                using (var file = TagLib.File.Create(fi.FullName))
                {
                    this.Artist = string.Join(", ", file.Tag.Performers);
                    this.Duration = file.Properties.Duration;
                }

            if (TextExtensions.Any(e => e.Equals(fi.Extension, StringComparison.CurrentCultureIgnoreCase)))
                ;
        }
    }
}