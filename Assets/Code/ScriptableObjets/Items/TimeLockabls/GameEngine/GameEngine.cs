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
    [SerializeField] private List<EngineSoundFeatres> soundFeatures = new List<EngineSoundFeatres>();
    [SerializeField] private List<EngineAIFeatres> aIFeatures = new List<EngineAIFeatres>();
    [SerializeField] private List<EngineGraphicsFeatres> graphicsFeatures = new List<EngineGraphicsFeatres>();
    [SerializeField] private List<EnginePhysicsFeatres> physicsFeatures = new List<EnginePhysicsFeatres>();
    [SerializeField] private List<EngineRenderFeatres> renderFeatures = new List<EngineRenderFeatres>();
    [SerializeField] private List<GameplayFeatures> basicFeatures = new List<GameplayFeatures>();

    public EngineSoundFeatres SoundFeature(int Index)
    {
        return soundFeatures[Index];
    }

    public EngineAIFeatres AIFeature(int Index)
    {
        return aIFeatures[Index];
    }
    public EngineGraphicsFeatres GraphicsFeature(int Index)
    {
        return graphicsFeatures[Index];
    }
    public EnginePhysicsFeatres PhysicsFeature(int Index)
    {
        return physicsFeatures[Index];
    }
    public EngineRenderFeatres RenderFeature(int Index)
    {
        return renderFeatures[Index];
    }
    public float GetDevPoints()
    {
        float totalDevPoints = 0f;


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


