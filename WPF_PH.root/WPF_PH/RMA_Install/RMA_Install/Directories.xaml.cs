using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.Compression;
using System.Resources;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace RMA_Install
{
    /// <summary>
    /// Interaction logic for Welcome1.xaml
    /// </summary>
    public partial class Directories : UserControl
    {
        public Directories()
        {
            InitializeComponent();
        }

        private object checks;

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {

            ApplicationState.Current.install_directory = txtdirectory.Text;

            try
            {


                {

                    if (Directory.Exists(txtdirectory.Text))
                    {

                        checks = checkgrid.FindVisualChildrens<CheckBox>();


                        var message = "This Directory exists, do you wish to delete it?";

                        var confirm = new ConfirmationDialog("Delete", message, "", DialogButtons.YesNo);

                        confirm.Closed += delegate
                        {
                            if (confirm.DialogResult != null &&
                                confirm.DialogResult == true)
                            {
                                DeleteDirectory(txtdirectory.Text);
                            }
                        };

                        confirm.Owner = Application.Current.MainWindow;
                        confirm.ShowDialog();
                    }




                    Assembly _assembly = Assembly.GetExecutingAssembly();

                    Stream inStream = _assembly.GetManifestResourceStream("RMA_Install.Zips.Batch_Directories.zip");

                    UnzipFromStream(inStream, txtdirectory.Text);



                    CreateHardLink(txtdirectory.Text + "\\alpha\\rmabill\\rmabillsolo\\data\\eft_constant", txtdirectory.Text + "\\alpha\\rmabill\\rmabillmp\\data\\eft_constant");

                    CreateHardLinkSoloUploadFrom101C(txtdirectory.Text, "");
                    CreateHardLinkSoloUploadFrom101C(txtdirectory.Text, "D2");


                    //var link = txtdirectory.Text + "\\alpha\\rmabill\\rmabillsolo\\data\\eft_constant";
                    //var target = txtdirectory.Text + "\\alpha\\rmabill\\rmabillsolo\\data\\eft_constant";

                    //Process.Start("mklink /H", String.Format("{0} {1}", link, target));

                }



                this.Content = new Reports();

            }
            catch (Exception ex)
            {
                var confirm = new ConfirmationDialog("Error", ex.Message, "", DialogButtons.Ok);

                confirm.Closed += delegate
                {
                    if (confirm.DialogResult != null &&
                        confirm.DialogResult == true)
                    {
                        System.Windows.Application.Current.Shutdown();
                    }
                };

                confirm.Owner = Application.Current.MainWindow;
                confirm.ShowDialog();
            }

        }


        public static void CreateHardLinkSoloUploadFrom101C(string directory, string drop)
        {
            var files = Directory.GetFiles(directory + "\\alpha\\rmabill\\rmabill101c" + drop + "\\Upload");

            foreach (string f in files)
            {
                CreateHardLink(f.Replace("101c", "Solo"), f);
            }
        }



        [DllImport("Kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool CreateHardLink(
        string lpFileName,
        string lpExistingFileName,
        IntPtr lpSecurityAttributes
    );

        public static void CreateHardLink(string linkName, string existingFileName)
        {
            if (!CreateHardLink(linkName, existingFileName, IntPtr.Zero))
            {

            }
        }

        public void DeleteDirectory(string target_dir)
        {
            string[] files = Directory.GetFiles(target_dir);
            string[] dirs = Directory.GetDirectories(target_dir);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                var enddir = dir.Substring(dir.LastIndexOf("\\") + 1);

                if (!CheckIfChecked(enddir))
                    DeleteDirectory(dir);
            }

            try
            {
                var enddir = target_dir.Substring(target_dir.LastIndexOf("\\") + 1);

                if (!CheckIfChecked(enddir))
                    Directory.Delete(target_dir, false);
            }
            catch
            {

            }

        }


        private bool CheckIfChecked(string dir)
        {
            if (checkBox1.IsChecked == true && (dir == checkBox1.Content.ToString() || dir.IndexOf("\\" + checkBox1.Content.ToString() + "\\") >= 0))
                return true;
            if (checkBox2.IsChecked == true && (dir == checkBox2.Content.ToString() || dir.IndexOf("\\" + checkBox2.Content.ToString() + "\\") >= 0))
                return true;
            if (checkBox3.IsChecked == true && (dir == checkBox3.Content.ToString() || dir.IndexOf("\\" + checkBox3.Content.ToString() + "\\") >= 0))
                return true;
            if (checkBox4.IsChecked == true && (dir == checkBox4.Content.ToString() || dir.IndexOf("\\" + checkBox4.Content.ToString() + "\\") >= 0))
                return true;
            if (checkBox5.IsChecked == true && (dir == checkBox5.Content.ToString() || dir.IndexOf("\\" + checkBox5.Content.ToString() + "\\") >= 0))
                return true;
            if (checkBox6.IsChecked == true && (dir == checkBox6.Content.ToString() || dir.IndexOf("\\" + checkBox6.Content.ToString() + "\\") >= 0))
                return true;
            if (checkBox7.IsChecked == true && (dir == checkBox7.Content.ToString() || dir.IndexOf("\\" + checkBox7.Content.ToString() + "\\") >= 0))
                return true;
            if (checkBox8.IsChecked == true && (dir == checkBox8.Content.ToString() || dir.IndexOf("\\" + checkBox8.Content.ToString() + "\\") >= 0))
                return true;
            if (checkBox9.IsChecked == true && (dir == checkBox9.Content.ToString() || dir.IndexOf("\\" + checkBox9.Content.ToString() + "\\") >= 0))
                return true;
            if (checkBox10.IsChecked == true && (dir == checkBox10.Content.ToString() || dir.IndexOf("\\" + checkBox10.Content.ToString() + "\\") >= 0))
                return true;
            if (checkBox11.IsChecked == true && (dir == checkBox11.Content.ToString() || dir.IndexOf("\\" + checkBox11.Content.ToString() + "\\") >= 0))
                return true;
            if (checkBox12.IsChecked == true && (dir == checkBox12.Content.ToString() || dir.IndexOf("\\" + checkBox12.Content.ToString() + "\\") >= 0))
                return true;
            if (checkBox13.IsChecked == true && (dir == checkBox13.Content.ToString() || dir.IndexOf("\\" + checkBox13.Content.ToString() + "\\") >= 0))
                return true;
            if (checkBox14.IsChecked == true && (dir == checkBox14.Content.ToString() || dir.IndexOf("\\" + checkBox14.Content.ToString() + "\\") >= 0))
                return true;

            return false;
        }

        public void UnzipFromStream(Stream zipStream, string outFolder)
        {

            ZipInputStream zipInputStream = new ZipInputStream(zipStream);
            ZipEntry zipEntry = zipInputStream.GetNextEntry();
            while (zipEntry != null)
            {
                String entryFileName = zipEntry.Name;
                // to remove the folder from the entry:- entryFileName = Path.GetFileName(entryFileName);
                // Optionally match entrynames against a selection list here to skip as desired.
                // The unpacked length is available in the zipEntry.Size property.

                byte[] buffer = new byte[4096];     // 4K is optimum

                // Manipulate the output filename here as desired.
                String fullZipToPath = System.IO.Path.Combine(outFolder, entryFileName);
                string directoryName = System.IO.Path.GetDirectoryName(fullZipToPath).Replace("\\Batch_Directories", "");
                if (directoryName.Length > 0)
                    Directory.CreateDirectory(directoryName);

               
                if (CheckIfChecked(directoryName))
                {
                    zipEntry = zipInputStream.GetNextEntry();
                    continue;
                }
                  

                // Skip directory entry
                string fileName = System.IO.Path.GetFileName(fullZipToPath);
                if (fileName.Length == 0)
                {
                    zipEntry = zipInputStream.GetNextEntry();
                    continue;
                }

                // Unzip file in buffered chunks. This is just as fast as unpacking to a buffer the full size
                // of the file, but does not waste memory.
                // The "using" will close the stream even if an exception occurs.
                using (FileStream streamWriter = File.Create(fullZipToPath.Replace("\\Batch_Directories", "")))
                {
                    StreamUtils.Copy(zipInputStream, streamWriter, buffer);
                }
                zipEntry = zipInputStream.GetNextEntry();
            }
        }




        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new License();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void radioButton1_Click(object sender, RoutedEventArgs e)
        {

            btnbrowse.IsEnabled = true;
            txtdirectory.IsEnabled = true;
        }

        private void radioButton_Click(object sender, RoutedEventArgs e)
        {

            btnbrowse.IsEnabled = false;
            txtdirectory.IsEnabled = false;
        }

        private void btnbrowse_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                txtdirectory.Text = dialog.SelectedPath;
            }
        }
    }
}
