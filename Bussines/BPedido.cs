using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines
{
    public class BPedido
    {
        private DPedido Dpedido = null;
        public List<Pedido> GetPedidosEntreFechas(DateTime FechaInicio, DateTime FechaFin)
        {
            List<Pedido> pedidos = null;
            try
            {
                Dpedido = new DPedido();
                pedidos = Dpedido.GetPedidos(new Pedido { FechaInicio = FechaInicio, FechaFin = FechaFin });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return pedidos;
        }
    }
}
