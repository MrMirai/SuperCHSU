using System.Windows;
using System.Windows.Controls;

namespace CSLB5.CustomControls

{
    public class GanttBlockControl : Control
    {
        static GanttBlockControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GanttBlockControl), new FrameworkPropertyMetadata(typeof(GanttBlockControl)));
        }

        public static readonly DependencyProperty BlockWidthProperty = DependencyProperty.Register(
            nameof(BlockWidth), typeof(double), typeof(GanttBlockControl), new PropertyMetadata(default(double)));

        public double BlockWidth
        {
            get => (double) GetValue(BlockWidthProperty);
            set => SetValue(BlockWidthProperty, value);
        }
    }
}