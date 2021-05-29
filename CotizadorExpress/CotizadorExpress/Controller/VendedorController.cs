using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CotizadorExpress.Model;

namespace CotizadorExpress.Controller
{
    public class VendedorController
    {
        public Vendedor InstantiateVendedor()
        {
            Vendedor vendedor = new Vendedor("Franco", "Delocca", "FD2305");

            return vendedor;
        }

        public void AddCotizacion(Cotizacion cotizacionPantalon)
        {
            Vendedor.cotizaciones.Add(cotizacionPantalon);
        }
    }
}
