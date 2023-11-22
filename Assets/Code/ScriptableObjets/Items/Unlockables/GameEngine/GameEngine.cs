using System.Collections.Generic;
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

    //TO DO: Add developemt time reduction for these features that are developed in engine
    //Engine us used to cutdown development of basic functions and features by 60%
    //Efficency needs to be redjusted by employess skill adverge skill level who worked on it.
    //[SerializeField] private float Efficency = 1f;
    //[SerializeField] private float MaxEfficency = 60f;
    public float GetEngineEfficency(Employee[] skills)
    {
        float AISkill = 0f;
        float GraphicsSkill = 0f;
        float SoundSkill= 0f;
        float RennderSkill= 0f;
        float phuycisSkil = 0f;

        foreach (var item in skills)
        {
            

        }
    }

    public float RoyalityFeee { get { return royalityShare; } set { royalityShare = value; } }
    public float DevLicenceFee { get { return devLicenceFee; } set { devLicenceFee = value; } }
    public bool InHouse { get { return inHouse; } set { inHouse = value; } }
    public bool IsOwned { get { return isOwned; } set { isOwned = value; } }

    public LockResearchables SelectAIFeature(int index, LockResearchables[] features)
    {
        if (index > features.Length || index < 0)
        {
            Debug.LogError("Selected Feature index is : " + index + " is out of array");
            //TO DO: Handle Error Execption
            return null;
        }
        return features[index];
    }

}


