namespace PD1.Exceptions;

public class RentalConflictException(int equipmentId, DateTime from, DateTime to) 
    : Exception($"Equipment {equipmentId} is already rented for the period from {from} to {to}.");