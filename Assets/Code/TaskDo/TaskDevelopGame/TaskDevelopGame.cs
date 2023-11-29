using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TaskDevelopGame : TaskDo
{
    //Placeholders for when game is finished so we know what we been making
    private string gameDescription;
    private string gameName;
    private Genres primaryGenre;
    private Genres secondaryGenre;
    private ThemeTopic primaryTopic;
    private ThemeTopic secondaryTopic;
    private TargetAudence targetAudence;
    //Stuff we actually use  to calcualte dev time
    private GameEngine engine;
    private ProjectSize projectSize;
    private ProjectGameType gameType;
    private List<GameplayFeatures> notDevelopedFeaturesList;
    private bool isInDevelopment = true;

    private List<IDevelop> ToDevelop = new List<IDevelop>();
    private float timeToDevelopPoints;

    private float developerPointsAccumulated = 0;

    public bool IsPolishing { get { return !IsDeveloping; } }
    public bool IsDeveloping { get { return isInDevelopment; } private set { isInDevelopment = value; } }
    #region Events

    public event Action<GameDeveloped> EventGameDeveloping;
    #endregion 


    public string GameTitle { get { return gameName; } set { gameName = value; } }
    public string GameDescription { get { return gameDescription; } set { gameDescription = value; } }
    public Genres PrimaryGenre { get { return primaryGenre; } private set { primaryGenre = value; } }
    public Genres SecondaryGenre { get { return secondaryGenre; } private set { secondaryGenre = value; } }
    public ThemeTopic PrimaryTopic { get { return primaryTopic; } private set { primaryTopic = value; } }
    public ThemeTopic SecondaryTopic { get { return secondaryTopic; } private set { secondaryTopic = value; } }
    public ProjectSize ProjectSize { get { return projectSize; } private set { projectSize = value; } }

    public float DeveopTimePoints { get { return timeToDevelopPoints; } private set { timeToDevelopPoints = value; } }
    public float GetTotalWorkRation { get { return developerPointsAccumulated / timeToDevelopPoints; } }

    //TO DO
    private int bugsCount;
    public List<GameplayFeatures> SelectedFeatures { get { return notDevelopedFeaturesList; } private set { notDevelopedFeaturesList = value; } }
 


    #region Setting To develop
    public void ChangeGameTitle(string title)
    {
        GameTitle = title;
    }
    public void ChangeGameDescription(string description)
    {
        GameDescription = description;
    }

    public void CutFeatures(GameplayFeatures features)
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

    public void AddFeaturesNotInEngie(GameplayFeatures features)
    {
        SelectedFeatures.Add(features);
    }

    #endregion


    
    private void CalculateTotalDevWork(GameEngine engine)
    {

        float totalDevWork = 0;
        if(engine != null)
        {
            totalDevWork += engine.GetTotalDevPoints();
        }
        else
        {
            Debug.LogError("Game Engine is not set in UI Properly!!");
        }
        if(notDevelopedFeaturesList  != null)
        {
            if (notDevelopedFeaturesList.Count > 0)
            {
                foreach (var feature in notDevelopedFeaturesList)
                {
                    totalDevWork += feature.DevelopTimeNeeded;
                }
            }
        }
        totalDevWork *= ProjectSize.SizeModifer;
        DeveopTimePoints = totalDevWork;
    }




    //Create instance of Task and assign it to Game room
    public TaskDevelopGame CreateNewGame(GameEngine enginem,string title, string description, Genres primGrene, Genres secGenre, ThemeTopic primTop, ThemeTopic secTop, ProjectSize size, Transform parent)
    {
        TaskDevelopGame NewTask = Instantiate(this, parent);
        NewTask.engine = enginem;
        NewTask.GameTitle = title;   
        NewTask.GameDescription = description;
        NewTask.PrimaryGenre = primGrene;
        NewTask.PrimaryTopic = primTop;
        NewTask.SecondaryGenre = secGenre;
        NewTask.SecondaryTopic = secTop;
        NewTask.ProjectSize = size;
        CalculateTotalDevWork(engine);
        return NewTask;
    }
  
    public override void AddDevPoints(float devPoints)
    {
        if (IsDeveloping)
        {
            if (devPoints > 0)
            {
                developerPointsAccumulated += devPoints;
                if (developerPointsAccumulated >= timeToDevelopPoints)
                {
                    IsDeveloping = false;
                    //SwitchTo PolishState
                    //TO DO:  Task Is compleated
                }
            }
        }
        else
        {
            //TO DO: Create Task PolishGame
        }
    }



}





