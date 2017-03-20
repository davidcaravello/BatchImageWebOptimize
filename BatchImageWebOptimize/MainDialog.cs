using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;

namespace BatchImageWebOptimize
{
    public partial class MainDialog : Form
    {
        public MainDialog()
        {
            InitializeComponent();

            sourceImageTextBox.Text = Properties.Settings.Default.sourcePath;
            outputImageTextBox.Text = Properties.Settings.Default.outputPath;
            sourceFileTypesTextBox.Text = Properties.Settings.Default.sourceFileTypes;

            updateQualityLabel();
            //progressLabel.Parent = progressBar1;
            //progressLabel.BackColor = Color.Transparent;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            updateQualityLabel();
        }

        private void updateQualityLabel()
        {
            this.qualityLabel.Text = qualityTrackBar.Value.ToString() + " %";
        }

        private void sourceImageBrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

            folderBrowserDialog1.Description = "Select the directory that contains all the *.jpg images you would like to optimize";
            folderBrowserDialog1.ShowNewFolderButton = true;

            if (!String.IsNullOrEmpty(sourceImageTextBox.Text))
                folderBrowserDialog1.SelectedPath = sourceImageTextBox.Text;
            //folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Personal;

            DialogResult result = folderBrowserDialog1.ShowDialog();

            if( result == DialogResult.OK)
            {
                sourceImageTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void outputImageBrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

            folderBrowserDialog1.Description = "Select the directory to save optimized images (will overwrite files that already exist)";
            folderBrowserDialog1.ShowNewFolderButton = false;

            if (!String.IsNullOrEmpty(outputImageTextBox.Text))
                folderBrowserDialog1.SelectedPath = outputImageTextBox.Text;
            //folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Personal;

            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                outputImageTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        class GUIData
        {
            public string SourcePath;
            public string OutputPath;
            public ArrayList SourceFileTypes;
            public int Quality;
        }


        private void optimzeButton_Click(object sender, EventArgs e)
        {
            //String outputPath = "C:\\deleteme\\imageResizeWorking\\working\\output";
            //DirectoryInfo dirInfo = new DirectoryInfo("C:\\deleteme\\imageResizeWorking\\working\\");
            
            if (backgroundWorker1.IsBusy != true)
            {
                var guiData = new GUIData();
                guiData.Quality = qualityTrackBar.Value;
                guiData.SourcePath = sourceImageTextBox.Text;
                guiData.OutputPath = outputImageTextBox.Text;
                guiData.SourceFileTypes = getSourceFileTypeExtensions(sourceFileTypesTextBox.Text);

                if( String.IsNullOrEmpty(guiData.SourcePath) || !Directory.Exists(guiData.SourcePath) )
                {
                    MessageBox.Show("Please provide a valid source path");
                    return;
                }

                if (String.IsNullOrEmpty(guiData.OutputPath) || !Directory.Exists(guiData.SourcePath))
                {
                    MessageBox.Show("Please provide an output path");
                    return;
                }

                updateGUIWorkInProgress(true);
                backgroundWorker1.RunWorkerAsync(guiData);
            }
        }

        private IEnumerable<FileInfo> GetFilesByExtensions(DirectoryInfo dirInfo, params string[] extensions)
        {
            var allowedExtensions = new HashSet<string>(extensions, StringComparer.OrdinalIgnoreCase);

            return dirInfo.EnumerateFiles().Where(f => allowedExtensions.Contains(f.Extension));
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var guiData = (GUIData)e.Argument;
                BackgroundWorker worker = sender as BackgroundWorker;

                String pathToImageMagick = AppDomain.CurrentDomain.BaseDirectory + "im\\";
                String pathToConvertExe = pathToImageMagick + "convert.exe";
                String sourcePath = sourceImageTextBox.Text;
                String outputPath = guiData.OutputPath;

                if (!String.IsNullOrEmpty(outputPath) && !outputPath.EndsWith("\\"))
                    outputPath += "\\";

                int quality = guiData.Quality;

                if (!File.Exists(pathToConvertExe))
                {
                    MessageBox.Show("Image Magick executable not found at: " + pathToConvertExe);
                    exitApplication();
                    return;
                }

                Console.WriteLine("Image Magick Location: " + pathToConvertExe);

                DirectoryInfo dirInfo = new DirectoryInfo(guiData.SourcePath);

                IEnumerable<FileInfo> files = GetFilesByExtensions(dirInfo, (string []) guiData.SourceFileTypes.ToArray(typeof(string)));

                int numFilesToConvert = files.Count();
                int currentFileIndex = 0;

                if(numFilesToConvert == 0)
                {
                    MessageBox.Show("No source image files found");
                    return;
                }

                foreach (FileInfo file in files)
                {
                    if (worker.CancellationPending == true)
                    {
                        e.Cancel = true;
                        break;
                    }

                    currentFileIndex++;
                    string sourceFileName = file.FullName;
                    string fileName = file.Name;
                    string fileNameNoExt = fileName.Substring(0, fileName.Length - file.Extension.Length);
                    string destinationFileName = outputPath + fileNameNoExt + "_q" + quality + file.Extension;

                    Console.WriteLine("howdy");

                    Process proc = new Process();
                    proc.StartInfo.FileName = pathToConvertExe;
                    proc.StartInfo.Arguments = sourceFileName + " -quality " + quality + " " + destinationFileName;
                    proc.StartInfo.RedirectStandardOutput = true;
                    proc.StartInfo.RedirectStandardError = true;
                    proc.StartInfo.UseShellExecute = false;
                    proc.StartInfo.CreateNoWindow = true;
                    proc.Start();


                    StreamReader srO = proc.StandardOutput;
                    string standardOutput = srO.ReadToEnd();

                    StreamReader srE = proc.StandardError;
                    string standardError = srE.ReadToEnd();

                    proc.WaitForExit();

                    //Console.WriteLine("Standard Output: ");
                    //Console.WriteLine(standardOutput);
                    //Console.WriteLine("Standard Error: ");
                    //Console.WriteLine(standardError);

                    string statusText = currentFileIndex + " / " + numFilesToConvert;

                    worker.ReportProgress((int)((currentFileIndex / (double)numFilesToConvert) * 100), statusText);
                }
            }
            catch(Exception ex)
            {
                e.Cancel = true;
                MessageBox.Show("Error occured: " + ex);
                exitApplication();
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int newValue = e.ProgressPercentage;

            if ( newValue + 1 <= 100 )
            {
                progressBar1.Value = (newValue*10) + 1;
                progressBar1.Value = (newValue*10);
            }
            else
            {
                progressBar1.Value = 1000;
                progressBar1.Value = 999;
                progressBar1.Value = 1000;
            }
            
            progressLabel.Text = e.UserState as string;
        }

        private void updateGUIWorkInProgress(bool workInProgress)
        {
            if(workInProgress)
            {
                sourceImageTextBox.Enabled = false;
                sourceImageBrowseButton.Enabled = false;
                outputImageTextBox.Enabled = false;
                outputImageBrowseButton.Enabled = false;
                qualityTrackBar.Enabled = false;
                optimzeButton.Enabled = false;
                cancelButton.Enabled = true;
            }
            else
            {
                sourceImageTextBox.Enabled = true;
                sourceImageBrowseButton.Enabled = true;
                outputImageTextBox.Enabled = true;
                outputImageBrowseButton.Enabled = true;
                qualityTrackBar.Enabled = true;
                optimzeButton.Enabled = true;
                cancelButton.Enabled = false;
            }
            
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            updateGUIWorkInProgress(false);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                backgroundWorker1.CancelAsync();
            }
        }

        private void exitApplication()
        {
            Application.Exit();
        }

        private void saveSettings()
        {
            Properties.Settings.Default.sourcePath = sourceImageTextBox.Text;
            Properties.Settings.Default.outputPath = outputImageTextBox.Text;
            Properties.Settings.Default.sourceFileTypes = sourceFileTypesTextBox.Text;
            Properties.Settings.Default.Save();
            Console.WriteLine("Settings Saved");
        }

        private void MainDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveSettings();
        }

        private ArrayList getSourceFileTypeExtensions(string rawCSV)
        {
            ArrayList result = new ArrayList();

            string[] splitCSV = rawCSV.Split(',');

            foreach(string csvValue in splitCSV)
            {
                string trimedValue = csvValue.Trim();
                if (trimedValue.StartsWith("."))
                    result.Add(trimedValue);
            }

            return result;
        }
    }
}
