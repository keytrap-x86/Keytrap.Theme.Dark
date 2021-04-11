using System.Windows;

namespace Keytrap.Theme.Dark.Controls
{
    /// <summary>
    /// Logique d'interaction pour UserControl1.xaml
    /// </summary>
    public partial class SpringPopup
    {
        public object Content
        {
            get { return GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Content.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(object), typeof(SpringPopup), new PropertyMetadata(null));

        public SpringPopup()
        {
            InitializeComponent();
        }
    }
}