using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TaskDevelopGame : TaskDo
{
    private string gameDescription;
    private string gameName;    
    private Genres primaryGenre;
    private Genres secondaryGenre;
    private ThemeTopic primaryTopic;
    private ThemeTopic secondaryTopic;
    private EngineAIFeatres gameAIFeature;
    private EngineGraphicsFeatres gameGraphicsFeature;
    private EnginePhysicsFeatres gamePhysicsFeature;
    private EngineRenderFeatres engineRenderFeatres;
    private EngineSoundFeatres engineSoundFeatres;
    private GameEngine engineSelected;
    private ProjectSize projectSize;
    private List<GameplayFeatures> notDevelopedFeaturesList;
    public event Action<GameDeveloped> EventGameDeveloping;

    public Genres PrimaryGenre { get { return primaryGenre; } private set { primaryGenre = value; } }
    public Genres SecondaryGenre { get { return secondaryGenre; } private set { secondaryGenre = value; } }
    public ThemeTopic PrimaryTopic { get { return primaryTopic; } private set { primaryTopic = value; } }
    public ThemeTopic SecondaryTopic { get { return secondaryTopic; } private set { secondaryTopic = value; } }
    public ProjectSize ProjectSize { get { return projectSize; } private set { projectSize = value; } }
    public List<GameplayFeatures> SelectedFeatures { get { return notDevelopedFeaturesList; } private set { notDevelopedFeaturesList = value; } }
    public EngineAIFeatres SetAIEngineFeature { get { return gameAIFeature; } private set { gameAIFeature = value; } }
    public EngineGraphicsFeatres SetEngineGraphicsFeatres { get { return gameGraphicsFeature; } private set { gameGraphicsFeature = value; } }
    public EnginePhysicsFeatres SetEnginePhysicsFeatres { get { return gamePhysicsFeature; } private set { gamePhysicsFeature = value; } }
    public EngineRenderFeatres SetEngineRenderFeatres { get { return engineRenderFeatres; } private set { engineRenderFeatres = value; } }
    public EngineSoundFeatres SetSoundEngineFeature { get { return engineSoundFeatres; } private set { engineSoundFeatres = value; } }
    public GameEngine SetEngineSelected { get { return engineSelected; } private set { engineSelected = value; } }

    public void AddFeaturesNotInEngie(GameplayFeatures features)
    {
        SelectedFeatures.Add(features);
    }

    public void RemoveFeaturesNotInEngine(GameplayFeatures features)
    {
        SelectedFeatures.Remove(features);
    }

    public void SelectPrimartyGenre(Genres primary)
    {
        PrimaryGenre = primary;
    }
    public void RemovePrimartyGenre()
    {
        PrimaryGenre = null;
    }
    public void SelectSecondaryGenre(Genres secondary)
    {
        SecondaryGenre = secondary;
    }
    public void RemoveSecondaryGenre()
    {
        SecondaryGenre = null;
    }
    public void SelectPrimartyTheme(ThemeTopic primary)
    {
        PrimaryTopic = primary;
    }
    public void RemovePrimartyTheme()
    {
        PrimaryTopic = null;
    }
    public void SelectSecondaryTheme(ThemeTopic secondary)
    {
        SecondaryTopic = secondary;
    }
    public void RemoveSecondaryTheme()
    {
        SecondaryTopic = null;
    }

    public void SetProjectSize(ProjectSize size)
    {
        ProjectSize = size;
    }

    public float CalculateTotalDevWork()
    {
        //TO DO
        return 0f;
    }



}