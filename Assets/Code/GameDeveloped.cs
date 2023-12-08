using System;
using System.Collections.Generic;

[Serializable]
public class GameDeveloped
{
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
    private bool isOnMarket = true;
    private float devCosts;
    private float totalDevTime;
    private float profitMade = 0;
    private int freeUpdates;
    private float ipRating;
    private TargetAudence audence;
 

}