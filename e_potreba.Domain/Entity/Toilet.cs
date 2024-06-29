using e_potreba.Domain.Entity.Common;

namespace e_potreba.Domain.Entity;
public class Toilet : BaseEntity
{
    public required string Address;
    public required string City;
    public required string Country;
    public required User Author;
    public required Point Point;
    public required string Status;
    public required int Rating;
}
