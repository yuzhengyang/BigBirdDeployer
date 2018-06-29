using Azylee.Core.IOUtils.ImageUtils;
using MetadataExtractor;
using MetadataExtractor.Formats.Exif;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Azylee.Core.IOUtils.ImageUtils.ExifHelper;

namespace Oreo.PictureInfo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BTOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "JPEG|*.jpg;*.jpeg;*.jpe;*.jfif";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    string filename = openFileDialog1.FileName;
                    if (File.Exists(filename))
                    {
                        TBFile.Text = filename;
                        IMImg.Source = new BitmapImage(new Uri(filename, UriKind.Absolute));
                        StringBuilder sb = new StringBuilder();
                        try
                        {
                            var directories = ImageMetadataReader.ReadMetadata(filename);
                            // print out all metadata
                            foreach (var directory in directories)
                                foreach (var tag in directory.Tags)
                                    sb.AppendLine($"{directory.Name} - {tag.Name} = {tag.Description}");

                            //ExifHelper exif = new ExifHelper(filename);
                            //foreach (ExifTagNames tag in (ExifTagNames[])Enum.GetValues(typeof(ExifTagNames)))
                            //{
                            //    double _double = exif.GetPropertyDouble((int)tag);
                            //    string _string = exif.GetPropertyString((int)tag);
                            //    char _char = '=';// exif.GetPropertyChar((int)tag);
                            //    sb.AppendLine($"{tag.ToString()} : {_double} : {_string} : {_char}");
                            //}
                            ////sb.AppendLine($"GpsAltitude: {exif.GetPropertyDouble((int)ExifTagNames.GpsAltitude)}"); 
                            ////sb.AppendLine($"GpsLatitude: {exif.GetPropertyDouble((int)ExifTagNames.GpsLatitude)}");
                            ////sb.AppendLine($"GpsLongitude: {exif.GetPropertyDouble((int)ExifTagNames.GpsLongitude)}");
                        }
                        catch { }
                        TBInfo.Text = sb.ToString();
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
    }
}
