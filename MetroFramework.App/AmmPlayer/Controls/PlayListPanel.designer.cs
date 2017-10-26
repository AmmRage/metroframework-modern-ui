namespace AmmPlayer.Controls
{
    partial class PlayListPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listViewTracks = new System.Windows.Forms.ListView();
            this.columnHeaderPlaying = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderArtist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderFullname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listViewTracks
            // 
            this.listViewTracks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderPlaying,
            this.columnHeaderName,
            this.columnHeaderArtist,
            this.columnHeaderDuration,
            this.columnHeaderFullname});
            this.listViewTracks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewTracks.Font = new System.Drawing.Font("Microsoft YaHei Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewTracks.FullRowSelect = true;
            this.listViewTracks.GridLines = true;
            this.listViewTracks.Location = new System.Drawing.Point(0, 0);
            this.listViewTracks.MultiSelect = false;
            this.listViewTracks.Name = "listViewTracks";
            this.listViewTracks.Size = new System.Drawing.Size(457, 346);
            this.listViewTracks.TabIndex = 0;
            this.listViewTracks.UseCompatibleStateImageBehavior = false;
            this.listViewTracks.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderPlaying
            // 
            this.columnHeaderPlaying.Text = "Playing";
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            // 
            // columnHeaderArtist
            // 
            this.columnHeaderArtist.Text = "Artist";
            // 
            // columnHeaderDuration
            // 
            this.columnHeaderDuration.Text = "Duration";
            // 
            // columnHeaderFullname
            // 
            this.columnHeaderFullname.Text = "Fullname";
            // 
            // PlayListPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listViewTracks);
            this.Name = "PlayListPanel";
            this.Size = new System.Drawing.Size(457, 346);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewTracks;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderPlaying;
        private System.Windows.Forms.ColumnHeader columnHeaderDuration;
        private System.Windows.Forms.ColumnHeader columnHeaderArtist;
        private System.Windows.Forms.ColumnHeader columnHeaderFullname;
    }
}
