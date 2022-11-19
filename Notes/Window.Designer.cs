using System;
using System.Windows.Forms;

namespace Notes
{
	partial class Window
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
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Window));
			this.menu = new System.Windows.Forms.MainMenu(this.components);
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.newGroupMenuItem = new System.Windows.Forms.MenuItem();
			this.newNoteMenuItem = new System.Windows.Forms.MenuItem();
			this.openMenuItem = new System.Windows.Forms.MenuItem();
			this.menuItem37 = new System.Windows.Forms.MenuItem();
			this.menuItem39 = new System.Windows.Forms.MenuItem();
			this.menuItem40 = new System.Windows.Forms.MenuItem();
			this.menuItem12 = new System.Windows.Forms.MenuItem();
			this.autoSaveMainMenuItem = new System.Windows.Forms.MenuItem();
			this.saveMenuItem = new System.Windows.Forms.MenuItem();
			this.menuItem34 = new System.Windows.Forms.MenuItem();
			this.menuItem13 = new System.Windows.Forms.MenuItem();
			this.menuItem14 = new System.Windows.Forms.MenuItem();
			this.menuItem15 = new System.Windows.Forms.MenuItem();
			this.menuItem16 = new System.Windows.Forms.MenuItem();
			this.importMenuItem = new System.Windows.Forms.MenuItem();
			this.createBackupMenuItem = new System.Windows.Forms.MenuItem();
			this.menuItem18 = new System.Windows.Forms.MenuItem();
			this.menuItem19 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem20 = new System.Windows.Forms.MenuItem();
			this.menuItem21 = new System.Windows.Forms.MenuItem();
			this.menuItem22 = new System.Windows.Forms.MenuItem();
			this.menuItem23 = new System.Windows.Forms.MenuItem();
			this.menuItem24 = new System.Windows.Forms.MenuItem();
			this.menuItem25 = new System.Windows.Forms.MenuItem();
			this.menuItem26 = new System.Windows.Forms.MenuItem();
			this.menuItem27 = new System.Windows.Forms.MenuItem();
			this.menuItem28 = new System.Windows.Forms.MenuItem();
			this.menuItem29 = new System.Windows.Forms.MenuItem();
			this.findAndReplace = new System.Windows.Forms.MenuItem();
			this.menuItem38 = new System.Windows.Forms.MenuItem();
			this.menuItem30 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.wordWrapMenuItem = new System.Windows.Forms.MenuItem();
			this.menuItem35 = new System.Windows.Forms.MenuItem();
			this.menuItem43 = new System.Windows.Forms.MenuItem();
			this.menuItem50 = new System.Windows.Forms.MenuItem();
			this.menuItem51 = new System.Windows.Forms.MenuItem();
			this.menuItem52 = new System.Windows.Forms.MenuItem();
			this.menuItem46 = new System.Windows.Forms.MenuItem();
			this.menuItem47 = new System.Windows.Forms.MenuItem();
			this.menuItem48 = new System.Windows.Forms.MenuItem();
			this.menuItem49 = new System.Windows.Forms.MenuItem();
			this.menuItem36 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.menuItem17 = new System.Windows.Forms.MenuItem();
			this.menuItem33 = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.menuItem31 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem41 = new System.Windows.Forms.MenuItem();
			this.statusbar = new System.Windows.Forms.StatusBar();
			this.statePanel = new System.Windows.Forms.StatusBarPanel();
			this.lineCountPanel = new System.Windows.Forms.StatusBarPanel();
			this.characterCountPanel = new System.Windows.Forms.StatusBarPanel();
			this.changesNeedSavingPanel = new System.Windows.Forms.StatusBarPanel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.list = new Notes.CustomTreeView();
			this.editor = new System.Windows.Forms.TextBox();
			this.listContextMenu = new System.Windows.Forms.ContextMenu();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.newGroupContextMenuItem = new System.Windows.Forms.MenuItem();
			this.newNoteContextMenuItem = new System.Windows.Forms.MenuItem();
			this.menuItem32 = new System.Windows.Forms.MenuItem();
			this.renameContextMenuItem = new System.Windows.Forms.MenuItem();
			this.deleteContextMenuItem = new System.Windows.Forms.MenuItem();
			this.attachmentsSeparator = new System.Windows.Forms.MenuItem();
			this.menuItem42 = new System.Windows.Forms.MenuItem();
			this.menuItem55 = new System.Windows.Forms.MenuItem();
			this.highlightContextMenuItem = new System.Windows.Forms.MenuItem();
			this.menuItem53 = new System.Windows.Forms.MenuItem();
			this.attachmentsListContextMenuItem = new System.Windows.Forms.MenuItem();
			this.menuItem45 = new System.Windows.Forms.MenuItem();
			this.attachFileContextMenuItem = new System.Windows.Forms.MenuItem();
			this.menuItem44 = new System.Windows.Forms.MenuItem();
			this.propertiesContextMenuItem = new System.Windows.Forms.MenuItem();
			((System.ComponentModel.ISupportInitialize)(this.statePanel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lineCountPanel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.characterCountPanel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.changesNeedSavingPanel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menu
			// 
			this.menu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2,
            this.menuItem3,
            this.menuItem4,
            this.menuItem43,
            this.menuItem46,
            this.menuItem5,
            this.menuItem10,
            this.menuItem6,
            this.menuItem7});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem8,
            this.openMenuItem,
            this.menuItem12,
            this.autoSaveMainMenuItem,
            this.saveMenuItem,
            this.menuItem34,
            this.menuItem13,
            this.menuItem14,
            this.menuItem15,
            this.menuItem16,
            this.importMenuItem,
            this.createBackupMenuItem,
            this.menuItem18,
            this.menuItem19});
			this.menuItem1.Text = "File";
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 0;
			this.menuItem8.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.newGroupMenuItem,
            this.newNoteMenuItem});
			this.menuItem8.Text = "New";
			this.menuItem8.Popup += new System.EventHandler(this.menuItem8_Popup);
			// 
			// newGroupMenuItem
			// 
			this.newGroupMenuItem.Index = 0;
			this.newGroupMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlG;
			this.newGroupMenuItem.Text = "Group";
			this.newGroupMenuItem.Click += new System.EventHandler(this.newGroupMenuItem_Click);
			// 
			// newNoteMenuItem
			// 
			this.newNoteMenuItem.Index = 1;
			this.newNoteMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
			this.newNoteMenuItem.Text = "Note";
			this.newNoteMenuItem.Click += new System.EventHandler(this.newNoteMenuItem_Click);
			// 
			// openMenuItem
			// 
			this.openMenuItem.Index = 1;
			this.openMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem37,
            this.menuItem39,
            this.menuItem40});
			this.openMenuItem.Text = "Open...";
			this.openMenuItem.Click += new System.EventHandler(this.openMenuItem_Click);
			// 
			// menuItem37
			// 
			this.menuItem37.Index = 0;
			this.menuItem37.Text = "Group...";
			// 
			// menuItem39
			// 
			this.menuItem39.Index = 1;
			this.menuItem39.Text = "Note...";
			// 
			// menuItem40
			// 
			this.menuItem40.Index = 2;
			this.menuItem40.Text = "File...";
			this.menuItem40.Click += new System.EventHandler(this.menuItem40_Click);
			// 
			// menuItem12
			// 
			this.menuItem12.Index = 2;
			this.menuItem12.Text = "-";
			// 
			// autoSaveMainMenuItem
			// 
			this.autoSaveMainMenuItem.Index = 3;
			this.autoSaveMainMenuItem.Text = "Auto Save";
			this.autoSaveMainMenuItem.Click += new System.EventHandler(this.autoSaveMainMenuItem_Click);
			// 
			// saveMenuItem
			// 
			this.saveMenuItem.Index = 4;
			this.saveMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
			this.saveMenuItem.Text = "Save";
			this.saveMenuItem.Click += new System.EventHandler(this.saveMenuItem_Click);
			// 
			// menuItem34
			// 
			this.menuItem34.Index = 5;
			this.menuItem34.Text = "-";
			// 
			// menuItem13
			// 
			this.menuItem13.Enabled = false;
			this.menuItem13.Index = 6;
			this.menuItem13.Text = "Print Preview";
			this.menuItem13.Click += new System.EventHandler(this.menuItem13_Click);
			// 
			// menuItem14
			// 
			this.menuItem14.Enabled = false;
			this.menuItem14.Index = 7;
			this.menuItem14.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
			this.menuItem14.Text = "Print";
			this.menuItem14.Click += new System.EventHandler(this.menuItem14_Click);
			// 
			// menuItem15
			// 
			this.menuItem15.Enabled = false;
			this.menuItem15.Index = 8;
			this.menuItem15.Text = "Page Setup";
			// 
			// menuItem16
			// 
			this.menuItem16.Index = 9;
			this.menuItem16.Text = "-";
			// 
			// importMenuItem
			// 
			this.importMenuItem.Index = 10;
			this.importMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlI;
			this.importMenuItem.Text = "Import Backup";
			this.importMenuItem.Click += new System.EventHandler(this.importMenuItem_Click);
			// 
			// createBackupMenuItem
			// 
			this.createBackupMenuItem.Index = 11;
			this.createBackupMenuItem.Text = "Create Backup";
			this.createBackupMenuItem.Click += new System.EventHandler(this.createBackupMenuItem_Click);
			// 
			// menuItem18
			// 
			this.menuItem18.Index = 12;
			this.menuItem18.Text = "-";
			// 
			// menuItem19
			// 
			this.menuItem19.Index = 13;
			this.menuItem19.Shortcut = System.Windows.Forms.Shortcut.AltF4;
			this.menuItem19.Text = "Exit";
			this.menuItem19.Click += new System.EventHandler(this.menuItem19_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem20,
            this.menuItem21,
            this.menuItem22,
            this.menuItem23,
            this.menuItem24,
            this.menuItem25,
            this.menuItem26,
            this.menuItem27,
            this.menuItem28,
            this.menuItem29,
            this.findAndReplace,
            this.menuItem38,
            this.menuItem30});
			this.menuItem2.Text = "Edit";
			// 
			// menuItem20
			// 
			this.menuItem20.Index = 0;
			this.menuItem20.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
			this.menuItem20.Text = "Undo";
			this.menuItem20.Click += new System.EventHandler(this.menuItem20_Click);
			// 
			// menuItem21
			// 
			this.menuItem21.Index = 1;
			this.menuItem21.Shortcut = System.Windows.Forms.Shortcut.CtrlY;
			this.menuItem21.Text = "Redo";
			this.menuItem21.Click += new System.EventHandler(this.menuItem21_Click);
			// 
			// menuItem22
			// 
			this.menuItem22.Index = 2;
			this.menuItem22.Text = "-";
			// 
			// menuItem23
			// 
			this.menuItem23.Index = 3;
			this.menuItem23.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
			this.menuItem23.Text = "Cut";
			this.menuItem23.Click += new System.EventHandler(this.menuItem23_Click);
			// 
			// menuItem24
			// 
			this.menuItem24.Index = 4;
			this.menuItem24.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
			this.menuItem24.Text = "Copy";
			this.menuItem24.Click += new System.EventHandler(this.menuItem24_Click);
			// 
			// menuItem25
			// 
			this.menuItem25.Index = 5;
			this.menuItem25.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
			this.menuItem25.Text = "Paste";
			this.menuItem25.Click += new System.EventHandler(this.menuItem25_Click);
			// 
			// menuItem26
			// 
			this.menuItem26.Index = 6;
			this.menuItem26.Text = "-";
			// 
			// menuItem27
			// 
			this.menuItem27.Index = 7;
			this.menuItem27.Shortcut = System.Windows.Forms.Shortcut.CtrlA;
			this.menuItem27.Text = "Select All";
			this.menuItem27.Click += new System.EventHandler(this.menuItem27_Click);
			// 
			// menuItem28
			// 
			this.menuItem28.Index = 8;
			this.menuItem28.Shortcut = System.Windows.Forms.Shortcut.Del;
			this.menuItem28.Text = "Delete";
			this.menuItem28.Click += new System.EventHandler(this.menuItem28_Click);
			// 
			// menuItem29
			// 
			this.menuItem29.Index = 9;
			this.menuItem29.Text = "-";
			// 
			// findAndReplace
			// 
			this.findAndReplace.Index = 10;
			this.findAndReplace.Shortcut = System.Windows.Forms.Shortcut.CtrlH;
			this.findAndReplace.Text = "Find and Replace";
			this.findAndReplace.Click += new System.EventHandler(this.findAndReplace_Click);
			// 
			// menuItem38
			// 
			this.menuItem38.Index = 11;
			this.menuItem38.Text = "-";
			// 
			// menuItem30
			// 
			this.menuItem30.Index = 12;
			this.menuItem30.Shortcut = System.Windows.Forms.Shortcut.F5;
			this.menuItem30.Text = "Date/Time";
			this.menuItem30.Click += new System.EventHandler(this.menuItem30_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Enabled = false;
			this.menuItem3.Index = 2;
			this.menuItem3.Text = "View";
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 3;
			this.menuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.wordWrapMenuItem,
            this.menuItem35});
			this.menuItem4.Text = "Format";
			// 
			// wordWrapMenuItem
			// 
			this.wordWrapMenuItem.Checked = true;
			this.wordWrapMenuItem.Index = 0;
			this.wordWrapMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlW;
			this.wordWrapMenuItem.Text = "Word Wrap";
			this.wordWrapMenuItem.Click += new System.EventHandler(this.wordWrapMenuItem_Click);
			// 
			// menuItem35
			// 
			this.menuItem35.Index = 1;
			this.menuItem35.Shortcut = System.Windows.Forms.Shortcut.CtrlF;
			this.menuItem35.Text = "Font...";
			this.menuItem35.Click += new System.EventHandler(this.menuItem35_Click);
			// 
			// menuItem43
			// 
			this.menuItem43.Enabled = false;
			this.menuItem43.Index = 4;
			this.menuItem43.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem50,
            this.menuItem51,
            this.menuItem52});
			this.menuItem43.Text = "Group";
			// 
			// menuItem50
			// 
			this.menuItem50.Index = 0;
			this.menuItem50.Text = "Delete";
			// 
			// menuItem51
			// 
			this.menuItem51.Index = 1;
			this.menuItem51.Text = "Properties";
			// 
			// menuItem52
			// 
			this.menuItem52.Index = 2;
			this.menuItem52.Text = "-";
			// 
			// menuItem46
			// 
			this.menuItem46.Index = 5;
			this.menuItem46.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem47,
            this.menuItem48,
            this.menuItem49,
            this.menuItem36});
			this.menuItem46.Text = "Note";
			// 
			// menuItem47
			// 
			this.menuItem47.Index = 0;
			this.menuItem47.Text = "Delete";
			// 
			// menuItem48
			// 
			this.menuItem48.Index = 1;
			this.menuItem48.Text = "-";
			// 
			// menuItem49
			// 
			this.menuItem49.Index = 2;
			this.menuItem49.Shortcut = System.Windows.Forms.Shortcut.CtrlR;
			this.menuItem49.Text = "Record Audio";
			this.menuItem49.Click += new System.EventHandler(this.menuItem49_Click);
			// 
			// menuItem36
			// 
			this.menuItem36.Index = 3;
			this.menuItem36.Text = "-";
			// 
			// menuItem5
			// 
			this.menuItem5.Enabled = false;
			this.menuItem5.Index = 6;
			this.menuItem5.Text = "Tools";
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 7;
			this.menuItem10.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem17,
            this.menuItem33,
            this.menuItem11,
            this.menuItem31});
			this.menuItem10.Text = "Extensions";
			// 
			// menuItem17
			// 
			this.menuItem17.DefaultItem = true;
			this.menuItem17.Index = 0;
			this.menuItem17.Text = "Import...";
			this.menuItem17.Click += new System.EventHandler(this.menuItem17_Click);
			// 
			// menuItem33
			// 
			this.menuItem33.Index = 1;
			this.menuItem33.Text = "-";
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 2;
			this.menuItem11.Text = "Browse Extensions";
			// 
			// menuItem31
			// 
			this.menuItem31.Index = 3;
			this.menuItem31.Text = "Manage Extensions";
			this.menuItem31.Click += new System.EventHandler(this.menuItem31_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Enabled = false;
			this.menuItem6.Index = 8;
			this.menuItem6.Text = "Window";
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 9;
			this.menuItem7.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem41});
			this.menuItem7.Text = "Help";
			// 
			// menuItem41
			// 
			this.menuItem41.Index = 0;
			this.menuItem41.Text = "About Notes";
			this.menuItem41.Click += new System.EventHandler(this.menuItem41_Click_1);
			// 
			// statusbar
			// 
			this.statusbar.Location = new System.Drawing.Point(0, 526);
			this.statusbar.Name = "statusbar";
			this.statusbar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statePanel,
            this.lineCountPanel,
            this.characterCountPanel,
            this.changesNeedSavingPanel});
			this.statusbar.ShowPanels = true;
			this.statusbar.Size = new System.Drawing.Size(1037, 22);
			this.statusbar.TabIndex = 1;
			this.statusbar.Text = "State: Idle.";
			// 
			// statePanel
			// 
			this.statePanel.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
			this.statePanel.Name = "statePanel";
			this.statePanel.Text = "State: Idle.";
			this.statePanel.Width = 68;
			// 
			// lineCountPanel
			// 
			this.lineCountPanel.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
			this.lineCountPanel.Name = "lineCountPanel";
			this.lineCountPanel.Text = "Lines:";
			this.lineCountPanel.Width = 44;
			// 
			// characterCountPanel
			// 
			this.characterCountPanel.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
			this.characterCountPanel.Name = "characterCountPanel";
			this.characterCountPanel.Text = "Characters:";
			this.characterCountPanel.Width = 73;
			// 
			// changesNeedSavingPanel
			// 
			this.changesNeedSavingPanel.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
			this.changesNeedSavingPanel.Icon = ((System.Drawing.Icon)(resources.GetObject("changesNeedSavingPanel.Icon")));
			this.changesNeedSavingPanel.MinWidth = 0;
			this.changesNeedSavingPanel.Name = "changesNeedSavingPanel";
			this.changesNeedSavingPanel.Text = "Changes need saving.";
			this.changesNeedSavingPanel.Width = 148;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.list);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.editor);
			this.splitContainer1.Size = new System.Drawing.Size(1037, 526);
			this.splitContainer1.SplitterDistance = 265;
			this.splitContainer1.TabIndex = 2;
			this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
			// 
			// list
			// 
			this.list.AllowDrop = true;
			this.list.BackColor = System.Drawing.Color.WhiteSmoke;
			this.list.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.list.Dock = System.Windows.Forms.DockStyle.Fill;
			this.list.FullRowSelect = true;
			this.list.HideSelection = false;
			this.list.ItemHeight = 25;
			this.list.LabelEdit = true;
			this.list.Location = new System.Drawing.Point(0, 0);
			this.list.Name = "list";
			this.list.ShowPlusMinus = false;
			this.list.Size = new System.Drawing.Size(265, 526);
			this.list.TabIndex = 0;
			this.list.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.list_BeforeLabelEdit);
			this.list.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.list_AfterLabelEdit);
			this.list.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.list_NodeMouseClick);
			this.list.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.list_NodeMouseDoubleClick);
			this.list.KeyUp += new System.Windows.Forms.KeyEventHandler(this.list_KeyUp);
			// 
			// editor
			// 
			this.editor.AcceptsReturn = true;
			this.editor.AcceptsTab = true;
			this.editor.AllowDrop = true;
			this.editor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
			this.editor.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.editor.Enabled = false;
			this.editor.HideSelection = false;
			this.editor.Location = new System.Drawing.Point(0, 0);
			this.editor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.editor.Multiline = true;
			this.editor.Name = "editor";
			this.editor.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.editor.Size = new System.Drawing.Size(768, 526);
			this.editor.TabIndex = 0;
			this.editor.TextChanged += new System.EventHandler(this.editor_TextChanged);
			this.editor.DragDrop += new System.Windows.Forms.DragEventHandler(this.editor_DragDrop);
			this.editor.DragEnter += new System.Windows.Forms.DragEventHandler(this.editor_DragEnter);
			this.editor.DragLeave += new System.EventHandler(this.editor_DragLeave);
			// 
			// listContextMenu
			// 
			this.listContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem9,
            this.menuItem32,
            this.renameContextMenuItem,
            this.deleteContextMenuItem,
            this.attachmentsSeparator,
            this.menuItem42,
            this.menuItem55,
            this.highlightContextMenuItem,
            this.menuItem53,
            this.attachmentsListContextMenuItem,
            this.menuItem44,
            this.propertiesContextMenuItem});
			this.listContextMenu.Popup += new System.EventHandler(this.listContextMenu_Popup);
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 0;
			this.menuItem9.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.newGroupContextMenuItem,
            this.newNoteContextMenuItem});
			this.menuItem9.Text = "New";
			// 
			// newGroupContextMenuItem
			// 
			this.newGroupContextMenuItem.Index = 0;
			this.newGroupContextMenuItem.Text = "Group";
			this.newGroupContextMenuItem.Click += new System.EventHandler(this.newGroupContextMenuItem_Click);
			// 
			// newNoteContextMenuItem
			// 
			this.newNoteContextMenuItem.Index = 1;
			this.newNoteContextMenuItem.Text = "Note";
			this.newNoteContextMenuItem.Click += new System.EventHandler(this.newNoteContextMenuItem_Click);
			// 
			// menuItem32
			// 
			this.menuItem32.Index = 1;
			this.menuItem32.Text = "-";
			// 
			// renameContextMenuItem
			// 
			this.renameContextMenuItem.Index = 2;
			this.renameContextMenuItem.Text = "Rename";
			this.renameContextMenuItem.Click += new System.EventHandler(this.renameContextMenuItem_Click);
			// 
			// deleteContextMenuItem
			// 
			this.deleteContextMenuItem.Index = 3;
			this.deleteContextMenuItem.Text = "Delete";
			this.deleteContextMenuItem.Click += new System.EventHandler(this.deleteContextMenuItem_Click);
			// 
			// attachmentsSeparator
			// 
			this.attachmentsSeparator.Index = 4;
			this.attachmentsSeparator.Text = "-";
			// 
			// menuItem42
			// 
			this.menuItem42.Index = 5;
			this.menuItem42.Text = "Protect";
			this.menuItem42.Click += new System.EventHandler(this.menuItem42_Click);
			// 
			// menuItem55
			// 
			this.menuItem55.Index = 6;
			this.menuItem55.Text = "-";
			// 
			// highlightContextMenuItem
			// 
			this.highlightContextMenuItem.Enabled = false;
			this.highlightContextMenuItem.Index = 7;
			this.highlightContextMenuItem.Text = "Highlight";
			this.highlightContextMenuItem.Click += new System.EventHandler(this.highlightContextMenuItem_Click);
			// 
			// menuItem53
			// 
			this.menuItem53.Index = 8;
			this.menuItem53.Text = "-";
			// 
			// attachmentsListContextMenuItem
			// 
			this.attachmentsListContextMenuItem.Index = 9;
			this.attachmentsListContextMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem45,
            this.attachFileContextMenuItem});
			this.attachmentsListContextMenuItem.Text = "Attachments";
			// 
			// menuItem45
			// 
			this.menuItem45.Index = 0;
			this.menuItem45.Text = "View";
			this.menuItem45.Click += new System.EventHandler(this.menuItem45_Click);
			// 
			// attachFileContextMenuItem
			// 
			this.attachFileContextMenuItem.Index = 1;
			this.attachFileContextMenuItem.Text = "Attach File...";
			this.attachFileContextMenuItem.Click += new System.EventHandler(this.attachFileContextMenuItem_Click);
			// 
			// menuItem44
			// 
			this.menuItem44.Index = 10;
			this.menuItem44.Text = "-";
			// 
			// propertiesContextMenuItem
			// 
			this.propertiesContextMenuItem.Index = 11;
			this.propertiesContextMenuItem.Text = "Properties";
			this.propertiesContextMenuItem.Click += new System.EventHandler(this.propertiesContextMenuItem_Click);
			// 
			// Window
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.ClientSize = new System.Drawing.Size(1037, 548);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.statusbar);
			this.Font = new System.Drawing.Font("Saira", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Menu = this.menu;
			this.Name = "Window";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Notes";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Window_FormClosing);
			this.Shown += new System.EventHandler(this.Window_Shown);
			this.LocationChanged += new System.EventHandler(this.Window_LocationChanged);
			this.SizeChanged += new System.EventHandler(this.Window_SizeChanged);
			this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Window_PreviewKeyDown);
			((System.ComponentModel.ISupportInitialize)(this.statePanel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lineCountPanel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.characterCountPanel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.changesNeedSavingPanel)).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.MainMenu menu;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem newGroupMenuItem;
		private System.Windows.Forms.MenuItem newNoteMenuItem;
		private System.Windows.Forms.MenuItem importMenuItem;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.MenuItem menuItem14;
		private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.MenuItem menuItem16;
		private System.Windows.Forms.MenuItem createBackupMenuItem;
		private System.Windows.Forms.MenuItem menuItem18;
		private System.Windows.Forms.MenuItem menuItem19;
		private System.Windows.Forms.MenuItem menuItem20;
		private System.Windows.Forms.MenuItem menuItem21;
		private System.Windows.Forms.MenuItem menuItem22;
		private System.Windows.Forms.MenuItem menuItem23;
		private System.Windows.Forms.MenuItem menuItem24;
		private System.Windows.Forms.MenuItem menuItem25;
		private System.Windows.Forms.MenuItem menuItem26;
		private System.Windows.Forms.MenuItem menuItem27;
		private System.Windows.Forms.MenuItem menuItem28;
		private System.Windows.Forms.MenuItem menuItem29;
		private System.Windows.Forms.MenuItem menuItem30;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ContextMenu listContextMenu;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem newGroupContextMenuItem;
		private System.Windows.Forms.MenuItem newNoteContextMenuItem;
		private System.Windows.Forms.MenuItem menuItem32;
		private System.Windows.Forms.MenuItem renameContextMenuItem;
		private System.Windows.Forms.MenuItem deleteContextMenuItem;
		private System.Windows.Forms.MenuItem saveMenuItem;
		private System.Windows.Forms.MenuItem menuItem34;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem17;
		private System.Windows.Forms.MenuItem menuItem31;
		private System.Windows.Forms.MenuItem wordWrapMenuItem;
		private System.Windows.Forms.MenuItem menuItem35;
		private System.Windows.Forms.StatusBarPanel lineCountPanel;
		private System.Windows.Forms.StatusBarPanel characterCountPanel;
		private System.Windows.Forms.StatusBarPanel statePanel;
		private System.Windows.Forms.MenuItem menuItem33;
		private System.Windows.Forms.MenuItem attachmentsSeparator;
		private System.Windows.Forms.MenuItem propertiesContextMenuItem;
		private System.Windows.Forms.MenuItem findAndReplace;
		private System.Windows.Forms.MenuItem menuItem38;
		private System.Windows.Forms.StatusBarPanel changesNeedSavingPanel;
		private System.Windows.Forms.MenuItem openMenuItem;
		private System.Windows.Forms.MenuItem menuItem37;
		private System.Windows.Forms.MenuItem menuItem39;
		private System.Windows.Forms.MenuItem menuItem40;
		public CustomTreeView list;
		public System.Windows.Forms.TextBox editor;
		private System.Windows.Forms.MenuItem attachFileContextMenuItem;
		private System.Windows.Forms.MenuItem menuItem44;
		private MenuItem attachmentsListContextMenuItem;
		private MenuItem menuItem45;
		private MenuItem menuItem46;
		private MenuItem menuItem47;
		private MenuItem menuItem48;
		private MenuItem menuItem49;
		public StatusBar statusbar;
		private MenuItem menuItem36;
		private MenuItem menuItem43;
		private MenuItem menuItem50;
		private MenuItem menuItem51;
		private MenuItem menuItem52;
		private MenuItem menuItem41;
		private MenuItem menuItem42;
		private MenuItem menuItem53;
		private MenuItem autoSaveMainMenuItem;
		private MenuItem menuItem55;
		private MenuItem highlightContextMenuItem;
	}
}

