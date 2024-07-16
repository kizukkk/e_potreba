using e_potreba.Domain.Entity.Common;

namespace e_potreba.Domain.Entity;
public class Toilet : BaseEntity
{
    public required string Address { get; set; }
    public required string City { get; set; }
    public required string Country{ get; set; }
    public required User Author{ get; set; }
    public required Point Point{ get; set; }
    public required string Status{ get; set; }
    public required int Rating{ get; set; }
}
