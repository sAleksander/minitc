using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

namespace MiniTC
{
    /// <summary>
    /// Interaction logic for PanelTC.xaml
    /// </summary>

    public partial class PanelTC : UserControl
    {
        private string extractOldPath(string path)
        {
            int i = path.Length - 1;
            bool extracted = false;
            while (!extracted)
            {
                i--;
                char tmp = path[i];
                if (tmp == '\\')
                {
                    extracted = true;
                }
            }
            return path.Substring(0, i + 1);
        }

        public PanelTC()
        {
            InitializeComponent();
        }

        #region main path
        public string Path
        {
            get { return (string)GetValue(pathProperty); }
            set { SetValue(pathProperty, value); }
        }

        public static readonly DependencyProperty pathProperty = DependencyProperty.Register(
           nameof(Path), typeof(string), typeof(PanelTC), new PropertyMetadata(SetPath));

        private static void SetPath(DependencyObject ob, DependencyPropertyChangedEventArgs args)
        {
            PanelTC panelObj = ob as PanelTC;
            panelObj.fullPath.Text = args.NewValue as string;
        }
        #endregion 
        #region combo control
        public string[] DrivesList
        {
            get { return (string[])GetValue(drivesListProperty); }
            set { SetValue(drivesListProperty, value); }
        }

        public static readonly DependencyProperty drivesListProperty = DependencyProperty.Register(
           nameof(DrivesList), typeof(string[]), typeof(PanelTC), new PropertyMetadata(SetDrivesList));

        private static void SetDrivesList(DependencyObject ob, DependencyPropertyChangedEventArgs args)
        {
            PanelTC panelObj = ob as PanelTC;
            panelObj.allPaths.ItemsSource = args.NewValue as string[];
        }

        public int ComboIndex
        {
            get { return (int)GetValue(comboIndexProperty); }
            set { SetValue(comboIndexProperty, value); }
        }

        public static readonly DependencyProperty comboIndexProperty = DependencyProperty.Register(
           nameof(ComboIndex), typeof(int), typeof(PanelTC), new PropertyMetadata(SetComboIndex));

        private static void SetComboIndex(DependencyObject ob, DependencyPropertyChangedEventArgs args)
        {
            PanelTC panelObj = ob as PanelTC;
            panelObj.allPaths.SelectedIndex = (int)args.NewValue;
        }

        private void AllPaths_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboIndex = allPaths.SelectedIndex;
        }
        #endregion
        #region files List

        public string[] FilesList
        {
            get { return (string[])GetValue(filesListProperty); }
            set { SetValue(filesListProperty, value); }
        }

        public static readonly DependencyProperty filesListProperty = DependencyProperty.Register(
           nameof(FilesList), typeof(string[]), typeof(PanelTC), new PropertyMetadata(SetFilesList));

        private static void SetFilesList(DependencyObject ob, DependencyPropertyChangedEventArgs args)
        {
            PanelTC panelObj = ob as PanelTC;
            string[] tmp = args.NewValue as string[];
            string[] display = new string[tmp.Length];
            bool addD = false;
            for (int i = 0; i < tmp.Length; i++)
            {
                addD = false;
                if (tmp[i].Contains("<D>"))
                {
                    addD = true;
                }
                string[] temp = tmp[i].Split('\\');
                if (addD)
                {
                display[i] ="<D>"+ temp[temp.Length - 1];
                }
                else
                {
                display[i] =temp[temp.Length - 1];
                }
            }
            panelObj.itemsList.ItemsSource = display;
        }

        public int ListIndex
        {
            get { return (int)GetValue(listIndexProperty); }
            set { SetValue(listIndexProperty, value); }
        }

        public static readonly DependencyProperty listIndexProperty = DependencyProperty.Register(
           nameof(ListIndex), typeof(int), typeof(PanelTC), new PropertyMetadata(SetListIndex));

        private static void SetListIndex(DependencyObject ob, DependencyPropertyChangedEventArgs args)
        {
            PanelTC panelObj = ob as PanelTC;
            panelObj.itemsList.SelectedIndex = (int)args.NewValue;
        }

        private void ItemsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListIndex = itemsList.SelectedIndex;
        }

        #endregion

        private void ItemsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (FilesList[itemsList.SelectedIndex].Contains("<D>"))
            {
                Path = FilesList[itemsList.SelectedIndex].Replace("<D>", "");
            }
            if (itemsList.SelectedIndex == 0 && Path.Length != 3)
            {
                Path = extractOldPath(Path);
            }
        }
    }
}
