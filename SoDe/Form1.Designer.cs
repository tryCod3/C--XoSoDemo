
namespace SoDe
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
            this.grPanelkqxs = new System.Windows.Forms.GroupBox();
            this.panelShow = new System.Windows.Forms.Panel();
            this.flowshow = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonRun = new System.Windows.Forms.Button();
            this.textBoxNumber = new System.Windows.Forms.TextBox();
            this.labelSoMongMuon = new System.Windows.Forms.Label();
            this.cbLocal = new System.Windows.Forms.ComboBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.buttonWantNumber = new System.Windows.Forms.Button();
            this.grPanelkqxs.SuspendLayout();
            this.panelShow.SuspendLayout();
            this.SuspendLayout();
            // 
            // grPanelkqxs
            // 
            this.grPanelkqxs.BackColor = System.Drawing.SystemColors.ControlDark;
            this.grPanelkqxs.Controls.Add(this.panelShow);
            this.grPanelkqxs.Location = new System.Drawing.Point(12, 12);
            this.grPanelkqxs.Name = "grPanelkqxs";
            this.grPanelkqxs.Size = new System.Drawing.Size(1040, 670);
            this.grPanelkqxs.TabIndex = 1;
            this.grPanelkqxs.TabStop = false;
            this.grPanelkqxs.Text = "kết quả xổ số";
            // 
            // panelShow
            // 
            this.panelShow.AutoScroll = true;
            this.panelShow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelShow.Controls.Add(this.flowshow);
            this.panelShow.Location = new System.Drawing.Point(6, 21);
            this.panelShow.Name = "panelShow";
            this.panelShow.Size = new System.Drawing.Size(1034, 643);
            this.panelShow.TabIndex = 1;
            // 
            // flowshow
            // 
            this.flowshow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.flowshow.Location = new System.Drawing.Point(119, 13);
            this.flowshow.Name = "flowshow";
            this.flowshow.Size = new System.Drawing.Size(200, 110);
            this.flowshow.TabIndex = 0;
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(1159, 15);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(101, 47);
            this.buttonRun.TabIndex = 2;
            this.buttonRun.Text = "Run";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // textBoxNumber
            // 
            this.textBoxNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNumber.Location = new System.Drawing.Point(1157, 113);
            this.textBoxNumber.Multiline = true;
            this.textBoxNumber.Name = "textBoxNumber";
            this.textBoxNumber.Size = new System.Drawing.Size(122, 28);
            this.textBoxNumber.TabIndex = 3;
            this.textBoxNumber.Text = "123";
            // 
            // labelSoMongMuon
            // 
            this.labelSoMongMuon.ForeColor = System.Drawing.Color.Red;
            this.labelSoMongMuon.Location = new System.Drawing.Point(1154, 87);
            this.labelSoMongMuon.Name = "labelSoMongMuon";
            this.labelSoMongMuon.Size = new System.Drawing.Size(140, 23);
            this.labelSoMongMuon.TabIndex = 4;
            this.labelSoMongMuon.Text = "số mong muốn";
            // 
            // cbLocal
            // 
            this.cbLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLocal.FormattingEnabled = true;
            this.cbLocal.Items.AddRange(new object[] {
            "Bình Định",
            "Đà Nẵng",
            "Phú Yên"});
            this.cbLocal.Location = new System.Drawing.Point(1158, 188);
            this.cbLocal.Name = "cbLocal";
            this.cbLocal.Size = new System.Drawing.Size(121, 28);
            this.cbLocal.TabIndex = 6;
            this.cbLocal.Text = "Bình Định";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(1157, 233);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(196, 27);
            this.dateTimePicker.TabIndex = 0;
           
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_Click);

            // 
            // buttonWantNumber
            // 
            this.buttonWantNumber.Location = new System.Drawing.Point(1203, 147);
            this.buttonWantNumber.Name = "buttonWantNumber";
            this.buttonWantNumber.Size = new System.Drawing.Size(75, 23);
            this.buttonWantNumber.TabIndex = 7;
            this.buttonWantNumber.Text = "check";
            this.buttonWantNumber.UseVisualStyleBackColor = true;
            this.buttonWantNumber.Click += new System.EventHandler(this.buttonWantNumber_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1358, 721);
            this.Controls.Add(this.buttonWantNumber);
            this.Controls.Add(this.cbLocal);
            this.Controls.Add(this.labelSoMongMuon);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.textBoxNumber);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.grPanelkqxs);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grPanelkqxs.ResumeLayout(false);
            this.panelShow.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox grPanelkqxs;
        private System.Windows.Forms.Panel panelShow;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.TextBox textBoxNumber;
        private System.Windows.Forms.Label labelSoMongMuon;
        private System.Windows.Forms.FlowLayoutPanel flowshow;
        private System.Windows.Forms.ComboBox cbLocal;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button buttonWantNumber;
    }
}

