namespace PD1.Exceptions;

public class TooManyRentedItemsException(int personId) : Exception($"There is too many rented items for user {personId}.");