using EquipmentRental.Domain;

namespace EquipmentRental.Services;

public class RentalPolicy
{
    public bool canRent(User user,  Equipment equipment, List<Rental> activeRentals, out string message)
    {
        message = "";

        if (!equipment.isAvailable())
        {
            message = "Sprzęt nie jest dostępny";
            return false;
        }
        
        int limit = getLimit(user);
        
        
        int activeCount = 0;
        foreach (var r in activeRentals)
        {
            if (r.user.Id == user.Id && r.isActive())
            {
                activeCount++;
            }
        }

        if (activeCount >= limit)
        {
            message = "Uzytkownik " + user.Id + " przekroczyl limit aktywnych wypozyczen.";
            return false;
        }

        return true;

        
    }

    public int getLimit(User user)
    {
        if (user.userType == userType.Student) return 2;
        if (user.userType == userType.Pracownik) return 5;

        return 0;
    }
}