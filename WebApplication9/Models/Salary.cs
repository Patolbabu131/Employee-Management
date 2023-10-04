using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication9.Models
{
    public class Salary
    {
        [Key]
        public int Sal_Id { get; set; }
        [DisplayName("Employee ID")]
        [Required(ErrorMessage = "Enter your Email")]
        public int Emp_No { get; set; }
        [ForeignKey("Emp_No")]
        [Required(ErrorMessage = "Enter your Email")]
        public virtual Employee id { get; set; }
        [DisplayName("Base")]
        public decimal Basic { get; set; }
        [DisplayName("Dearness Allowance")]
        public decimal DA { get; set; }
        [DisplayName("House Rent Allowance")]
        public decimal HRA { get; set; }
        [DisplayName("Food Allowance")]
        public decimal FA { get; set; }
        [DisplayName("Misc Expense")]
        public decimal ME { get; set; }
        [DisplayName("Salary Month")]
        public decimal SM { get; set; }
        [DisplayName("Salary Year")]
        public decimal SY { get; set; }
        
        [DisplayName("Month & Year")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/yyyy}")]
        public DateTime month_year { get; set; }

    }
}
