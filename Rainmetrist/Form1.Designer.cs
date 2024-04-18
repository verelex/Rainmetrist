namespace Rainmetrist
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
            textBox1 = new TextBox();
            label1 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            label2 = new Label();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            textBox7 = new TextBox();
            textBox8 = new TextBox();
            buttonSaveCfg = new Button();
            buttonStart = new Button();
            label3 = new Label();
            textBox9 = new TextBox();
            label4 = new Label();
            buttonStop = new Button();
            menuStrip1 = new MenuStrip();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 74);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(1163, 31);
            textBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 46);
            label1.Name = "label1";
            label1.Size = new Size(113, 25);
            label1.TabIndex = 1;
            label1.Text = "Web адреса:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 123);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(1163, 31);
            textBox2.TabIndex = 2;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(12, 171);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(1163, 31);
            textBox3.TabIndex = 3;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(12, 218);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(1163, 31);
            textBox4.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 290);
            label2.Name = "label2";
            label2.Size = new Size(359, 25);
            label2.TabIndex = 5;
            label2.Text = "Директории сохранения (соответственно):";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(12, 318);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(1163, 31);
            textBox5.TabIndex = 6;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(12, 368);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(1163, 31);
            textBox6.TabIndex = 7;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(12, 418);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(1163, 31);
            textBox7.TabIndex = 8;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(12, 470);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(1163, 31);
            textBox8.TabIndex = 9;
            // 
            // buttonSaveCfg
            // 
            buttonSaveCfg.Location = new Point(963, 513);
            buttonSaveCfg.Name = "buttonSaveCfg";
            buttonSaveCfg.Size = new Size(212, 53);
            buttonSaveCfg.TabIndex = 10;
            buttonSaveCfg.Text = "Сохранить конфиг";
            buttonSaveCfg.UseVisualStyleBackColor = true;
            buttonSaveCfg.Click += buttonSaveCfg_Click;
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(309, 515);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(321, 51);
            buttonStart.TabIndex = 12;
            buttonStart.Text = "Создать задачу в планировщике";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 525);
            label3.Name = "label3";
            label3.Size = new Size(170, 25);
            label3.TabIndex = 13;
            label3.Text = "Повторный запуск:";
            // 
            // textBox9
            // 
            textBox9.Location = new Point(180, 523);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(48, 31);
            textBox9.TabIndex = 14;
            textBox9.Text = "50";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(234, 525);
            label4.Name = "label4";
            label4.Size = new Size(61, 25);
            label4.TabIndex = 15;
            label4.Text = "минут";
            // 
            // buttonStop
            // 
            buttonStop.Location = new Point(636, 515);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new Size(321, 51);
            buttonStop.TabIndex = 16;
            buttonStop.Text = "Удалить задачу из планировщика";
            buttonStop.UseVisualStyleBackColor = true;
            buttonStop.Click += buttonStop_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1186, 24);
            menuStrip1.TabIndex = 17;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1186, 582);
            Controls.Add(buttonStop);
            Controls.Add(label4);
            Controls.Add(textBox9);
            Controls.Add(label3);
            Controls.Add(buttonStart);
            Controls.Add(buttonSaveCfg);
            Controls.Add(textBox8);
            Controls.Add(textBox7);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(label2);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Rainmetrist";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label2;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox8;
        private Button buttonSaveCfg;
        private Button buttonStart;
        private Label label3;
        private TextBox textBox9;
        private Label label4;
        private Button buttonStop;
        private MenuStrip menuStrip1;
    }
}
