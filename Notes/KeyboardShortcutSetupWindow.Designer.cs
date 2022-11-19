namespace Notes
{
	partial class KeyboardShortcutSetupWindow
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
			this.list = new System.Windows.Forms.ListBox();
			this.okButton = new ALMSTWKND.UI.WindowsForms.Controls.Button();
			this.SuspendLayout();
			// 
			// list
			// 
			this.list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.list.FormattingEnabled = true;
			this.list.ItemHeight = 18;
			this.list.Location = new System.Drawing.Point(12, 17);
			this.list.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.list.Name = "list";
			this.list.Size = new System.Drawing.Size(248, 166);
			this.list.TabIndex = 0;
			// 
			// okButton
			// 
			this.okButton.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(210)))), ((int)(((byte)(214)))));
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(239)))));
			this.okButton.BackgroundImageLayout = null;
			this.okButton.BackgroundTexture = null;
			this.okButton.BackgroundTextureLayout = System.Windows.Forms.ImageLayout.None;
			this.okButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(165)))), ((int)(((byte)(173)))));
			this.okButton.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this.okButton.BorderThickness = 1F;
			this.okButton.CheckboxActiveColor = System.Drawing.Color.Empty;
			this.okButton.CheckboxBackgroundColor = System.Drawing.Color.Empty;
			this.okButton.CheckboxHighlightColor = System.Drawing.Color.Empty;
			this.okButton.CheckmarkColor = System.Drawing.Color.Empty;
			this.okButton.CheckmarkThickness = 0F;
			this.okButton.ConfirmedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(242)))), ((int)(((byte)(230)))));
			this.okButton.ConfirmedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
			this.okButton.ConfirmedCheckBoxBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(242)))), ((int)(((byte)(230)))));
			this.okButton.ConfirmedCheckmarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
			this.okButton.DisabledBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(232)))));
			this.okButton.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
			this.okButton.DisabledCheckBoxBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(232)))));
			this.okButton.DisabledCheckmarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
			this.okButton.DisabledSeparatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
			this.okButton.FocusedBorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this.okButton.FocusedColor = System.Drawing.Color.Empty;
			this.okButton.HasBorder = true;
			this.okButton.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(222)))), ((int)(((byte)(226)))));
			this.okButton.Location = new System.Drawing.Point(185, 196);
			this.okButton.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.okButton.Name = "okButton";
			this.okButton.RequiresConfirmation = false;
			this.okButton.SeparatorDistance = 0;
			this.okButton.Size = new System.Drawing.Size(75, 25);
			this.okButton.StyleButtonSeparately = false;
			this.okButton.SynchronizeCheckMarkWithBorderSettings = false;
			this.okButton.TabIndex = 2;
			this.okButton.Text = "OK";
			this.okButton.UsingTexturedBackground = false;
			// 
			// KeyboardShortcutSetupWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.ClientSize = new System.Drawing.Size(272, 236);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.list);
			this.Font = new System.Drawing.Font("Saira", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "KeyboardShortcutSetupWindow";
			this.Text = "Extension Shortcut Setup";
			this.Shown += new System.EventHandler(this.KeyboardShortcutSetupWindow_Shown);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox list;
		private ALMSTWKND.UI.WindowsForms.Controls.Button okButton;
	}
}