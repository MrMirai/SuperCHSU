using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        public static readonly DependencyProperty FrontContentProperty =
            DependencyProperty.Register("FrontContent", typeof(object), typeof(DayContentControl), new PropertyMetadata(null));

        public object FrontContent
        {
            get { return GetValue(FrontContentProperty); }
            set { SetValue(FrontContentProperty, value); }
        }

        public static readonly DependencyProperty BackContentProperty =
            DependencyProperty.Register("BackContent", typeof(object), typeof(DayContentControl), new PropertyMetadata(null));

        public object BackContent
        {
            get { return GetValue(BackContentProperty); }
            set { SetValue(BackContentProperty, value); }
        }



        //public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register(
        //    nameof(Items), typeof(IEnumerable), typeof(DayContentControl), new PropertyMetadata(default(IEnumerable)));

        //public IEnumerable Items
        //{
        //    get => (IEnumerable) GetValue(ItemsProperty);
        //    set => SetValue(ItemsProperty, value);
        //}

        //public static readonly DependencyProperty DataProperty = DependencyProperty.Register(
        //    nameof(Data), typeof(object), typeof(DayContentControl), new PropertyMetadata(default(object)));

        //public object Data
        //{
        //    get => (object) GetValue(DataProperty);
        //    set => SetValue(DataProperty, value);
        //}
    }
}
