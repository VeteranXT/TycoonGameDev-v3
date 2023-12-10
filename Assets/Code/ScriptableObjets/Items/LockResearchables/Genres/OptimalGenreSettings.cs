using UnityEngine;

[CreateAssetMenu]
public class OptimalGenreSettings : ScriptableObject
{
    [SerializeField] private TargetAudence audence;
    [SerializeField,Range(0,10)] private int gameLength = 0;
    [SerializeField, Range(0, 10)] private int gamedepth = 0;
    [SerializeField, Range(0, 10)] private int accessibility = 0;
    [SerializeField, Range(0, 10)] private int innovation = 0;

    [SerializeField, Range(0, 10)] private int storyline = 0;
    [SerializeField, Range(0, 10)] private int characterDesign = 0;
    [SerializeField, Range(0, 10)] private int levelDesign = 0;
    [SerializeField, Range(0, 10)] private int missionDesign = 0;

    [SerializeField, Range(0, 10)] private int cruelty = 0;
    [SerializeField, Range(0, 10)] private int difficulty = 0;
    [SerializeField, Range(0, 10)] private int hardCore = 0;

    public int GetGameLegnth { get { return gameLength; } }
    public int GetGameDepth { get {  return gamedepth; } }
    public int GetAccessibility { get { return accessibility; } }
    public int GetInnovation { get { return innovation; } }
    public int GetStoryline { get { return storyline; } }
    public int GetCharacterDesign { get {  return characterDesign; } }
    public int GetLevelDesign { get { return levelDesign; } }
    public int GetMissionDesign { get { return missionDesign; } }
    public int GetCruelty { get {  return cruelty; } }
    public int GetDifficulty { get {  return difficulty; } }
    public int GetHardCore { get {  return hardCore; } }

    public TargetAudence GetAudence { get { return audence; } }
        
}