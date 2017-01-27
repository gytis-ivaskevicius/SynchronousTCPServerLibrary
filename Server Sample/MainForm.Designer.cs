namespace Server_Sample
{
    partial class MainForm
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
            this.send_cbox = new System.Windows.Forms.CheckBox();
            this.Connection_lbl = new System.Windows.Forms.Label();
            this.connect_btn = new System.Windows.Forms.Button();
            this.port_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.console_txt = new System.Windows.Forms.TextBox();
            this.broadcast_btn = new System.Windows.Forms.Button();
            this.send_txt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // send_cbox
            // 
            this.send_cbox.AutoSize = true;
            this.send_cbox.Location = new System.Drawing.Point(435, 623);
            this.send_cbox.Name = "send_cbox";
            this.send_cbox.Size = new System.Drawing.Size(77, 17);
            this.send_cbox.TabIndex = 20;
            this.send_cbox.Text = "+New Line";
            this.send_cbox.UseVisualStyleBackColor = true;
            // 
            // Connection_lbl
            // 
            this.Connection_lbl.AutoSize = true;
            this.Connection_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 33F);
            this.Connection_lbl.ForeColor = System.Drawing.Color.Red;
            this.Connection_lbl.Location = new System.Drawing.Point(293, 664);
            this.Connection_lbl.Name = "Connection_lbl";
            this.Connection_lbl.Size = new System.Drawing.Size(300, 52);
            this.Connection_lbl.TabIndex = 19;
            this.Connection_lbl.Text = "Server Closed";
            // 
            // connect_btn
            // 
            this.connect_btn.Location = new System.Drawing.Point(12, 693);
            this.connect_btn.Name = "connect_btn";
            this.connect_btn.Size = new System.Drawing.Size(266, 26);
            this.connect_btn.TabIndex = 18;
            this.connect_btn.Text = "Start listening";
            this.connect_btn.UseVisualStyleBackColor = true;
            this.connect_btn.Click += new System.EventHandler(this.connect_btn_Click);
            // 
            // port_txt
            // 
            this.port_txt.Location = new System.Drawing.Point(12, 667);
            this.port_txt.Name = "port_txt";
            this.port_txt.Size = new System.Drawing.Size(266, 20);
            this.port_txt.TabIndex = 17;
            this.port_txt.Text = "1000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 651);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Port:";
            // 
            // console_txt
            // 
            this.console_txt.Location = new System.Drawing.Point(12, 9);
            this.console_txt.Multiline = true;
            this.console_txt.Name = "console_txt";
            this.console_txt.Size = new System.Drawing.Size(581, 608);
            this.console_txt.TabIndex = 15;
            // 
            // broadcast_btn
            // 
            this.broadcast_btn.Location = new System.Drawing.Point(518, 621);
            this.broadcast_btn.Name = "broadcast_btn";
            this.broadcast_btn.Size = new System.Drawing.Size(75, 20);
            this.broadcast_btn.TabIndex = 14;
            this.broadcast_btn.Text = "Broadcast";
            this.broadcast_btn.UseVisualStyleBackColor = true;
            this.broadcast_btn.Click += new System.EventHandler(this.send_btn_Click);
            // 
            // send_txt
            // 
            this.send_txt.Location = new System.Drawing.Point(12, 621);
            this.send_txt.Name = "send_txt";
            this.send_txt.Size = new System.Drawing.Size(419, 20);
            this.send_txt.TabIndex = 13;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 728);
            this.Controls.Add(this.send_cbox);
            this.Controls.Add(this.Connection_lbl);
            this.Controls.Add(this.connect_btn);
            this.Controls.Add(this.port_txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.console_txt);
            this.Controls.Add(this.broadcast_btn);
            this.Controls.Add(this.send_txt);
            this.Name = "MainForm";
            this.Text = "Server Sample";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox send_cbox;
        private System.Windows.Forms.Label Connection_lbl;
        private System.Windows.Forms.Button connect_btn;
        private System.Windows.Forms.TextBox port_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox console_txt;
        private System.Windows.Forms.Button broadcast_btn;
        private System.Windows.Forms.TextBox send_txt;
    }
}

