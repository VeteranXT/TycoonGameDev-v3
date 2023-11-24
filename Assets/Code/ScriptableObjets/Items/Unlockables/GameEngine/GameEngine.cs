using System;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;


[CreateAssetMenu(fileName = "New Game Engine", menuName = "Features/New Game Engine")]
public class GameEngine : TimeLockables
{
    [SerializeField] private EngineSoundFeatres[] soundFeatures;
    [SerializeField] private EngineAIFeatres[] aIFeatures;
    [SerializeField] private EngineGraphicsFeatres[] graphicsFeatures;
    [SerializeField] private EngineRenderFeatres[] renderFeatures;
    [SerializeField] private EnginePhysicsFeatres[] physicsFeatures;
    [SerializeField] private GameplayFeatures[] basicFeatures;
    [SerializeField] private float royalityShare = 0f;
    [SerializeField] private float devLicenceFee = 0f;
    [SerializeField] private bool inHouse = false;
    [SerializeField] private bool isOwned = false;
    [SerializeField] private int devKitCost = 1000;
    [SerializeField] private float efficency = 0f;
    [SerializeField] private float maxEfficency = 0.6f;

    public float  GetEfficency { get { return efficency; } private set { efficency = value; } }

    public void SetEfficency(List<Employee> employees)
    {
    } 

    public float RoyalityFeee { get { return royalityShare; } set { royalityShare = value; } }
    public float DevLicenceFee { get { return devLicenceFee; } set { devLicenceFee = value; } }
    public bool InHouse { get { return inHouse; } set { inHouse = value; } }
    public bool IsOwned { get { return isOwned; } set { isOwned = value; } }

   

    

}


