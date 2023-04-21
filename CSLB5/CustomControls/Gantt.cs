using CSLB5.DataBase.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
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
    /// <summary>
    /// Выполните шаги 1a или 1b, а затем 2, чтобы использовать этот пользовательский элемент управления в файле XAML.
    ///
    /// Шаг 1a. Использование пользовательского элемента управления в файле XAML, существующем в текущем проекте.
    /// Добавьте атрибут XmlNamespace в корневой элемент файла разметки, где он 
    /// будет использоваться:
    ///
    ///     xmlns:MyNamespace="clr-namespace:CSLB5.CustomControls"
    ///
    ///
    /// Шаг 1б. Использование пользовательского элемента управления в файле XAML, существующем в другом проекте.
    /// Добавьте атрибут XmlNamespace в корневой элемент файла разметки, где он 
    /// будет использоваться:
    ///
    ///     xmlns:MyNamespace="clr-namespace:CSLB5.CustomControls;assembly=CSLB5.CustomControls"
    ///
    /// Потребуется также добавить ссылку из проекта, в котором находится файл XAML,
    /// на данный проект и пересобрать во избежание ошибок компиляции:
    ///
    ///     Щелкните правой кнопкой мыши нужный проект в обозревателе решений и выберите
    ///     "Добавить ссылку"->"Проекты"->[Поиск и выбор проекта]
    ///
    ///
    /// Шаг 2)
    /// Теперь можно использовать элемент управления в файле XAML.
    ///
    ///     <MyNamespace:Gantt/>
    ///
    /// </summary>
    public class Gantt : Control
    {
        //рубрика эксперименты
        static Gantt()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Gantt), new FrameworkPropertyMetadata(typeof(Gantt)));

        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(Gantt), new PropertyMetadata(default(string)));
        public static readonly DependencyProperty CountProperty = DependencyProperty.Register(nameof(Count), typeof(int), typeof(Gantt), new PropertyMetadata(default(int)));

        private Canvas canvas;

        public string Text
        {
            get {
                return (string)GetValue(TextProperty);
                    }
            set {
                SetValue(TextProperty, value); }
        }
        public int Count
        {
            get => (int)GetValue(CountProperty);
            set => SetValue(CountProperty, value);
        }
        public override void OnApplyTemplate()
        {
            canvas = Template.FindName("canvas", this) as Canvas;
            canvas.Height = Count * 30;
            base.OnApplyTemplate();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            canvas = Template.FindName("canvas", this) as Canvas;
            base.OnRender(drawingContext);
            int textSetTop = 10;
            int lineY = 30;
            int RectY = 0;
            int RectX = 60;
            for (int i = 0; i < Count; i++)
            {
                //текст
                TextBlock textBlock = new TextBlock();
                textBlock.Text = Text;
                textBlock.FontSize = 14;
                Canvas.SetLeft(textBlock, 10);
                Canvas.SetTop(textBlock, textSetTop);
                canvas.Children.Add(textBlock);
                //линия 
                Line line = new Line();
                line.Stroke = Brushes.Black;
                line.X1 = 0;
                line.Y1 = lineY;
                line.X2 = ActualWidth;
                line.Y2 = lineY;
                canvas.Children.Add(line);
                //прямоугольник
                // Вычисляем координаты и размеры прямоугольника
                double x = RectX;
                double y = RectY;
                double width = 60;
                double height = 30;
                // Создаем и настраиваем прямоугольник
                var rect = new System.Windows.Shapes.Rectangle();
                rect.Fill = Brushes.Red;
                rect.Width = width;
                rect.Height = height;
                Canvas.SetLeft(rect, x);
                Canvas.SetTop(rect, y);
                canvas.Children.Add(rect);
                textSetTop += 30;
                lineY += 30;
                RectY += 30;
                RectX += 70;
            }
        }
    }
}
