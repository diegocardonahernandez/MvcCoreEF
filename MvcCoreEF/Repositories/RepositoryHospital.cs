using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MvcCoreEF.Data;
using MvcCoreEF.Models;

namespace MvcCoreEF.Repositories
{
    public class RepositoryHospital
    {
        private HospitalContext context;
        public RepositoryHospital(HospitalContext context)
        {
            this.context = context;

        }

        public async Task<List<Hospital>> GetHospitalesAsync()
        {
            var consulta = from datos in this.context.hospitales select datos;
            return await consulta.ToListAsync();
        }

        public async Task<Hospital> FindHospital(int id)
        {
            var consulta = from datos in this.context.hospitales
                           where datos.IdHospital == id
                           select datos;

            //Cuando buscamos, si no encuentra algo debemos devolver un null
            return await consulta.FirstOrDefaultAsync();

        }

        public async Task CreateHospitalAsync(int idHospital, string nombre, string direccion, string telefono, int camas)
        {
            //CReamos un nuevo model
            Hospital hospital = new Hospital();
            //Asignamos sus propiedades
            hospital.IdHospital = idHospital;
            hospital.Nombre = nombre;
            hospital.Direccion = direccion;
            hospital.Telefono = telefono;
            hospital.Camas = camas;
            //Añadimos nuestro objeto al DBSET
            //Ahora mismo es temporal, esta en la coleccion
            //SALDRA EN CONSULTAS, PERO NO EN BASE DE DATOS
            await this.context.hospitales.AddAsync(hospital);
            //AHORA SI GUARDAMOS EN LA BASE DE DATOS
            await this.context.SaveChangesAsync();

        }
        public async Task DeleteHospitalAsync(int id)
        {
            //Buscamos el hospital a eliminar
            Hospital hospital = await this.FindHospital(id);
            //Eliminamos temporalmente de la coleccion
            this.context.hospitales.Remove(hospital);
            //Guardamos los cambios en la BBDD
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateHospitalAsync(int id, string nombre, string direccion, string telefono, int camas)
        {
            Hospital hospital = await this.FindHospital(id);
            //Modificamos todas sus propiedades exepto su KEY
            hospital.Nombre = nombre;
            hospital.Direccion = direccion;
            hospital.Telefono = telefono;
            hospital.Camas = camas;
            //No tenemos ningun metodo para realizar update dentro de colecciones
            await this.context.SaveChangesAsync();
        }

    }
}
