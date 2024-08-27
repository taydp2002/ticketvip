namespace Ecommerce.Application.Dto;

public class BookingDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Description { get; set; }
    public float? Amount { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? Enđate { get; set; }

    public int Status { get; set; }
}
