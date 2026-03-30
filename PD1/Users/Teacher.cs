namespace PD1.Users;

public class Teacher(string firstName, string lastName) : Person(firstName, lastName)
{
    public override int GetMaxRentals() => 5;
}