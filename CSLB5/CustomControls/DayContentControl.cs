using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CSLB5.CustomControls
{
    public class DayContentControl : Control
    {
        

        static DayContentControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DayContentControl), new FrameworkPropertyMetadata(typeof(DayContentControl)));
        }
        

        public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register(
            nameof(Items), typeof(IEnumerable), typeof(DayContentControl), new PropertyMetadata(default(IEnumerable)));

        public IEnumerable Items
        {
            get => (IEnumerable) GetValue(ItemsProperty);
            set => SetValue(ItemsProperty, value);
        }

        public static readonly DependencyProperty DataProperty = DependencyProperty.Register(
            nameof(Data), typeof(object), typeof(DayContentControl), new PropertyMetadata(default(object)));

        public object Data
        {
            get => (object) GetValue(DataProperty);
            set => SetValue(DataProperty, value);
        }
    }
}
