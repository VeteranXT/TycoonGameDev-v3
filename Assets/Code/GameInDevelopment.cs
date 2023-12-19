using System;
using System.Collections.Generic;
using UnityEngine;
public enum TargetAudence
{
    All,
    Elder,
    Adult,
    Teen,
    Childern
}
[Serializable]
public class GameInDevelopment
{
    private string gameName;
    private GameInDevelopment lastSeaquel;
    private GameEngine engine;
    private List<GameplayFeatures> features = new List<GameplayFeatures>();
    private List<MarketPlatform> platformList = new List<MarketPlatform>();
    private Genres genre;
    private ThemeTopic topic;
    private Genres subGenre;
    private ThemeTopic subTopic;
    private ProjectGameType gameType;
    private int selectedAudioIndex;
    private int selectedAIindex;
    private int selectedGraphicsIndex;
    private int selectedPhysicsIndex;
    private int selectedRenderIndex;

    private bool isDevelopmentFinished = false;
    private float pointsAccumulated = 0;
    private int marketingHype = 0;
    private int overHype = 100;
    private int maxMarketingHype = 200;

    public event Action<GameInDevelopment> EventDevelopmentFinished; 
    public bool IsDevelopmentFinished { get { return isDevelopmentFinished; } private set { isDevelopmentFinished=value; } }
    public void AddDevPoints(float Points)
    {
        if(pointsAccumulated < GetTotalDevPoints())
        {
            pointsAccumulated += Points;
            if(pointsAccumulated > GetTotalDevPoints())
            {
                IsDevelopmentFinished = true;
                EventDevelopmentFinished?.Invoke(this);
            }
        }
    }


    public float GetTotalDevPoints()
    {
        float total = 0;
        total += engine.SoundFeature(selectedAudioIndex).DevelopTimeNeeded * engine.GetEfficency;
        total += engine.AIFeature(selectedAIindex).DevelopTimeNeeded * engine.GetEfficency;
        total += engine.GraphicsFeature(selectedGraphicsIndex).DevelopTimeNeeded * engine.GetEfficency;
        total += engine.PhysicsFeature(selectedPhysicsIndex).DevelopTimeNeeded * engine.GetEfficency;
        total += engine.PhysicsFeature(selectedRenderIndex).DevelopTimeNeeded * engine.GetEfficency;
        total += engine.GetDevPoints();
        return total;
    }
    public void AddMarketingHype(int amount)
    {
        if(CanAddMarketHype())
        {
            marketingHype += amount;
            if(marketingHype >= maxMarketingHype / 2)
            {
                marketingHype = maxMarketingHype;
            }
        }
    }
    private bool CanAddMarketHype()
    {
        if(marketingHype < maxMarketingHype / 2)
        {
            return true;
        }
        return false;
    }
    public bool CanOverHype()
    {
        if(marketingHype > 90)
        {
            return true;
        }
        return false;
    }
    public bool SubGenreMatchesWithGenre()
    {
        return subGenre.GetSecondaryGenreCombo(genre);
    }
    public bool TopicMatchesGenre()
    {
        return topic.MatchesWithGenre(genre);
    }
    public bool SubTopicMatchesGenre()
    {
        return subTopic.MatchesWithGenre(genre);
    }
    public bool HasSubTopic()
    {
        return subTopic != null;
    }
    public bool HasSubGenre()
    {
        return subGenre != null;
    }
}