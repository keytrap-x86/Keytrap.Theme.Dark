
using Keytrap.Theme.Dark.Controls;
using Keytrap.Theme.Dark.Tools;

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using Window = Keytrap.Theme.Dark.Controls.Window;

// ReSharper disable AssignNullToNotNullAttribute

namespace Keytrap.Theme.Dark.Themes
{
    public partial class Generic
    {

        public Generic()
        {
            if (DesignerHelper.IsInDesignMode)
            {
                MergedDictionaries.Add(new ResourceDictionary
                {
                    Source = new Uri("pack://application:,,,/Keytrap.Theme.Dark;component/Themes/SkinDefault.xaml")
                });
                MergedDictionaries.Add(new ResourceDictionary
                {
                    Source = new Uri("pack://application:,,,/Keytrap.Theme.Dark;component/Themes/Generic.xaml")
                });
            }
            else
            {
                UpdateResource();
            }
        }

        private Uri _source;

        public new Uri Source
        {
            get => DesignerHelper.IsInDesignMode ? null : _source;
            set => _source = value;
        }

        public string Name { get; set; }

        public virtual ResourceDictionary GetTheme() => new ResourceDictionary
        {
            Source = new Uri("pack://application:,,,/Keytrap.Theme.Dark;component/Themes/Generic.xaml")
        };

        private void UpdateResource()
        {
            if (DesignerHelper.IsInDesignMode) 
                return;

            //MergedDictionaries.Clear();
            //MergedDictionaries.Add(GetSkin());
           // MergedDictionaries.Add(GetTheme());
        }

        private ResourceDictionary GetSkin() => new ResourceDictionary
        {
            Source = new Uri("pack://application:,,,/Keytrap.Theme.Dark;component/Themes/SkinDefault.xaml")
        };

        private void GrdDragForm_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!(System.Windows.Window.GetWindow(sender as Grid) is Window window))
                return;

            if (e.ChangedButton == MouseButton.Left)
                window.DragMove();
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            if (sender != null && Window.GetWindow(sender as WindowControlButton) is Window window)
                window.WindowState = WindowState.Minimized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            if (sender != null && Window.GetWindow(sender as WindowControlButton) is Window window)
                window.Close();
        }

        private void BtnMaximize_OnClick(object sender, RoutedEventArgs e)
        {
            if (sender == null || !(Window.GetWindow(sender as WindowControlButton) is Window window)) 
                return;

            switch (window.WindowState)
            {
                case WindowState.Maximized:
                    window.WindowState = WindowState.Normal;
                    break;
                case WindowState.Normal:
                    window.WindowState = WindowState.Maximized;
                    break;
            }
        }
    }
}
