using UnityEngine;

public class EmployeeData : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private CharacterStat soundiSkill = new CharacterStat(Random.Range(8, 15));
    [SerializeField] private CharacterStat graphicsSkill = new CharacterStat(Random.Range(8, 15));
    [SerializeField] private CharacterStat programmingSkill = new CharacterStat(Random.Range(8, 15));
    [SerializeField] private CharacterStat aiSkill = new CharacterStat(Random.Range(8, 15));
    [SerializeField] private CharacterStat physicsSkill = new CharacterStat(Random.Range(8, 15));
    [SerializeField] private bool isCEO = false;

    public CharacterStat SoundStat {  get { return soundiSkill; } set {  soundiSkill = value; } }
    public CharacterStat GraphicsStat { get { return graphicsSkill; } set {  graphicsSkill = value; } } 
    public CharacterStat ProgrammingStat { get { return programmingSkill; } set {  programmingSkill = value; } }
    public CharacterStat AiSkill { get { return aiSkill; } set { aiSkill = value; } }
    public bool IsCEO { get { return isCEO; } set { isCEO = value; } }

}