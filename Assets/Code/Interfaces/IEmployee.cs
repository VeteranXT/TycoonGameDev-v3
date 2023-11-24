using System.Threading.Tasks;

public enum EmployeeSate
{
    Idle,
    Working,
    Break,
    GoingToFullfillNeed,
    FullfilingNeeed,
    GoingBackToDesk,
    NotAssignedToRoom

}
public interface IEmployee
{
    public string FirstName { get; }
    public float GetWage { get; }
    void DoTask();

    void DoNeed();

    // TO DO Add more like human things.
    //GO to batroom
    //Drink coffee
    //Print documents
    //Chatter with collegues
    //Manage stress
    //Ask for salary rise
    //Quit job
    //Ask for Vacation
    //Ask for Snacks funds
    //etc...
}