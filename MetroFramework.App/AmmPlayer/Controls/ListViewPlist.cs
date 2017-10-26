using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AmmPlayer.PlayerItems;
using MetroFramework;
using MetroFramework.Controls;

namespace AmmPlayer.Controls
{
    public class ListViewPlist: MetroListView
    {
        private ColumnHeader columnHeaderName;
        private ColumnHeader columnHeaderPlaying;
        private ColumnHeader columnHeaderDuration;
        private ColumnHeader columnHeaderArtist;
        private ColumnHeader columnHeaderFullname;

        public ListViewPlist()
        {
            this.columnHeaderPlaying = new ColumnHeader();
            this.columnHeaderName = new ColumnHeader();
            this.columnHeaderArtist = new ColumnHeader();
            this.columnHeaderDuration = new ColumnHeader();
            this.columnHeaderFullname = new ColumnHeader();

            SuspendLayout();
            // 
            // listViewTracks
            // 
            this.Columns.AddRange(new[] { this.columnHeaderPlaying,
                this.columnHeaderName,
                this.columnHeaderArtist,
                this.columnHeaderDuration,
                this.columnHeaderFullname});
            this.Dock = DockStyle.Fill;
            this.Font = new Font("Microsoft YaHei Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.FullRowSelect = true;
            this.GridLines = true;
            this.Location = new Point(0, 0);
            this.MultiSelect = false;
            this.Name = "listViewTracks";
            //this.Size = new Size(457, 346);
            this.TabIndex = 0;
            this.UseCompatibleStateImageBehavior = false;
            this.View = View.Details;
            this.columnHeaderPlaying.Text = "Playing";
            this.columnHeaderName.Text = "Name";
            this.columnHeaderArtist.Text = "Artist";
            this.columnHeaderDuration.Text = "Duration";
            this.columnHeaderFullname.Text = "Fullname";

            this.Scrollable = true;
            this.Style = MetroColorStyle.Silver;
            this.MultiSelect = false;

            ResumeLayout(false);
        }

        public ListViewPlist(List<TrackInfo> plistTracks): this()
        {
            AddTracks(plistTracks);            
        }

        public void AddTracks(List<TrackInfo> plistTracks)
        {
            this.Items.AddRange(plistTracks.Select(t =>
            {
                return new ListViewItem(new string[]
                {
                    "",
                    t.Name,
                    t.Artist,
                    t.Duration?.ToString("mm:ss"),
                    t.Fullname,
                });
            }).ToArray());
        }

        public void AddTracks(IEnumerable<FileInfo> files)
        {
            this.Items.AddRange(files.Select(fi =>
            {
                return new TrackInfo(fi);
            })            
            .Where(t => t.TrackType != MediaType.Unknown)
            .Select(t => new ListViewItem(new string[]
            {
                "",
                t.Name,
                t.Artist ?? "",
                t.Duration == null?"":string.Format("{0}:{1:D2}:{2:D2}",
                    t.Duration.Value.TotalHours == 0?"":t.Duration.Value.Hours.ToString(),
                    t.Duration.Value.Minutes,
                    t.Duration.Value.Seconds),                
                t.Fullname,
            }))
            .ToArray());
        }
    }
}