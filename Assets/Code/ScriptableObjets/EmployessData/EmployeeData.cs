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
    [SerializeField] private Employee[] employeePrefabs;
  
    public float SoundStat {  get { return soundiSkill.GetSkill; }  }
    public float GraphicsStat { get { return graphicsSkill.GetSkill; }  } 
    public float ProgrammingStat { get { return programmingSkill.GetSkill; }  }
    public float AiSkill { get { return aiSkill.GetSkill; }  }
    public float PhysicsSkill { get { return physicsSkill.GetSkill; } }
    public bool IsCEO { get { return isCEO; } set { isCEO = value; } }
    public Employee EmployeePrefabs { get {  return employeePrefabs[Random.Range(0, employeePrefabs.Length)]; } }


}