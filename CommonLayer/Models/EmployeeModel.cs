using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Models
{
    public class EmployeeModel
    {
        [Required(ErrorMessage = "NAME CANNOT BE EMPTY....")]
        public string Name { get; set; }

        [Required(ErrorMessage = "PROFILEIMAGE CANNOT BE EMPTY....")]

        public string ProfileImage { get; set; }

        [Required(ErrorMessage = "GENDER CANNOT BE EMPTY....")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "DEPARTMENT CANNOT BE EMPTY....")]
        public string Department { get; set; }

        [Required(ErrorMessage = "SALARY CANNOT BE EMPTY....")]
        [RegularExpression(@"[0-9]", ErrorMessage = "SALARY MUST BE A NUMBER")]

        public long Salary { get; set; }

        [Required(ErrorMessage = "DATE CANNOT BE EMPTY....")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "NOTES CANNOT BE EMPTY....")]
        public string Notes { get; set; }
    }
}
