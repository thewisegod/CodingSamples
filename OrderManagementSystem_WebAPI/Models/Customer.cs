using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem_WebAPI.Models
{
    public class Customer
    {
		[Key]
		public int Id { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "First Name Required")]
		[MaxLength(40, ErrorMessage = "The max length of the First Name field is 40 characters")]
		public string FirstName { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "Last Name Required")]
		[MaxLength(40, ErrorMessage = "The max length of the Last Name field is 40 characters")]
		public string LastName { get; set; }

		[MaxLength(40, ErrorMessage = "The max length of the City field is 40 characters")]
		public string City { get; set; }

		[MaxLength(40, ErrorMessage = "The max length of the Country field is 40 characters")]
		public string Country { get; set; }

		[MaxLength(20, ErrorMessage = "The max length of the Phone field is 20 characters")]
		public string Phone { get; set; }
	}
}