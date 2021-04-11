using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Media;

namespace Keytrap.Theme.Dark.Controls
{
    /// <summary>
    ///     Class that provides the SpringPopup attached property
    /// </summary>
    public class SpringPopupService : DependencyObject, IDisposable
    {
        public static SpringPopup Popup;

        /// <summary>
        ///     SpringPopup Attached Dependency Property
        /// </summary>
        public static readonly DependencyProperty SpringPopupProperty = DependencyProperty.RegisterAttached(
            "SpringPopup",
            typeof(object),
            typeof(SpringPopupService),
            new FrameworkPropertyMetadata(null, OnSpringPopupChanged));

        /// <summary>
        ///     Gets the SpringPopup property.  This dependency property indicates the SpringPopup for the control.
        /// </summary>
        /// <param name="d"><see cref="DependencyObject" /> to get the property from</param>
        /// <returns>The value of the SpringPopup property</returns>
        public static object GetSpringPopup(DependencyObject d)
        {
            return d.GetValue(SpringPopupProperty);
        }

        /// <summary>
        ///     Sets the SpringPopup property.  This dependency property indicates the SpringPopup for the control.
        /// </summary>
        /// <param name="d"><see cref="DependencyObject" /> to set the property on</param>
        /// <param name="value">value of the property</param>
        public static void SetSpringPopup(DependencyObject d, object value)
        {
            d.SetValue(SpringPopupProperty, value);
        }

        /// <summary>
        ///     Handles changes to the SpringPopup property.
        /// </summary>
        /// <param name="d"><see cref="DependencyObject" /> that fired the event</param>
        /// <param name="e">A <see cref="DependencyPropertyChangedEventArgs" /> that contains the event data.</param>
        private static void OnSpringPopupChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (Control)d;

            control.MouseEnter += (s, e) =>
           {
               var content = d.GetValue(SpringPopupProperty);

               if (content is string)
               {
                   content = BuildDefaultTextBlock(content?.ToString());
               }

               Popup = new SpringPopup
               {
                   Content = content,
                   PopupAnimation = PopupAnimation.None,
                   PlacementTarget = control
               };

               if (Popup != null)
                   Popup.IsOpen = true;
           };

            control.MouseLeave += (s, e) =>
            {
                if (Popup != null)
                    Popup.IsOpen = false;
                Popup = null;
            };
        }

        #region Helper Methods

        private static TextBlock BuildDefaultTextBlock(string text)
        {
            return new TextBlock
            {
                Text = text,
                Padding = new Thickness(12),
                TextWrapping = TextWrapping.Wrap,
                TextAlignment = TextAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left,
                Background = Brushes.Transparent,
            };
        }

        public static T FindParent<T>(DependencyObject obj) where T : DependencyObject
        {
            while (true)
            {
                if (obj == null) return null;
                var parent = VisualTreeHelper.GetParent(obj);

                if (parent is T dependencyObject)
                    return dependencyObject;

                obj = parent;
            }
        }

        public void Dispose()
        {
            if (Popup != null)
                Popup.IsOpen = false;
            Popup = null;
        }

        #endregion Helper Methods
    }
}