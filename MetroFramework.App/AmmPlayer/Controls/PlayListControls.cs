using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace CSCoreDemo.PlayerDemo
{
    public class PlayListControls
    {
        public ReadOnlyTextBox NameBox { get; private set; }

        public PlayListPanel PlistPanel { get; private set; }

        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);

        public PlayListControls(string name, List<TrackInfo> plistTracks)
        {
            this.NameBox = CreateTitle(name);

            this.PlistPanel = new PlayListPanel(plistTracks)
            {
                Dock = DockStyle.Fill,
            };
        }

        public PlayListControls(string name)
        {
            this.NameBox = CreateTitle(name);

            this.PlistPanel = new PlayListPanel()
            {
                Dock = DockStyle.Fill,
            };
        }

        private ReadOnlyTextBox CreateTitle(string name)
        {
            var textbox = new ReadOnlyTextBox();
            textbox.AutoSize = true;

            textbox.Location = new Point(3, 3);
            textbox.MinimumSize = new Size(56, 23);

            textbox.Size = new Size(56, 23);
            textbox.TabIndex = 0;
            textbox.Text = name;
            textbox.ReadOnly = true;
            textbox.Cursor = Cursors.Arrow;
            textbox.BorderStyle = BorderStyle.FixedSingle;

            //HideCaret(textbox.Handle);

            return textbox;
        }
    }
}