namespace Ecommerce.Application.Dto;

public class PortfolioCategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public string Desciption { get; set; }
     public string? Icon { get; set; }
    public string? ImageBanner { get; set; }
    public int? ParentCategoryId { get; set; }
    public string ParentCategoryName { get; set; }
    public PortfolioCategoryDto ParentCategory { get; set; }
    
}
