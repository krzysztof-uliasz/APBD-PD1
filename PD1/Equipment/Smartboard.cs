namespace PD1.Equipment;

public class Smartboard(string name, string manufacturer, bool hasElectronicSharpie, bool hasMediaPlayback) : Stuff(name, manufacturer)
{
    public bool HasElectronicSharpie { get; set; } = hasElectronicSharpie;
    public bool HasMediaPlayback { get; set; } = hasMediaPlayback;
}