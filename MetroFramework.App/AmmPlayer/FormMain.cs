using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AmmPlayer.Controls;
using AmmPlayer.Extensions;
using AmmPlayer.PlayerItems;
using AmmPlayer.Players;
using AmmPlayer.Properties;
using MetroFramework;
using MetroFramework.Animation;
using MetroFramework.Controls;
using MetroFramework.Drawing;
using MetroFramework.Forms;
using Transitions;

namespace AmmPlayer
{
    public class FormMain: MetroForm
    {
        #region properties & init

        private TabPagePlist activePageList;

        private TabPagePlist ActivePageList
        {
            get { return activePageList; }
            set
            {
                activePageList = value;
            }
        }

        private FolderBrowserDialogEx folderBrowser;

        private void Init()
        {
            folderBrowser = new FolderBrowserDialogEx()
            {
                Description = "Load file",
                NewStyle = true,
                RootFolder = Environment.SpecialFolder.MyComputer,
                ShowEditBox = true,
                ShowBothFilesAndFolders = true,
                
            };
            LoadLists();
        }

        #endregion

        #region attributes ctor
        private MetroTabControl metroTabControlMain;
        private FlowLayoutPanel flowLayoutPanelButtons;
        private MetroButton metroButtonPrev;
        private MetroButton metroButtonPause;
        private MetroButton metroButtonNext;
        private MetroButton metroButtonPlayOrder;
        private MetroButton metroButtonStop;
        private TableLayoutPanel tableLayoutPanelMain;
        private MetroTrackBar metroTrackBarPlayPosition;
        private MetroButton metroButtonMenu;
        private MetroButton metroButtonSettings;
        private ToolStrip toolStripCurrentPlayListOperations;
        private ToolStripButton toolStripButtonAddList;
        private ToolStripButton toolStripButtonAddDir;
        private OpenFileDialog openFileDialogAddList;
        private ToolStrip toolStripManagePlayLists;
        private ToolStripButton toolStripButtonAddPlist;
        private ToolStripTextBox toolStripTextBoxPlistName;
        private ToolStripButton toolStripButtonRenamePlist;
        private ToolStripTextBox toolStripTextBoxPlistNewName;
        private MetroButton metroButtonPlay;

        public FormMain()
        {
            InitializeComponent();
            Init();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.metroButtonPlay = new MetroFramework.Controls.MetroButton();
            this.metroTabControlMain = new MetroFramework.Controls.MetroTabControl();
            this.flowLayoutPanelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.metroButtonPrev = new MetroFramework.Controls.MetroButton();
            this.metroButtonPause = new MetroFramework.Controls.MetroButton();
            this.metroButtonNext = new MetroFramework.Controls.MetroButton();
            this.metroButtonStop = new MetroFramework.Controls.MetroButton();
            this.metroButtonPlayOrder = new MetroFramework.Controls.MetroButton();
            this.metroButtonMenu = new MetroFramework.Controls.MetroButton();
            this.metroButtonSettings = new MetroFramework.Controls.MetroButton();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.metroTrackBarPlayPosition = new MetroFramework.Controls.MetroTrackBar();
            this.toolStripCurrentPlayListOperations = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonRenamePlist = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBoxPlistNewName = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonAddDir = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAddList = new System.Windows.Forms.ToolStripButton();
            this.openFileDialogAddList = new System.Windows.Forms.OpenFileDialog();
            this.toolStripManagePlayLists = new System.Windows.Forms.ToolStrip();
            this.toolStripTextBoxPlistName = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonAddPlist = new System.Windows.Forms.ToolStripButton();
            this.flowLayoutPanelButtons.SuspendLayout();
            this.tableLayoutPanelMain.SuspendLayout();
            this.toolStripCurrentPlayListOperations.SuspendLayout();
            this.toolStripManagePlayLists.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroButtonPlay
            // 
            this.metroButtonPlay.BackgroundImage = global::AmmPlayer.Properties.Resources.play;
            this.metroButtonPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.metroButtonPlay.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButtonPlay.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.metroButtonPlay.ForeColor = System.Drawing.Color.DimGray;
            this.metroButtonPlay.Location = new System.Drawing.Point(3, 3);
            this.metroButtonPlay.Name = "metroButtonPlay";
            this.metroButtonPlay.Size = new System.Drawing.Size(50, 50);
            this.metroButtonPlay.TabIndex = 0;
            this.metroButtonPlay.UseSelectable = true;
            this.metroButtonPlay.Click += new System.EventHandler(this.metroButtonPlay_Click);
            this.metroButtonPlay.MouseEnter += new System.EventHandler(this.metroButton_MouseEnter);
            this.metroButtonPlay.MouseLeave += new System.EventHandler(this.metroButton_MouseLeave);
            // 
            // metroTabControlMain
            // 
            this.metroTabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControlMain.Location = new System.Drawing.Point(3, 3);
            this.metroTabControlMain.Name = "metroTabControlMain";
            this.metroTabControlMain.Size = new System.Drawing.Size(449, 231);
            this.metroTabControlMain.TabIndex = 0;
            this.metroTabControlMain.UseSelectable = true;
            this.metroTabControlMain.SelectedIndexChanged += new System.EventHandler(this.metroTabControlMain_SelectedIndexChanged);
            this.metroTabControlMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.metroTabControlMain_MouseClick);
            // 
            // flowLayoutPanelButtons
            // 
            this.flowLayoutPanelButtons.AutoSize = true;
            this.flowLayoutPanelButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelButtons.Controls.Add(this.metroButtonPlay);
            this.flowLayoutPanelButtons.Controls.Add(this.metroButtonPrev);
            this.flowLayoutPanelButtons.Controls.Add(this.metroButtonPause);
            this.flowLayoutPanelButtons.Controls.Add(this.metroButtonNext);
            this.flowLayoutPanelButtons.Controls.Add(this.metroButtonStop);
            this.flowLayoutPanelButtons.Controls.Add(this.metroButtonPlayOrder);
            this.flowLayoutPanelButtons.Controls.Add(this.metroButtonMenu);
            this.flowLayoutPanelButtons.Controls.Add(this.metroButtonSettings);
            this.flowLayoutPanelButtons.Location = new System.Drawing.Point(3, 240);
            this.flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
            this.flowLayoutPanelButtons.Size = new System.Drawing.Size(448, 56);
            this.flowLayoutPanelButtons.TabIndex = 2;
            // 
            // metroButtonPrev
            // 
            this.metroButtonPrev.BackgroundImage = global::AmmPlayer.Properties.Resources.prev;
            this.metroButtonPrev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.metroButtonPrev.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButtonPrev.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.metroButtonPrev.ForeColor = System.Drawing.Color.DimGray;
            this.metroButtonPrev.Location = new System.Drawing.Point(59, 3);
            this.metroButtonPrev.Name = "metroButtonPrev";
            this.metroButtonPrev.Size = new System.Drawing.Size(50, 50);
            this.metroButtonPrev.TabIndex = 1;
            this.metroButtonPrev.UseSelectable = true;
            this.metroButtonPrev.Click += new System.EventHandler(this.metroButtonPrev_Click);
            this.metroButtonPrev.MouseEnter += new System.EventHandler(this.metroButton_MouseEnter);
            this.metroButtonPrev.MouseLeave += new System.EventHandler(this.metroButton_MouseLeave);
            // 
            // metroButtonPause
            // 
            this.metroButtonPause.BackgroundImage = global::AmmPlayer.Properties.Resources.pause;
            this.metroButtonPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.metroButtonPause.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButtonPause.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.metroButtonPause.ForeColor = System.Drawing.Color.DimGray;
            this.metroButtonPause.Location = new System.Drawing.Point(115, 3);
            this.metroButtonPause.Name = "metroButtonPause";
            this.metroButtonPause.Size = new System.Drawing.Size(50, 50);
            this.metroButtonPause.TabIndex = 2;
            this.metroButtonPause.UseSelectable = true;
            this.metroButtonPause.Click += new System.EventHandler(this.metroButtonPause_Click);
            this.metroButtonPause.MouseEnter += new System.EventHandler(this.metroButton_MouseEnter);
            this.metroButtonPause.MouseLeave += new System.EventHandler(this.metroButton_MouseLeave);
            // 
            // metroButtonNext
            // 
            this.metroButtonNext.BackgroundImage = global::AmmPlayer.Properties.Resources.next;
            this.metroButtonNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.metroButtonNext.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButtonNext.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.metroButtonNext.ForeColor = System.Drawing.Color.DimGray;
            this.metroButtonNext.Location = new System.Drawing.Point(171, 3);
            this.metroButtonNext.Name = "metroButtonNext";
            this.metroButtonNext.Size = new System.Drawing.Size(50, 50);
            this.metroButtonNext.TabIndex = 3;
            this.metroButtonNext.UseSelectable = true;
            this.metroButtonNext.Click += new System.EventHandler(this.metroButtonNext_Click);
            this.metroButtonNext.MouseEnter += new System.EventHandler(this.metroButton_MouseEnter);
            this.metroButtonNext.MouseLeave += new System.EventHandler(this.metroButton_MouseLeave);
            // 
            // metroButtonStop
            // 
            this.metroButtonStop.BackgroundImage = global::AmmPlayer.Properties.Resources.stop;
            this.metroButtonStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.metroButtonStop.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButtonStop.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.metroButtonStop.ForeColor = System.Drawing.Color.DimGray;
            this.metroButtonStop.Location = new System.Drawing.Point(227, 3);
            this.metroButtonStop.Name = "metroButtonStop";
            this.metroButtonStop.Size = new System.Drawing.Size(50, 50);
            this.metroButtonStop.TabIndex = 5;
            this.metroButtonStop.UseSelectable = true;
            this.metroButtonStop.Click += new System.EventHandler(this.metroButtonStop_Click);
            this.metroButtonStop.MouseEnter += new System.EventHandler(this.metroButton_MouseEnter);
            this.metroButtonStop.MouseLeave += new System.EventHandler(this.metroButton_MouseLeave);
            // 
            // metroButtonPlayOrder
            // 
            this.metroButtonPlayOrder.BackgroundImage = global::AmmPlayer.Properties.Resources.random;
            this.metroButtonPlayOrder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.metroButtonPlayOrder.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButtonPlayOrder.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.metroButtonPlayOrder.ForeColor = System.Drawing.Color.DimGray;
            this.metroButtonPlayOrder.Location = new System.Drawing.Point(283, 3);
            this.metroButtonPlayOrder.Name = "metroButtonPlayOrder";
            this.metroButtonPlayOrder.Size = new System.Drawing.Size(50, 50);
            this.metroButtonPlayOrder.TabIndex = 4;
            this.metroButtonPlayOrder.UseSelectable = true;
            this.metroButtonPlayOrder.Click += new System.EventHandler(this.metroButtonPlayOrder_Click);
            this.metroButtonPlayOrder.MouseEnter += new System.EventHandler(this.metroButton_MouseEnter);
            this.metroButtonPlayOrder.MouseLeave += new System.EventHandler(this.metroButton_MouseLeave);
            // 
            // metroButtonMenu
            // 
            this.metroButtonMenu.BackgroundImage = global::AmmPlayer.Properties.Resources.menu;
            this.metroButtonMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.metroButtonMenu.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButtonMenu.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.metroButtonMenu.ForeColor = System.Drawing.Color.DimGray;
            this.metroButtonMenu.Location = new System.Drawing.Point(339, 3);
            this.metroButtonMenu.Name = "metroButtonMenu";
            this.metroButtonMenu.Size = new System.Drawing.Size(50, 50);
            this.metroButtonMenu.TabIndex = 6;
            this.metroButtonMenu.UseSelectable = true;
            this.metroButtonMenu.Click += new System.EventHandler(this.metroButtonMenu_Click);
            this.metroButtonMenu.MouseEnter += new System.EventHandler(this.metroButton_MouseEnter);
            this.metroButtonMenu.MouseLeave += new System.EventHandler(this.metroButton_MouseLeave);
            // 
            // metroButtonSettings
            // 
            this.metroButtonSettings.BackgroundImage = global::AmmPlayer.Properties.Resources.setting;
            this.metroButtonSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.metroButtonSettings.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButtonSettings.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.metroButtonSettings.ForeColor = System.Drawing.Color.DimGray;
            this.metroButtonSettings.Location = new System.Drawing.Point(395, 3);
            this.metroButtonSettings.Name = "metroButtonSettings";
            this.metroButtonSettings.Size = new System.Drawing.Size(50, 50);
            this.metroButtonSettings.TabIndex = 7;
            this.metroButtonSettings.UseSelectable = true;
            this.metroButtonSettings.Click += new System.EventHandler(this.metroButtonSettings_Click);
            this.metroButtonSettings.MouseEnter += new System.EventHandler(this.metroButton_MouseEnter);
            this.metroButtonSettings.MouseLeave += new System.EventHandler(this.metroButton_MouseLeave);
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.AutoSize = true;
            this.tableLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.metroTabControlMain, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.flowLayoutPanelButtons, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.metroTrackBarPlayPosition, 0, 2);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(20, 60);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 3;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(455, 331);
            this.tableLayoutPanelMain.TabIndex = 3;
            this.tableLayoutPanelMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanelMain_MouseClick);
            // 
            // metroTrackBarPlayPosition
            // 
            this.metroTrackBarPlayPosition.BackColor = System.Drawing.Color.Transparent;
            this.metroTrackBarPlayPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTrackBarPlayPosition.Location = new System.Drawing.Point(3, 304);
            this.metroTrackBarPlayPosition.Name = "metroTrackBarPlayPosition";
            this.metroTrackBarPlayPosition.Size = new System.Drawing.Size(449, 24);
            this.metroTrackBarPlayPosition.TabIndex = 3;
            this.metroTrackBarPlayPosition.Text = "metroTrackBar1";
            this.metroTrackBarPlayPosition.Value = 0;
            // 
            // toolStripCurrentPlayListOperations
            // 
            this.toolStripCurrentPlayListOperations.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.toolStripCurrentPlayListOperations.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripCurrentPlayListOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonRenamePlist,
            this.toolStripTextBoxPlistNewName,
            this.toolStripButtonAddDir,
            this.toolStripButtonAddList});
            this.toolStripCurrentPlayListOperations.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStripCurrentPlayListOperations.Location = new System.Drawing.Point(175, 16);
            this.toolStripCurrentPlayListOperations.MinimumSize = new System.Drawing.Size(100, 57);
            this.toolStripCurrentPlayListOperations.Name = "toolStripCurrentPlayListOperations";
            this.toolStripCurrentPlayListOperations.Size = new System.Drawing.Size(122, 92);
            this.toolStripCurrentPlayListOperations.Stretch = true;
            this.toolStripCurrentPlayListOperations.TabIndex = 2;
            this.toolStripCurrentPlayListOperations.Visible = false;
            // 
            // toolStripButtonRenamePlist
            // 
            this.toolStripButtonRenamePlist.BackColor = System.Drawing.SystemColors.ControlDark;
            this.toolStripButtonRenamePlist.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonRenamePlist.Font = new System.Drawing.Font("Segoe UI", 10.75F);
            this.toolStripButtonRenamePlist.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRenamePlist.Image")));
            this.toolStripButtonRenamePlist.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRenamePlist.Name = "toolStripButtonRenamePlist";
            this.toolStripButtonRenamePlist.Size = new System.Drawing.Size(120, 24);
            this.toolStripButtonRenamePlist.Text = "Rename Plist";
            this.toolStripButtonRenamePlist.Click += new System.EventHandler(this.toolStripButtonRenamePlist_Click);
            // 
            // toolStripTextBoxPlistNewName
            // 
            this.toolStripTextBoxPlistNewName.AutoSize = false;
            this.toolStripTextBoxPlistNewName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBoxPlistNewName.Name = "toolStripTextBoxPlistNewName";
            this.toolStripTextBoxPlistNewName.Size = new System.Drawing.Size(120, 23);
            this.toolStripTextBoxPlistNewName.Visible = false;
            // 
            // toolStripButtonAddDir
            // 
            this.toolStripButtonAddDir.BackColor = System.Drawing.SystemColors.ControlDark;
            this.toolStripButtonAddDir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonAddDir.Font = new System.Drawing.Font("Segoe UI", 10.75F);
            this.toolStripButtonAddDir.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddDir.Image")));
            this.toolStripButtonAddDir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddDir.Name = "toolStripButtonAddDir";
            this.toolStripButtonAddDir.Size = new System.Drawing.Size(120, 24);
            this.toolStripButtonAddDir.Text = "Add From Dir...";
            this.toolStripButtonAddDir.Click += new System.EventHandler(this.toolStripButtonAddDir_Click);
            // 
            // toolStripButtonAddList
            // 
            this.toolStripButtonAddList.BackColor = System.Drawing.SystemColors.ControlDark;
            this.toolStripButtonAddList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonAddList.Font = new System.Drawing.Font("Segoe UI", 10.75F);
            this.toolStripButtonAddList.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddList.Image")));
            this.toolStripButtonAddList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddList.Name = "toolStripButtonAddList";
            this.toolStripButtonAddList.Size = new System.Drawing.Size(120, 24);
            this.toolStripButtonAddList.Text = "Add From Files...";
            this.toolStripButtonAddList.Click += new System.EventHandler(this.toolStripButtonAddList_Click);
            // 
            // openFileDialogAddList
            // 
            this.openFileDialogAddList.FileName = "openFileDialog1";
            this.openFileDialogAddList.Multiselect = true;
            this.openFileDialogAddList.RestoreDirectory = true;
            // 
            // toolStripManagePlayLists
            // 
            this.toolStripManagePlayLists.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.toolStripManagePlayLists.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripManagePlayLists.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxPlistName,
            this.toolStripButtonAddPlist});
            this.toolStripManagePlayLists.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStripManagePlayLists.Location = new System.Drawing.Point(306, 21);
            this.toolStripManagePlayLists.MinimumSize = new System.Drawing.Size(100, 57);
            this.toolStripManagePlayLists.Name = "toolStripManagePlayLists";
            this.toolStripManagePlayLists.Size = new System.Drawing.Size(111, 61);
            this.toolStripManagePlayLists.Stretch = true;
            this.toolStripManagePlayLists.TabIndex = 4;
            this.toolStripManagePlayLists.Visible = false;
            // 
            // toolStripTextBoxPlistName
            // 
            this.toolStripTextBoxPlistName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBoxPlistName.Name = "toolStripTextBoxPlistName";
            this.toolStripTextBoxPlistName.Size = new System.Drawing.Size(107, 23);
            // 
            // toolStripButtonAddPlist
            // 
            this.toolStripButtonAddPlist.BackColor = System.Drawing.SystemColors.ControlDark;
            this.toolStripButtonAddPlist.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonAddPlist.Font = new System.Drawing.Font("Segoe UI", 10.75F);
            this.toolStripButtonAddPlist.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddPlist.Image")));
            this.toolStripButtonAddPlist.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddPlist.Name = "toolStripButtonAddPlist";
            this.toolStripButtonAddPlist.Size = new System.Drawing.Size(109, 24);
            this.toolStripButtonAddPlist.Text = "Add New List...";
            this.toolStripButtonAddPlist.Click += new System.EventHandler(this.toolStripButtonAddPlist_Click);
            // 
            // FormMain
            // 
            this.ClientSize = new System.Drawing.Size(495, 411);
            this.Controls.Add(this.toolStripCurrentPlayListOperations);
            this.Controls.Add(this.toolStripManagePlayLists);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Font = new System.Drawing.Font("Microsoft YaHei Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(495, 411);
            this.Name = "FormMain";
            this.Opacity = 0.5D;
            this.Style = MetroFramework.MetroColorStyle.White;
            this.Text = "Dawn Time";
            this.TransparencyKey = System.Drawing.Color.FloralWhite;
            this.flowLayoutPanelButtons.ResumeLayout(false);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            this.toolStripCurrentPlayListOperations.ResumeLayout(false);
            this.toolStripCurrentPlayListOperations.PerformLayout();
            this.toolStripManagePlayLists.ResumeLayout(false);
            this.toolStripManagePlayLists.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region animation

        private void metroButton_MouseEnter(object sender, EventArgs e)
        {
            Transition.run(sender, "BackColor", Color.Gray, new TransitionType_Linear(100));
        }

        private void metroButton_MouseLeave(object sender, EventArgs e)
        {
            Transition.run(sender, "BackColor", Color.White, new TransitionType_Linear(100));
        }

        #endregion 

        #region player lists

        private void LoadLists()
        {
            var lists = TrackListsManager.Load();
            if (lists.Lists.Count == 0)
            {
                var page = new TabPagePlist("Default");
                page.PlistMouseClick += pageList_MouseClick;

                this.metroTabControlMain.TabPages.Add(page);
                this.ActivePageList = page;
            }
            else
                foreach (var plist in lists.Lists)
                {
                    var page = new TabPagePlist(plist.Name, plist.Tracks);
                    page.PlistMouseClick += pageList_MouseClick;
                    this.metroTabControlMain.TabPages.Add(page);
                }
        }

        private void AddTracks(IEnumerable<string> files)
        {
            AddTracks(files.Select(f => new FileInfo(f)));
        }

        private void AddTracks(IEnumerable<FileInfo> files)
        {
            this.ActivePageList.AddTracks(files);
        }

        private void metroTabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ActivePageList = (sender as TabPagePlist);
        }

        /// <summary>
        /// add a play list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonAddPlist_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.toolStripTextBoxPlistName.Text))
            {
                MetroMessageBox.Show(this, "Specify a name first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            var page = new TabPagePlist(this.toolStripTextBoxPlistName.Text);
            page.PlistMouseClick += pageList_MouseClick;
            this.metroTabControlMain.TabPages.Add(page);
        }

        /// <summary>
        /// click on play list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pageList_MouseClick(object sender, MouseEventArgs e)
        {
            TogglePlayListOptionToolStripVisibility();
        }

        private void metroTabControlMain_MouseClick(object sender, MouseEventArgs e)
        {            
            if (e.Button == MouseButtons.Right && !this.toolStripCurrentPlayListOperations.Visible)
            {
                this.toolStripCurrentPlayListOperations.Location = PointToClient(Cursor.Position);

                this.toolStripCurrentPlayListOperations.Visible = true;
                this.toolStripCurrentPlayListOperations.BringToFront();
                return;
            }
            if (this.toolStripCurrentPlayListOperations.Visible)
            {
                TogglePlayListOptionToolStripVisibility();
            }
        }

        private void toolStripButtonAddList_Click(object sender, EventArgs e)
        {
            if (this.openFileDialogAddList.ShowDialog() == DialogResult.OK)
            {
                AddTracks(this.openFileDialogAddList.FileNames);

                TogglePlayListOptionToolStripVisibility();
            }
        }

        private void toolStripButtonAddDir_Click(object sender, EventArgs e)
        {
            if (this.folderBrowser.ShowDialog() == DialogResult.OK)
            {
                AddTracks(new DirectoryInfo(this.folderBrowser.SelectedPath).GetFiles());
                
                TogglePlayListOptionToolStripVisibility();
            }
        }

        private void toolStripButtonRenamePlist_Click(object sender, EventArgs e)
        {
            SuspendLayout();
            this.toolStripButtonRenamePlist.Visible = false;
            this.toolStripTextBoxPlistNewName.Text = this.ActivePageList.Text;
            this.toolStripTextBoxPlistNewName.Visible = true;
            this.toolStripTextBoxPlistNewName.Focus();
            this.toolStripTextBoxPlistNewName.SelectAll();
            ResumeLayout();
        }

        /// <summary>
        /// hide the ToolStrip control on handling the play list
        /// </summary>
        /// <param name="visible"></param>
        private void TogglePlayListOptionToolStripVisibility()
        {
            if (this.toolStripCurrentPlayListOperations.Visible)
            {
                if (this.toolStripTextBoxPlistNewName.Visible && string.IsNullOrWhiteSpace(this.toolStripTextBoxPlistNewName.Text))
                {
                    MetroMessageBox.Show(this, "Invalid new name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                if (this.toolStripTextBoxPlistNewName.Visible)
                {
                    this.ActivePageList.Text = this.toolStripTextBoxPlistNewName.Text;
                }
            }

            if (!this.toolStripCurrentPlayListOperations.Visible)
            {
                this.toolStripCurrentPlayListOperations.Location = PointToClient(Cursor.Position);

                this.toolStripCurrentPlayListOperations.Visible = true;
                this.toolStripCurrentPlayListOperations.BringToFront();
                return;
            }
            if (this.toolStripCurrentPlayListOperations.Visible)
            {
                this.toolStripCurrentPlayListOperations.Visible = false;
            }
        }

        #endregion

        #region tabel layout 

        /// <summary>
        /// add list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tableLayoutPanelMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && !this.toolStripManagePlayLists.Visible)
            {
                this.toolStripManagePlayLists.Location = PointToClient(Cursor.Position);

                this.toolStripManagePlayLists.Visible = true;
                this.toolStripManagePlayLists.BringToFront();
                return;
            }
            if (this.toolStripManagePlayLists.Visible)
            {
                this.toolStripManagePlayLists.Visible = false;
            }
        }

        #endregion

        #region play controls
        private void metroButtonPlay_Click(object sender, EventArgs e)
        {
            
        }

        private void metroButtonPrev_Click(object sender, EventArgs e)
        {

        }

        private void metroButtonPause_Click(object sender, EventArgs e)
        {

        }

        private void metroButtonNext_Click(object sender, EventArgs e)
        {

        }

        private void metroButtonStop_Click(object sender, EventArgs e)
        {

        }

        private void metroButtonPlayOrder_Click(object sender, EventArgs e)
        {

        }

        private void metroButtonMenu_Click(object sender, EventArgs e)
        {

        }

        private void metroButtonSettings_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}