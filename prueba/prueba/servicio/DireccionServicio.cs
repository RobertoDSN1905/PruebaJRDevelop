using prueba.Models;
using System.Globalization;
using System.Net;

namespace prueba.servicio
{
    public class DireccionServicio
    {

        public enum ordenar
        {

            Adress1,
            CreationDate

        }

        public List<Direccion> SortAddresses(List<Direccion> direcciones, ordenar ord, bool ascending = true)
        {
            switch (ord)
            {
                case ordenar.Adress1:
                    return ascending ?
                        direcciones.OrderBy(a => a.Adress1).ToList() :
                        direcciones.OrderByDescending(a => a.Adress1).ToList();

                case ordenar.CreationDate:
                    return ascending ?
                        direcciones.OrderBy(a => a.CreationDate).ToList() :
                        direcciones.OrderByDescending(a => a.CreationDate).ToList();

                default:
                    throw new ArgumentException("No se pudo ordenar");
            }
        }



    }
}
