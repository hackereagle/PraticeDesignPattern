namespace MvpPattern
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
            this.simpleView1 = new MvpPattern.View.SimpleView();
            this.calculatorView1 = new MvpPattern.View.CalculatorView();
            this.SuspendLayout();
            // 
            // simpleView1
            // 
            this.simpleView1.Location = new System.Drawing.Point(25, 32);
            this.simpleView1.Name = "simpleView1";
            this.simpleView1.Size = new System.Drawing.Size(389, 150);
            this.simpleView1.TabIndex = 0;
            // 
            // calculatorView1
            // 
            this.calculatorView1.Location = new System.Drawing.Point(440, 32);
            this.calculatorView1.Name = "calculatorView1";
            this.calculatorView1.Size = new System.Drawing.Size(206, 226);
            this.calculatorView1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 281);
            this.Controls.Add(this.calculatorView1);
            this.Controls.Add(this.simpleView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private View.SimpleView simpleView1;
        private View.CalculatorView calculatorView1;
    }
}

