
//Interfece that represnet that this objects can be researched
using Newtonsoft.Json.Bson;

public interface IResearchable
{
   
    public bool IsResearched { get; }
    public int UnlockYear { get; }
    public int UnlockMonth { get; }
    void Research(float amount);
    void ResearchComplete();
    bool CanResearch();
    void ResetResearch();
}