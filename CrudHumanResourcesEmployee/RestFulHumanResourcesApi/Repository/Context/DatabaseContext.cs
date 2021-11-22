using Microsoft.EntityFrameworkCore;
using RestFulHumanResourcesApi.Model;
using RestFulHumanResourcesApi.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestFulHumanResourcesApi.Repository.Context
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
             : base(options)
        {
        }

        public DbSet<PersonaDto> Persona { get; set; }
        public DbSet<EmpleadoDto> Empleado { get; set; }
        public DbSet<ResultadoProceso> ResultadoProceso { get; set; }
        public DbSet<HistorialPagoDto> HistorialPago { get; set; }

    }
}
