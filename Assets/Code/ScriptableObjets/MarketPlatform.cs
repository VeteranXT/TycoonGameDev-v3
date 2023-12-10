
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MarketPlatform : ScriptableObject
{
    //how many gamers use this specific platform and how many we can sell games to them
    [SerializeField] private double activeUsers;
    [SerializeField] private bool hasMaxActiveUsersLimit = false;
    [SerializeField] private double maxActiveUsers = 500_000_000_000;
    //How much space we can use in KB 1024 = 1MB 1024MB = 1 TB 
    [SerializeField] private int maxWorkSpaceKB;
    [SerializeField] private bool isInfiniteWorkSpace = false;
    [SerializeField] private float FundingDiscount = 0f;
    [SerializeField] EngineAIFeatres supportedAI;
    [SerializeField] EngineGraphicsFeatres supportedGraphics;
    [SerializeField] EngineRenderFeatres supportedRender;
    [SerializeField] EngineSoundFeatres supportedSound;
    [SerializeField] EnginePhysicsFeatres supportedPhysics;
 
    public EngineAIFeatres GetSupportedAI { get { return supportedAI; } }
    public EngineGraphicsFeatres EngineGraphicsFeatres { get { return supportedGraphics; } }
    public EngineRenderFeatres EngineRender { get {  return supportedRender; } }
    public EngineSoundFeatres EngineSound { get { return supportedSound; } }
    public EnginePhysicsFeatres EnginePhysics { get {  return supportedPhysics; } }
    public double GetActiveUsers {  get { return activeUsers; } private set { activeUsers = value; } }
    public void AddActiveUsers(double activeUsers)
    {
        if(hasMaxActiveUsersLimit)
        {
            if(GetActiveUsers < maxActiveUsers)
            {
                this.GetActiveUsers += activeUsers;
                if(GetActiveUsers > maxActiveUsers)
                    GetActiveUsers = maxActiveUsers;
            }

        }
        else
            this.GetActiveUsers += activeUsers;
    }
}