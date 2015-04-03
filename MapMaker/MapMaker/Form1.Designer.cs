namespace MapMaker
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
            this.label1 = new System.Windows.Forms.Label();
            this.squadForm = new System.Windows.Forms.Label();
            this.squadBox_X = new System.Windows.Forms.TextBox();
            this.enemyLabel1 = new System.Windows.Forms.Label();
            this.enemyLabel2 = new System.Windows.Forms.Label();
            this.enemyLabel3 = new System.Windows.Forms.Label();
            this.enemyBox1_X = new System.Windows.Forms.TextBox();
            this.enemyBox2_X = new System.Windows.Forms.TextBox();
            this.enemyBox3_X = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.mapLabel = new System.Windows.Forms.Label();
            this.mapBox = new System.Windows.Forms.TextBox();
            this.squadBox_Y = new System.Windows.Forms.TextBox();
            this.enemyBox1_Y = new System.Windows.Forms.TextBox();
            this.enemyBox2_Y = new System.Windows.Forms.TextBox();
            this.enemyBox3_Y = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(392, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "For all coordinates, they must be within 1280 x 720 (width x height) and\r\nin sepa" +
    "rated by one comma, no space (e.g. \"4,5\"):\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // squadForm
            // 
            this.squadForm.AutoSize = true;
            this.squadForm.Location = new System.Drawing.Point(21, 112);
            this.squadForm.Name = "squadForm";
            this.squadForm.Size = new System.Drawing.Size(177, 13);
            this.squadForm.TabIndex = 1;
            this.squadForm.Text = "Enter coordinates for squad spawn: ";
            // 
            // squadBox_X
            // 
            this.squadBox_X.Location = new System.Drawing.Point(194, 109);
            this.squadBox_X.Name = "squadBox_X";
            this.squadBox_X.Size = new System.Drawing.Size(55, 20);
            this.squadBox_X.TabIndex = 2;
            // 
            // enemyLabel1
            // 
            this.enemyLabel1.AutoSize = true;
            this.enemyLabel1.Location = new System.Drawing.Point(21, 135);
            this.enemyLabel1.Name = "enemyLabel1";
            this.enemyLabel1.Size = new System.Drawing.Size(151, 13);
            this.enemyLabel1.TabIndex = 3;
            this.enemyLabel1.Text = "Enter coordinates for enemy 1:";
            // 
            // enemyLabel2
            // 
            this.enemyLabel2.AutoSize = true;
            this.enemyLabel2.Location = new System.Drawing.Point(21, 160);
            this.enemyLabel2.Name = "enemyLabel2";
            this.enemyLabel2.Size = new System.Drawing.Size(151, 13);
            this.enemyLabel2.TabIndex = 4;
            this.enemyLabel2.Text = "Enter coordinates for enemy 2:";
            // 
            // enemyLabel3
            // 
            this.enemyLabel3.AutoSize = true;
            this.enemyLabel3.Location = new System.Drawing.Point(21, 184);
            this.enemyLabel3.Name = "enemyLabel3";
            this.enemyLabel3.Size = new System.Drawing.Size(151, 13);
            this.enemyLabel3.TabIndex = 5;
            this.enemyLabel3.Text = "Enter coordinates for enemy 3:";
            // 
            // enemyBox1_X
            // 
            this.enemyBox1_X.Location = new System.Drawing.Point(194, 132);
            this.enemyBox1_X.Name = "enemyBox1_X";
            this.enemyBox1_X.Size = new System.Drawing.Size(55, 20);
            this.enemyBox1_X.TabIndex = 6;
            // 
            // enemyBox2_X
            // 
            this.enemyBox2_X.Location = new System.Drawing.Point(194, 155);
            this.enemyBox2_X.Name = "enemyBox2_X";
            this.enemyBox2_X.Size = new System.Drawing.Size(55, 20);
            this.enemyBox2_X.TabIndex = 7;
            // 
            // enemyBox3_X
            // 
            this.enemyBox3_X.Location = new System.Drawing.Point(194, 181);
            this.enemyBox3_X.Name = "enemyBox3_X";
            this.enemyBox3_X.Size = new System.Drawing.Size(55, 20);
            this.enemyBox3_X.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(194, 220);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Generate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mapLabel
            // 
            this.mapLabel.AutoSize = true;
            this.mapLabel.Location = new System.Drawing.Point(21, 61);
            this.mapLabel.Name = "mapLabel";
            this.mapLabel.Size = new System.Drawing.Size(89, 13);
            this.mapLabel.TabIndex = 10;
            this.mapLabel.Text = "Name of map file:";
            // 
            // mapBox
            // 
            this.mapBox.Location = new System.Drawing.Point(116, 58);
            this.mapBox.Name = "mapBox";
            this.mapBox.Size = new System.Drawing.Size(100, 20);
            this.mapBox.TabIndex = 11;
            // 
            // squadBox_Y
            // 
            this.squadBox_Y.Location = new System.Drawing.Point(255, 109);
            this.squadBox_Y.Name = "squadBox_Y";
            this.squadBox_Y.Size = new System.Drawing.Size(55, 20);
            this.squadBox_Y.TabIndex = 12;
            // 
            // enemyBox1_Y
            // 
            this.enemyBox1_Y.Location = new System.Drawing.Point(255, 135);
            this.enemyBox1_Y.Name = "enemyBox1_Y";
            this.enemyBox1_Y.Size = new System.Drawing.Size(55, 20);
            this.enemyBox1_Y.TabIndex = 13;
            // 
            // enemyBox2_Y
            // 
            this.enemyBox2_Y.Location = new System.Drawing.Point(255, 157);
            this.enemyBox2_Y.Name = "enemyBox2_Y";
            this.enemyBox2_Y.Size = new System.Drawing.Size(55, 20);
            this.enemyBox2_Y.TabIndex = 14;
            // 
            // enemyBox3_Y
            // 
            this.enemyBox3_Y.Location = new System.Drawing.Point(255, 181);
            this.enemyBox3_Y.Name = "enemyBox3_Y";
            this.enemyBox3_Y.Size = new System.Drawing.Size(55, 20);
            this.enemyBox3_Y.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(274, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Y";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 255);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.enemyBox3_Y);
            this.Controls.Add(this.enemyBox2_Y);
            this.Controls.Add(this.enemyBox1_Y);
            this.Controls.Add(this.squadBox_Y);
            this.Controls.Add(this.mapBox);
            this.Controls.Add(this.mapLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.enemyBox3_X);
            this.Controls.Add(this.enemyBox2_X);
            this.Controls.Add(this.enemyBox1_X);
            this.Controls.Add(this.enemyLabel3);
            this.Controls.Add(this.enemyLabel2);
            this.Controls.Add(this.enemyLabel1);
            this.Controls.Add(this.squadBox_X);
            this.Controls.Add(this.squadForm);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Map Maker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label squadForm;
        private System.Windows.Forms.TextBox squadBox_X;
        private System.Windows.Forms.Label enemyLabel1;
        private System.Windows.Forms.Label enemyLabel2;
        private System.Windows.Forms.Label enemyLabel3;
        private System.Windows.Forms.TextBox enemyBox1_X;
        private System.Windows.Forms.TextBox enemyBox2_X;
        private System.Windows.Forms.TextBox enemyBox3_X;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label mapLabel;
        private System.Windows.Forms.TextBox mapBox;
        private System.Windows.Forms.TextBox squadBox_Y;
        private System.Windows.Forms.TextBox enemyBox1_Y;
        private System.Windows.Forms.TextBox enemyBox2_Y;
        private System.Windows.Forms.TextBox enemyBox3_Y;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

