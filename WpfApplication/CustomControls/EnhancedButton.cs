using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApplication.CustomControls
{
    public class EnhancedButton : Button
    {
        public Brush HoverBackground
        {
            get { return (Brush)GetValue(HoverBackgroundProperty); }
            set { SetValue(HoverBackgroundProperty, value); }
        }


        public static readonly DependencyProperty HoverBackgroundProperty =
            DependencyProperty.Register("HoverBackground", typeof(Brush), typeof(EnhancedButton), new PropertyMetadata(Brushes.Transparent));


    }
}


