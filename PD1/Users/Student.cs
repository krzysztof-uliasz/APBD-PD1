namespace PD1.Users;

public class Student(string firstName, string lastName) : Person(firstName, lastName)
{
    public override int GetMaxRentals() => 2;
}