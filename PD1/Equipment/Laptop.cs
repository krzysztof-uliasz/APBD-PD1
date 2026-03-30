namespace PD1.Equipment;

public class Laptop(string name, string manufacturer, int screenSize) : Stuff(name, manufacturer)
{
    public int ScreenSize { get; set; } = screenSize;
}