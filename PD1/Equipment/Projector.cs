namespace PD1.Equipment;

public class Projector(string name, string manufacturer, int powerDrawInWatts) : Stuff(name, manufacturer)
{
    public int PowerDrawInWatts { get; set; } = powerDrawInWatts;
}