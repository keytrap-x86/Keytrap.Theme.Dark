using Keytrap.Theme.Dark.Tools.Extension;

using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Keytrap.Theme.Dark.Controls
{
    /// <summary>
    /// Logique d'interaction pour DropZone.xaml
    /// </summary>
    public partial class DropZone
    {
        #region DropZoneText

        public static readonly DependencyProperty DropZoneTextProperty =
           DependencyProperty.Register("DropZoneText", typeof(string), typeof(DropZone), new PropertyMetadata("Click or drop files here"));

        public string DropZoneText
        {
            get { return (string)GetValue(DropZoneTextProperty); }
            set { SetValue(DropZoneTextProperty, value); }
        }

        #endregion DropZoneText

        #region DropZoneTextForeground

        public static readonly DependencyProperty DropZoneTextForegroundProperty =
           DependencyProperty.Register("DropZoneTextForeground", typeof(Brush), typeof(DropZone), new PropertyMetadata(Brushes.DarkGray));

        public Brush DropZoneTextForeground
        {
            get { return (Brush)GetValue(DropZoneTextForegroundProperty); }
            set { SetValue(DropZoneTextForegroundProperty, value); }
        }

        #endregion DropZoneTextForeground

        #region IsDragging

        public static readonly DependencyProperty IsDraggingProperty =
            DependencyProperty.RegisterAttached("IsDragging", typeof(bool), typeof(DropZone), new UIPropertyMetadata(false));

        public bool IsDragging
        {
            get { return (bool)GetValue(IsDraggingProperty); }
            set
            {
                SetValue(IsDraggingProperty, value);
                Console.WriteLine("IsDragging: " + value);
            }
        }

        #endregion IsDragging

        #region DraggedFilesHaveAllowedExtensions

        public static readonly DependencyProperty DraggedFilesHaveAllowedExtensionsProperty =
            DependencyProperty.RegisterAttached("DraggedFilesHaveAllowedExtensions", typeof(bool), typeof(DropZone), new UIPropertyMetadata(true));

        public bool DraggedFilesHaveAllowedExtensions
        {
            get { return (bool)GetValue(DraggedFilesHaveAllowedExtensionsProperty); }
            set
            {
                SetValue(DraggedFilesHaveAllowedExtensionsProperty, value);
                Console.WriteLine("DraggedFilesHaveAllowedExtensions: " + value);
            }
        }

        #endregion DraggedFilesHaveAllowedExtensions

        #region Image

        public static readonly DependencyProperty ImageProperty =
           DependencyProperty.Register("Image", typeof(ImageSource), typeof(DropZone), new PropertyMetadata(null));

        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        #endregion Image

        #region AllowedFileExtensions

        public static readonly DependencyProperty AllowedFileExtensionsProperty =
           DependencyProperty.Register("AllowedFileExtensions", typeof(string), typeof(DropZone), new PropertyMetadata("*"));

        public string AllowedFileExtensions
        {
            get { return (string)GetValue(AllowedFileExtensionsProperty); }
            set { SetValue(AllowedFileExtensionsProperty, value); }
        }

        #endregion AllowedFileExtensions

        public DropZone()
        {
            InitializeComponent();
        }

        private void DropZone_DragLeave(object sender, DragEventArgs e)
        {
            if (e.OriginalSource is DependencyObject source)
            {
                source.SetParentValue<Button>(IsDraggingProperty, false);
                source.SetParentValue<Button>(DraggedFilesHaveAllowedExtensionsProperty, true);
            }
        }

        private void DropZone_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, true))
            {
                var filenames = e.Data.GetData(DataFormats.FileDrop, true) as string[];

                var source = e.OriginalSource as DependencyObject;

                source.SetParentValue<Button>(IsDraggingProperty, true);
                source.SetParentValue<Button>(DraggedFilesHaveAllowedExtensionsProperty, DoDraggedFilesHaveAllowedExtensions(filenames));
            }
            else
            {
                e.Effects = DragDropEffects.None;
                e.Handled = true;
            }
        }

        private void DropZone_Drop(object sender, DragEventArgs e)
        {
            if (e.OriginalSource is DependencyObject source)
            {
                source.SetParentValue<Button>(IsDraggingProperty, false);
                source.SetParentValue<Button>(DraggedFilesHaveAllowedExtensionsProperty, true);
            }
        }

        internal bool DoDraggedFilesHaveAllowedExtensions(string[] fileNames)
        {
            if (AllowedFileExtensions.ToLower().Contains("*"))
                return true;

            foreach (string filename in fileNames)
            {
                // If at leats one of the current dragged files extension is not found in the allowed extensions array, we return false
                if (AllowedFileExtensions.ToLower().Contains(System.IO.Path.GetExtension(filename)) == false)
                {
                    return false;
                }
            }

            return true;
        }
    }
}