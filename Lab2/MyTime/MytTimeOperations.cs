namespace Lab2.MyTime;

public partial class MyTime
{
    public int GetTimeSinceMidnight()
    {
        int secondsInHours = hour * 3600;
        int secondsInMinutes = minute * 60;

        return second + secondsInHours + secondsInMinutes;
    }

    public MyTime SetTimeSinceMidnight(int t)
    {
        hour = t / 3600;
        minute = t / 60 % 60;
        second = t % 60;

        if (hour >= 24)
        {
            hour = 0;
        }

        return this;
    }

    public MyTime AddSeconds(string operation)
    {
        if (_operations.ContainsKey(operation))
        {
            int newTime = GetTimeSinceMidnight() + _operations[operation];
            SetTimeSinceMidnight(newTime);
        }

        return this;
    }

    public MyTime AddSeconds(int s)
    {
        int newTime = GetTimeSinceMidnight() + s;
        int secondsInDay = 60 * 60 * 24;
        if (newTime < 0) {
            newTime = secondsInDay + newTime;
        }
        SetTimeSinceMidnight(newTime);

        return this;
    }

    public int Difference(MyTime time)
    {
        return GetTimeSinceMidnight() - time.GetTimeSinceMidnight();
    }
    
    public string WhatLesson()
    {
        int timeSinceMidnight = GetTimeSinceMidnight();
        int pairLength = 4800;

        for (int i = 0; i < _timetable.Count; i++)
        {
            int pair = _timetable[i];
            if (i == 0 && timeSinceMidnight < pair)
            {
                return "пари ще не почалися";
            }

            if (timeSinceMidnight >= pair && timeSinceMidnight <= pair + pairLength)
            {
                return $"{i + 1}-а пара";
            }

            if (timeSinceMidnight < pair)
            {
                return $"перерва між {i}-ю та {i + 1}-ю парами";
            }
        }

        return "пари вже кінчилися";
    }
}
