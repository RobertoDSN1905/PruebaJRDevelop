using prueba.Models;
using System.Net;

namespace prueba.servicio
{
    public class PostalCodeService
    {
        public List<Direccion> BuscarPostalCode(List<Direccion> addresses, string postalCode)
        {
            return addresses
                .Where(a => a.PostalCode == postalCode)
                .ToList();
        }
    }
}
