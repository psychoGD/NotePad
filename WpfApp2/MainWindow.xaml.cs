//using Microsoft.Win32;
using Microsoft.Win32;
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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public bool OnorOff { get; set; } = false;

        private void off_Click(object sender, RoutedEventArgs e)
        {
            if (OnorOff)
            {

            }
        }

        private void Ellipse_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void OFD_Btn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == true)
            {
                FlowDocument myFlowDoc = new FlowDocument();
                string filename = openFileDialog1.FileName;
                myFlowDoc.Blocks.Add(new Paragraph(new Run(File.ReadAllText(filename))));
                TextBox_1.Document = myFlowDoc;
                this.FilePath_TxtB.Text = filename;
            }
        }
        private void SaveFunc()
        {
            if (FilePath_TxtB.Text != string.Empty)
            {
                string richText = new TextRange(TextBox_1.Document.ContentStart, TextBox_1.Document.ContentEnd).Text;
                File.WriteAllText(this.FilePath_TxtB.Text, richText);
            }

        }
        private void Save_Btn_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to overwrite the file?");
            if (result == MessageBoxResult.OK)
            {
                SaveFunc();
            }
        }

        private void SelectAll_Btn_Click(object sender, RoutedEventArgs e)
        {



        }



        private void AutoSaveOff_RB_Checked(object sender, RoutedEventArgs e)
        {
            TextBox_1.TextChanged -= TextBox_1_TextChanged;
        }

        private void AutoSaveOn_RB_Checked(object sender, RoutedEventArgs e)
        {
            if (FilePath_TxtB.Text.Length > 0)
            {
                TextBox_1.TextChanged += TextBox_1_TextChanged;
                Error_Label.Content = string.Empty;
            }
            else
            {
                Error_Label.Visibility = Visibility.Visible;
                Error_Label.Content = $"AutoSave Does Not Work,\n No Files Are Selected";
            }
        }

        private void TextBox_1_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            SaveFunc();
        }


    }
}
