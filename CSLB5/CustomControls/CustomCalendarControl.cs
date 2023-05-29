using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CSLB5.CustomControls;

[TemplatePart(Name = CalendarName, Type = typeof(Calendar))]
[TemplatePart(Name = DayButtonName, Type = typeof(Button))]
[TemplatePart(Name = RangeButtonName, Type = typeof(Button))]

public class CustomCalendarControl : Control
{
    private Calendar _calendar;
    private Button _dayButton;
    private Button _rangeButton;
    private const string CalendarName = "PART_Calendar";
    private const string DayButtonName = "PART_DayButton";
    private const string RangeButtonName = "PART_RangeButton";
    static CustomCalendarControl()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomCalendarControl), new FrameworkPropertyMetadata(typeof(CustomCalendarControl)));

    }
    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        _calendar = Template.FindName(CalendarName, this) as Calendar;
        _dayButton = Template.FindName(DayButtonName, this) as Button;
        _rangeButton = Template.FindName(RangeButtonName, this) as Button;
        _dayButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E31E24"));
        _dayButton.Foreground = new SolidColorBrush(Colors.White);
        _calendar.SelectionModeChanged += OnSelectionModeChanged;
        _calendar.SelectedDatesChanged += OnSelectedDatesChanged;

    }

    public static readonly DependencyProperty SelectionModeProperty = DependencyProperty.Register(
        nameof(SelectionMode), typeof(CalendarSelectionMode), typeof(CustomCalendarControl), new PropertyMetadata(default(CalendarSelectionMode)));
    public CalendarSelectionMode SelectionMode
    {
        get => (CalendarSelectionMode)GetValue(SelectionModeProperty);
        set => SetValue(SelectionModeProperty, value);
    }

    public static readonly DependencyProperty SetSelectModeToSingleCommandProperty = DependencyProperty.Register(
        nameof(SetSelectModeToSingleCommand), typeof(ICommand), typeof(CustomCalendarControl), new PropertyMetadata(default(ICommand)));
    public ICommand SetSelectModeToSingleCommand
    {
        get => (ICommand)GetValue(SetSelectModeToSingleCommandProperty);
        set => SetValue(SetSelectModeToSingleCommandProperty, value);
    }

    public static readonly DependencyProperty SetSelectModeToRangeCommandProperty = DependencyProperty.Register(
        nameof(SetSelectModeToRangeCommand), typeof(ICommand), typeof(CustomCalendarControl), new PropertyMetadata(default(ICommand)));
    public ICommand SetSelectModeToRangeCommand
    {
        get => (ICommand)GetValue(SetSelectModeToRangeCommandProperty);
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


    public void OnSelectedDatesChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (_calendar.SelectionMode == CalendarSelectionMode.SingleDate)
        {
            SelectedDate = _calendar.SelectedDate;
        }
        if (_calendar.SelectionMode == CalendarSelectionMode.SingleRange)
        {
            SelectedDates = _calendar.SelectedDates;
        }
    }

    private void OnSelectionModeChanged(object? sender, EventArgs e)
    {
        if (_calendar.SelectionMode == CalendarSelectionMode.SingleDate)
        {
            _dayButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E31E24"));
            _dayButton.Foreground = new SolidColorBrush(Colors.White);
            _rangeButton.Background = new SolidColorBrush(Colors.White);
            _rangeButton.Foreground = new SolidColorBrush(Colors.Black);
        }
        if (_calendar.SelectionMode == CalendarSelectionMode.SingleRange)
        {
            _rangeButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E31E24"));
            _rangeButton.Foreground = new SolidColorBrush(Colors.White);
            _dayButton.Background = new SolidColorBrush(Colors.White);
            _dayButton.Foreground = new SolidColorBrush(Colors.Black);

        }
    }
}