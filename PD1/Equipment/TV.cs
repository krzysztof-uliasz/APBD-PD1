namespace PD1.Equipment;

public class TV(string name, string manufacturer, int screenSize, bool isOLED) : Stuff(name, manufacturer)
{
    public int ScreenSize { get; set; } = screenSize;
    public bool IsOLED { get; set; } = isOLED;
}