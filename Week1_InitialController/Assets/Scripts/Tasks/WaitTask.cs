using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitTask : Task
{
    // Get the timestamp in floating point milliseconds from the Unix epoch   
    private static readonly System.DateTime UnixEpoch = new System.DateTime(1970, 1, 1);

    private static double GetTimestamp()
    {
        return (System.DateTime.UtcNow - UnixEpoch).TotalMilliseconds;
    }

    private readonly double _duration; //how long does this wait for
    private double _startTime; //when did we start waiting

    public WaitTask(double duration)
    {
        this._duration = duration;
    }

    protected override void Init()
    {
        _startTime = GetTimestamp();
    }

    internal override void Update()
    {
        var now = GetTimestamp(); //use var for a) less typing, b) if it changes from float, to int, to double, etc.
        var durationElapsed = (now - _startTime) > _duration;

        if (durationElapsed)
        {
            SetStatus(TaskStatus.Success);
        }
    }
}