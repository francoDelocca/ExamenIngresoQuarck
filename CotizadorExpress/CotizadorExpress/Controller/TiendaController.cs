using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CotizadorExpress.Model;

namespace CotizadorExpress.Controller
{
    public class TiendaController
    {

        public Tienda InstantiateTienda()
        {
            Tienda tienda = new Tienda("Ropa de locos", "Av.Mitre 275");
            Tienda.items = CreateItems();

            return tienda;
        }

        private List<Prenda> CreateItems()
        {
            List<Prenda> list = new List<Prenda>();

            Camisa camisaCortaMao = new Camisa(200, true, true);
            Camisa camisaCortaNormal = new Camisa(300, true, false);
            Camisa camisaLargaMao = new Camisa(150, false, true);
            Camisa camisaLargaNormal = new Camisa(350, false, false);

            Pantalon pantalonChupin = new Pantalon(1500, true);
            Pantalon pantalonNormal = new Pantalon(500, false);

            list.Add(camisaCortaMao);
            list.Add(camisaCortaNormal);
            list.Add(camisaLargaMao);
            list.Add(camisaLargaNormal);
            list.Add(pantalonChupin);
            list.Add(pantalonNormal);

            return list;
        }

        public int CheckStock(bool isPantalon, bool isChupin, bool isMangaCorta, bool isMao)
        {
            var stock = 0;

            foreach (var item in Tienda.items)
            {
                if (item.GetType().Name == "Pantalon")
                {
                    Pantalon panta = (Pantalon)item;

                    if (isPantalon)
                    {
                        if (isChupin)
                        {
                            if (panta.Chupines)
                            {
                                stock = panta.Stock;
                                return stock;
                            }
                            //stock += panta.Stock;
                        }
                        stock = panta.Stock;
                    }
                }
                else if(item.GetType().Name == "Camisa")
                {
                    Camisa camisa = (Camisa)item;

                    if (isMangaCorta && isMao)
                    {
                        if (camisa.MangaCorta && camisa.Mao)
                        {
                            stock += camisa.Stock;
                        }
                    }
                    else if (isMangaCorta && !isMao)
                    {
                        if (camisa.MangaCorta && !camisa.Mao)
                        {
                            stock = camisa.Stock;
                        }
                    }
                    else if (!isMangaCorta && !isMao)
                    {
                        if (!camisa.MangaCorta && !camisa.Mao)
                        {
                            stock = camisa.Stock;
                        }
                    }
                    else if(!isMangaCorta && isMao)
                    {
                        if (!camisa.MangaCorta && camisa.Mao)
                        {
                            stock = camisa.Stock;
                        }
                    }
                }
            }

            return stock;
        }

        public void RestarStock(bool isPantalon, bool isChupin, bool isMangaCorta, bool isMao, int cantidad)
        {
            foreach (var item in Tienda.items)
            {
                if (item.GetType().Name == "Pantalon")
                {
                    Pantalon panta = (Pantalon)item;

                    if (isPantalon)
                    {
                        if (isChupin)
                        {
                            if (panta.Chupines)
                            {
                                if (!(panta.Stock - cantidad < 0))
                                {
                                    panta.Stock -= cantidad;
                                    return;
                                }
                                else
                                {
                                    throw new Exception();
                                }
                            }
                            //stock += panta.Stock;
                        }
                        //panta.Stock -= cantidad;
                        if (!(panta.Stock - cantidad < 0))
                        {
                            panta.Stock -= cantidad;
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                }
                else if (item.GetType().Name == "Camisa")
                {
                    Camisa camisa = (Camisa)item;

                    if (isMangaCorta && isMao)
                    {
                        if (camisa.MangaCorta && camisa.Mao)
                        {
                            if (!(camisa.Stock - cantidad < 0))
                            {
                                camisa.Stock -= cantidad;
                            }
                            else
                            {
                                throw new Exception();
                            }
                            

                        }
                    }
                    else if (isMangaCorta && !isMao)
                    {
                        if (camisa.MangaCorta && !camisa.Mao)
                        {
                            if (!(camisa.Stock - cantidad < 0))
                            {
                                camisa.Stock -= cantidad;
                            }
                            else
                            {
                                throw new Exception();
                            }
                        }
                    }
                    else if (!isMangaCorta && !isMao)
                    {
                        if (!camisa.MangaCorta && !camisa.Mao)
                        {
                            if (!(camisa.Stock - cantidad < 0))
                            {
                                camisa.Stock -= cantidad;
                            }
                            else
                            {
                                throw new Exception();
                            }
                        }
                    }
                    else if (!isMangaCorta && isMao)
                    {
                        if (!camisa.MangaCorta && camisa.Mao)
                        {
                            if (!(camisa.Stock - cantidad < 0))
                            {
                                camisa.Stock -= cantidad;
                            }
                            else
                            {
                                throw new Exception();
                            }
                        }
                    }
                }
            }
        }

    }
}
