using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockResearchables : BaseItem, ITimeLock, IResearchable
{
    #region Fields

    [SerializeField] private Sprite icon;
    [SerializeField] private bool isResearched = false;

    [SerializeField] private float researchPoints = 100;
    [SerializeField] private float researchLeft; 

    [SerializeField] private int unlockYear;
    [SerializeField] private int unlockMonth;
    [SerializeField] private bool isLocked = true;
    [SerializeField] private bool alreadyUnlocked = false;
    #endregion

    #region Getters Setters
    public bool IsLocked { get { return isLocked; }  private set { isLocked = value; EventUnlockedForResearch?.Invoke(this); } }
    public bool IsResearched { get { return isResearched; } private set { isResearched = value; EventResearchComplete?.Invoke(this); } }

    public int UnlockYear { get {  return unlockYear; } }  
    public int UnlockMonth { get {  return unlockMonth; } }

    public bool AlreadyUnlocked { get { return alreadyUnlocked; } }

    #endregion

    #region Events
    public static Action<LockResearchables> EventUnlockedForResearch;

    public static Action<LockResearchables> EventResearchComplete;
    #endregion

    #region OnEnabled
    private void OnEnable()
    {
        TimeManager.EventTimePassed += Unlock;
    }


    #endregion


    public void Research(float amount)
    {
        if (!CanResearch())
        {
            return;
        }
        researchLeft += amount;
        if(researchLeft >= researchPoints)
        {
            
            ResearchComplete();
        }
    }
    //Dev optoion only : Set this to be already researched
    public void ResearchComplete()
    {
        researchLeft = researchPoints;
        IsResearched = true;
    }
    //Dev optoion only : Set this to be researched
    public void ResetResearch()
    {
        IsResearched = false;
        researchLeft = 0;
    }
    //Can we research this?
    public bool CanResearch()
    {
        if(!IsResearched && !IsLocked)
        {
            return true;
        }
        return false;
    }

    //Unlock this by time so we can research it
    public void Unlock(int year, int month)
    {
        if(CanUnlock())
        {
            IsLocked = false;
        }
    }
    //Lock this feature 
    //NOTE TO SELF: If we lock after unlock date, we can never unlock it again.
    public void Lock()
    {
        isLocked = true;
    }

    private bool CanUnlock()
    {
        return IsLocked == true;
    }

}
