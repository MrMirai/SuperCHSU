using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CSLB5.CustomControls;

[TemplatePart(Name = CalendarName, Type = typeof(Calendar))]
public class CustomCalendarControl : Control
{
    private Calendar _calendar;
    private const string CalendarName  = "PART_Calendar";
    static CustomCalendarControl()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomCalendarControl), new FrameworkPropertyMetadata(typeof(CustomCalendarControl)));
        
    }
    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        _calendar = Template.FindName(CalendarName, this) as Calendar;
        if(_calendar!=null)_calendar.SelectedDatesChanged+= Changed;
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

    public static readonly DependencyProperty SelectedDateProperty = DependencyProperty.Register(
        nameof(SelectedDate), typeof(DateTime?), typeof(CustomCalendarControl), new PropertyMetadata(default(DateTime?)));
    public DateTime? SelectedDate
    {
        get => (DateTime?)GetValue(SelectedDateProperty);
        set => SetValue(SelectedDateProperty, value);
    }

    public static readonly DependencyProperty SelectedDatesProperty = DependencyProperty.Register(
        nameof(SelectedDates), typeof(SelectedDatesCollection), typeof(CustomCalendarControl), new PropertyMetadata(default(SelectedDatesCollection)));
    public SelectedDatesCollection SelectedDates
    {
        get => (SelectedDatesCollection)GetValue(SelectedDatesProperty);
        set => SetValue(SelectedDatesProperty, value);
    }
    public void Changed(object? sender, SelectionChangedEventArgs e)
    {
        if(_calendar.SelectionMode== CalendarSelectionMode.SingleDate)
        {
            SelectedDate = _calendar.SelectedDate;
        }
        if (_calendar.SelectionMode == CalendarSelectionMode.SingleRange)
        {
            SelectedDates = _calendar.SelectedDates;
        }
    }
}