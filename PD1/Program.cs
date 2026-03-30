using PD1.Equipment;
using PD1.EquipmentServices;
using PD1.RentalServices;
using PD1.RentalServices;
using PD1.Users;

var user1 = new Student("Jan", "Kowalski");
var user2 = new Teacher("Michael", "Doe");

var equiment1 = new Laptop("laptop1", "Asus", 16);
var equiment2 = new Projector("projector1", "Epson", 700);
var equiment3 = new TV("tv1", "Samsung", 60, true);
var equiment4 = new Smartboard("smartboard1", "LG", false, true);

IEquipmentService equipmentService = new EquipmentService();

equipmentService.AddEquipment(equiment1);
equipmentService.AddEquipment(equiment2);
equipmentService.AddEquipment(equiment3);
equipmentService.AddEquipment(equiment4);

equipmentService.SetUnavailable(equiment2.Id);

IRentalService rentalService = new RentalService();

// Attempt to book a room that is not available
try
{
    Console.WriteLine("\n[Attempt to book a room that is not available]: ");
    rentalService.CreateRental(
        user1,
        equiment2,
        new DateTime(2026, 1, 1, 10, 0, 0),
        new DateTime(2026, 1, 1, 11, 30, 0),
        new DateTime(2026, 1, 3, 11, 30, 0)
        );
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

// Attempt to create conflicting reservation
try
{
    Console.WriteLine("\n[Attempt to create conflicting reservation]: ");
    rentalService.CreateRental(
        user1,
        equipmentService.GetEquipmentById(1),
        new DateTime(2026, 1, 1, 10, 0, 0),
        new DateTime(2026, 1, 1, 11, 30, 0),
        new DateTime(2026, 1, 3, 11, 30, 0));
    rentalService.CreateRental(
        user1,
        equipmentService.GetEquipmentById(3),
        new DateTime(2026, 1, 1, 10, 0, 0),
        new DateTime(2026, 2, 1, 11, 30, 0),
        new DateTime(2026, 1, 3, 11, 30, 0));
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

// Attempt to cancel not existing reservation
try
{
    Console.WriteLine("\n[Attempt to cancel not existing reservation]: ");
    rentalService.CancelRental(10);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

// Attempt to get not existing room
try
{
    Console.WriteLine("\n[Attempt to get not existing room]: ");
    var room = equipmentService.GetEquipmentById(10);
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}