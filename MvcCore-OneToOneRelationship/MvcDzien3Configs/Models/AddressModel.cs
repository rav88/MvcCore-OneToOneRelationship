using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcDzien3Configs.Models
{
    public class AddressModel
    {
		[Key]
		[ForeignKey("Customer")]
		public int Id { get; set; }

		[Required]
	    public string Street { get; set; }

	    [Required]
		public string PostalCode { get; set; }

	    [Required]
		public string City { get; set; }
	    
		public CustomerModel Customer { get; set; }
    }
}
