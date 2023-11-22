using System.Threading.Tasks;

public interface IEmployee
{
    public string FirstName { get; }
    public float GetWage { get; }
    void PayWage();
    void Learn(CharacterStat skill, float amount);

    void Develop(TaskDevelop develop);

    void MarketProdurct(TaskAddHype addHype);

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