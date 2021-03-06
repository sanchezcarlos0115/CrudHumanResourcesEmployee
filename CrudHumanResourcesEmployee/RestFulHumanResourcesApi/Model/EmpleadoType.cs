using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestFulHumanResourcesApi.Model
{
    public class EmpleadoType
    {
        [JsonPropertyName("businessentityid")]
        public int BusinessEntityId { get; set; }

        [JsonPropertyName("namedescription")]
        public string NameDescription { get; set; }

        [JsonPropertyName("nationalidnumber")]
        public string NationalIdNumber { get; set; }

        [JsonPropertyName("loginid")]
        public string LoginId { get; set; }

        [JsonPropertyName("jobtitle")]
        public string JobTitle { get; set; }
        [JsonPropertyName("birthdate")]
        public DateTime BirthDate { get; set; }
        [JsonPropertyName("maritalstatus")]
        public string MaritalStatus { get; set; }
        [JsonPropertyName("gender")]
        public string Gender { get; set; }
        [JsonPropertyName("hiredate")]
        public DateTime HireDate { get; set; }

        [JsonPropertyName("vacationhours")]
        public short VacationHours { get; set; }

        [JsonPropertyName("sickleavehours")]
        public short SickLeaveHours { get; set; }

    }
}
