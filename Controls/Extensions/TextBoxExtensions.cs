using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Keytrap.Theme.Controls.Extensions
{
    public static class TextboxExtensions
    {
        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.RegisterAttached(
                "Placeholder",
                typeof(string),
                typeof(TextboxExtensions),
                new PropertyMetadata(default(string), PlaceholderChanged)
            );

        private static void PlaceholderChanged(DependencyObject dependencyObject,
            DependencyPropertyChangedEventArgs args)
        {
            if (!(dependencyObject is TextBox tb))
                return;

            tb.LostFocus -= OnLostFocus;
            tb.GotFocus -= OnGotFocus;
            tb.TextChanged += (sender, eventArgs) =>
            {
                if(string.IsNullOrEmpty(tb.Text))
                    ShowPlaceholder(tb);
                else
                    HidePlaceholder(tb);
            };

            if (args.NewValue != null)
            {
                tb.GotFocus += OnGotFocus;
                tb.LostFocus += OnLostFocus;
            }

            SetPlaceholder(dependencyObject, args.NewValue as string);

            if (!tb.IsFocused)
                ShowPlaceholder(tb);
            else
                HidePlaceholder(tb);
        }

        private static void OnLostFocus(object sender, RoutedEventArgs routedEventArgs)
        {
            ShowPlaceholder(sender as TextBox);
        }

        private static void OnGotFocus(object sender, RoutedEventArgs routedEventArgs)
        {
            var textBox = sender as TextBox;
            if (string.IsNullOrEmpty(textBox?.Text))
                HidePlaceholder(textBox);
        }

        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        public static void SetPlaceholder(DependencyObject element, string value)
        {
            element.SetValue(PlaceholderProperty, value);
        }

        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        public static string GetPlaceholder(DependencyObject element)
        {
            return (string) element.GetValue(PlaceholderProperty);
        }

        private static void ShowPlaceholder(TextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = GetPlaceholder(textBox);
                textBox.Foreground = Brushes.Gray;
                textBox.Opacity = 0.75;
            }
        }

        private static void HidePlaceholder(TextBox textBox)
        {
            var placeholderText = GetPlaceholder(textBox);

            if (textBox.Text == placeholderText)
            {
                //textBox.Text = string.Empty;
                //textBox.Foreground = Brushes.Black;
            }
        }
    }
}