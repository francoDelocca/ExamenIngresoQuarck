using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CotizadorExpress.Model;

namespace CotizadorExpress.Controller
{
    public class PantalonController
    {
        public Pantalon CreatePantalon(bool chupin, string calidad, string precio)
        {
            //int cantidadNew = int.Parse(cantidad);
            double precioNew = double.Parse(precio);

            Pantalon pantalon = new Pantalon(calidad, precioNew, chupin);

            return pantalon;

        }
    }
}
