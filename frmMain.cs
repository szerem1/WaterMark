using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using System.Data;
using System.IO;
using Microsoft.Win32;

namespace WaterMark
{
    /// <summary>
    /// Summary description for frmMain.
    /// </summary>
    public class frmMain : System.Windows.Forms.Form
    {
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox lstFileList;
        private System.Windows.Forms.TextBox txtWorkingFolder;
        private System.Windows.Forms.ComboBox cmbImageType;
        private System.Windows.Forms.PictureBox picSource;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button cmdBrowse1;
        private System.Windows.Forms.Button cmdMake;
        private System.Windows.Forms.CheckBox chkPreview;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button cmdBrowse3;
        private System.Windows.Forms.TextBox txtOutputFolder;
        private System.Windows.Forms.CheckBox chkSameOutputFolder;
        private System.Windows.Forms.TextBox txtSuffix;
        private System.Windows.Forms.Label lblSuffix2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        //private const string RegKey = @"Software\Szerem Tech\Mark My Image";
        private string regInputFolder, regOutputFolder, regWaterMarkImage;
        private WMProperties pt;
        private Label lblSuffix1;
        private Button button9;
        private Button button8;
        private Button button7;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public frmMain()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstFileList = new System.Windows.Forms.CheckedListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbImageType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdBrowse1 = new System.Windows.Forms.Button();
            this.txtWorkingFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkPreview = new System.Windows.Forms.CheckBox();
            this.picSource = new System.Windows.Forms.PictureBox();
            this.cmdMake = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.cmdBrowse3 = new System.Windows.Forms.Button();
            this.txtOutputFolder = new System.Windows.Forms.TextBox();
            this.chkSameOutputFolder = new System.Windows.Forms.CheckBox();
            this.txtSuffix = new System.Windows.Forms.TextBox();
            this.lblSuffix2 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblSuffix1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSource)).BeginInit();
            this.SuspendLayout();
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 464);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(792, 18);
            this.statusBar1.TabIndex = 0;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Text = "Ready";
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Width = 675;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstFileList);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.cmbImageType);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmdBrowse1);
            this.groupBox1.Controls.Add(this.txtWorkingFolder);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkPreview);
            this.groupBox1.Location = new System.Drawing.Point(4, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 458);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // lstFileList
            // 
            this.lstFileList.Location = new System.Drawing.Point(8, 76);
            this.lstFileList.Name = "lstFileList";
            this.lstFileList.Size = new System.Drawing.Size(396, 169);
            this.lstFileList.TabIndex = 4;
            this.lstFileList.SelectedIndexChanged += new System.EventHandler(this.lstFileList_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button9);
            this.groupBox2.Controls.Add(this.button8);
            this.groupBox2.Controls.Add(this.button7);
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(6, 252);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 200);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Znak wodny";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(269, 131);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(125, 50);
            this.button9.TabIndex = 8;
            this.button9.Text = "9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(138, 131);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(125, 50);
            this.button8.TabIndex = 7;
            this.button8.Text = "8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(7, 131);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(125, 50);
            this.button7.TabIndex = 6;
            this.button7.Text = "7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(269, 73);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(125, 50);
            this.button6.TabIndex = 5;
            this.button6.Text = "6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(138, 73);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(125, 50);
            this.button5.TabIndex = 4;
            this.button5.Text = "5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(7, 73);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(125, 50);
            this.button4.TabIndex = 3;
            this.button4.Text = "4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(269, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(125, 50);
            this.button3.TabIndex = 2;
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(138, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 50);
            this.button2.TabIndex = 1;
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbImageType
            // 
            this.cmbImageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbImageType.Items.AddRange(new object[] {
            "Wszystkie",
            "JPEG Images (*.JPG, *.JPEG, *.PNG)",
            "Windows Bitmap Images (*.bmp)"});
            this.cmbImageType.Location = new System.Drawing.Point(104, 46);
            this.cmbImageType.Name = "cmbImageType";
            this.cmbImageType.Size = new System.Drawing.Size(176, 21);
            this.cmbImageType.TabIndex = 2;
            this.cmbImageType.SelectedIndexChanged += new System.EventHandler(this.cmbImageType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(10, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "Typ ";
            // 
            // cmdBrowse1
            // 
            this.cmdBrowse1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdBrowse1.Location = new System.Drawing.Point(382, 20);
            this.cmdBrowse1.Name = "cmdBrowse1";
            this.cmdBrowse1.Size = new System.Drawing.Size(22, 20);
            this.cmdBrowse1.TabIndex = 1;
            this.cmdBrowse1.Text = "...";
            this.cmdBrowse1.Click += new System.EventHandler(this.cmdBrowse1_Click);
            // 
            // txtWorkingFolder
            // 
            this.txtWorkingFolder.Location = new System.Drawing.Point(104, 20);
            this.txtWorkingFolder.Name = "txtWorkingFolder";
            this.txtWorkingFolder.Size = new System.Drawing.Size(274, 20);
            this.txtWorkingFolder.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Katalog";
            // 
            // chkPreview
            // 
            this.chkPreview.Checked = true;
            this.chkPreview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPreview.Location = new System.Drawing.Point(284, 48);
            this.chkPreview.Name = "chkPreview";
            this.chkPreview.Size = new System.Drawing.Size(120, 20);
            this.chkPreview.TabIndex = 3;
            this.chkPreview.Text = "&Podgl¹d";
            this.chkPreview.CheckedChanged += new System.EventHandler(this.chkPreview_CheckedChanged);
            // 
            // picSource
            // 
            this.picSource.Location = new System.Drawing.Point(418, 6);
            this.picSource.Name = "picSource";
            this.picSource.Size = new System.Drawing.Size(370, 228);
            this.picSource.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSource.TabIndex = 2;
            this.picSource.TabStop = false;
            // 
            // cmdMake
            // 
            this.cmdMake.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdMake.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMake.Location = new System.Drawing.Point(416, 353);
            this.cmdMake.Name = "cmdMake";
            this.cmdMake.Size = new System.Drawing.Size(370, 32);
            this.cmdMake.TabIndex = 12;
            this.cmdMake.Text = "START";
            this.cmdMake.Click += new System.EventHandler(this.cmdMake_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(416, 238);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(372, 22);
            this.progressBar1.TabIndex = 14;
            // 
            // cmdBrowse3
            // 
            this.cmdBrowse3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdBrowse3.Location = new System.Drawing.Point(766, 313);
            this.cmdBrowse3.Name = "cmdBrowse3";
            this.cmdBrowse3.Size = new System.Drawing.Size(22, 20);
            this.cmdBrowse3.TabIndex = 11;
            this.cmdBrowse3.Text = "...";
            this.cmdBrowse3.Click += new System.EventHandler(this.cmdBrowse3_Click);
            // 
            // txtOutputFolder
            // 
            this.txtOutputFolder.Location = new System.Drawing.Point(418, 313);
            this.txtOutputFolder.Name = "txtOutputFolder";
            this.txtOutputFolder.Size = new System.Drawing.Size(342, 20);
            this.txtOutputFolder.TabIndex = 10;
            // 
            // chkSameOutputFolder
            // 
            this.chkSameOutputFolder.BackColor = System.Drawing.SystemColors.Control;
            this.chkSameOutputFolder.Checked = true;
            this.chkSameOutputFolder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSameOutputFolder.Location = new System.Drawing.Point(420, 270);
            this.chkSameOutputFolder.Name = "chkSameOutputFolder";
            this.chkSameOutputFolder.Size = new System.Drawing.Size(366, 17);
            this.chkSameOutputFolder.TabIndex = 9;
            this.chkSameOutputFolder.Text = "Katalog wyjœciowy taki sam jak wejsciowy ";
            this.chkSameOutputFolder.UseVisualStyleBackColor = false;
            this.chkSameOutputFolder.CheckedChanged += new System.EventHandler(this.chkSameOutputFolder_CheckedChanged);
            // 
            // txtSuffix
            // 
            this.txtSuffix.Location = new System.Drawing.Point(489, 287);
            this.txtSuffix.MaxLength = 15;
            this.txtSuffix.Name = "txtSuffix";
            this.txtSuffix.Size = new System.Drawing.Size(54, 20);
            this.txtSuffix.TabIndex = 19;
            this.txtSuffix.Text = "_final";
            // 
            // lblSuffix2
            // 
            this.lblSuffix2.Location = new System.Drawing.Point(549, 290);
            this.lblSuffix2.Name = "lblSuffix2";
            this.lblSuffix2.Size = new System.Drawing.Size(82, 16);
            this.lblSuffix2.TabIndex = 20;
            this.lblSuffix2.Text = "po nazwie pliku";
            // 
            // lblSuffix1
            // 
            this.lblSuffix1.Location = new System.Drawing.Point(417, 290);
            this.lblSuffix1.Name = "lblSuffix1";
            this.lblSuffix1.Size = new System.Drawing.Size(66, 16);
            this.lblSuffix1.TabIndex = 22;
            this.lblSuffix1.Text = "dodaj suffix";
            // 
            // frmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 482);
            this.Controls.Add(this.lblSuffix1);
            this.Controls.Add(this.lblSuffix2);
            this.Controls.Add(this.txtSuffix);
            this.Controls.Add(this.chkSameOutputFolder);
            this.Controls.Add(this.txtOutputFolder);
            this.Controls.Add(this.cmdBrowse3);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.picSource);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.cmdMake);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Watermar My Image v1.0";
            this.Closed += new System.EventHandler(this.frmMain_Closed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new frmMain());
        }


        private WMButtons _buttons = null;
        private string _filesName = "Wszystkie pliki |*png;*.jpg;*.bmp|JPEG(*.JPEG,*JPG,*PNG)|*.jpg;*.jpeg|Bitmap Files(*.BMP)|*.bmp|All Files|*.*";


        private void frmMain_Load(object sender, System.EventArgs e)
        {
            _buttons = new WMButtons();

            cmbImageType.SelectedIndex = 0;
            txtOutputFolder.Text = regOutputFolder;
            txtOutputFolder.Enabled = false;
            cmdBrowse3.Enabled = false;

            setWMButtons();
            GetFiles();

            if (chkPreview.Checked == true && lstFileList.Items.Count > 0)
            {
                lstFileList.SelectedIndex = 0;
                if (File.Exists(lstFileList.Items[0].ToString()))
                    picSource.Image = Image.FromFile(lstFileList.Items[0].ToString());
            }

        }

        private void GetFiles()
        {
            List<string> files = new List<string>();

            try
            {
                switch (cmbImageType.SelectedIndex)
                {
                    case 0:
                        files.AddRange(GetFiles(txtWorkingFolder.Text, "*.jpg"));
                        files.AddRange(GetFiles(txtWorkingFolder.Text, "*.jpeg"));
                        files.AddRange(GetFiles(txtWorkingFolder.Text, "*.bmp"));
                        files.AddRange(GetFiles(txtWorkingFolder.Text, "*.png"));
                        break;
                    case 1:
                        files.AddRange(GetFiles(txtWorkingFolder.Text, "*.jpg"));
                        files.AddRange(GetFiles(txtWorkingFolder.Text, "*.jpeg"));
                        files.AddRange(GetFiles(txtWorkingFolder.Text, "*.png"));
                        break;
                    case 2:
                        files.AddRange(GetFiles(txtWorkingFolder.Text, "*.bmp"));
                        break;

                }

                progressBar1.Maximum = files.Count;
                lstFileList.Items.Clear();

                foreach (string fileName in files)
                {
                    if (fileName != null)
                        lstFileList.Items.Add(fileName.Replace(AppDomain.CurrentDomain.BaseDirectory, @".\"), CheckState.Checked);
                }

                statusBarPanel2.Text = lstFileList.Items.Count + " File(s)";

                txtWorkingFolder.Text = AppConfig.IN;
            }
            catch { }

        }

        private List<string> GetFiles(string pathDirectory, string extension)
        {
            List<string> result = new List<string>();
            if (!String.IsNullOrEmpty(txtWorkingFolder.Text)
                && Directory.Exists(txtWorkingFolder.Text))
                result.AddRange(Directory.GetFiles(txtWorkingFolder.Text, extension));
            return result;
        }

        private void cmdBrowse1_Click(object sender, System.EventArgs e)
        {
            txtWorkingFolder.Text = AppConfig.IN;
            string oldWorkingFolder;
            try
            {

                if (txtWorkingFolder.Text.Substring(0, 1) == ".")
                    oldWorkingFolder = txtWorkingFolder.Text.Replace(".", AppDomain.CurrentDomain.BaseDirectory.Substring(0, AppDomain.CurrentDomain.BaseDirectory.Length - 1));
                else
                    oldWorkingFolder = txtWorkingFolder.Text;

                folderBrowserDialog1.SelectedPath = oldWorkingFolder;
                //folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.Personal;
            }
            catch { }
            try
            {
                folderBrowserDialog1.ShowNewFolderButton = false;
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    txtWorkingFolder.Text = folderBrowserDialog1.SelectedPath;
                    if (chkSameOutputFolder.Checked == true)
                    {
                        txtOutputFolder.Text = txtWorkingFolder.Text;
                    }
                    AppConfig.IN = txtWorkingFolder.Text;
                GetFiles();
                }
            }
            catch { }
        }


        private void lstFileList_SelectedIndexChanged(object sender, System.EventArgs e)
        {

            string filename = lstFileList.SelectedItem.ToString();
            if (chkPreview.Checked == true)
            {
                picSource.Image = new WaterMark(filename).GetImage(_buttons.getWotermarks());
            }
        }

        private void cmdMake_Click(object sender, System.EventArgs e)
        {

            if (chkSameOutputFolder.Checked == false && txtWorkingFolder.Text.Equals(txtOutputFolder.Text))
            {
                MessageBox.Show("Output folder can not be same as input folder", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                this.Cursor = Cursors.WaitCursor;
                statusBarPanel1.Text = "Busy";
                Application.DoEvents();
                WaterMark wm;
                string srcPic, dstPic;


                for (int i = 0; i < lstFileList.CheckedItems.Count; i++)
                {
                    //srcPic = txtWorkingFolder.Text + lstFileList.Items[i].ToString().Substring(1);
                    srcPic = txtWorkingFolder.Text + lstFileList.Items[i].ToString().Substring(lstFileList.Items[i].ToString().LastIndexOf("\\"));
                    if (chkSameOutputFolder.Checked == true)
                        dstPic = srcPic.Insert(srcPic.LastIndexOf("."), txtSuffix.Text);
                    else
                        dstPic = txtOutputFolder.Text + "\\" + srcPic.Substring(srcPic.LastIndexOf("\\") + 1);

                    new WaterMark(srcPic).SaveImage(_buttons.getWotermarks(), dstPic);
                    //wm.MarkImage(srcPic, dstPic);
                    progressBar1.Increment(1);
                    statusBarPanel2.Text = "Proecessing Image " + srcPic.Substring(lstFileList.Items[i].ToString().LastIndexOf("\\") + 1);
                    Application.DoEvents();
                }
                progressBar1.Value = 0;
                statusBarPanel1.Text = "Ready";
                statusBarPanel2.Text = "";
                this.Cursor = Cursors.Default;
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                progressBar1.Value = 0;
                statusBarPanel1.Text = "Ready";
                statusBarPanel2.Text = ex.Message;
                this.Cursor = Cursors.Default;
                Application.DoEvents();
            }

        }

        private void chkSameOutputFolder_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkSameOutputFolder.Checked == true)
            {
                chkSameOutputFolder.Text = "Katalog wyjœciowy taki sam jak wejsciowy";
                chkSameOutputFolder.Width = 306;
                chkSameOutputFolder.SendToBack();

                txtOutputFolder.Text = txtWorkingFolder.Text;
                txtOutputFolder.Enabled = false;
                cmdBrowse3.Enabled = false;
                txtSuffix.Visible = true;
                lblSuffix1.Visible = true;
                lblSuffix2.Visible = true;
            }
            else
            {
                chkSameOutputFolder.Text = "U¿yj katalogu wyjœciowego i zachowaj tê sam¹ nazwê pliku(ów)";
                chkSameOutputFolder.Width = cmdMake.Width;
                chkSameOutputFolder.BringToFront();

                txtOutputFolder.Text = regOutputFolder;
                txtOutputFolder.Enabled = true;
                cmdBrowse3.Enabled = true;
                txtSuffix.Visible = false;
                lblSuffix1.Visible = false;
                lblSuffix2.Visible = false;
            }
        }





        private void chkPreview_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (chkPreview.Checked == false)
                    picSource.Image = null;
                else
                    picSource.Image = Image.FromFile(txtWorkingFolder.Text + lstFileList.SelectedItem.ToString().Substring(1));
            }
            catch { }
        }

        private void cmbImageType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            GetFiles();
        }

        private void cmdBrowse3_Click(object sender, System.EventArgs e)
        {
            string oldInputFolder;
            try
            {
                if (txtOutputFolder.Text.Substring(0, 1) == ".")
                    oldInputFolder = txtOutputFolder.Text.Replace(".", AppDomain.CurrentDomain.BaseDirectory.Substring(0, AppDomain.CurrentDomain.BaseDirectory.Length - 1));
                else
                    oldInputFolder = txtOutputFolder.Text;
                folderBrowserDialog1.SelectedPath = oldInputFolder;
                //folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.Personal;
            }
            catch { }
            try
            {
                folderBrowserDialog1.ShowNewFolderButton = true;
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (txtWorkingFolder.Text == folderBrowserDialog1.SelectedPath)
                        MessageBox.Show("Input and output folder can not be same", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                        txtOutputFolder.Text = folderBrowserDialog1.SelectedPath;
                }
                folderBrowserDialog1.ShowNewFolderButton = false;
            }
            catch { }
        }



        private void frmMain_Closed(object sender, System.EventArgs e)
        {

        }



        private void setWMButtons()
        {
            setWMButton(this.button1, _buttons.TopLeft_1);
            setWMButton(this.button2, _buttons.TopCenter_2);
            setWMButton(this.button3, _buttons.TopRight_3);
            setWMButton(this.button4, _buttons.MiddleLeft_4);
            setWMButton(this.button5, _buttons.MiddleCenter_5);
            setWMButton(this.button6, _buttons.MiddleRight_6);
            setWMButton(this.button7, _buttons.BottomLeft_7);
            setWMButton(this.button8, _buttons.BottomCenter_8);
            setWMButton(this.button9, _buttons.BottomRight_9);
        }


        private string setWMButton(Button button, string fileName)
        {
            if (!String.IsNullOrEmpty(fileName) && File.Exists(fileName))
            {
                button.BackgroundImage = new Bitmap(Image.FromFile(fileName), button.Size);
                return fileName;
            }
            else
            {
                button.BackgroundImage = null;
                return string.Empty;
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            if (sender is Button)
                _buttons.TopLeft_1 = buttonX_Click(sender as Button);

        }



        private void button2_Click(object sender, EventArgs e)
        {
            if (sender is Button)
                _buttons.TopCenter_2 = buttonX_Click(sender as Button);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (sender is Button)
                _buttons.TopRight_3 = buttonX_Click(sender as Button);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (sender is Button)
                _buttons.MiddleLeft_4 = buttonX_Click(sender as Button);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (sender is Button)
                _buttons.MiddleCenter_5 = buttonX_Click(sender as Button);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (sender is Button)
                _buttons.MiddleRight_6 = buttonX_Click(sender as Button);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (sender is Button)
                _buttons.BottomLeft_7 = buttonX_Click(sender as Button);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (sender is Button)
                _buttons.BottomCenter_8 = buttonX_Click(sender as Button);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (sender is Button)
                _buttons.BottomRight_9 = buttonX_Click(sender as Button);
        }

        private string buttonX_Click(Button sender)
        {
            openFileDialog1.Filter = _filesName;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                return setWMButton(sender, openFileDialog1.FileName);
            }

            return setWMButton(sender, string.Empty);
        }

    }
}
