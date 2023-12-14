using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gameplay Feature", menuName = "Features/Gameplay Features/New Gameplay")]

public class GameplayFeatures : EngineFeature
{
    [SerializeField] private bool hasAdditionalGameplay = false;
    [SerializeField] private List<GameplayList> gameplayLists = new List<GameplayList>();

    public List<GameplayList> GetGameplayList { get { return gameplayLists; } }


    public float GetTotalDevPoints()
    {
        float total = 0;

        foreach (var item in gameplayLists)
        {
            total += item.DevelopTimeNeeded;
        }
        return total;
    }
}


//NOTE TO SELF!!


///Independant game play features 
//Classes/Counts
//Add Dungeons Count/Sizes
//Weather Effects
//Cheat Codes Count
//Level Editor
//Saving Passwords/Data?
//Pause Game
//Dynamic Economy
//Pet/Companion System
//Seasonal Events  (4 max)?? 
//Dynamic Soundtrack couns
//Quests Counts
//Side Quests/ counts
//Weapons types/counts per type
//Tutorial type/size
//Protagonits count
//Antagonist counts
//Endings count
//Cutscenes count
//NPC Factions
//Player Housing
//Barter Economy
//Player Trading
//loot items counts
//Mounts Count
//Strategy Resources count
//Day/Night Cycle Effects
//Clan/Guild Systems
//Teritory Clan Wars
//Leaderborads
//Achievement System count
//Desctuctable Combat environment 
//Character Customization Count
//Bosses count
//Furniture count
//Vehicles  connt (Sport racing transports?)

///Dependent
//Skill Trees/count (depended and multipiled on amount of classes)
//Weapon Skins (Depended on amount of types and how many weapons of that type)
//Endings Cutscenes count (Depends on endings count * Protagonits * Antagonist;
//BackStories count  = (Depends on * Protagonits * Antagonist)
//Character Relationships (Depends on Protagonists and Antagonists; affects dialogue and story)
//Bosses Abilites per boss
//Dynamic Story Branching (Dependent on Player Choices and Quest Outcomes)
//Dynamic Enemy Scaling (Dependent on Player Level and Progression)
//Seasonal Challenges (Dependent on Seasonal Events and Quests)
//Interactive NPCs (Dependent on NPC Factions and Player Actions)
