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
        //[Display(Name = "BusinessEntityId")]
        public int BusinessEntityId { get; set; }
        public string NameDescription { get; set; }
        [Required]
        public string NationalIdNumber { get; set; }
        [Required]
        public string LoginId { get; set; }

        [Required]
        public string JobTitle { get; set; }
        [Required]
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
                if (HireDate.Equals("M"))
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
        public short VacationHours { get; set; }

        [Required]
        public short SickLeaveHours { get; set; }
    }
}