using System.Windows;
using System.Windows.Controls;


namespace CSLB5.CustomControls
{
    public class CustomGanttControl : Control
    {
        static CustomGanttControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomGanttControl), new FrameworkPropertyMetadata(typeof(CustomGanttControl)));
        }

        public static readonly DependencyProperty FrontContentProperty =
            DependencyProperty.Register("FrontContent", typeof(object), typeof(CustomGanttControl), new PropertyMetadata(null));

        public object FrontContent
        {
            get { return GetValue(FrontContentProperty); }
            set { SetValue(FrontContentProperty, value); }
        }

        public static readonly DependencyProperty BackContentProperty =
            DependencyProperty.Register("BackContent", typeof(object), typeof(CustomGanttControl), new PropertyMetadata(null));

        public object BackContent
        {
            get { return GetValue(BackContentProperty); }
            set { SetValue(BackContentProperty, value); }
        }
    }
}
