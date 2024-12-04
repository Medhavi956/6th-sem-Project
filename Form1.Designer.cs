namespace Graphical_Programming_Language_App_Medhavi
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
            this.run = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.save = new System.Windows.Forms.Label();
            this.load = new System.Windows.Forms.Label();
            this.canva_clear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.reset = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.position = new System.Windows.Forms.Label();
            this.fill = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.syntax_check = new System.Windows.Forms.Button();
            this.scoreBoard = new System.Windows.Forms.Label();
            this.error = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // run
            // 
            this.run.BackColor = System.Drawing.Color.YellowGreen;
            this.run.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.run.Location = new System.Drawing.Point(33, 657);
            this.run.Name = "run";
            this.run.Size = new System.Drawing.Size(135, 33);
            this.run.TabIndex = 0;
            this.run.Text = "Run";
            this.run.UseVisualStyleBackColor = false;
            this.run.Click += new System.EventHandler(this.run_Click);
            // 
            // Clear
            // 
            this.Clear.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clear.Location = new System.Drawing.Point(181, 657);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(135, 33);
            this.Clear.TabIndex = 1;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = false;
            this.Clear.Click += new System.EventHandler(this.syntax_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(33, 50);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(572, 271);
            this.textBox1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(629, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(543, 517);
            this.panel1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(33, 602);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(572, 22);
            this.textBox2.TabIndex = 4;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // save
            // 
            this.save.AutoSize = true;
            this.save.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save.Location = new System.Drawing.Point(43, 13);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(43, 16);
            this.save.TabIndex = 5;
            this.save.Text = "Save";
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // load
            // 
            this.load.AutoSize = true;
            this.load.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.load.Location = new System.Drawing.Point(119, 13);
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(38, 16);
            this.load.TabIndex = 6;
            this.load.Text = "load";
            this.load.Click += new System.EventHandler(this.load_Click);
            // 
            // canva_clear
            // 
            this.canva_clear.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.canva_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.canva_clear.Location = new System.Drawing.Point(1048, 4);
            this.canva_clear.Name = "canva_clear";
            this.canva_clear.Size = new System.Drawing.Size(135, 32);
            this.canva_clear.TabIndex = 7;
            this.canva_clear.Text = "Clear Canvas";
            this.canva_clear.UseVisualStyleBackColor = false;
            this.canva_clear.Click += new System.EventHandler(this.Canva_clear_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(771, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Fill:";
            // 
            // reset
            // 
            this.reset.BackColor = System.Drawing.Color.SandyBrown;
            this.reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reset.Location = new System.Drawing.Point(629, 7);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(109, 29);
            this.reset.TabIndex = 10;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = false;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(908, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Position :";
            // 
            // position
            // 
            this.position.AutoSize = true;
            this.position.Location = new System.Drawing.Point(975, 13);
            this.position.Name = "position";
            this.position.Size = new System.Drawing.Size(46, 16);
            this.position.TabIndex = 12;
            this.position.Text = "(10,10)";
            // 
            // fill
            // 
            this.fill.AutoSize = true;
            this.fill.Location = new System.Drawing.Point(804, 13);
            this.fill.Name = "fill";
            this.fill.Size = new System.Drawing.Size(21, 16);
            this.fill.TabIndex = 13;
            this.fill.Text = "off";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(33, 343);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(572, 239);
            this.textBox3.TabIndex = 14;
            // 
            // syntax_check
            // 
            this.syntax_check.Location = new System.Drawing.Point(454, 657);
            this.syntax_check.Name = "syntax_check";
            this.syntax_check.Size = new System.Drawing.Size(108, 33);
            this.syntax_check.TabIndex = 15;
            this.syntax_check.Text = "Syntax";
            this.syntax_check.UseVisualStyleBackColor = true;
            this.syntax_check.Click += new System.EventHandler(this.syntax_check_Click);
            // 
            // scoreBoard
            // 
            this.scoreBoard.AutoSize = true;
            this.scoreBoard.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreBoard.Location = new System.Drawing.Point(822, 595);
            this.scoreBoard.Name = "scoreBoard";
            this.scoreBoard.Size = new System.Drawing.Size(0, 29);
            this.scoreBoard.TabIndex = 16;
            // 
            // error
            // 
            this.error.Location = new System.Drawing.Point(629, 644);
            this.error.Multiline = true;
            this.error.Name = "error";
            this.error.ReadOnly = true;
            this.error.Size = new System.Drawing.Size(543, 62);
            this.error.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(1178, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 10);
            this.panel2.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 718);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.error);
            this.Controls.Add(this.scoreBoard);
            this.Controls.Add(this.syntax_check);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.fill);
            this.Controls.Add(this.position);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.canva_clear);
            this.Controls.Add(this.load);
            this.Controls.Add(this.save);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.run);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button run;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label save;
        private System.Windows.Forms.Label load;
        private System.Windows.Forms.Button canva_clear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label position;
        private System.Windows.Forms.Label fill;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button syntax_check;
        private System.Windows.Forms.Label scoreBoard;
        private System.Windows.Forms.TextBox error;
        private System.Windows.Forms.Panel panel2;
    }
}

