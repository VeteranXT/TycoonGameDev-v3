using UnityEngine;

public class Employee : MonoBehaviour, IEmployee
{
    private CharacterStat soundiSkill = new CharacterStat(Random.Range(8, 15));
    private CharacterStat graphicsSkill = new CharacterStat(Random.Range(8, 15));
    private CharacterStat programmingSkill = new CharacterStat(Random.Range(8, 15));
    private CharacterStat aiSkill = new CharacterStat(Random.Range(8, 15));
    private CharacterStat physicsSkill = new CharacterStat(Random.Range(8, 15));

    private string firstName = "Joe";

    public float salaryWage = 1_000;
    public float GetWage {get { return salaryWage; } set { salaryWage = value; } }


    public void Setup(EmployeeData data)
    {

    }
    public void Setup(string name,float soundiSkill, float  graphicsSkill, float programmingSkill, float aiSkill, float physicsSkill)
    {
        this.firstName = name;
        this.soundiSkill.SetSkill(soundiSkill);
        this.graphicsSkill.SetSkill(graphicsSkill);
        this.programmingSkill.SetSkill(programmingSkill);
        this.aiSkill.SetSkill(aiSkill);
        this.physicsSkill.SetSkill(physicsSkill);
    }
    public string FirstName { get { return firstName; } }
    public void Develop(TaskDevelop develop)
    {
        throw new System.NotImplementedException();
    }
    public void AddSlarayRise(float amount)
    {
        salaryWage += amount;
    }
    public void Learn(CharacterStat skill, float amount,float eff)
    {
        skill.Learn(amount, eff);
    }

    public void MarketProdurct(TaskAddHype addHype)
    {
        throw new System.NotImplementedException();
    }

    public void PayWage()
    {
        throw new System.NotImplementedException();
    }

    public void Learn(CharacterStat skill, float amount)
    {
        throw new System.NotImplementedException();
    }
}