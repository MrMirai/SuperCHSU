using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MVVM;
using MVVM.Commands;

namespace CSLB5.CustomControls;

public class CustomCalendarControl : Control
{
    static CustomCalendarControl()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomCalendarControl), new FrameworkPropertyMetadata(typeof(CustomCalendarControl)));
    }

    public static readonly DependencyProperty SelectionModeProperty = DependencyProperty.Register(
        nameof(SelectionMode), typeof(CalendarSelectionMode), typeof(CustomCalendarControl), new PropertyMetadata(default(CalendarSelectionMode)));
    public CalendarSelectionMode SelectionMode
    {
        get => (CalendarSelectionMode) GetValue(SelectionModeProperty);
        set => SetValue(SelectionModeProperty, value);
    }
    
    public static readonly DependencyProperty SetSelectModeToSingleCommandProperty = DependencyProperty.Register(
        nameof(SetSelectModeToSingleCommand), typeof(ICommand), typeof(CustomCalendarControl), new PropertyMetadata(default(ICommand)));
    public ICommand SetSelectModeToSingleCommand
    {
        get => (ICommand) GetValue(SetSelectModeToSingleCommandProperty);
        set => SetValue(SetSelectModeToSingleCommandProperty, value);
    }

    public static readonly DependencyProperty SetSelectModeToRangeCommandProperty = DependencyProperty.Register(
        nameof(SetSelectModeToRangeCommand), typeof(ICommand), typeof(CustomCalendarControl), new PropertyMetadata(default(ICommand)));
    public ICommand SetSelectModeToRangeCommand
    {
        get => (ICommand) GetValue(SetSelectModeToRangeCommandProperty);
        set => SetValue(SetSelectModeToRangeCommandProperty, value);
    }
}