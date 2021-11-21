using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestFulHumanResourcesApi.Repository.Dto
{
    public class EmpleadoDto
    {
        [Key]
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        [Column("NameDescription")]
        public string NameDescription { get; set; }
       
        [Column("NationalIDNumber")]
        public string NationalIdNumber { get; set; }

        [Column("LoginID")]
        public string LoginId { get; set; }
       
        [Column("JobTitle")]
        public string JobTitle { get; set; }
        [Column("BirthDate")]
        public DateTime BirthDate { get; set; }
        [Column("MaritalStatus")]
        public string MaritalStatus { get; set; }
        [Column("Gender")]
        public string Gender { get; set; }
        [Column("HireDate")]
        public DateTime HireDate { get; set; }

      
        [Column("VacationHours")]
        public short VacationHours { get; set; }//restriccion de ingreso de a 240

        [Column("SickLeaveHours")]
        public short SickLeaveHours { get; set; }//restriccion de ingreso de 0 a 120

     
    }
}
