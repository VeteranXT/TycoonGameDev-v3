using UnityEngine;

[System.Serializable]
public class CharacterStat
{
    private float skill = UnityEngine.Random.Range(9,17);
    private float maxSkill = 100;

    public float GetSkill { get { return skill; } set { skill = value; } }
    public float GetMaxSkill { get { return maxSkill; } }   

    public float GetRatio { get { return skill/ maxSkill; } }
    public CharacterStat (float skill, float maxSkill = 100)
    {
        this.skill = skill;
        this.maxSkill = maxSkill;
    }
    public void SetSkill(float skill)
    {
        this.skill = skill;
    }
    public void Learn(float skill, float efficency)
    {
        if (CanLearn())
        {
            this.skill += skill * efficency;
        }
    }
    private bool CanLearn()
    {
        return skill < maxSkill;
    }

}