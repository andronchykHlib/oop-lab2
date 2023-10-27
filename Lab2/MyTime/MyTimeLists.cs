namespace Lab2.MyTime;

public partial class MyTime
{
    private List<int> _timetable = new() { 28800, 34800, 40800, 46800, 52800, 58800 };
    private Dictionary<string, int> _operations = new ()
    {
        { "second", 1 },
        { "minute", 60 },
        { "hour", 3600 },
    };
}
