using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    #region Fields
    private float dayTimer;
    private int week =1;
    private int month = 1;
    private int year = 1976;

    #endregion

    #region Getter Setters
    public float DayTimer { get { return dayTimer; } set { dayTimer = value; } }
    public int Week { get { return week; } set { week = value; } }
    public int Month { get { return month; } set { month = value; } }
    public int Year { get { return year; } set { year = value; } }
    #endregion

    #region Events
    public static event Action EventWeekPassed;
    public static event Action EventMonthPassed;
    public static event Action EventYearPassed;
   
    public static event Action<float> EventRatioToWeek;
    public static event Action<bool> EventNotifUnlock;
    public static event Action<int, int> EventTimePassed;
    #endregion
    public void Update()
    {
        //Game is paused no need to increment time
        if (GameManager.IsGamePaused)
            return;



        dayTimer += Time.deltaTime;

        if(dayTimer >= 6f)
        {
            week++;
            if(week > 4)
            {
                //Increment Month
                month++;
                //Reset Week
                week = 1;
                if(month > 12) 
                {
                    //Reset month
                    month = 1;
                    //Increment month.
                    year++;
                    //Invoke event that year is passed
                    EventYearPassed?.Invoke();
                }
                //Invoke event that Month has passed
                EventMonthPassed?.Invoke();
            }
            //Reset timer
            dayTimer = 0;
            //Invoke event that 
            EventWeekPassed?.Invoke();
            //Invoke event that month or year is passed
            EventTimePassed?.Invoke(month, year);
            //Get UI Precent Ratio for weeks for UI
            EventRatioToWeek?.Invoke(GetPerWeekPrecent());
            //TO DO: Add settings to check if setting is true or false for notifiying player.
            EventNotifUnlock?.Invoke(false);
        }
        
    }

    private float GetPerWeekPrecent()
    {
        return dayTimer /6f;
    }
}

