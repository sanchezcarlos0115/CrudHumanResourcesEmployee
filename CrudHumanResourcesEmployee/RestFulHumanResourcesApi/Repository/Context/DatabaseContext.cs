using Microsoft.EntityFrameworkCore;
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
    }
}
