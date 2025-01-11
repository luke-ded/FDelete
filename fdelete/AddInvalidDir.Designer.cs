namespace fdelete
{
    partial class AddInvalidDir
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            inputTB = new TextBox();
            cancelBT = new Button();
            okBT = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 18);
            label1.Name = "label1";
            label1.Size = new Size(727, 32);
            label1.TabIndex = 0;
            label1.Text = "Adding a directory here will place it in the list of invalid directories.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(47, 50);
            label2.Name = "label2";
            label2.Size = new Size(706, 32);
            label2.TabIndex = 1;
            label2.Text = "Directories added here will be unable to be added to the run list.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(70, 135);
            label3.Name = "label3";
            label3.Size = new Size(194, 32);
            label3.TabIndex = 2;
            label3.Text = "Enter a directory:";
            // 
            // inputTB
            // 
            inputTB.Location = new Point(270, 132);
            inputTB.Name = "inputTB";
            inputTB.Size = new Size(460, 39);
            inputTB.TabIndex = 3;
            inputTB.KeyPress += inputTB_KeyPress;
            // 
            // cancelBT
            // 
            cancelBT.Location = new Point(614, 229);
            cancelBT.Name = "cancelBT";
            cancelBT.Size = new Size(150, 46);
            cancelBT.TabIndex = 4;
            cancelBT.Text = "Cancel";
            cancelBT.UseVisualStyleBackColor = true;
            cancelBT.Click += cancelBT_Click;
            // 
            // okBT
            // 
            okBT.Location = new Point(438, 229);
            okBT.Name = "okBT";
            okBT.Size = new Size(150, 46);
            okBT.TabIndex = 5;
            okBT.Text = "OK";
            okBT.UseVisualStyleBackColor = true;
            okBT.Click += okBT_Click;
            // 
            // AddInvalidDir
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 297);
            Controls.Add(okBT);
            Controls.Add(cancelBT);
            Controls.Add(inputTB);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddInvalidDir";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "Add Invalid Directory";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox inputTB;
        private Button cancelBT;
        private Button okBT;
    }
}