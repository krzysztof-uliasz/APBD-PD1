
using PD1.Exceptions;

namespace PD1.EquipmentServices;

using PD1.Enums;
using PD1.Equipment;

public class EquipmentService : IEquipmentService
{
    private readonly List<Stuff> _equipment = [];

    public void AddEquipment(Stuff equipment)
    {
        _equipment.Add(equipment);
    }

    public Stuff GetEquipmentById(int equipmentId)
    {
        return _equipment.FirstOrDefault(equipment => equipment.Id == equipmentId) 
               ?? throw new EquipmentNotFoundException(equipmentId);
    }

    public List<Stuff> GetAll()
    {
        return _equipment;
    }

    public List<Stuff> GetAvailable()
    {
        return _equipment.Where(equipment => equipment.Status == EquipmentStatus.Available).ToList();
    }

    public void SetAvailable(int equipmentId)
    {
        GetEquipmentById(equipmentId).Status = EquipmentStatus.Available;
    }

    public void SetUnavailable(int equipmentId)
    {
        GetEquipmentById(equipmentId).Status = EquipmentStatus.Unavailable;
    }
}