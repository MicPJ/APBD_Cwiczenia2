namespace EquipmentRental.Domain;

public class Rental
{
    private static int nextId = 1;
    
    public int Id { get; }
    public User user { get; }
    public Equipment equipment { get; }
    
    public DateTime rentDate { get; }
    public int days { get; }
    public DateTime dueDate { get; }
    
    public DateTime? returnDate { get; private set; }
    public decimal penalty {get; private set;}

    public Rental(User user, Equipment equipment, DateTime rentDate, int days)
    {
        Id = nextId;
        nextId++;
        
        this.user = user;
        this.equipment = equipment;
        this.rentDate = rentDate;
        this.days = days;
        this.dueDate = rentDate.AddDays(days);

        returnDate = null;
        this.penalty = 0;
    }

    public bool isActive()
    {
        return returnDate == null;
    }

    public bool isOverDue(DateTime today)
    {
        return today.Date > dueDate.Date && isActive();
    }
    
    public void returnEquipment(DateTime returnDate, decimal penalty)
    {
        this.returnDate = returnDate;
        this.penalty = penalty;
    }

    public override string ToString()
    {
        string isReturned = returnDate == null ? "-" : returnDate.Value.ToString("dd.MM.yyyy");
        return "Wypożyczenie " + Id + " | Uzytkownik: " + user.firstName + " " + user.lastName 
            + " | Sprzęt: " + equipment.Name 
            + " | Wypożyczono: " + rentDate.ToString("dd.MM.yyyy") 
            + " | Termin oddania: " + dueDate.ToString("dd.MM.yyyy")
            + " | Oddano: " + isReturned
            + " | Kara: " +  penalty;
     }
}