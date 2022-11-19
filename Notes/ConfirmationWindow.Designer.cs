namespace Notes
{
	partial class ConfirmationWindow
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfirmationWindow));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.button1 = new ALMSTWKND.UI.WindowsForms.Controls.Button();
			this.applyChangesButton = new ALMSTWKND.UI.WindowsForms.Controls.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::Notes.Properties.Resources.questionmark;
			this.pictureBox1.Location = new System.Drawing.Point(41, 41);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(32, 32, 3, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(32, 32);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(79, 49);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(291, 18);
			this.label1.TabIndex = 1;
			this.label1.Text = "Are you sure you want to exit without saving changes?";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.applyChangesButton);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 115);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(406, 55);
			this.panel1.TabIndex = 2;
			// 
			// button1
			// 
			this.button1.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(210)))), ((int)(((byte)(214)))));
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(239)))));
			this.button1.BackgroundImageLayout = null;
			this.button1.BackgroundTexture = null;
			this.button1.BackgroundTextureLayout = System.Windows.Forms.ImageLayout.None;
			this.button1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(165)))), ((int)(((byte)(173)))));
			this.button1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this.button1.BorderThickness = 1F;
			this.button1.CheckboxActiveColor = System.Drawing.Color.Empty;
			this.button1.CheckboxBackgroundColor = System.Drawing.Color.Empty;
			this.button1.CheckboxHighlightColor = System.Drawing.Color.Empty;
			this.button1.CheckmarkColor = System.Drawing.Color.Empty;
			this.button1.CheckmarkThickness = 1F;
			this.button1.ConfirmedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(242)))), ((int)(((byte)(230)))));
			this.button1.ConfirmedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
			this.button1.ConfirmedCheckBoxBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(242)))), ((int)(((byte)(230)))));
			this.button1.ConfirmedCheckmarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
			this.button1.DisabledBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(232)))));
			this.button1.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
			this.button1.DisabledCheckBoxBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(232)))));
			this.button1.DisabledCheckmarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
			this.button1.DisabledSeparatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
			this.button1.FocusedBorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this.button1.FocusedColor = System.Drawing.Color.Empty;
			this.button1.HasBorder = true;
			this.button1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(222)))), ((int)(((byte)(226)))));
			this.button1.Location = new System.Drawing.Point(238, 17);
			this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.button1.Name = "button1";
			this.button1.RequiresConfirmation = true;
			this.button1.SeparatorDistance = 25;
			this.button1.Size = new System.Drawing.Size(75, 25);
			this.button1.StyleButtonSeparately = false;
			this.button1.SynchronizeCheckMarkWithBorderSettings = false;
			this.button1.TabIndex = 5;
			this.button1.Text = "Yes";
			this.button1.UsingTexturedBackground = false;
			this.button1.Confirmed += new System.EventHandler<ALMSTWKND.UI.WindowsForms.Controls.Button.ButtonConfirmedEventArgs>(this.button1_Confirmed);
			// 
			// applyChangesButton
			// 
			this.applyChangesButton.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(210)))), ((int)(((byte)(214)))));
			this.applyChangesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.applyChangesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(239)))));
			this.applyChangesButton.BackgroundImageLayout = null;
			this.applyChangesButton.BackgroundTexture = null;
			this.applyChangesButton.BackgroundTextureLayout = System.Windows.Forms.ImageLayout.None;
			this.applyChangesButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(165)))), ((int)(((byte)(173)))));
			this.applyChangesButton.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this.applyChangesButton.BorderThickness = 1F;
			this.applyChangesButton.CheckboxActiveColor = System.Drawing.Color.Empty;
			this.applyChangesButton.CheckboxBackgroundColor = System.Drawing.Color.Empty;
			this.applyChangesButton.CheckboxHighlightColor = System.Drawing.Color.Empty;
			this.applyChangesButton.CheckmarkColor = System.Drawing.Color.Empty;
			this.applyChangesButton.CheckmarkThickness = 1F;
			this.applyChangesButton.ConfirmedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(242)))), ((int)(((byte)(230)))));
			this.applyChangesButton.ConfirmedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
			this.applyChangesButton.ConfirmedCheckBoxBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(242)))), ((int)(((byte)(230)))));
			this.applyChangesButton.ConfirmedCheckmarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
			this.applyChangesButton.DisabledBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(232)))));
			this.applyChangesButton.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
			this.applyChangesButton.DisabledCheckBoxBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(232)))));
			this.applyChangesButton.DisabledCheckmarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
			this.applyChangesButton.DisabledSeparatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
			this.applyChangesButton.FocusedBorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this.applyChangesButton.FocusedColor = System.Drawing.Color.Empty;
			this.applyChangesButton.HasBorder = true;
			this.applyChangesButton.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(222)))), ((int)(((byte)(226)))));
			this.applyChangesButton.Location = new System.Drawing.Point(319, 17);
			this.applyChangesButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.applyChangesButton.Name = "applyChangesButton";
			this.applyChangesButton.RequiresConfirmation = false;
			this.applyChangesButton.SeparatorDistance = 25;
			this.applyChangesButton.Size = new System.Drawing.Size(75, 25);
			this.applyChangesButton.StyleButtonSeparately = false;
			this.applyChangesButton.SynchronizeCheckMarkWithBorderSettings = true;
			this.applyChangesButton.TabIndex = 4;
			this.applyChangesButton.Text = "No";
			this.applyChangesButton.UsingTexturedBackground = false;
			this.applyChangesButton.Clicked += new System.EventHandler<ALMSTWKND.UI.WindowsForms.Controls.Button.ButtonClickedEventArgs>(this.applyChangesButton_Clicked);
			// 
			// ConfirmationWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(406, 170);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.Font = new System.Drawing.Font("Saira", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "ConfirmationWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Confirmation";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private ALMSTWKND.UI.WindowsForms.Controls.Button button1;
		private ALMSTWKND.UI.WindowsForms.Controls.Button applyChangesButton;
	}
}