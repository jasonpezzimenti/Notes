namespace Notes
{
	partial class NewGroupWindow
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewGroupWindow));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupNameTextField = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.okButton = new ALMSTWKND.UI.WindowsForms.Controls.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.groupNameTextField);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(12, 17);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox1.Size = new System.Drawing.Size(254, 90);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Group Properties";
			// 
			// groupNameTextField
			// 
			this.groupNameTextField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupNameTextField.Location = new System.Drawing.Point(10, 47);
			this.groupNameTextField.Name = "groupNameTextField";
			this.groupNameTextField.Size = new System.Drawing.Size(238, 25);
			this.groupNameTextField.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(73, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "Group Name:";
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
			this.okButton.Location = new System.Drawing.Point(191, 115);
			this.okButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.okButton.Name = "okButton";
			this.okButton.RequiresConfirmation = false;
			this.okButton.SeparatorDistance = 0;
			this.okButton.Size = new System.Drawing.Size(75, 25);
			this.okButton.StyleButtonSeparately = false;
			this.okButton.SynchronizeCheckMarkWithBorderSettings = false;
			this.okButton.TabIndex = 1;
			this.okButton.Text = "OK";
			this.okButton.UsingTexturedBackground = false;
			this.okButton.Clicked += new System.EventHandler<ALMSTWKND.UI.WindowsForms.Controls.Button.ButtonClickedEventArgs>(this.okButton_Clicked);
			// 
			// NewGroupWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.ClientSize = new System.Drawing.Size(278, 153);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.groupBox1);
			this.Font = new System.Drawing.Font("Saira", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "NewGroupWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "New Group";
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NewGroupWindow_KeyPress);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox groupNameTextField;
		private System.Windows.Forms.Label label1;
		private ALMSTWKND.UI.WindowsForms.Controls.Button okButton;
	}
}