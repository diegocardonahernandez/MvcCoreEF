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

        public List<Hospital> GetHospitales()
        {
            var consulta = from datos in this.context.hospitales select datos;
            return consulta.ToList();
        }

    }
}
