using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class TimeLockables : BaseItem, ITimeLock
{
    private bool locked;
    private int unlockYear;
    private int unlockMonth;
    private bool alreadyUnlocked = false;
    public bool IsLocked { get { return locked; } set { locked = value; } }
    
    public int UnlockYear { get { return unlockYear; } set { unlockYear = value; } }

    public int UnlockMonth { get { return unlockMonth; } set { unlockMonth = value; } }

    public bool AlreadyUnlocked { get { return alreadyUnlocked; } set { alreadyUnlocked = value; } }

    private void OnEnable()
    {
        TimeManager.EventTimePassed += Unlock;
    }
    private bool CanUnlock()
    {
        return IsLocked == true;
    }

    public void Lock()
    {
        //Returns true of locked = false
       if (!CanUnlock())
       {
            IsLocked = true;
       }
    }

    public void Unlock(int year, int month)
    {
        if (!AlreadyUnlocked)
        {
            if (unlockYear == year && unlockMonth == month)
            {
                if (CanUnlock())
                {
                    IsLocked = true;
                    AlreadyUnlocked = true;
                }
            }
        }
       
      
    }
}

