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

namespace RMA_Install
{
    /// <summary>
    /// Interaction logic for Welcome1.xaml
    /// </summary>
    public partial class Batch : UserControl
    {
        public Batch()
        {
            InitializeComponent();
            txtdirectory.Text = ApplicationState.Current.install_directory + "\\RMA_Batch";
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {

            ApplicationState.Current.install_batch = txtdirectory.Text;

            try
            {

                if (radioButton1.IsChecked == true)
                {

                    Assembly _assembly = Assembly.GetExecutingAssembly();

                    Stream inStream = _assembly.GetManifestResourceStream("RMA_Install.Zips.Core_Batch.zip");

                    UnzipFromStream(inStream, txtdirectory.Text);

                }

                this.Content = new Batch_config();

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
                string directoryName = System.IO.Path.GetDirectoryName(fullZipToPath).Replace("\\Core_Batch", "");
                if (directoryName.Length > 0)
                    Directory.CreateDirectory(directoryName);

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
                using (FileStream streamWriter = File.Create(fullZipToPath.Replace("\\Core_Batch", "")))
                {
                    StreamUtils.Copy(zipInputStream, streamWriter, buffer);
                }
                zipEntry = zipInputStream.GetNextEntry();
            }
        }




        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new Reports();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void radioButton1_Click(object sender, RoutedEventArgs e)
        {
            radioButton.IsChecked = false;
            btnbrowse.IsEnabled = true;
            txtdirectory.IsEnabled = true;
        }

        private void radioButton_Click(object sender, RoutedEventArgs e)
        {
            radioButton1.IsChecked = false;
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
