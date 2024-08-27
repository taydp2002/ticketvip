using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Web.Mvc.Models
{
    public class QRCodeModel
    {
        [Display(Name = "Enter QRCode Text")]
        public string QRCodeText { get; set; }

    }
}
