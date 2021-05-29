using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CotizadorExpress.Model;

namespace CotizadorExpress.Controller
{
    public class CotizacionController
    {
        public double CreateCotizacion(string sellerCode,object item,string unit)
        {
            var total = 0.00;
            string type = item.GetType().Name;
            VendedorController vendedor = new VendedorController();
            TiendaController tienda = new TiendaController();

            switch (type)
            {
                case "Camisa":
                    Camisa camisa = (Camisa)item;
                    total += camisa.Price * int.Parse(unit);
                    if (camisa.MangaCorta)
                    {
                        total = total * .9;
                    }
                    if (camisa.Mao)
                    {
                        total = total * 1.03;
                    }
                    if (camisa.Quality == "Premium")
                    {
                        total = total * 1.3;
                    }

                    try
                    {
                        tienda.RestarStock(false, false, camisa.MangaCorta, camisa.Mao, int.Parse(unit));
                    }
                    catch (Exception)
                    {

                        return -1.0;
                    }
                    

                    Cotizacion cotizacionCamisa = new Cotizacion(sellerCode, camisa, int.Parse(unit), total);

                    vendedor.AddCotizacion(cotizacionCamisa);
                    break;

                case "Pantalon":
                    Pantalon pantalon = (Pantalon)item;
                    total += pantalon.Price * int.Parse(unit);
                    if (pantalon.Chupines)
                    {
                        total = total * .88;
                    }
                    if (pantalon.Quality == "Premium")
                    {
                        total = total * 1.3;
                    }

                    try
                    {
                        tienda.RestarStock(true, pantalon.Chupines, false, false, int.Parse(unit));
                    }
                    catch (Exception)
                    {

                        return -1.0;
                    }

                    Cotizacion cotizacionPantalon = new Cotizacion(sellerCode, pantalon, int.Parse(unit), total);
                    vendedor.AddCotizacion(cotizacionPantalon);
                    break;
                default:
                    break;
            }

            return total;
        }

        public string GetHistory()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Cotizaciones: ");
            foreach (var item in Vendedor.cotizaciones)
            {
                sb.AppendLine($"Numero:{item.Id}");
                sb.AppendLine($"Fecha:{item.Created}");
                sb.AppendLine($"Total:{item.Result}");
                sb.AppendLine($"Vendedor:{item.SellerCode}");
                sb.AppendLine("--------------");
            }

            return sb.ToString();
        }
    }
}
