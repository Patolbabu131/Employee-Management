
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;



namespace WebApplication9.Models
{
    public class Employee
    {
        [Key]
        
        public int Emp_No { get; set; }
        [DisplayName("Name")]
        public string name { get; set; }
        [DisplayName("Gender")]
        public string gender { get; set; }

        
        [DisplayFormat( DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayName("Date Of Birth")]
  
        public DateTime? DOB { get; set; }
        
        [DisplayFormat( DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayName("Date Of joining")]
       
        public DateTime DOJ { get; set; }
        [DisplayName("Contact  No.")]
        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Please Enter Valid Mobile Number.")]
        public double Contact_No { get; set; }

    }
}