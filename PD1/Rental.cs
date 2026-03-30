using PD1.Equipment;
using PD1.Users;

namespace PD1;

public class Rental(Stuff equipment, Person person, DateTime from, DateTime to, DateTime actualReturn)
{
    private static int _nextId = 1;
    
    public int Id { get; set; } = _nextId++;
    public Stuff Equipment { get; set; } = equipment;
    public Person Person { get; set; } = person;
    public DateTime From { get; set; } = from >= to ? throw new ArgumentException("Invalid time range") : from;
    public DateTime To { get; set; } = to;
    public DateTime ActualReturn { get; set; } = actualReturn;
    public bool IsCancelled { get; private set; } = false;
    
    public void Cancel()
    {
        IsCancelled = true;
    }

    public bool ReturnedOnTime()
    {
        return !(ActualReturn >= To);
    }

    public bool Overlaps(DateTime from, DateTime to)
    {
        return !(From > to || from > To);
    }
}