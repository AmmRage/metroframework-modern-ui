using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using AmmPlayer.PlayerItems;
using MetroFramework.Controls;

namespace AmmPlayer.Controls
{
    public class TabPagePlist : MetroTabPage
    {
        public PlayList PlayList;

        private ListViewPlist plist;

        public event MouseEventHandler PlistMouseClick;

        public TrackInfo SelectedTrack
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        private TabPagePlist()
        {
            this.VerticalScrollbar = false;
            this.HorizontalScrollbar = false;
        }

        public TabPagePlist(string listName, List<TrackInfo> tracks):this()
        {
            this.Text = listName;
            this.plist = new ListViewPlist(tracks);
            this.Controls.Add(this.plist);
            this.plist.MouseDown += MouseEventHandler;
        }

        public TabPagePlist(string listName) : this()
        {
            this.Text = listName;
            this.plist = new ListViewPlist();
            this.Controls.Add(this.plist);
            this.plist.MouseDown += MouseEventHandler;
        }

        private void MouseEventHandler(object sender, MouseEventArgs e)
        {
            var loc = PointToClient(Cursor.Position);            
            var lvItem = this.plist.GetItemAt(loc.X, loc.Y);

            if(lvItem == null)
                PlistMouseClick?.Invoke(sender, e);
        }

        public void AddTracks(IEnumerable<FileInfo> files)
        {
            this.plist.AddTracks(files);            
        }        
    }
}