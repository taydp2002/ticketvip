using Ecommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class PortfolioCategory : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desciption { get; set; }
        public string Slug { get; set; }
        public string? Icon { get; set; }
        public string? ImageBanner { get; set; }
        public int? ParentPortfolioCategoryId { get; set; }
        public virtual PortfolioCategory ParentPortfolioCategory { get; set; }
      //  public List<Category> Children { get; set; }
      
    }

}
