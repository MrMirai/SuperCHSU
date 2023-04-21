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
using static System.Net.Mime.MediaTypeNames;

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
    ///     <MyNamespace:ScheduleTable/>
    ///
    /// </summary>
    public class ScheduleTable : Control
    {
        static ScheduleTable()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ScheduleTable), new FrameworkPropertyMetadata(typeof(ScheduleTable)));
        }

        private Grid table;
        protected override void OnRender(DrawingContext drawingContext)
        {
            table = Template.FindName("grid", this) as Grid;
            int k = 0;
            for (int d = 1; d <= 50; d++) {
                table.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

                var dayTextBlock = new TextBlock { Text = d.ToString() };
                dayTextBlock.Background = new SolidColorBrush(Colors.RosyBrown);
                Grid.SetRow(dayTextBlock, k);
                k++;
                table.Children.Add(dayTextBlock);

                for (int i = 0; i <= d % 4; i++)
                {
                    table.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                    var nestedTable = new Grid();
                    nestedTable.ColumnDefinitions.Add(new ColumnDefinition());
                    nestedTable.ColumnDefinitions.Add(new ColumnDefinition());
                    nestedTable.ColumnDefinitions.Add(new ColumnDefinition());

                    var lessonTextBlock = new TextBlock { Text = "Предмет" };
                    lessonTextBlock.Background = new SolidColorBrush(Colors.White);
                    Grid.SetColumn(lessonTextBlock, 0);
                    nestedTable.Children.Add(lessonTextBlock);

                    var startTextBlock = new TextBlock { Text = "Начало" };
                    Grid.SetColumn(startTextBlock, 1);
                    nestedTable.Children.Add(startTextBlock);

                    var endTextBlock = new TextBlock { Text = "Конец" };
                    Grid.SetColumn(endTextBlock, 3);
                    nestedTable.Children.Add(endTextBlock);

                    Grid.SetRow(nestedTable, k);
                    table.Children.Add(nestedTable);
                    k++;
                }
            }

        }
    }
}
