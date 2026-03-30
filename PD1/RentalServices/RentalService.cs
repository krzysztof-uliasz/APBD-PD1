using PD1.Enums;
using PD1.Exceptions;
using PD1.Equipment;
using PD1.Users;

namespace PD1.RentalServices;

public class RentalService : IRentalService
{
    private readonly List<Rental> _rentals = [];
    
    public void CreateRental(Person person, Stuff equipment, DateTime from, DateTime to, DateTime actualReturn)
    {
        if (equipment.Status != EquipmentStatus.Available)
        {
            throw new EquipmentNotAvailableException(equipment.Id);
        }

        int activeUserRentals = _rentals.Count(rental => 
            !rental.IsCancelled 
            && rental.Person == person);

        if (activeUserRentals >= person.GetMaxRentals())
        {
            throw new TooManyRentedItemsException(activeUserRentals);
        }

        bool rentalsConflict = _rentals.Any(rentals =>
            !rentals.IsCancelled
            && rentals.Equipment == equipment
            && rentals.Overlaps(from, to));

        if (rentalsConflict)
        {
            throw new RentalConflictException(equipment.Id, from, to);
        }
        
        var newRental = new Rental(equipment, person, from, to, actualReturn);
        _rentals.Add(newRental);
    }

    public void CancelRental(int rentalsId)
    {
        var rentals = _rentals.FirstOrDefault(rentals => rentals.Id == rentalsId);
        
        if (rentals is null)
        {
            throw new RentalNotFoundException(rentalsId);
        }
        
        rentals.Cancel();
    }

    public List<Rental> GetUserRentals(Person person)
    {
        return _rentals.Where(rentals => rentals.Person == person && !rentals.IsCancelled).ToList();
    }

    public List<Rental> GetAll()
    {
        return _rentals;
    }
}