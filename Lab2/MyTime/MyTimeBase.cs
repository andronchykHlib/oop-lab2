namespace Lab2.MyTime;

public partial class MyTime
{
    // TODO: fix
    public int hour { get; private set; } 
    public int minute { get; private set; }
    public int second { get; private set; }
    
    public MyTime(int h, int m, int s)
    {
        bool isHoursNotApplicable = h >= 24 || h < 0;
        bool isMinutesNotApplicable = m >= 60 || m < 0;
        bool isSecondsNotApplicable = s >= 60 || s < 0;
        
        if (isHoursNotApplicable || isMinutesNotApplicable || isSecondsNotApplicable)
        {
            throw new ArgumentException("Incorrect time values.");
        }

        hour = h;
        minute = m;
        second = s;
    }
    
    private string AddZeroAtStartPos(int val)
    {
        return $"{val}".PadLeft(2, '0');
    }
    
    public override string ToString()
    {
        string minutes = AddZeroAtStartPos(minute);
        string seconds = AddZeroAtStartPos(second);

        return $"{hour}:{minutes}:{seconds}";
    }
}