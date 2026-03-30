using PD1.Enums;

namespace PD1.Equipment;

public abstract class Stuff(string name, string manufacturer)
{
    
    private static int _nextId = 1;

    public int Id { get; } = _nextId++;
    public string Name { get; set; } = name;
    public string Manufacturer { get; set; } = manufacturer;
    public EquipmentStatus Status { get; set; } = EquipmentStatus.Available;

    
}