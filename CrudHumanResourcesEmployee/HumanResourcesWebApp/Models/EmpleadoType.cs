using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HumanResourcesWebApp.Models
{
    public class EmpleadoType
    {
        //[Required]
        //[Display(Name = "BusinessEntityId")]
        public int BusinessEntityId { get; set; }
        public string NameDescription { get; set; }
        public string NationalIdNumber { get; set; }

        public string LoginId { get; set; }

        public string JobTitle { get; set; }
      
        public DateTime BirthDate { get; set; }
       
        public string MaritalStatus { get; set; }
      
        public string Gender { get; set; }
      
        public DateTime HireDate { get; set; }

       
        public short VacationHours { get; set; }

      
        public short SickLeaveHours { get; set; }
    }
}