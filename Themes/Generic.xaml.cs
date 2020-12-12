using Keytrap.Theme.Controls;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Keytrap.Theme.Themes
{
    public partial class Generic : ResourceDictionary
    {
        private void GrdDragForm_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Window.GetWindow(sender as Grid) is Window window)
                if (e.ChangedButton == MouseButton.Left)
                    window.DragMove();

        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            if (Window.GetWindow(sender as WindowControlButton) is Window window)
                window.WindowState = WindowState.Minimized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            if (Window.GetWindow(sender as WindowControlButton) is Window window)
                window.Close();
        }
    }
}
