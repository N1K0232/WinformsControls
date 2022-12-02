namespace WinformsControls;

/// <summary>
/// represents a digital clock control
/// </summary>
public partial class Clock : UserControl
{
    private TimeOnly _currentTime; //the current time

    private int _currentSecond = 0; //the current second
    private int _currentMinute = 0; //the current minute
    private int _currentHour = 0; //the current hour


    /// <summary>
    /// creates a new instance of the <see cref="Clock"/> class
    /// </summary>
    public Clock()
    {
        InitializeComponent();
    }


    protected override void OnLoad(EventArgs e)
    {
        //gets the current Utc time from a DateTime
        _currentTime = TimeOnly.FromDateTime(DateTime.UtcNow);

        _currentSecond = _currentTime.Second; //sets the currentSecond field
        _currentMinute = _currentTime.Minute; //sets the currentMinute field
        _currentHour = _currentTime.Hour; //sets the currentHour field

        timerClock.Enabled = true; //enables the timer

        base.OnLoad(e);
    }

    /// <summary>
    /// during every tick of the timer the time is updated and the text of the label is updated
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Timer_OnTick(object sender, EventArgs e)
    {
        _currentSecond++;

        if (_currentSecond == 60)
        {
            _currentSecond = 0;
            _currentMinute++;
        }

        if (_currentMinute == 60)
        {
            _currentMinute = 0;
            _currentHour++;
        }

        if (_currentHour == 24)
        {
            _currentHour = 0;
        }

        TimeOnly updatedTime = new(_currentHour, _currentMinute, _currentSecond);
        lblClock.Text = updatedTime.ToLongTimeString();
    }
}