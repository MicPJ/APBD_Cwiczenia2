using EquipmentRental.Domain;

namespace EquipmentRental.Services;

public class PenaltyCalculation
{
    public decimal calculatePenalty(Rental rental, DateTime returnDate)
    {
        if (returnDate.Date <= rental.dueDate.Date)
        {
            return 0;
        }
        
        int remainingDays = (returnDate.Date - rental.dueDate.Date).Days;
        return remainingDays * 3;
    }
}