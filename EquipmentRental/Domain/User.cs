namespace EquipmentRental.Domain;

public enum userType
{
    Student,
    Pracownik
}
public abstract class User
{
    private static int nextId = 1;

    public int Id { get; }
    public string firstName { get; }
    public string lastName { get; }
    public userType userType { get; private set; }

    public User(string firstName, string lastName, userType userType)
    {
        Id = nextId;
        nextId++;
        
        this.firstName = firstName;
        this.lastName = lastName;
        this.userType = userType;
    }

    public override string ToString()
    {
        return Id + " | " + userType + "| "+ firstName + " " + lastName;
    }
}