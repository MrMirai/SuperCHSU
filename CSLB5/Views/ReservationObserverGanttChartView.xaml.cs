using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CSLB5.Views;

public partial class ReservationObserverGanttChartView : UserControl
{
    public ReservationObserverGanttChartView()
    {
        InitializeComponent();
        AddTimeScaleItems();
        //AddTaskTypes();
    }

    private void AddTimeScaleItems()
    {
        for (int i = 0; i < 24; i++)
        {
            TextBlock timeText = new TextBlock
            {
                Text = $"{i}:00",
                Width = 40,
                FontWeight = FontWeight.FromOpenTypeWeight(700),
                TextAlignment = TextAlignment.Center
            };
            TimeScale.Items.Add(timeText);
        }
    }

    //private void AddTaskTypes()
    //{
    //    string[] taskTypes = { "Task Type 1", "Task Type 2", "Task Type 3" };

    //    foreach (var taskType in taskTypes)
    //    {
    //        TextBlock task = new TextBlock
    //        {
    //            Text = taskType,
    //            FontWeight = FontWeight.FromOpenTypeWeight(700),
    //            TextAlignment = TextAlignment.Center
    //        };
    //        TaskTypes.Items.Add(task);
    //    }
    //}

}