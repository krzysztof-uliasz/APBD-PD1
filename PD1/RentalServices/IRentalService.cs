using PD1.Equipment;
using PD1.Users;

namespace PD1.RentalServices;

public interface IRentalService
{
    public void CreateRental(Person person, Stuff equipment, DateTime from, DateTime to, DateTime actualReturn);
    public void CancelRental(int rentalId);
    public List<Rental> GetUserRentals(Person person);
    public List<Rental> GetAll();
}