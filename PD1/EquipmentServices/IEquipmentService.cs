using PD1.Equipment;

namespace PD1.EquipmentServices;

public interface IEquipmentService
{
    public void AddEquipment(Stuff equipment);
    public Stuff GetEquipmentById(int equipmentId);
    public List<Stuff> GetAll();
    public List<Stuff> GetAvailable();
    public void SetAvailable(int equipmentId);
    public void SetUnavailable(int equipmentId);
}