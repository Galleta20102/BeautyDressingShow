namespace finalProject
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button_save = new System.Windows.Forms.Button();
            this.button_open = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_toHSV = new System.Windows.Forms.Button();
            this.button_Binarization = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button_Closure = new System.Windows.Forms.Button();
            this.button_Opening = new System.Windows.Forms.Button();
            this.button_Connected = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Rbar = new System.Windows.Forms.TrackBar();
            this.Gbar = new System.Windows.Forms.TrackBar();
            this.Bbar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.combineBtn = new System.Windows.Forms.Button();
            this.hat = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.findFaceBtn = new System.Windows.Forms.Button();
            this.poolingBtn = new System.Windows.Forms.Button();
            this.facialFeaturesBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Rbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hat)).BeginInit();
            this.SuspendLayout();
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(136, 22);
            this.button_save.Margin = new System.Windows.Forms.Padding(4);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(100, 29);
            this.button_save.TabIndex = 79;
            this.button_save.Text = "save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_open
            // 
            this.button_open.Location = new System.Drawing.Point(13, 22);
            this.button_open.Margin = new System.Windows.Forms.Padding(4);
            this.button_open.Name = "button_open";
            this.button_open.Size = new System.Drawing.Size(100, 29);
            this.button_open.TabIndex = 78;
            this.button_open.Text = "open";
            this.button_open.UseVisualStyleBackColor = true;
            this.button_open.Click += new System.EventHandler(this.button_open_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pictureBox5.Location = new System.Drawing.Point(452, 112);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(400, 375);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 76;
            this.pictureBox5.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(446, 73);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 20);
            this.label7.TabIndex = 75;
            this.label7.Text = "Result Image";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pictureBox1.Location = new System.Drawing.Point(14, 112);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 375);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 73;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(9, 73);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 20);
            this.label1.TabIndex = 72;
            this.label1.Text = "Original Image";
            // 
            // button_toHSV
            // 
            this.button_toHSV.Location = new System.Drawing.Point(1226, 112);
            this.button_toHSV.Margin = new System.Windows.Forms.Padding(4);
            this.button_toHSV.Name = "button_toHSV";
            this.button_toHSV.Size = new System.Drawing.Size(100, 29);
            this.button_toHSV.TabIndex = 80;
            this.button_toHSV.Text = "toHSV";
            this.button_toHSV.UseVisualStyleBackColor = true;
            this.button_toHSV.Click += new System.EventHandler(this.button_toHSV_Click);
            // 
            // button_Binarization
            // 
            this.button_Binarization.Location = new System.Drawing.Point(1226, 149);
            this.button_Binarization.Margin = new System.Windows.Forms.Padding(4);
            this.button_Binarization.Name = "button_Binarization";
            this.button_Binarization.Size = new System.Drawing.Size(100, 29);
            this.button_Binarization.TabIndex = 81;
            this.button_Binarization.Text = "Binarization";
            this.button_Binarization.UseVisualStyleBackColor = true;
            this.button_Binarization.Click += new System.EventHandler(this.button_Binarization_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button_Closure
            // 
            this.button_Closure.Location = new System.Drawing.Point(1226, 186);
            this.button_Closure.Margin = new System.Windows.Forms.Padding(4);
            this.button_Closure.Name = "button_Closure";
            this.button_Closure.Size = new System.Drawing.Size(100, 29);
            this.button_Closure.TabIndex = 82;
            this.button_Closure.Text = "Closure";
            this.button_Closure.UseVisualStyleBackColor = true;
            this.button_Closure.Click += new System.EventHandler(this.button_Closure_Click);
            // 
            // button_Opening
            // 
            this.button_Opening.Location = new System.Drawing.Point(1226, 223);
            this.button_Opening.Margin = new System.Windows.Forms.Padding(4);
            this.button_Opening.Name = "button_Opening";
            this.button_Opening.Size = new System.Drawing.Size(100, 29);
            this.button_Opening.TabIndex = 83;
            this.button_Opening.Text = "Opening";
            this.button_Opening.UseVisualStyleBackColor = true;
            this.button_Opening.Click += new System.EventHandler(this.button_Opening_Click);
            // 
            // button_Connected
            // 
            this.button_Connected.Location = new System.Drawing.Point(1226, 260);
            this.button_Connected.Margin = new System.Windows.Forms.Padding(4);
            this.button_Connected.Name = "button_Connected";
            this.button_Connected.Size = new System.Drawing.Size(100, 29);
            this.button_Connected.TabIndex = 84;
            this.button_Connected.Text = "Connected";
            this.button_Connected.UseVisualStyleBackColor = true;
            this.button_Connected.Click += new System.EventHandler(this.button_Connected_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Rbar);
            this.groupBox1.Controls.Add(this.Gbar);
            this.groupBox1.Controls.Add(this.Bbar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(14, 506);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1205, 248);
            this.groupBox1.TabIndex = 97;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "飾品配色調整";
            // 
            // Rbar
            // 
            this.Rbar.Cursor = System.Windows.Forms.Cursors.Default;
            this.Rbar.Location = new System.Drawing.Point(55, 41);
            this.Rbar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Rbar.Maximum = 1000;
            this.Rbar.Minimum = -1000;
            this.Rbar.Name = "Rbar";
            this.Rbar.Size = new System.Drawing.Size(1115, 56);
            this.Rbar.TabIndex = 82;
            this.Rbar.ValueChanged += new System.EventHandler(this.RValueChange);
            // 
            // Gbar
            // 
            this.Gbar.Location = new System.Drawing.Point(55, 102);
            this.Gbar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Gbar.Maximum = 1000;
            this.Gbar.Minimum = -1000;
            this.Gbar.Name = "Gbar";
            this.Gbar.Size = new System.Drawing.Size(1115, 56);
            this.Gbar.TabIndex = 83;
            this.Gbar.ValueChanged += new System.EventHandler(this.GValueChange);
            // 
            // Bbar
            // 
            this.Bbar.Location = new System.Drawing.Point(55, 176);
            this.Bbar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Bbar.Maximum = 1000;
            this.Bbar.Minimum = -1000;
            this.Bbar.Name = "Bbar";
            this.Bbar.Size = new System.Drawing.Size(1115, 56);
            this.Bbar.TabIndex = 84;
            this.Bbar.ValueChanged += new System.EventHandler(this.BValueChange);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(25, 41);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 20);
            this.label3.TabIndex = 86;
            this.label3.Text = "R";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(25, 111);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 20);
            this.label4.TabIndex = 87;
            this.label4.Text = "G";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(25, 176);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 20);
            this.label5.TabIndex = 88;
            this.label5.Text = "B";
            // 
            // combineBtn
            // 
            this.combineBtn.Location = new System.Drawing.Point(870, 458);
            this.combineBtn.Margin = new System.Windows.Forms.Padding(4);
            this.combineBtn.Name = "combineBtn";
            this.combineBtn.Size = new System.Drawing.Size(349, 29);
            this.combineBtn.TabIndex = 102;
            this.combineBtn.Text = "Combine";
            this.combineBtn.UseVisualStyleBackColor = true;
            this.combineBtn.Click += new System.EventHandler(this.combineBtn_Click);
            // 
            // hat
            // 
            this.hat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.hat.Location = new System.Drawing.Point(870, 176);
            this.hat.Margin = new System.Windows.Forms.Padding(4);
            this.hat.Name = "hat";
            this.hat.Size = new System.Drawing.Size(349, 275);
            this.hat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.hat.TabIndex = 101;
            this.hat.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(870, 112);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(348, 56);
            this.comboBox1.TabIndex = 100;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // findFaceBtn
            // 
            this.findFaceBtn.Location = new System.Drawing.Point(1226, 332);
            this.findFaceBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.findFaceBtn.Name = "findFaceBtn";
            this.findFaceBtn.Size = new System.Drawing.Size(100, 29);
            this.findFaceBtn.TabIndex = 105;
            this.findFaceBtn.Text = "Find Face";
            this.findFaceBtn.UseVisualStyleBackColor = true;
            this.findFaceBtn.Click += new System.EventHandler(this.findFaceBtn_Click);
            // 
            // poolingBtn
            // 
            this.poolingBtn.Location = new System.Drawing.Point(1226, 297);
            this.poolingBtn.Margin = new System.Windows.Forms.Padding(4);
            this.poolingBtn.Name = "poolingBtn";
            this.poolingBtn.Size = new System.Drawing.Size(100, 29);
            this.poolingBtn.TabIndex = 104;
            this.poolingBtn.Text = "Pooling";
            this.poolingBtn.UseVisualStyleBackColor = true;
            this.poolingBtn.Click += new System.EventHandler(this.poolingBtn_Click);
            // 
            // facialFeaturesBtn
            // 
            this.facialFeaturesBtn.Location = new System.Drawing.Point(1226, 367);
            this.facialFeaturesBtn.Margin = new System.Windows.Forms.Padding(4);
            this.facialFeaturesBtn.Name = "facialFeaturesBtn";
            this.facialFeaturesBtn.Size = new System.Drawing.Size(100, 29);
            this.facialFeaturesBtn.TabIndex = 103;
            this.facialFeaturesBtn.Text = "facial features";
            this.facialFeaturesBtn.UseVisualStyleBackColor = true;
            this.facialFeaturesBtn.Click += new System.EventHandler(this.facialFeaturesBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1511, 767);
            this.Controls.Add(this.findFaceBtn);
            this.Controls.Add(this.poolingBtn);
            this.Controls.Add(this.facialFeaturesBtn);
            this.Controls.Add(this.combineBtn);
            this.Controls.Add(this.hat);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_Connected);
            this.Controls.Add(this.button_Opening);
            this.Controls.Add(this.button_Closure);
            this.Controls.Add(this.button_Binarization);
            this.Controls.Add(this.button_toHSV);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.button_open);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Rbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_open;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_toHSV;
        private System.Windows.Forms.Button button_Binarization;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button_Closure;
        private System.Windows.Forms.Button button_Opening;
        private System.Windows.Forms.Button button_Connected;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar Rbar;
        private System.Windows.Forms.TrackBar Gbar;
        private System.Windows.Forms.TrackBar Bbar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button combineBtn;
        private System.Windows.Forms.PictureBox hat;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button findFaceBtn;
        private System.Windows.Forms.Button poolingBtn;
        private System.Windows.Forms.Button facialFeaturesBtn;
    }
}

