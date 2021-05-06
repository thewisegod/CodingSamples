using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem_MVC.Models
{
    public class Supplier
    {
		[Key]
		public int Id { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "Company Name Required")]
		[MaxLength(40, ErrorMessage = "The max length of the Company Name field is 40 characters")]
		public string CompanyName { get; set; }

		[MaxLength(50, ErrorMessage = "The max length of the Contact Name field is 50 characters")]
		public string ContactName { get; set; }

		[MaxLength(40, ErrorMessage = "The max length of the Contact Title field is 40 characters")]
		public string ContactTitle { get; set; }

		[MaxLength(40, ErrorMessage = "The max length of the City field is 40 characters")]
		public string City { get; set; }

		[MaxLength(40, ErrorMessage = "The max length of the Country field is 40 characters")]
		public string Country { get; set; }

		[MaxLength(30, ErrorMessage = "The max length of the Phone field is 30 characters")]
		public string Phone { get; set; }

		[MaxLength(30, ErrorMessage = "The max length of the Fax field is 30 characters")]
		public string Fax { get; set; }
	}
}