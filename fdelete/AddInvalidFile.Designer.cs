namespace fdelete
{
    partial class AddInvalidFile
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
            label1.Location = new Point(27, 18);
            label1.Name = "label1";
            label1.Size = new Size(746, 32);
            label1.TabIndex = 0;
            label1.Text = "Adding a file here will place it in the list of invalid (undeletable) files.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 50);
            label2.Name = "label2";
            label2.Size = new Size(829, 32);
            label2.TabIndex = 1;
            label2.Text = "Files added here will be unable to be deleted, even if in a selected directory.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 135);
            label3.Name = "label3";
            label3.Size = new Size(428, 32);
            label3.TabIndex = 2;
            label3.Text = "Enter a file name (including extention):";
            // 
            // inputTB
            // 
            inputTB.Location = new Point(436, 132);
            inputTB.Name = "inputTB";
            inputTB.Size = new Size(403, 39);
            inputTB.TabIndex = 3;
            inputTB.KeyPress += inputTB_KeyPress;
            // 
            // cancelBT
            // 
            cancelBT.Location = new Point(667, 222);
            cancelBT.Name = "cancelBT";
            cancelBT.Size = new Size(150, 46);
            cancelBT.TabIndex = 4;
            cancelBT.Text = "Cancel";
            cancelBT.UseVisualStyleBackColor = true;
            cancelBT.Click += cancelBT_Click;
            // 
            // okBT
            // 
            okBT.Location = new Point(491, 222);
            okBT.Name = "okBT";
            okBT.Size = new Size(150, 46);
            okBT.TabIndex = 5;
            okBT.Text = "OK";
            okBT.UseVisualStyleBackColor = true;
            okBT.Click += okBT_Click;
            // 
            // AddInvalidFile
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(851, 296);
            Controls.Add(okBT);
            Controls.Add(cancelBT);
            Controls.Add(inputTB);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddInvalidFile";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "Add Invalid File";
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