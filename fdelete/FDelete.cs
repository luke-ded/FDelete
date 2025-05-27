using System.Reflection;
using System.Text;

namespace fdelete
{
    public partial class MainForm : Form
    {
        private Operations op;

        private string? resourcesPath;

        // Settings variables
        private Boolean extCheck, dirCheck, subCheck, delUnCheck;

        public MainForm()
        {
            InitializeComponent();

            // Create/recall resources folder
            resourcesPath = Path.Combine(Application.StartupPath, "Resources");

            if (!Directory.Exists(resourcesPath))
                InitSaveFolder();


            op = new Operations(resourcesPath);

            InitAll();
        }


        // Initialization //
        private void InitAll()
        {
            InitSettings();

            InitExtTB();
            InitDirTB();

            InitExtLB();
            InitDirLB();


            // Add application name to invalid file list
            string fileName = Path.GetFileName(System.Windows.Forms.Application.ExecutablePath);

            if (!op.GetInvalidFiles().Contains(fileName))
                op.InvalidFilesFileUpdate(fileName);
        }

        private void InitSaveFolder()
        {
            // Create Resources folder
            DirectoryInfo newFolder = new DirectoryInfo(Path.Combine(Application.StartupPath, "Resources"));

            newFolder.Create();
            newFolder.Attributes |= FileAttributes.Hidden;

            InitFile("allExtensions.txt", true);
            InitFile("dirLBData.txt", false);
            InitFile("extLBData.txt", false);
            InitFile("invalidDirData.txt", true);
            InitFile("invalidFileData.txt", false);
            InitFile("settingsData.txt", false);
        }

        private void InitFile(string fileName, Boolean init)
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                Stream? currentFile = assembly.GetManifestResourceStream("fdelete.Resources." + fileName);

                if (currentFile == null || resourcesPath == null)
                    throw new FileNotFoundException();


                StreamReader sr = new StreamReader(currentFile);
                StreamWriter sw = new StreamWriter(Path.Combine(resourcesPath, fileName));


                // No inital values needed
                if (!init)
                {
                    sw.WriteLine();
                    sr.Close();
                    sw.Close();

                    return;
                }


                // Populate inital values
                string? line = sr.ReadLine();

                while (line != null)
                {
                    sw.WriteLine(line);

                    line = sr.ReadLine();
                }

                sr.Close();
                sw.Close();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);

                MessageBox.Show("Could not initialize resource files. Application will likely experience " +
                    "significant issues", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void InitSettings()
        {
            string? filePath = null;
            Boolean valid;

            // Allow user checking
            extCheckMenuItem.CheckOnClick = true;
            dirCheckMenuItem.CheckOnClick = true;
            subCheckMenuItem.CheckOnClick = true;
            delUnCheckMenuItem.CheckOnClick = true;

            try
            {
                if (resourcesPath == null) throw new FileNotFoundException();

                filePath = Path.Combine(resourcesPath, "settingsData.txt");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Filepath = " + filePath);
                System.Diagnostics.Debug.WriteLine(e.Message);

                MessageBox.Show("Previous session data corrupt or missing.\n",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (File.Exists(filePath))
            {

                try
                {
                    StreamReader sr = new StreamReader(filePath);

                    string? temp = sr.ReadLine();

                    if (string.IsNullOrEmpty(temp))
                    {

                        SetDefaultSettings();

                        sr.Close();

                        return;
                    }

                    // Line 1
                    valid = bool.TryParse(temp, out extCheck);
                    extCheckMenuItem.Checked = extCheck;

                    // Line 2
                    valid &= bool.TryParse(sr.ReadLine(), out dirCheck);
                    dirCheckMenuItem.Checked = dirCheck;

                    // Line 3
                    valid &= bool.TryParse(sr.ReadLine(), out subCheck);
                    subCheckMenuItem.Checked = subCheck;

                    // Line 4
                    valid &= bool.TryParse(sr.ReadLine(), out delUnCheck);
                    delUnCheckMenuItem.Checked = delUnCheck;



                    if (!valid)
                    {
                        MessageBox.Show("Previous session settings corrupt. Default settings applied.\n",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        SetDefaultSettings();
                    }


                    sr.Close();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Filepath = " + filePath);
                    System.Diagnostics.Debug.WriteLine(e.Message);

                    MessageBox.Show("Previous session settings corrupt or missing.\n",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Previous session settings corrupt or missing.\n",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitExtTB()
        {
            extTB.Text = ".extension";
            extTB.ForeColor = Color.DarkGray;

            extTB.Select(extTB.Text.Length, 0);
        }

        private void InitDirTB()
        {
            dirTB.Text = "C:\\Users\\JohnSmith\\Documents\\Coding";
            dirTB.ForeColor = Color.DarkGray;

            dirTB.Select(dirTB.Text.Length, 0);
        }

        private void InitExtLB()
        {
            string? filePath = null;
            string[] line;


            try
            {
                if (resourcesPath == null) throw new FileNotFoundException();

                filePath = Path.Combine(resourcesPath, "extLBData.txt");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Filepath = " + filePath);
                System.Diagnostics.Debug.WriteLine(e.Message);

                MessageBox.Show("Previous session data corrupt or missing.\n",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }


            if (File.Exists(filePath))
            {
                StringBuilder result;

                try
                {
                    StreamReader sr = new StreamReader(filePath);

                    string? data = sr.ReadLine();

                    while (!string.IsNullOrEmpty(data))
                    {
                        result = new StringBuilder(data);
                        result.Remove(0, 2);

                        line = data.Split(" ");
                        if (!op.GetExtUsed().Contains(line[1]) && op.ValidExt(line[1], extCheck))
                        {
                            if (delUnCheck && line[0] == "f")
                            {
                                data = sr.ReadLine();

                                continue;
                            }

                            op.GetExtUsed().Add(result.ToString());
                            extLB.Items.Add(result.ToString());

                            if (line[0] == "t")
                                extLB.SetItemChecked(extLB.Items.Count - 1, true);
                            else
                                extLB.SetItemChecked(extLB.Items.Count - 1, false);
                        }

                        data = sr.ReadLine();
                    }

                    sr.Close();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Filepath = " + filePath);
                    System.Diagnostics.Debug.WriteLine(e.Message);

                    MessageBox.Show("Previous session data corrupt or missing.\n",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Previous session data corrupt or missing.\n",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitDirLB()
        {
            string? filePath = null;
            string[] line;


            try
            {
                if (resourcesPath == null) throw new FileNotFoundException();

                filePath = Path.Combine(resourcesPath, "dirLBData.txt");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Filepath = " + filePath);
                System.Diagnostics.Debug.WriteLine(e.Message);

                MessageBox.Show("Previous session data corrupt or missing.\n",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }


            if (File.Exists(filePath))
            {
                StringBuilder result;

                try
                {
                    StreamReader sr = new StreamReader(filePath);

                    string? data = sr.ReadLine();

                    while (!string.IsNullOrEmpty(data))
                    {
                        result = new StringBuilder(data);
                        result.Remove(0, 2);

                        line = data.Split(" ");
                        if (!op.GetDirsUsed().Contains(line[1]) && op.ValidDir(line[1], dirCheck))
                        {
                            if (delUnCheck && line[0] == "f")
                            {
                                data = sr.ReadLine();

                                continue;
                            }

                            op.GetDirsUsed().Add(result.ToString());
                            dirLB.Items.Add(result.ToString());

                            if (line[0] == "t")
                                dirLB.SetItemChecked(dirLB.Items.Count - 1, true);
                            else
                                dirLB.SetItemChecked(dirLB.Items.Count - 1, false);
                        }

                        data = sr.ReadLine();
                    }

                    sr.Close();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Filepath = " + filePath);
                    System.Diagnostics.Debug.WriteLine(e.Message);

                    MessageBox.Show("Previous session data corrupt or missing.\n",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Previous session data corrupt or missing.\n",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Operating //

        private void runBT_Click(object sender, EventArgs e)
        {
            int numFiles;
      
            if ((numFiles = op.DeleteExt(extLB, dirLB, subCheck)) > -1)
                MessageBox.Show("Successfully removed " + numFiles +" file(s).", "Complete", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void extTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            extTB.ForeColor = Color.Black;

            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!op.GetExtUsed().Contains(extTB.Text) && op.ValidExt(extTB.Text, extCheck))
                {
                    op.GetExtUsed().Add(extTB.Text);
                    extLB.Items.Add(extTB.Text);
                    extLB.SetItemChecked(extLB.Items.Count - 1, true);

                    extTB.ForeColor = Color.DarkGray;
                    extTB.Text = string.Empty;
                }
            }
            else
                return;


            e.Handled = true;
        }

        private void extTB_Enter(object sender, EventArgs e)
        {
            extTB.Text = string.Empty;
        }

        private void extTB_Leave(object sender, EventArgs e)
        {
            InitExtTB();
        }

        private void extLB_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string? ext = extLB.Items[e.Index].ToString();

            if (ext == null) return;

            if (e.NewValue == CheckState.Checked)
            {
                op.GetExtUsed().Add(ext);
            }
            else
                op.GetExtUsed().Remove(ext);
        }


        private void dirTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            dirTB.ForeColor = Color.Black;

            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!op.GetDirsUsed().Contains(dirTB.Text) && op.ValidDir(dirTB.Text, dirCheck))
                {
                    op.GetDirsUsed().Add(dirTB.Text);
                    dirLB.Items.Add(dirTB.Text);
                    dirLB.SetItemChecked(dirLB.Items.Count - 1, true);

                    dirTB.ForeColor = Color.DarkGray;
                    dirTB.Text = string.Empty;
                }

            }
            else
                return;

            e.Handled = true;
        }

        private void dirTB_Enter(object sender, EventArgs e)
        {
            dirTB.Text = string.Empty;
        }

        private void dirTB_Leave(object sender, EventArgs e)
        {
            InitDirTB();
        }

        private void dirLB_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string? dir = dirLB.Items[e.Index].ToString();

            if (dir == null) return;

            if (e.NewValue == CheckState.Checked)
            {
                op.GetDirsUsed().Add(dir);
            }
            else
                op.GetDirsUsed().Remove(dir);
        }


        // Edit Functions //

        private void addExtensionMenuItem_Click(object sender, EventArgs e)
        {
            AddValidExt InputBox = new AddValidExt();


            if (InputBox.ShowDialog() == DialogResult.OK)
            {
                string? ext = InputBox.GetInput();

                if (ext == null)
                {
                    MessageBox.Show("Could not add extension.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                op.GetExtensions().Add(ext);

                op.ExtFileUpdate(ext);

                System.Diagnostics.Debug.WriteLine("Added: " + ext);
            }
        }

        private void addInvalidDirMenuItem_Click(object sender, EventArgs e)
        {
            AddInvalidDir InputBox = new AddInvalidDir();


            if (InputBox.ShowDialog() == DialogResult.OK)
            {
                string? dir = InputBox.GetInput();

                if (dir == null)
                {
                    MessageBox.Show("Could not add directory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                if (!op.GetInvalidDirs().Contains(dir))
                {
                    op.GetInvalidDirs().Add(dir);

                    op.InvalidDirsFileUpdate(dir);
                }

                System.Diagnostics.Debug.WriteLine("Added: " + dir);
            }
        }

        private void addInvalidFileMenuItem_Click(object sender, EventArgs e)
        {
            AddInvalidFile inputBox = new AddInvalidFile();


            if (inputBox.ShowDialog() == DialogResult.OK)
            {
                string? file = inputBox.GetInput();

                if (file == null)
                {
                    MessageBox.Show("Could not add file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                if (!op.GetInvalidFiles().Contains(file))
                {
                    op.GetInvalidFiles().Add(file);

                    op.InvalidFilesFileUpdate(file);
                }


                System.Diagnostics.Debug.WriteLine("Added: " + file);
            }
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            About aboutBox = new About();

            aboutBox.Show();
        }


        // Settings //

        private void SetDefaultSettings()
        {
            // Line 0
            extCheck = true;
            extCheckMenuItem.Checked = true;

            // Line 1
            dirCheck = true;
            dirCheckMenuItem.Checked = true;

            // Line 2
            subCheck = true;
            subCheckMenuItem.Checked = true;

            // Line 4
            delUnCheck = true;
            delUnCheckMenuItem.Checked = true;
        }

        private void extCheckMenuItem_Click(object sender, EventArgs e)
        {
            if (extCheck)
                extCheck = false;
            else
                extCheck = true;

            System.Diagnostics.Debug.WriteLine("extCheck = " + extCheck);
        }

        private void dirCheckMenuItem_Click(object sender, EventArgs e)
        {
            if (dirCheck)
                dirCheck = false;
            else
                dirCheck = true;

            System.Diagnostics.Debug.WriteLine("dirCheck = " + dirCheck);
        }

        private void subCheckMenuItem_Click(object sender, EventArgs e)
        {
            if (subCheck)
                subCheck = false;
            else
                subCheck = true;

            System.Diagnostics.Debug.WriteLine("subCheck = " + subCheck);
        }

        private void delUnCheckMenuItem_Click(object sender, EventArgs e)
        {
            if (delUnCheck)
                delUnCheck = false;
            else
                delUnCheck = true;

            System.Diagnostics.Debug.WriteLine("delUnCheck = " + delUnCheck);
        }


        // Save data to files
        private void FDelete_FormClosing(object sender, EventArgs e)
        {
            string? filePath = null;

            try
            {
                if (resourcesPath == null) throw new FileNotFoundException();

                filePath = Path.Combine(resourcesPath, "settingsData.txt");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Filepath = " + filePath);
                System.Diagnostics.Debug.WriteLine(ex.Message);

                return;
            }

            if (File.Exists(filePath))
            {

                try
                {
                    StreamWriter sw = new StreamWriter(filePath, append: false);

                    sw.WriteLine(extCheck);
                    sw.WriteLine(dirCheck);
                    sw.WriteLine(subCheck);
                    sw.WriteLine(delUnCheck);

                    sw.Close();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Filepath = " + filePath);
                    System.Diagnostics.Debug.WriteLine(ex.Message);

                    MessageBox.Show("Could not save settings.\n",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("File does not exist at filepath = " + filePath);

                return;
            }


            try
            {
                if (resourcesPath == null) throw new FileNotFoundException();

                filePath = Path.Combine(resourcesPath, "extLBData.txt");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Could not update file due to: " + ex.Message);

                return;
            }

            if (File.Exists(filePath))
            {
                try
                {
                    StreamWriter sw = new StreamWriter(filePath, append: false);

                    if (extLB.Items.Count == 0)
                    {
                        sw.WriteLine();
                        sw.Close();
                    }
                    for (int i = 0; i < extLB.Items.Count; i++)
                    {
                        if (extLB.GetItemChecked(i))
                            sw.Write("t ");
                        else
                            sw.Write("f ");

                        sw.WriteLine(extLB.Items[i].ToString());
                    }

                    sw.Close();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Could not update file at filepath = " + filePath);
                    System.Diagnostics.Debug.WriteLine(ex.Message);

                    return;
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("File does not exist at filepath = " + filePath);

                return;
            }


            try
            {
                if (resourcesPath == null) throw new FileNotFoundException();

                filePath = Path.Combine(resourcesPath, "dirLBData.txt");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Could not update file due to: " + ex.Message);

                return;
            }

            if (File.Exists(filePath))
            {
                try
                {
                    StreamWriter sw = new StreamWriter(filePath, append: false);

                    if (dirLB.Items.Count == 0)
                    {
                        sw.WriteLine();
                        sw.Close();
                    }
                    for (int i = 0; i < dirLB.Items.Count; i++)
                    {
                        if (dirLB.GetItemChecked(i))
                            sw.Write("t ");
                        else
                            sw.Write("f ");

                        sw.WriteLine(dirLB.Items[i].ToString());
                    }

                    sw.Close();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Could not update file at filepath = " + filePath);
                    System.Diagnostics.Debug.WriteLine(ex.Message);

                    return;
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("File does not exist at filepath = " + filePath);

                return;
            }
        }
    }


    public partial class Operations
    {
        private HashSet<string> extensions;
        private HashSet<string> invalidDirs;
        private HashSet<string> invalidFiles;

        private HashSet<string> extUsed;
        private HashSet<string> dirsUsed;

        private string? resourcesPath;

        private int numFiles;

        public Operations(string? resourcesPath)
        {
            extensions = new HashSet<string>();
            invalidDirs = new HashSet<string>();
            invalidFiles = new HashSet<string>();

            extUsed = new HashSet<string>();
            dirsUsed = new HashSet<string>();

            this.resourcesPath = resourcesPath;

            InitArray();
        }


        // Operation Functions //
        public int DeleteExt(CheckedListBox extLB, CheckedListBox dirLB, Boolean checkSubs)
        {
            numFiles = 0;

            for (int j = 0; j < dirLB.CheckedItems.Count; j++)
            {
                string? item = dirLB.CheckedItems[j]?.ToString();

                if (item == null) return -1;

                if (checkSubs)
                    runDirWrap(extLB, item);
                else
                    runDir(extLB, item);

            }

            return numFiles;
        }

        private void runDirWrap(CheckedListBox extLB, string dir)
        {
            string[] dirs = Directory.GetDirectories(dir);

            foreach (string d in dirs)
                runDirWrap(extLB, d);

            runDir(extLB, dir);
        }

        private void runDir(CheckedListBox extLB, string dir)
        {
            if(dir == resourcesPath) return;

            string[] files = Directory.GetFiles(dir);

            foreach (string file in files)
            {
                if (extUsed.Contains(Path.GetExtension(file)) && !invalidFiles.Contains(file) && extLB.CheckedItems.Contains(Path.GetExtension(file)))
                {
                    System.Diagnostics.Debug.WriteLine($"file = " + Path.GetFileName(file));
                    File.Delete(file);

                    numFiles++;
                }
            }
        }

        public Boolean ValidExt(string ext, Boolean validityCheck)
        {
            System.Diagnostics.Debug.WriteLine(ext);
            if ((validityCheck) && (ext == null || ext == "\0" || !extensions.Contains(ext)))
            {

                MessageBox.Show("You must enter a valid file extension. To avoid this message, " +
                    "disable validity checking in \"settings\" or add a new extension under \"edit\".",
                    "Error: Invalid File extension", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return true;
        }

        public Boolean ValidDir(string dir, Boolean validityCheck)
        {
            if ((validityCheck) && (dir == null || dir == "\0" || invalidDirs.Contains(dir) || !Directory.Exists(dir)))
            {
                MessageBox.Show("You must enter a valid directory. To avoid this message, " +
                   "disable validity checking in \"settings\".",
                   "Error: Invalid Directory", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return true;
        }


        // File Handling //

        private void InitArray()
        {
            string? filePath = null;

            try
            {
                if (resourcesPath == null) throw new FileNotFoundException();

                filePath = Path.Combine(resourcesPath, "allExtensions.txt");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Filepath = " + filePath);
                System.Diagnostics.Debug.WriteLine(e.Message);

                MessageBox.Show("Extension validation failure.\n" +
                    "disable validity checking in \"settings\" and continue running the program " +
                    "with no validation at your own risk.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }


            if (File.Exists(filePath))
            {
                try
                {
                    StreamReader sr = new StreamReader(filePath);

                    string? line = sr.ReadLine();

                    while (line != null)
                    {
                        extensions.Add(line);

                        line = sr.ReadLine();
                    }

                    sr.Close();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Filepath = " + filePath);
                    System.Diagnostics.Debug.WriteLine(e.Message);

                    MessageBox.Show("Extension validation failure.\n" +
                        "disable validity checking in \"settings\" and continue running the program " +
                        "with no validation at your own risk.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Extension validation file \"allExtensions.txt\" not found.\n" +
                    "disable validity checking in \"settings\" and continue running the program " +
                    "with no validation at your own risk.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            try
            {
                if (resourcesPath == null) throw new FileNotFoundException();

                filePath = Path.Combine(resourcesPath, "invalidDirData.txt");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Filepath = " + filePath);
                System.Diagnostics.Debug.WriteLine(e.Message);
                MessageBox.Show("Could not retrieve invalid directory list. Continue running the program " +
                    "with no validation at your own risk. (This is safe, just make sure you don't enter an" +
                    " essential windows directory",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }


            if (File.Exists(filePath))
            {
                try
                {
                    StreamReader sr = new StreamReader(filePath);

                    string? line = sr.ReadLine();

                    while (line != null)
                    {
                        invalidDirs.Add(line);

                        line = sr.ReadLine();
                    }

                    sr.Close();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Filepath = " + filePath);
                    System.Diagnostics.Debug.WriteLine(e.Message);

                    MessageBox.Show("Could not retrieve invalid directory list. Continue running the program " +
                    "with no validation at your own risk. (This is safe, just make sure you don't enter an" +
                    " essential windows directory",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Could not retrieve invalid directory list. Continue running the program " +
                    "with no validation at your own risk. (This is safe, just make sure you don't enter an" +
                    " essential windows directory",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                if (resourcesPath == null) throw new FileNotFoundException();

                filePath = Path.Combine(resourcesPath, "invalidFileData.txt");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Filepath = " + filePath);
                System.Diagnostics.Debug.WriteLine(e.Message);
                MessageBox.Show("Could not retrieve invalid file list. Continue running the program " +
                    "with no file validation at your own risk.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }


            if (File.Exists(filePath))
            {
                try
                {
                    StreamReader sr = new StreamReader(filePath);

                    string? line = sr.ReadLine();

                    while (line != null)
                    {
                        invalidFiles.Add(line);

                        line = sr.ReadLine();
                    }

                    sr.Close();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Filepath = " + filePath);
                    System.Diagnostics.Debug.WriteLine(e.Message);

                    MessageBox.Show("Could not retrieve invalid file list. Continue running the program " +
                    "with no file validation at your own risk.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Could not retrieve invalid file list. Continue running the program " +
                    "with no file validation at your own risk.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExtFileUpdate(string ext)
        {
            string? filePath = null;

            try
            {
                if (resourcesPath == null) throw new FileNotFoundException();

                filePath = Path.Combine(resourcesPath, "allExtensions.txt");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Could not update file due to: " + e.Message);

                return;
            }

            if (File.Exists(filePath))
            {
                try
                {
                    StreamWriter sw = new StreamWriter(filePath, append: true);

                    sw.WriteLine(ext);

                    sw.Close();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Could not update file at filepath = " + filePath);
                    System.Diagnostics.Debug.WriteLine(e.Message);

                    return;
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("File does not exist at filepath = " + filePath);

                return;
            }
        }

        public void InvalidDirsFileUpdate(string dir)
        {
            string? filePath = null;

            try
            {
                if (resourcesPath == null) throw new FileNotFoundException();

                filePath = Path.Combine(resourcesPath, "invalidDirData.txt");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Could not update file due to: " + e.Message);

                return;
            }

            if (File.Exists(filePath))
            {
                try
                {
                    StreamWriter sw = new StreamWriter(filePath, append: true);

                    sw.WriteLine(dir);

                    sw.Close();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Could not update file at filepath = " + filePath);
                    System.Diagnostics.Debug.WriteLine(e.Message);

                    return;
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("File does not exist at filepath = " + filePath);

                return;
            }
        }

        public void InvalidFilesFileUpdate(string file)
        {
            string? filePath = null;

            try
            {
                if (resourcesPath == null) throw new FileNotFoundException();

                filePath = Path.Combine(resourcesPath, "invalidFileData.txt");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Could not update file due to: " + e.Message);

                return;
            }

            if (File.Exists(filePath))
            {
                try
                {
                    StreamWriter sw = new StreamWriter(filePath, append: true);

                    sw.WriteLine(file);

                    sw.Close();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Could not update file at filepath = " + filePath);
                    System.Diagnostics.Debug.WriteLine(e.Message);

                    return;
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("File does not exist at filepath = " + filePath);

                return;
            }
        }


        // Getters //

        public HashSet<string> GetExtensions()
        {
            return extensions;
        }

        public HashSet<string> GetInvalidDirs()
        {
            return invalidDirs;
        }

        public HashSet<string> GetInvalidFiles()
        {
            return invalidFiles;
        }

        public HashSet<string> GetExtUsed()
        {
            return extUsed;
        }

        public HashSet<string> GetDirsUsed()
        {
            return dirsUsed;
        }
    }
}