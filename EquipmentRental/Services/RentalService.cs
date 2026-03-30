using EquipmentRental.Domain;

namespace EquipmentRental.Services;

public class RentalService
{
    private List<User> users = new List<User>();
    private List<Equipment> Equipments = new List<Equipment>();
    private List<Rental> Rentals = new List<Rental>();

    private RentalPolicy policy = new RentalPolicy();
    private PenaltyCalculation PenaltyCalculation = new PenaltyCalculation();

    public void addUser(User user)
    {
        users.Add(user);
    }

    public void addEquipment(Equipment equipment)
    {
        Equipments.Add(equipment);
    }

    public bool rentEquipment(int userId, int equipmentId, int days, out string message)
    {
        message = "";
        
        User user = findUser(userId);
        if (user == null)
        {
            message = "Nie znaleziono użytkownika o ID: " + userId;

            return false;
        }
        
        Equipment equipment = findEquipment(equipmentId);
        if (equipment == null)
        {
            message = "Nie znaleziono sprzętu o ID:  " + equipmentId;

            return false;
        }

        if (!policy.canRent(user, equipment, Rentals, out message))
        {
            return false;
        }
        
        Rental rental = new Rental(user, equipment, DateTime.Today, days);
        Rentals.Add(rental);
        
        equipment.markRented();

        message = "Wypożyczono";
        
        return true;
    }

    public bool returnEquipment(int rentalId, DateTime returnDate, out string message)
    {
        message = "";
        
        Rental rental = findRental(rentalId);
        if (rental == null)
        {
            message = "Nie znaleziono wypożyczenia o ID: "  + rentalId;
            return false;
        }

        if (!rental.isActive())
        {
            message = "Wypożycznie o ID: " + rentalId + " zostało zakończone";
            return false;
        }

        decimal penalty = PenaltyCalculation.calculatePenalty(rental, returnDate);
        rental.returnEquipment(returnDate, penalty);
        
        rental.equipment.markAvailable();

        message = "Zwrot pomyślny | Kara: " + penalty;
        
        return true;
    }
    
    
    public void markEquipmentUnavailable(int equipmentId)
    {
        Equipment equipment = findEquipment(equipmentId);
        if (equipment != null)
        {
            equipment.markUnavailable();
        }
    }

    
    public List<Equipment> getAllEquipment()
    {
        return Equipments;
    }

    public List<Equipment> getAvailableEquipment()
    {
        List<Equipment> result = new List<Equipment>();
        foreach (var e in Equipments)
        {
            if (e.isAvailable())
            {
                result.Add(e);
            }
        }
        return result;
    }
    
    
    public List<Rental> getActiveRentalsForUser(int userId)
    {
        List<Rental> result = new List<Rental>();
        foreach (var r in Rentals)
        {
            if (r.user.Id == userId && r.isActive())
            {
                result.Add(r);
            }
        }
        return result;
    }

    public List<Rental> getOverdueRentals(DateTime today)
    {
        List<Rental> result = new List<Rental>();
        foreach (var r in Rentals)
        {
            if (r.isOverDue(today))
            {
                result.Add(r);
            }
        }
        return result;
    }



    private User findUser(int id)
    {
        foreach (var u in users)
        {
            if (u.Id == id) return u;
        }

        return null;
    }

    private Equipment findEquipment(int id)
    {
        foreach (var e in Equipments)
        {
            if (e.Id == id) return e;
        }
        return null;
    }

    private Rental findRental(int id)
    {
        foreach (var r in Rentals)
        {
            if (r.Id == id) return r;
        }
        return null;
    }
}