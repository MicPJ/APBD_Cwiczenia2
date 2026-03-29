namespace EquipmentRental.Domain;

public enum EquipmentStatus
{
    Dostepny,
    Wypozyczony,
    Niedostepny
}
public abstract class Equipment
{
    private static int nextId = 1;
    public int Id { get; }
    public string Name { get; }
    public EquipmentStatus Status { get; private set; }

    public Equipment(string name)
    {
        Id = nextId;
        nextId++;
        
        Name = name;
        Status = EquipmentStatus.Dostepny;
    }

    public bool isAvailable()
    {
        return Status == EquipmentStatus.Dostepny;
    }

    public void markRented()
    {
        Status = EquipmentStatus.Wypozyczony;
    }

    public void markUnavailable()
    {
        Status = EquipmentStatus.Niedostepny;
    }

    public void markAvailable()
    {
        Status = EquipmentStatus.Dostepny;
    }

    public override string ToString()
    {
        return Id + " | Sprzęt: " + Name + " | Status: " + Status;
    }
}