using Ecommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Booking:BaseEntity
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
}
