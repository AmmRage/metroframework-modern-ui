using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AmmPlayer.PlayerItems;

namespace AmmPlayer.Controls
{
    public partial class PlayListPanel : UserControl
    {
        public PlayListPanel()
        {
            InitializeComponent();
        }

        public PlayListPanel(List<TrackInfo> plistTracks)
        {
            this.listViewTracks.Items.AddRange(plistTracks.Select(t =>
            {
                return new ListViewItem(new string[]
                {
                    "",
                    t.Name,
                    t.Artist,
                    t.Duration.ToString("mm:ss"),
                    t.Fullname,
                });
            }).ToArray());
        }
    }
}
