using System.Drawing;

namespace e_potreba.Application.DTO.Toilet;
public sealed record ToiletRequest(
    string address, string city, string country, Point point
    )
{
}
