namespace BeAkdToLnHstCmptr2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox_Set = new GroupBox();
            btn_Connect = new Button();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            groupBox_Show = new GroupBox();
            txt_Receive = new TextBox();
            groupBox_Send = new GroupBox();
            btn_Send = new Button();
            txt_Send = new TextBox();
            groupBox_Set.SuspendLayout();
            groupBox_Show.SuspendLayout();
            groupBox_Send.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox_Set
            // 
            groupBox_Set.Controls.Add(btn_Connect);
            groupBox_Set.Controls.Add(comboBox2);
            groupBox_Set.Controls.Add(comboBox1);
            groupBox_Set.Controls.Add(label2);
            groupBox_Set.Controls.Add(label1);
            groupBox_Set.Location = new Point(12, 12);
            groupBox_Set.Name = "groupBox_Set";
            groupBox_Set.Size = new Size(754, 130);
            groupBox_Set.TabIndex = 0;
            groupBox_Set.TabStop = false;
            groupBox_Set.Text = "通信设置";
            // 
            // btn_Connect
            // 
            btn_Connect.Location = new Point(547, 59);
            btn_Connect.Name = "btn_Connect";
            btn_Connect.Size = new Size(112, 34);
            btn_Connect.TabIndex = 4;
            btn_Connect.Text = "连接设备";
            btn_Connect.UseVisualStyleBackColor = true;
            btn_Connect.Click += btn_Connect_Click;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "9600", "115200" });
            comboBox2.Location = new Point(85, 86);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(182, 32);
            comboBox2.TabIndex = 3;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "COM1", "COM2", "COM3" });
            comboBox1.Location = new Point(85, 41);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(182, 32);
            comboBox1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 86);
            label2.Name = "label2";
            label2.Size = new Size(82, 24);
            label2.TabIndex = 1;
            label2.Text = "波特率：";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 41);
            label1.Name = "label1";
            label1.Size = new Size(64, 24);
            label1.TabIndex = 0;
            label1.Text = "端口：";
            // 
            // groupBox_Show
            // 
            groupBox_Show.Controls.Add(txt_Receive);
            groupBox_Show.Location = new Point(12, 148);
            groupBox_Show.Name = "groupBox_Show";
            groupBox_Show.Size = new Size(754, 170);
            groupBox_Show.TabIndex = 1;
            groupBox_Show.TabStop = false;
            groupBox_Show.Text = "数据监控";
            // 
            // txt_Receive
            // 
            txt_Receive.Location = new Point(6, 29);
            txt_Receive.Multiline = true;
            txt_Receive.Name = "txt_Receive";
            txt_Receive.ScrollBars = ScrollBars.Vertical;
            txt_Receive.Size = new Size(536, 135);
            txt_Receive.TabIndex = 0;
            // 
            // groupBox_Send
            // 
            groupBox_Send.Controls.Add(btn_Send);
            groupBox_Send.Controls.Add(txt_Send);
            groupBox_Send.Location = new Point(12, 324);
            groupBox_Send.Name = "groupBox_Send";
            groupBox_Send.Size = new Size(754, 120);
            groupBox_Send.TabIndex = 2;
            groupBox_Send.TabStop = false;
            groupBox_Send.Text = "指令发送";
            // 
            // btn_Send
            // 
            btn_Send.Location = new Point(547, 29);
            btn_Send.Name = "btn_Send";
            btn_Send.Size = new Size(112, 52);
            btn_Send.TabIndex = 1;
            btn_Send.Text = "发送指令";
            btn_Send.UseVisualStyleBackColor = true;
            btn_Send.Click += btn_Send_Click;
            // 
            // txt_Send
            // 
            txt_Send.Location = new Point(6, 29);
            txt_Send.Name = "txt_Send";
            txt_Send.Size = new Size(536, 30);
            txt_Send.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(778, 444);
            Controls.Add(groupBox_Send);
            Controls.Add(groupBox_Show);
            Controls.Add(groupBox_Set);
            Name = "Form1";
            Text = "上位机界面";
            Load += Form1_Load;
            groupBox_Set.ResumeLayout(false);
            groupBox_Set.PerformLayout();
            groupBox_Show.ResumeLayout(false);
            groupBox_Show.PerformLayout();
            groupBox_Send.ResumeLayout(false);
            groupBox_Send.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox_Set;
        private Label label1;
        private GroupBox groupBox_Show;
        private GroupBox groupBox_Send;
        private Button btn_Connect;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private Label label2;
        private TextBox txt_Receive;
        private Button btn_Send;
        private TextBox txt_Send;
    }
}
