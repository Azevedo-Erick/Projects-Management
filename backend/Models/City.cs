namespace ProjectsManagement.Models;

public class City : BaseEntity
{
    public City(string name, State state)
    {
        Name = name;
        State = state;
    }

    public City(string name, State state, int stateId)
    {
        Name = name;
        State = state;
        StateId = stateId;
    }
    public City(string name, int stateId)
    {
        Name = name;
        StateId = stateId;
        State = new State();

    }

    public City()
    {
        Name = "";
        State = new State();
    }

    public string Name { get; set; }
    public State State { get; set; }
    public int StateId { get; set; }

}