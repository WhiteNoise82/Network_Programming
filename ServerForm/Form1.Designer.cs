namespace ServerForm
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbServerIP = new System.Windows.Forms.Label();
            this.lbConnectIP = new System.Windows.Forms.Label();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.txtConnectIP = new System.Windows.Forms.TextBox();
            this.btnConnectStart = new System.Windows.Forms.Button();
            this.btnTransferStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbServerIP
            // 
            this.lbServerIP.AutoSize = true;
            this.lbServerIP.Location = new System.Drawing.Point(12, 9);
            this.lbServerIP.Name = "lbServerIP";
            this.lbServerIP.Size = new System.Drawing.Size(47, 12);
            this.lbServerIP.TabIndex = 0;
            this.lbServerIP.Text = "서버 ip:";
            // 
            // lbConnectIP
            // 
            this.lbConnectIP.AutoSize = true;
            this.lbConnectIP.Location = new System.Drawing.Point(12, 40);
            this.lbConnectIP.Name = "lbConnectIP";
            this.lbConnectIP.Size = new System.Drawing.Size(59, 12);
            this.lbConnectIP.TabIndex = 1;
            this.lbConnectIP.Text = "접속자 ip:";
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(85, 6);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.ReadOnly = true;
            this.txtServerIP.Size = new System.Drawing.Size(166, 21);
            this.txtServerIP.TabIndex = 2;
            // 
            // txtConnectIP
            // 
            this.txtConnectIP.Location = new System.Drawing.Point(85, 37);
            this.txtConnectIP.Name = "txtConnectIP";
            this.txtConnectIP.ReadOnly = true;
            this.txtConnectIP.Size = new System.Drawing.Size(166, 21);
            this.txtConnectIP.TabIndex = 3;
            // 
            // btnConnectStart
            // 
            this.btnConnectStart.Location = new System.Drawing.Point(269, 4);
            this.btnConnectStart.Name = "btnConnectStart";
            this.btnConnectStart.Size = new System.Drawing.Size(75, 23);
            this.btnConnectStart.TabIndex = 4;
            this.btnConnectStart.Text = "접속 시작";
            this.btnConnectStart.UseVisualStyleBackColor = true;
            this.btnConnectStart.Click += new System.EventHandler(this.BtnConnectStart_Click);
            // 
            // btnTransferStart
            // 
            this.btnTransferStart.Location = new System.Drawing.Point(76, 76);
            this.btnTransferStart.Name = "btnTransferStart";
            this.btnTransferStart.Size = new System.Drawing.Size(214, 23);
            this.btnTransferStart.TabIndex = 5;
            this.btnTransferStart.Text = "송수신 시작";
            this.btnTransferStart.UseVisualStyleBackColor = true;
            this.btnTransferStart.Click += new System.EventHandler(this.BtnTransferStart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 108);
            this.Controls.Add(this.btnTransferStart);
            this.Controls.Add(this.btnConnectStart);
            this.Controls.Add(this.txtConnectIP);
            this.Controls.Add(this.txtServerIP);
            this.Controls.Add(this.lbConnectIP);
            this.Controls.Add(this.lbServerIP);
            this.Name = "Form1";
            this.Text = "Simple Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbServerIP;
        private System.Windows.Forms.Label lbConnectIP;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.TextBox txtConnectIP;
        private System.Windows.Forms.Button btnConnectStart;
        private System.Windows.Forms.Button btnTransferStart;
    }
}

