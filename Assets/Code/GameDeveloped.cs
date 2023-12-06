using System;
using System.Collections.Generic;

[Serializable]
public class GameDeveloped
{
    /// <summary>
    /// Name of game
    /// </summary>
    private string gameTitle;
    private string gameDesctiption;
    private Genres primaryGenre;
    private Genres secondaryGenre;
    private ThemeTopic primaryTopic;
    private ThemeTopic secondaryTopic;
    private bool isOnMarket = true;
    private float devCosts;
    private float totalDevTime;
    private float profitMade = 0;
    private ProjectSize gameSize;
    private ProjectGameType gameType;
    private int freeUpdates;
    private List<GameAddons> gameAddons = new List<GameAddons>();
    private List<GameDeveloped> sequels = new List<GameDeveloped>();
    private float ipRating;
    private TargetAudence audence;
 

}