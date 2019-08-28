namespace ClientForm
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
            this.lbInt = new System.Windows.Forms.Label();
            this.lbFloat = new System.Windows.Forms.Label();
            this.lbString = new System.Windows.Forms.Label();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.txtInt = new System.Windows.Forms.TextBox();
            this.txtFloat = new System.Windows.Forms.TextBox();
            this.txtString = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.lboxReceivedData = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbServerIP
            // 
            this.lbServerIP.AutoSize = true;
            this.lbServerIP.Location = new System.Drawing.Point(12, 9);
            this.lbServerIP.Name = "lbServerIP";
            this.lbServerIP.Size = new System.Drawing.Size(101, 12);
            this.lbServerIP.TabIndex = 0;
            this.lbServerIP.Text = "접속할 서버 주소:";
            // 
            // lbInt
            // 
            this.lbInt.AutoSize = true;
            this.lbInt.Location = new System.Drawing.Point(12, 35);
            this.lbInt.Name = "lbInt";
            this.lbInt.Size = new System.Drawing.Size(74, 12);
            this.lbInt.TabIndex = 1;
            this.lbInt.Text = "int형 데이터:";
            // 
            // lbFloat
            // 
            this.lbFloat.AutoSize = true;
            this.lbFloat.Location = new System.Drawing.Point(12, 61);
            this.lbFloat.Name = "lbFloat";
            this.lbFloat.Size = new System.Drawing.Size(84, 12);
            this.lbFloat.TabIndex = 2;
            this.lbFloat.Text = "float형 데이터:";
            // 
            // lbString
            // 
            this.lbString.AutoSize = true;
            this.lbString.Location = new System.Drawing.Point(12, 87);
            this.lbString.Name = "lbString";
            this.lbString.Size = new System.Drawing.Size(85, 12);
            this.lbString.TabIndex = 3;
            this.lbString.Text = "문자열 데이터:";
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(138, 6);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(152, 21);
            this.txtServerIP.TabIndex = 4;
            // 
            // txtInt
            // 
            this.txtInt.Location = new System.Drawing.Point(138, 32);
            this.txtInt.Name = "txtInt";
            this.txtInt.Size = new System.Drawing.Size(152, 21);
            this.txtInt.TabIndex = 5;
            // 
            // txtFloat
            // 
            this.txtFloat.Location = new System.Drawing.Point(138, 58);
            this.txtFloat.Name = "txtFloat";
            this.txtFloat.Size = new System.Drawing.Size(152, 21);
            this.txtFloat.TabIndex = 6;
            // 
            // txtString
            // 
            this.txtString.Location = new System.Drawing.Point(138, 84);
            this.txtString.Name = "txtString";
            this.txtString.Size = new System.Drawing.Size(152, 21);
            this.txtString.TabIndex = 7;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(306, 4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 8;
            this.btnConnect.Text = "접속";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // btnTransfer
            // 
            this.btnTransfer.Location = new System.Drawing.Point(306, 82);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(94, 23);
            this.btnTransfer.TabIndex = 9;
            this.btnTransfer.Text = "전송 및 수신";
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.BtnTransfer_Click);
            // 
            // lboxReceivedData
            // 
            this.lboxReceivedData.FormattingEnabled = true;
            this.lboxReceivedData.ItemHeight = 12;
            this.lboxReceivedData.Location = new System.Drawing.Point(14, 122);
            this.lboxReceivedData.Name = "lboxReceivedData";
            this.lboxReceivedData.Size = new System.Drawing.Size(276, 172);
            this.lboxReceivedData.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 303);
            this.Controls.Add(this.lboxReceivedData);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtString);
            this.Controls.Add(this.txtFloat);
            this.Controls.Add(this.txtInt);
            this.Controls.Add(this.txtServerIP);
            this.Controls.Add(this.lbString);
            this.Controls.Add(this.lbFloat);
            this.Controls.Add(this.lbInt);
            this.Controls.Add(this.lbServerIP);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbServerIP;
        private System.Windows.Forms.Label lbInt;
        private System.Windows.Forms.Label lbFloat;
        private System.Windows.Forms.Label lbString;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.TextBox txtInt;
        private System.Windows.Forms.TextBox txtFloat;
        private System.Windows.Forms.TextBox txtString;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.ListBox lboxReceivedData;
    }
}

