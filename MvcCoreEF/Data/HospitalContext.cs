using Microsoft.EntityFrameworkCore;
using MvcCoreEF.Models;

namespace MvcCoreEF.Data
{
    public class HospitalContext : DbContext
    {
        //El constructor recibira siempre las opciones para este contexto
        //La clase que recibe es DbContextOptions<Context>

        //Estas options debemos enviarla a la clase BASE/SUPER del Dbcontext

        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options)
        {

        }

        //Debemos tener un colecicon por cada model
        //Dicha coleccion dee ser Tipo<T>
        public DbSet<Hospital> hospitales {get;set;}

    }
}
