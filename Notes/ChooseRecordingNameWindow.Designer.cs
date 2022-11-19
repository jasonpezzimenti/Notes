namespace Notes
{
	partial class ChooseRecordingNameWindow
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseRecordingNameWindow));
			this.applyChangesButton = new ALMSTWKND.UI.WindowsForms.Controls.Button();
			this.recordingNameTextField = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
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
			this.applyChangesButton.Location = new System.Drawing.Point(202, 67);
			this.applyChangesButton.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.applyChangesButton.Name = "applyChangesButton";
			this.applyChangesButton.RequiresConfirmation = true;
			this.applyChangesButton.SeparatorDistance = 25;
			this.applyChangesButton.Size = new System.Drawing.Size(75, 25);
			this.applyChangesButton.StyleButtonSeparately = false;
			this.applyChangesButton.SynchronizeCheckMarkWithBorderSettings = true;
			this.applyChangesButton.TabIndex = 2;
			this.applyChangesButton.Text = "Apply";
			this.applyChangesButton.UsingTexturedBackground = false;
			this.applyChangesButton.Confirmed += new System.EventHandler<ALMSTWKND.UI.WindowsForms.Controls.Button.ButtonConfirmedEventArgs>(this.applyChangesButton_Confirmed);
			// 
			// recordingNameTextField
			// 
			this.recordingNameTextField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.recordingNameTextField.Location = new System.Drawing.Point(15, 30);
			this.recordingNameTextField.Name = "recordingNameTextField";
			this.recordingNameTextField.Size = new System.Drawing.Size(262, 25);
			this.recordingNameTextField.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(93, 18);
			this.label1.TabIndex = 4;
			this.label1.Text = "Recording Name:";
			// 
			// ChooseRecordingNameWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.ClientSize = new System.Drawing.Size(289, 107);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.recordingNameTextField);
			this.Controls.Add(this.applyChangesButton);
			this.Font = new System.Drawing.Font("Saira", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "ChooseRecordingNameWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Recording Name";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ALMSTWKND.UI.WindowsForms.Controls.Button applyChangesButton;
		private System.Windows.Forms.TextBox recordingNameTextField;
		private System.Windows.Forms.Label label1;
	}
}