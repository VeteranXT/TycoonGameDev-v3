
//Interfece that represnet that this objects can be researched
using Newtonsoft.Json.Bson;

public interface IResearchable
{
    public float ResearchPoints { get; }
    public float ReserachPointsLeft { get; set; }
    public bool IsResearched { get; }
    public int UnlockYear { get; }
    public int UnlockMonth { get; }
    void Research(float amount);
    void ResearchComplete();
    bool CanResearch();
    void ResetResearch();
}