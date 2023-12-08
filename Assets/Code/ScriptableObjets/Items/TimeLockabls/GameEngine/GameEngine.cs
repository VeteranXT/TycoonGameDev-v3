using System;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;


[CreateAssetMenu(fileName = "New Game Engine", menuName = "Features/New Game Engine")]
public class GameEngine : TimeLockables
{
    [SerializeField] private float royalityShare = 0f;
    [SerializeField] private float devLicenceFee = 0f;
    [SerializeField] private bool inHouse = false;
    [SerializeField] private bool isOwned = false;
    [SerializeField] private int devKitCost = 1000;
    [SerializeField] private float efficency = 0f;
    [SerializeField] private float maxEfficency = 0.6f;
    [SerializeField] private List<EngineSoundFeatres> soundFeatures;
    [SerializeField] private List<EngineAIFeatres> aIFeatures;
    [SerializeField] private List<EngineGraphicsFeatres> graphicsFeatures;
    [SerializeField] private List<EnginePhysicsFeatres> physicsFeatures;
    [SerializeField] private List<EngineRenderFeatres> renderFeatures;
    [SerializeField] private List<GameplayFeatures> basicFeatures;
    [SerializeField] private int selectedAudioIndex;
    [SerializeField] private int selectedAIindex;
    [SerializeField] private int selectedGraphicsIndex;
    [SerializeField] private int selectedPhysicsIndex;
    [SerializeField] private int selectedRenderIndex;



    public void SetEngineAudio(int audio)
    {
        selectedAudioIndex = audio;
    }
    public void SetEngineAI(int AI)
    {
        selectedAIindex = AI;
    }
    public void SetGraphicsIndex(int index)
    {
        selectedGraphicsIndex = index;
    }
    public void SetPhysicsIndex(int index)
    {
        selectedPhysicsIndex = index;
    }

    public void SetRenderIndex(int index)
    {
        selectedAIindex = index;
    }
    public float GetTotalDevPoints()
    {
        float totalDevPoints = 0f;
        totalDevPoints += soundFeatures[selectedAudioIndex].DevelopTimeNeeded;
        totalDevPoints += aIFeatures[selectedAIindex].DevelopTimeNeeded;
        totalDevPoints += graphicsFeatures[selectedGraphicsIndex].DevelopTimeNeeded;
        totalDevPoints += physicsFeatures[selectedPhysicsIndex].DevelopTimeNeeded;
        totalDevPoints += renderFeatures[selectedRenderIndex].DevelopTimeNeeded;

        foreach (var feature in basicFeatures)
        {
            totalDevPoints += feature.DevelopTimeNeeded;
        }

        totalDevPoints *= GetEfficency;
        return totalDevPoints;
    }


    public float  GetEfficency { get { return efficency; } private set { efficency = value; } }


    public void AddGamePlayFeaturesToDevelop(GameplayFeatures feature)
    {
        if(feature !=  null && !basicFeatures.Contains(feature))
        {
            basicFeatures.Add(feature);
        }
    }

    public void RemoveGameplayFeature(GameplayFeatures feature)
    {
        if (feature != null && basicFeatures.Contains(feature))
        {
            basicFeatures.Remove(feature);
        }
    }
    public float RoyalityFeee { get { return royalityShare; } set { royalityShare = value; } }
    public float DevLicenceFee { get { return devLicenceFee; } set { devLicenceFee = value; } }
    public bool InHouse { get { return inHouse; } set { inHouse = value; } }
    public bool IsOwned { get { return isOwned; } set { isOwned = value; } }

    public void SetEfficency(List<Employee> employees)
    {
        //TO DO: Calcualte efficency 
    }



}


