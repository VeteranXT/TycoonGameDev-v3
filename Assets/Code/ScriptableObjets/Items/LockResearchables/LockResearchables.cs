using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockResearchables : BaseItem, ITimeLock, IResearchable
{
    #region Fields


    [SerializeField] private bool isResearched = false;

    [SerializeField] private float researchPoints = 100;
    [SerializeField] private float researchLeft; 

    [SerializeField] private int unlockYear;
    [SerializeField] private int unlockMonth;
    [SerializeField] private bool isLocked = true;
    [SerializeField] private bool alreadyUnlocked = false;
    #endregion

    #region Getters Setters

    /// <summary>
    /// Is locked by time aka tech that we can research
    /// </summary>
    public bool IsLocked { get { return isLocked; }  private set { isLocked = value; AlreadyUnlocked = true; EventUnlockedForResearch?.Invoke(this); } }
    /// <summary>
    /// Is already researched
    /// </summary>
    public bool IsResearched { get { return isResearched; } private set { isResearched = value; EventResearchComplete?.Invoke(this); } }

    /// <summary>
    /// What year this is going to be unlocked for research
    /// </summary>
    public int UnlockYear { get {  return unlockYear; } }  
    /// <summary>
    /// What month of year is going to be researched
    /// </summary>
    public int UnlockMonth { get {  return unlockMonth; } }
    /// <summary>
    /// Is player already notified that this is unlocked
    /// </summary>

    public bool AlreadyUnlocked { get { return alreadyUnlocked; } private set { alreadyUnlocked = value; } }
    /// <summary>
    /// How many points dose it need to research it
    /// </summary>
    public float ResearchPoints { get { return researchPoints; }}
    
    /// <summary>
    /// How many points we already did research
    /// </summary>
    public float ReserachPointsLeft { get { return researchLeft; } set { researchLeft = value; } }

    #endregion

    #region Events
    /// <summary>
    /// Event that notifies player that this reasearch is avalible to research
    /// </summary>
    public static Action<LockResearchables> EventUnlockedForResearch;
    /// <summary>
    /// Event that notifies UI that it needs to be removed form list and added to list of things to make
    /// </summary>

    public static Action<LockResearchables> EventResearchComplete;
    #endregion

    #region OnEnabled
    private void OnEnable()
    {
        //We check if its time to unlock by date. automaticly
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
        ReserachPointsLeft = ResearchPoints;
        IsResearched = true;
    }
    //Dev optoion only : Set this to be researched
    public void ResetResearch()
    {
        IsResearched = false;
        researchLeft = 0;
        alreadyUnlocked = false;
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
        if(!AlreadyUnlocked)
        {
            if (CanUnlock(year, month))
            {
                IsLocked = false;
                AlreadyUnlocked = true;
                TimeManager.EventTimePassed -= Unlock;
            }
        }
        
    }
    //Lock this feature 
    //NOTE TO SELF: If we lock after unlock date, we can never unlock it again.
    public void Lock()
    {
        IsLocked = true;
    }
    //Returns false if we are not reached time of year and this feature is already locked.
    private bool CanUnlock(int year, int month)
    {
        if (unlockYear >= year && (unlockMonth == month || unlockMonth <= month || unlockMonth >= month))
        {
            if(IsLocked)
            {
                return true;
            }
        }
        return false;
    }

}
