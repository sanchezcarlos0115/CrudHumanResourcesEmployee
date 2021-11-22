using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HumanResourcesWebApp.Models
{
    public class EmpleadoType
    {

        private const string FORMATO_FECHA = "dd/MM/yyyy";

        [Required]
        public int BusinessEntityId { get; set; }
        public string NameDescription { get; set; }
        [Required]
        public string NationalIdNumber { get; set; }
        [Required]
        public string LoginId { get; set; }

        [Required]
        public string JobTitle { get; set; }


    //    [Range(typeof(DateTime), "2004-12-01", "2004-12-31",
    //ErrorMessage = "Value for {0} must be between {1} and {2}")]
    //    public datetime Something { get; set; }


        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public string BirthDateInen
        {
            get
            {
                if (BirthDate.Equals(DateTime.MinValue))
                {
                    return string.Empty;
                }
                else
                {
                    return BirthDate.ToString(FORMATO_FECHA);
                }
            }
        }

        [Required]
        public string MaritalStatus { get; set; }

        public string MaritalStatusFormat
        {
            get
            {
                if (MaritalStatus.Equals("M"))
                {
                    return "Casado";
                }
                else
                {
                    return "Soltero";
                }
            }
        }


        [Required]
        public string Gender { get; set; }
        public string GenderFormat
        {
            get
            {
                if (Gender.Equals("M"))
                {
                    return "Masculino";
                }
                else
                {
                    return "Femenino";
                }
            }
        }


        [Required]
        public DateTime HireDate { get; set; }

        public string HireDateInen
        {
            get
            {
                if (HireDate.Equals(DateTime.MinValue))
                {
                    return string.Empty;
                }
                else
                {
                    return HireDate.ToString(FORMATO_FECHA);
                }
            }
        }

        [Required]
        [Range(-40, 240, ErrorMessage = "VacationHours must be between -40 and 240")]
        public short VacationHours { get; set; }

        [Required]
        [Range(0, 120, ErrorMessage = "SickLeaveHours must be between 0 and 120")]
        public short SickLeaveHours { get; set; }
    }
}