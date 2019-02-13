namespace LineSorter.Commands.UserSort
{
    partial class FormTestFunc
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
            this.labelTest = new System.Windows.Forms.Label();
            this.labelResult = new System.Windows.Forms.Label();
            this.buttDone = new System.Windows.Forms.Button();
            this.textResult = new LineSorter.Commands.UserSort.LangBox();
            this.textTest = new LineSorter.Commands.UserSort.LangBox();
            this.SuspendLayout();
            // 
            // labelTest
            // 
            this.labelTest.AutoSize = true;
            this.labelTest.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTest.Location = new System.Drawing.Point(3, 9);
            this.labelTest.Name = "labelTest";
            this.labelTest.Size = new System.Drawing.Size(34, 15);
            this.labelTest.TabIndex = 4;
            this.labelTest.Text = "Тест:";
            // 
            // labelResult
            // 
            this.labelResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelResult.AutoSize = true;
            this.labelResult.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult.Location = new System.Drawing.Point(244, 9);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(63, 15);
            this.labelResult.TabIndex = 5;
            this.labelResult.Text = "Результат:";
            // 
            // buttDone
            // 
            this.buttDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttDone.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttDone.Location = new System.Drawing.Point(367, 263);
            this.buttDone.Name = "buttDone";
            this.buttDone.Size = new System.Drawing.Size(115, 23);
            this.buttDone.TabIndex = 2;
            this.buttDone.Text = "Готово";
            this.buttDone.UseVisualStyleBackColor = true;
            this.buttDone.Click += new System.EventHandler(this.ButtDone_Click);
            // 
            // textResult
            // 
            this.textResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textResult.AutoHeight = false;
            this.textResult.BackColor = System.Drawing.Color.White;
            this.textResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textResult.ClassColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(163)))), ((int)(((byte)(213)))));
            this.textResult.CommentColor = System.Drawing.Color.YellowGreen;
            this.textResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.textResult.Freezed = false;
            this.textResult.Interval = 1000;
            this.textResult.KeywordColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.textResult.Location = new System.Drawing.Point(247, 27);
            this.textResult.Name = "textResult";
            this.textResult.NumericColor = System.Drawing.Color.MediumSeaGreen;
            this.textResult.ReadOnly = true;
            this.textResult.Size = new System.Drawing.Size(235, 230);
            this.textResult.StringColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.textResult.TabIndex = 1;
            this.textResult.TabSize = 4;
            this.textResult.Text = "";
            // 
            // textTest
            // 
            this.textTest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textTest.AutoHeight = false;
            this.textTest.BackColor = System.Drawing.Color.White;
            this.textTest.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textTest.ClassColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(163)))), ((int)(((byte)(213)))));
            this.textTest.CommentColor = System.Drawing.Color.YellowGreen;
            this.textTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.textTest.Freezed = false;
            this.textTest.Interval = 1000;
            this.textTest.KeywordColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.textTest.Location = new System.Drawing.Point(6, 27);
            this.textTest.Name = "textTest";
            this.textTest.NumericColor = System.Drawing.Color.MediumSeaGreen;
            this.textTest.Size = new System.Drawing.Size(235, 230);
            this.textTest.StringColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.textTest.TabIndex = 0;
            this.textTest.TabSize = 4;
            this.textTest.Text = "";
            this.textTest.TextChanged += new System.EventHandler(this.TextTest_TextChanged);
            // 
            // FormTestFunc
            // 
            this.AcceptButton = this.buttDone;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttDone;
            this.ClientSize = new System.Drawing.Size(494, 293);
            this.Controls.Add(this.buttDone);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.labelTest);
            this.Controls.Add(this.textResult);
            this.Controls.Add(this.textTest);
            this.Name = "FormTestFunc";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тест функции сортировки";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormTestFunc_Load);
            this.Resize += new System.EventHandler(this.FormTestFunc_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LangBox textTest;
        private LangBox textResult;
        private System.Windows.Forms.Label labelTest;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Button buttDone;
    }
}