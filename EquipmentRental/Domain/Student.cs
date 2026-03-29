namespace EquipmentRental.Domain;

public class Student : User
{
    public int maxActiveRentals { get; } = 2;

    
    public Student(string firstName, string lastName)
        : base(firstName, lastName, userType.Student)
    {
    }

}