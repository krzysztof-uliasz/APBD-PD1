namespace PD1.Users;

public abstract class Person(string firstName, string lastName)
{
    private static int _nextId = 1;

    public int Id { get; set; } = _nextId++;
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    
    public abstract int GetMaxRentals();
}