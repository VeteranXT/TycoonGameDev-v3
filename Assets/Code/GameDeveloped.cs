using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[Serializable]
public class GameDeveloped
{
    #region Fields
    private string gameTitle;
    private string gameDesctiption;
    private Genres primaryGenre;
    private Genres secondaryGenre;
    private ThemeTopic primaryTopic;
    private ThemeTopic secondaryTopic;
    private ProjectSize gameSize;
    private ProjectGameType gameType;
    private List<TaskDoGameAdddon> gameAddons = new List<TaskDoGameAdddon>();
    private List<GameDeveloped> sequels = new List<GameDeveloped>();
    //How much this game costed when we made it...salaries and costs
    private float totaldevCosts;
    //How many years/months used to make a game
    private float totalDevTime;
    // How much money is made
    private float profitMade = 0;
    private float maxIpRating = 5f;
    //IP rating for extra sales?
    private float ipRating = 0;
    //How many free updates this game got.
    private int freeUpdates;
    //How many copies of this game was sold
    private int copiesSold = 0;
    //Is this game currently on market aka selling
    private bool isOnMarket = true;
    //Is this game sequel
    private bool isSequel = false;
    private TargetAudence audence;
    #endregion

    #region Getter Setters
    public int TotalCopiesSold { get { return copiesSold; } private set { copiesSold = value; } }
    public bool IsSequael { get { return isSequel; } }
    public TargetAudence Audence { get { return audence; } }
    public string GetGameName { get { return gameTitle; } }
    public string GameDescription { get { return gameDesctiption; } }
    public float TotaldevCosts { get { return totaldevCosts; } private set { totaldevCosts = value; } }
    public bool IsOnMarket { get { return isOnMarket; } private set { isOnMarket = value; } }
    public float TotalDevTime { get { return totalDevTime; } }
    public float ProfitMade { get {  return profitMade; } }
    public string PrimaryGenre { get { return primaryGenre.ItemName; } }
    public Sprite PrimaryGenreIcon { get { return primaryGenre.GetIcon; } }
    public string SecondaryGenre {  get { return secondaryGenre.ItemName; } }    
    public Sprite SecondatyGenreIcon { get { return secondaryGenre.GetIcon; } }
    public string PrimatyTheme { get { return primaryTopic.ItemName; } }
    public string SecondaryTheme { get { return secondaryTopic.ItemName; } }
    public int FreeUpdatesGot { get { return freeUpdates; } private set { freeUpdates = value; EventUpdateRecived?.Invoke(freeUpdates); }  }
    #endregion

    public event Action<int> EventUpdateRecived;
    public void AddCountOfFreeUpdates()
    {
        FreeUpdatesGot++;
    }
    public void AddIPRating(float rewiew, float rating)
    {
        if (rewiew < 5)
        {
            if (CanAddRating())
            {
                ipRating -= rating;
            }

        }
        if (rewiew > 5)
        {
            if (CanAddRating())
            {
                ipRating += rating;
            }
        }
        if (ipRating < 0)
        {
            ipRating = 0;
        }
        if (ipRating > maxIpRating)
        {
            ipRating = maxIpRating;
        }
    }
    public int CountSequals()
    {
        return sequels.Count;
    }
    public void RemoveFromMarket()
    {
        IsOnMarket = false;
    }
    public void AddCopiesSold(int sold)
    {
        copiesSold += sold;
    }
    public string GetAudenceFormat()
    {
        return Audence.ToString();
    }
    private bool CanAddRating()
    {
        if (ipRating <= maxIpRating)
        {
            return true;
        }
        return false;
    }

}