namespace PD1.Exceptions;

public class EquipmentNotAvailableException(int equipmentId) : Exception($"Equipment with id {equipmentId} is not available.");