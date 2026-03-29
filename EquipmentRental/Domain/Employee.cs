namespace EquipmentRental.Domain;

public class Employee : User
{
    public int maxActiveRentals { get; } = 5;
    public Employee(string firstName, string lastName)
        : base(firstName, lastName, userType.Pracownik)
    {
    }
}