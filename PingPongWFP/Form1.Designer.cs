namespace PingPongWFP
{
    partial class Form1
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
            this.tmrMain = new System.Windows.Forms.Timer(this.components);
            this.ChkbOnOff = new System.Windows.Forms.Button();
            this.pingPong2 = new PingPongWFP.PingPong();
            this.pingPong1 = new PingPongWFP.PingPong();
            this.SuspendLayout();
            // 
            // tmrMain
            // 
            this.tmrMain.Tick += new System.EventHandler(this.tmrMain_Tick);
            // 
            // ChkbOnOff
            // 
            this.ChkbOnOff.Location = new System.Drawing.Point(25, 401);
            this.ChkbOnOff.Name = "ChkbOnOff";
            this.ChkbOnOff.Size = new System.Drawing.Size(75, 23);
            this.ChkbOnOff.TabIndex = 2;
            this.ChkbOnOff.Text = "Start";
            this.ChkbOnOff.UseVisualStyleBackColor = true;
            this.ChkbOnOff.Click += new System.EventHandler(this.ChkbOnOff_Click);
            // 
            // pingPong2
            // 
            this.pingPong2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pingPong2.Location = new System.Drawing.Point(5, 4);
            this.pingPong2.Name = "pingPong2";
            this.pingPong2.Size = new System.Drawing.Size(640, 444);
            this.pingPong2.TabIndex = 1;
            this.pingPong2.Visible = false;
            // 
            // pingPong1
            // 
            this.pingPong1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pingPong1.Location = new System.Drawing.Point(5, 4);
            this.pingPong1.Name = "pingPong1";
            this.pingPong1.Size = new System.Drawing.Size(792, 444);
            this.pingPong1.TabIndex = 0;
            this.pingPong1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(657, 450);
            this.Controls.Add(this.ChkbOnOff);
            this.Controls.Add(this.pingPong2);
            this.Controls.Add(this.pingPong1);
            this.Name = "Form1";
            this.Text = "Ping Pong";
            this.ResumeLayout(false);

        }

        #endregion

        private PingPong pingPong1;
        private System.Windows.Forms.Timer tmrMain;
        private PingPong pingPong2;
        private System.Windows.Forms.Button ChkbOnOff;
    }
}

