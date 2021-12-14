using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapTimeManager : MonoBehaviour {

    private int MinuteCount=0;
    private int SecCount=0;
    private int Hour=0;
    private int Milisecond=0;
    public int Hour1
    {
        get
        {
            return Hour;
        }

        set
        {
            Hour = value;
        }
    }

    public int SecCount1
    {
        get
        {
            return SecCount;
        }

        set
        {
            SecCount = value;
        }
    }

    public int MinuteCount1
    {
        get
        {
            return MinuteCount;
        }

        set
        {
            MinuteCount = value;
        }
    }

    public void SetTime(int sec,int minute,int hour)
    {
        SecCount1 = sec;
        MinuteCount1 = minute;
        Hour1 = hour;
    }
    public string GetTime()
    {
        string time="";
        if(Hour1<10)
        {
            time += "0" + Hour1+":";
        }
        else
        {
            time += Hour1 + ":";
        }

        if( MinuteCount1 < 10)
        {
            time += "0" + MinuteCount1 + ":";
        }
        else
        {
            time += MinuteCount1 + ":";
        }

        if (SecCount1 < 10)
        {
            time += "0" + SecCount1;
        }
        else
        {
            time += SecCount1;
        }
        return time;
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.deltaTime>0)
        {
            Milisecond += 1;
        }
        if (Milisecond >= 60)
        {
            Milisecond = 0;
            SecCount1 += 1;
        }
        if (SecCount1 >= 60)
        {
            SecCount1 = 0;
            MinuteCount1 += 1;
        }
        if (MinuteCount1 == 60)
        {
            Hour1 += 1;
            MinuteCount1 = 0;
        }

    }
}
