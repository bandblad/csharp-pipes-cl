namespace main_proc_client
{
    partial class MainWindow
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
            this.bSubmit = new System.Windows.Forms.Button();
            this.tbPipeName = new System.Windows.Forms.TextBox();
            this.gbNameOfPipe = new System.Windows.Forms.GroupBox();
            this.gbMessage = new System.Windows.Forms.GroupBox();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.bSendMessage = new System.Windows.Forms.Button();
            this.rtbLogWindow = new System.Windows.Forms.RichTextBox();
            this.gbNameOfPipe.SuspendLayout();
            this.gbMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // bSubmit
            // 
            this.bSubmit.Location = new System.Drawing.Point(292, 13);
            this.bSubmit.Name = "bSubmit";
            this.bSubmit.Size = new System.Drawing.Size(75, 26);
            this.bSubmit.TabIndex = 0;
            this.bSubmit.Text = "Connect";
            this.bSubmit.UseVisualStyleBackColor = true;
            // 
            // tbPipeName
            // 
            this.tbPipeName.Location = new System.Drawing.Point(6, 17);
            this.tbPipeName.Name = "tbPipeName";
            this.tbPipeName.Size = new System.Drawing.Size(280, 20);
            this.tbPipeName.TabIndex = 1;
            this.tbPipeName.Text = "Type name of pipe...";
            // 
            // gbNameOfPipe
            // 
            this.gbNameOfPipe.Controls.Add(this.tbPipeName);
            this.gbNameOfPipe.Controls.Add(this.bSubmit);
            this.gbNameOfPipe.Location = new System.Drawing.Point(12, 12);
            this.gbNameOfPipe.Name = "gbNameOfPipe";
            this.gbNameOfPipe.Size = new System.Drawing.Size(373, 45);
            this.gbNameOfPipe.TabIndex = 2;
            this.gbNameOfPipe.TabStop = false;
            this.gbNameOfPipe.Text = "Name of pipe:";
            // 
            // gbMessage
            // 
            this.gbMessage.Controls.Add(this.tbMessage);
            this.gbMessage.Controls.Add(this.bSendMessage);
            this.gbMessage.Location = new System.Drawing.Point(12, 261);
            this.gbMessage.Name = "gbMessage";
            this.gbMessage.Size = new System.Drawing.Size(373, 45);
            this.gbMessage.TabIndex = 3;
            this.gbMessage.TabStop = false;
            this.gbMessage.Text = "Name of pipe:";
            // 
            // tbMessage
            // 
            this.tbMessage.Enabled = false;
            this.tbMessage.Location = new System.Drawing.Point(6, 17);
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(280, 20);
            this.tbMessage.TabIndex = 1;
            this.tbMessage.Text = "Type message to send...";
            // 
            // bSendMessage
            // 
            this.bSendMessage.Enabled = false;
            this.bSendMessage.Location = new System.Drawing.Point(292, 13);
            this.bSendMessage.Name = "bSendMessage";
            this.bSendMessage.Size = new System.Drawing.Size(75, 26);
            this.bSendMessage.TabIndex = 0;
            this.bSendMessage.Text = "Send";
            this.bSendMessage.UseVisualStyleBackColor = true;
            // 
            // rtbLogWindow
            // 
            this.rtbLogWindow.Location = new System.Drawing.Point(12, 63);
            this.rtbLogWindow.Name = "rtbLogWindow";
            this.rtbLogWindow.ReadOnly = true;
            this.rtbLogWindow.Size = new System.Drawing.Size(373, 192);
            this.rtbLogWindow.TabIndex = 2;
            this.rtbLogWindow.Text = "";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 318);
            this.Controls.Add(this.rtbLogWindow);
            this.Controls.Add(this.gbMessage);
            this.Controls.Add(this.gbNameOfPipe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.Text = "GUI Pipe Client";
            this.gbNameOfPipe.ResumeLayout(false);
            this.gbNameOfPipe.PerformLayout();
            this.gbMessage.ResumeLayout(false);
            this.gbMessage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bSubmit;
        private System.Windows.Forms.TextBox tbPipeName;
        private System.Windows.Forms.GroupBox gbNameOfPipe;
        private System.Windows.Forms.GroupBox gbMessage;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.Button bSendMessage;
        private System.Windows.Forms.RichTextBox rtbLogWindow;
    }
}