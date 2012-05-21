using System.Windows;
using System.Windows.Controls;

namespace WatermarkedTextBoxControl
{
    public class WatermarkedTextBox : TextBox
    {
        ContentControl _watermarkContent;
        public static readonly DependencyProperty WatermarkProperty =
                DependencyProperty.Register("Watermark", typeof(object), typeof(WatermarkedTextBox), new PropertyMetadata(OnWatermarkPropertyChanged));

        public static readonly DependencyProperty WatermarkStyleProperty =
                DependencyProperty.Register("WatermarkStyle", typeof(Style), typeof(WatermarkedTextBox), null);

        public Style WatermarkStyle
        {
            get { return GetValue(WatermarkStyleProperty) as Style; }
            set { SetValue(WatermarkStyleProperty, value); }
        }

        public object Watermark
        {
            get { return GetValue(WatermarkProperty); }
            set { SetValue(WatermarkProperty, value); }
        }

        public WatermarkedTextBox()
        {
            DefaultStyleKey = typeof(WatermarkedTextBox);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _watermarkContent = GetTemplateChild("watermarkContent") as ContentControl;
            if (_watermarkContent != null)
                DetermineWatermarkContentVisibility();
        }

        protected override void OnGotFocus(RoutedEventArgs e)
        {
            if (_watermarkContent != null && string.IsNullOrEmpty(Text))
                _watermarkContent.Visibility = Visibility.Collapsed;
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(RoutedEventArgs e)
        {
            if (_watermarkContent != null && string.IsNullOrEmpty(Text))
                _watermarkContent.Visibility = Visibility.Visible;
            base.OnLostFocus(e);
        }

        private static void OnWatermarkPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            var watermarkTextBox = sender as WatermarkedTextBox;
            if (watermarkTextBox != null && watermarkTextBox._watermarkContent != null)
            {
                watermarkTextBox.DetermineWatermarkContentVisibility();
            }
        }

        private void DetermineWatermarkContentVisibility()
        {
            _watermarkContent.Visibility = string.IsNullOrEmpty(Text) ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
