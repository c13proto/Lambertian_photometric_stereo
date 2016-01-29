namespace Lambertian_photometric_stereo
{
    partial class main
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxIpl1 = new OpenCvSharp.UserInterface.PictureBoxIpl();
            this.button_開く = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton_3 = new System.Windows.Forms.RadioButton();
            this.radioButton_2 = new System.Windows.Forms.RadioButton();
            this.radioButton_1 = new System.Windows.Forms.RadioButton();
            this.radioButton_0 = new System.Windows.Forms.RadioButton();
            this.textBox_camera = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_0b = new System.Windows.Forms.TextBox();
            this.textBox_1b = new System.Windows.Forms.TextBox();
            this.textBox_2b = new System.Windows.Forms.TextBox();
            this.textBox_3b = new System.Windows.Forms.TextBox();
            this.textBox_3a = new System.Windows.Forms.TextBox();
            this.textBox_2a = new System.Windows.Forms.TextBox();
            this.textBox_1a = new System.Windows.Forms.TextBox();
            this.textBox_0a = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button_テンプレ = new System.Windows.Forms.Button();
            this.button_実行 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxIpl1
            // 
            this.pictureBoxIpl1.Location = new System.Drawing.Point(104, 3);
            this.pictureBoxIpl1.Name = "pictureBoxIpl1";
            this.pictureBoxIpl1.Size = new System.Drawing.Size(640, 480);
            this.pictureBoxIpl1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxIpl1.TabIndex = 0;
            this.pictureBoxIpl1.TabStop = false;
            // 
            // button_開く
            // 
            this.button_開く.Location = new System.Drawing.Point(5, 12);
            this.button_開く.Name = "button_開く";
            this.button_開く.Size = new System.Drawing.Size(75, 23);
            this.button_開く.TabIndex = 1;
            this.button_開く.Text = "開く";
            this.button_開く.UseVisualStyleBackColor = true;
            this.button_開く.Click += new System.EventHandler(this.Click_開く);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButton_3);
            this.panel1.Controls.Add(this.radioButton_2);
            this.panel1.Controls.Add(this.radioButton_1);
            this.panel1.Controls.Add(this.radioButton_0);
            this.panel1.Location = new System.Drawing.Point(1, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(95, 100);
            this.panel1.TabIndex = 2;
            // 
            // radioButton_3
            // 
            this.radioButton_3.AutoSize = true;
            this.radioButton_3.Location = new System.Drawing.Point(4, 73);
            this.radioButton_3.Name = "radioButton_3";
            this.radioButton_3.Size = new System.Drawing.Size(61, 16);
            this.radioButton_3.TabIndex = 3;
            this.radioButton_3.Text = "左下[3]";
            this.radioButton_3.UseVisualStyleBackColor = true;
            this.radioButton_3.Click += new System.EventHandler(this.Click_radio3);
            // 
            // radioButton_2
            // 
            this.radioButton_2.AutoSize = true;
            this.radioButton_2.Location = new System.Drawing.Point(4, 49);
            this.radioButton_2.Name = "radioButton_2";
            this.radioButton_2.Size = new System.Drawing.Size(61, 16);
            this.radioButton_2.TabIndex = 2;
            this.radioButton_2.Text = "左上[2]";
            this.radioButton_2.UseVisualStyleBackColor = true;
            this.radioButton_2.Click += new System.EventHandler(this.Click_radio2);
            // 
            // radioButton_1
            // 
            this.radioButton_1.AutoSize = true;
            this.radioButton_1.Location = new System.Drawing.Point(4, 27);
            this.radioButton_1.Name = "radioButton_1";
            this.radioButton_1.Size = new System.Drawing.Size(61, 16);
            this.radioButton_1.TabIndex = 1;
            this.radioButton_1.Text = "右下[1]";
            this.radioButton_1.UseVisualStyleBackColor = true;
            this.radioButton_1.Click += new System.EventHandler(this.Click_radio1);
            // 
            // radioButton_0
            // 
            this.radioButton_0.AutoSize = true;
            this.radioButton_0.Location = new System.Drawing.Point(4, 4);
            this.radioButton_0.Name = "radioButton_0";
            this.radioButton_0.Size = new System.Drawing.Size(61, 16);
            this.radioButton_0.TabIndex = 0;
            this.radioButton_0.Text = "右上[0]";
            this.radioButton_0.UseVisualStyleBackColor = true;
            this.radioButton_0.Click += new System.EventHandler(this.Click_radio0);
            // 
            // textBox_camera
            // 
            this.textBox_camera.Location = new System.Drawing.Point(44, 189);
            this.textBox_camera.Name = "textBox_camera";
            this.textBox_camera.Size = new System.Drawing.Size(44, 19);
            this.textBox_camera.TabIndex = 3;
            this.textBox_camera.Text = "3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "カメラ(y軸周り)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-1, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "光源(xy,xy-z)";
            // 
            // textBox_0b
            // 
            this.textBox_0b.Location = new System.Drawing.Point(56, 229);
            this.textBox_0b.Name = "textBox_0b";
            this.textBox_0b.Size = new System.Drawing.Size(40, 19);
            this.textBox_0b.TabIndex = 5;
            this.textBox_0b.Text = "60";
            // 
            // textBox_1b
            // 
            this.textBox_1b.Location = new System.Drawing.Point(56, 254);
            this.textBox_1b.Name = "textBox_1b";
            this.textBox_1b.Size = new System.Drawing.Size(40, 19);
            this.textBox_1b.TabIndex = 9;
            this.textBox_1b.Text = "60";
            // 
            // textBox_2b
            // 
            this.textBox_2b.Location = new System.Drawing.Point(56, 279);
            this.textBox_2b.Name = "textBox_2b";
            this.textBox_2b.Size = new System.Drawing.Size(40, 19);
            this.textBox_2b.TabIndex = 12;
            this.textBox_2b.Text = "45";
            // 
            // textBox_3b
            // 
            this.textBox_3b.Location = new System.Drawing.Point(56, 304);
            this.textBox_3b.Name = "textBox_3b";
            this.textBox_3b.Size = new System.Drawing.Size(40, 19);
            this.textBox_3b.TabIndex = 15;
            this.textBox_3b.Text = "45";
            // 
            // textBox_3a
            // 
            this.textBox_3a.Location = new System.Drawing.Point(14, 304);
            this.textBox_3a.Name = "textBox_3a";
            this.textBox_3a.Size = new System.Drawing.Size(38, 19);
            this.textBox_3a.TabIndex = 20;
            this.textBox_3a.Text = "135";
            // 
            // textBox_2a
            // 
            this.textBox_2a.Location = new System.Drawing.Point(14, 279);
            this.textBox_2a.Name = "textBox_2a";
            this.textBox_2a.Size = new System.Drawing.Size(38, 19);
            this.textBox_2a.TabIndex = 19;
            this.textBox_2a.Text = "-135";
            // 
            // textBox_1a
            // 
            this.textBox_1a.Location = new System.Drawing.Point(14, 254);
            this.textBox_1a.Name = "textBox_1a";
            this.textBox_1a.Size = new System.Drawing.Size(38, 19);
            this.textBox_1a.TabIndex = 18;
            this.textBox_1a.Text = "45";
            // 
            // textBox_0a
            // 
            this.textBox_0a.Location = new System.Drawing.Point(14, 229);
            this.textBox_0a.Name = "textBox_0a";
            this.textBox_0a.Size = new System.Drawing.Size(38, 19);
            this.textBox_0a.TabIndex = 17;
            this.textBox_0a.Text = "-45";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-2, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 21;
            this.label3.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-2, 257);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-2, 282);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 23;
            this.label5.Text = "2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(-2, 307);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 24;
            this.label6.Text = "3";
            // 
            // button_テンプレ
            // 
            this.button_テンプレ.Location = new System.Drawing.Point(5, 41);
            this.button_テンプレ.Name = "button_テンプレ";
            this.button_テンプレ.Size = new System.Drawing.Size(75, 23);
            this.button_テンプレ.TabIndex = 25;
            this.button_テンプレ.Text = "テンプレ";
            this.button_テンプレ.UseVisualStyleBackColor = true;
            this.button_テンプレ.Click += new System.EventHandler(this.Click_テンプレ);
            // 
            // button_実行
            // 
            this.button_実行.Location = new System.Drawing.Point(-2, 329);
            this.button_実行.Name = "button_実行";
            this.button_実行.Size = new System.Drawing.Size(75, 23);
            this.button_実行.TabIndex = 26;
            this.button_実行.Text = "実行";
            this.button_実行.UseVisualStyleBackColor = true;
            this.button_実行.Click += new System.EventHandler(this.Click_実行);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(749, 489);
            this.Controls.Add(this.button_実行);
            this.Controls.Add(this.button_テンプレ);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_3a);
            this.Controls.Add(this.textBox_2a);
            this.Controls.Add(this.textBox_1a);
            this.Controls.Add(this.textBox_0a);
            this.Controls.Add(this.textBox_3b);
            this.Controls.Add(this.textBox_2b);
            this.Controls.Add(this.textBox_1b);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_0b);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_camera);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_開く);
            this.Controls.Add(this.pictureBoxIpl1);
            this.Name = "main";
            this.Text = "main";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenCvSharp.UserInterface.PictureBoxIpl pictureBoxIpl1;
        private System.Windows.Forms.Button button_開く;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton_3;
        private System.Windows.Forms.RadioButton radioButton_2;
        private System.Windows.Forms.RadioButton radioButton_1;
        private System.Windows.Forms.RadioButton radioButton_0;
        private System.Windows.Forms.TextBox textBox_camera;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_0b;
        private System.Windows.Forms.TextBox textBox_1b;
        private System.Windows.Forms.TextBox textBox_2b;
        private System.Windows.Forms.TextBox textBox_3b;
        private System.Windows.Forms.TextBox textBox_3a;
        private System.Windows.Forms.TextBox textBox_2a;
        private System.Windows.Forms.TextBox textBox_1a;
        private System.Windows.Forms.TextBox textBox_0a;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_テンプレ;
        private System.Windows.Forms.Button button_実行;
    }
}

