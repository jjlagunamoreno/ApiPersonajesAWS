using ApiPersonajesAWS.Models;
using Microsoft.EntityFrameworkCore;
using ApiPersonajesAWS.Models;

public class PersonajesContext : DbContext
{
    public PersonajesContext(DbContextOptions<PersonajesContext> options)
        : base(options)
    {
    }

    public DbSet<Personaje> Personajes { get; set; }
}
