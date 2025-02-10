namespace fdelete
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            aboutMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            addExtensionMenuItem = new ToolStripMenuItem();
            addInvalidDirMenuItem = new ToolStripMenuItem();
            addInvalidFileMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            extCheckMenuItem = new ToolStripMenuItem();
            dirCheckMenuItem = new ToolStripMenuItem();
            subCheckMenuItem = new ToolStripMenuItem();
            delUnCheckMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            extTB = new TextBox();
            runBT = new Button();
            label2 = new Label();
            dirTB = new TextBox();
            extLB = new CheckedListBox();
            dirLB = new CheckedListBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, settingsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1355, 40);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(71, 36);
            fileToolStripMenuItem.Text = "File";
            // 
            // aboutMenuItem
            // 
            aboutMenuItem.Name = "aboutMenuItem";
            aboutMenuItem.Size = new Size(212, 44);
            aboutMenuItem.Text = "About";
            aboutMenuItem.Click += aboutMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addExtensionMenuItem, addInvalidDirMenuItem, addInvalidFileMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(74, 36);
            editToolStripMenuItem.Text = "Edit";
            // 
            // addExtensionMenuItem
            // 
            addExtensionMenuItem.Name = "addExtensionMenuItem";
            addExtensionMenuItem.Size = new Size(395, 44);
            addExtensionMenuItem.Text = "Validate New Extension";
            addExtensionMenuItem.Click += addExtensionMenuItem_Click;
            // 
            // addInvalidDirMenuItem
            // 
            addInvalidDirMenuItem.Name = "addInvalidDirMenuItem";
            addInvalidDirMenuItem.Size = new Size(395, 44);
            addInvalidDirMenuItem.Text = "Add Invalid Directory";
            addInvalidDirMenuItem.Click += addInvalidDirMenuItem_Click;
            // 
            // addInvalidFileMenuItem
            // 
            addInvalidFileMenuItem.Name = "addInvalidFileMenuItem";
            addInvalidFileMenuItem.Size = new Size(395, 44);
            addInvalidFileMenuItem.Text = "Add Invalid File";
            addInvalidFileMenuItem.Click += addInvalidFileMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { extCheckMenuItem, dirCheckMenuItem, subCheckMenuItem, delUnCheckMenuItem });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(127, 36);
            settingsToolStripMenuItem.Text = " Settings";
            // 
            // extCheckMenuItem
            // 
            extCheckMenuItem.Name = "extCheckMenuItem";
            extCheckMenuItem.Size = new Size(439, 44);
            extCheckMenuItem.Text = "Extension Validity Checking";
            extCheckMenuItem.Click += extCheckMenuItem_Click;
            // 
            // dirCheckMenuItem
            // 
            dirCheckMenuItem.Name = "dirCheckMenuItem";
            dirCheckMenuItem.Size = new Size(439, 44);
            dirCheckMenuItem.Text = "Directory Validity Checking";
            dirCheckMenuItem.Click += dirCheckMenuItem_Click;
            // 
            // subCheckMenuItem
            // 
            subCheckMenuItem.Name = "subCheckMenuItem";
            subCheckMenuItem.Size = new Size(439, 44);
            subCheckMenuItem.Text = "Run On Subdirectories";
            subCheckMenuItem.Click += subCheckMenuItem_Click;
            // 
            // delUnCheckMenuItem
            // 
            delUnCheckMenuItem.Name = "delUnCheckMenuItem";
            delUnCheckMenuItem.Size = new Size(439, 44);
            delUnCheckMenuItem.Text = "Delete Unchecked Items";
            delUnCheckMenuItem.Click += delUnCheckMenuItem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(23, 93);
            label1.Name = "label1";
            label1.Size = new Size(262, 32);
            label1.TabIndex = 1;
            label1.Text = "Enter file extension(s): ";
            // 
            // extTB
            // 
            extTB.Location = new Point(278, 90);
            extTB.Name = "extTB";
            extTB.Size = new Size(200, 39);
            extTB.TabIndex = 2;
            extTB.Enter += extTB_Enter;
            extTB.KeyPress += extTB_KeyPress;
            extTB.Leave += extTB_Leave;
            // 
            // runBT
            // 
            runBT.Location = new Point(1132, 699);
            runBT.Name = "runBT";
            runBT.Size = new Size(150, 46);
            runBT.TabIndex = 3;
            runBT.Text = "Run Now";
            runBT.UseVisualStyleBackColor = true;
            runBT.Click += runBT_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(633, 93);
            label2.Name = "label2";
            label2.Size = new Size(208, 32);
            label2.TabIndex = 4;
            label2.Text = "Enter directory(s):";
            // 
            // dirTB
            // 
            dirTB.Location = new Point(838, 90);
            dirTB.Name = "dirTB";
            dirTB.Size = new Size(444, 39);
            dirTB.TabIndex = 5;
            dirTB.Enter += dirTB_Enter;
            dirTB.KeyPress += dirTB_KeyPress;
            dirTB.Leave += dirTB_Leave;
            // 
            // extLB
            // 
            extLB.BackColor = SystemColors.Menu;
            extLB.BorderStyle = BorderStyle.None;
            extLB.CheckOnClick = true;
            extLB.FormattingEnabled = true;
            extLB.Location = new Point(33, 155);
            extLB.MinimumSize = new Size(445, 504);
            extLB.Name = "extLB";
            extLB.Size = new Size(445, 504);
            extLB.TabIndex = 6;
            extLB.ItemCheck += extLB_ItemCheck;
            // 
            // dirLB
            // 
            dirLB.BackColor = SystemColors.Menu;
            dirLB.BorderStyle = BorderStyle.None;
            dirLB.CheckOnClick = true;
            dirLB.FormattingEnabled = true;
            dirLB.Location = new Point(642, 155);
            dirLB.MinimumSize = new Size(640, 504);
            dirLB.Name = "dirLB";
            dirLB.Size = new Size(640, 504);
            dirLB.TabIndex = 7;
            dirLB.ItemCheck += dirLB_ItemCheck;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1355, 770);
            Controls.Add(dirLB);
            Controls.Add(extLB);
            Controls.Add(dirTB);
            Controls.Add(label2);
            Controls.Add(runBT);
            Controls.Add(extTB);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "MainForm";
            Text = "FDelete";
            FormClosing += FDelete_FormClosing;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void ExtTB_Leave(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DirTB_Leave(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }



        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private Label label1;
        private TextBox extTB;
        private Button runBT;
        private Label label2;
        private TextBox dirTB;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem extCheckMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem addExtensionMenuItem;
        private CheckedListBox extLB;
        private CheckedListBox dirLB;
        private ToolStripMenuItem addInvalidDirMenuItem;
        private ToolStripMenuItem dirCheckMenuItem;
        private ToolStripMenuItem addInvalidFileMenuItem;
        private ToolStripMenuItem subCheckMenuItem;
        private ToolStripMenuItem delUnCheckMenuItem;
        private ToolStripMenuItem aboutMenuItem;
    }
}
