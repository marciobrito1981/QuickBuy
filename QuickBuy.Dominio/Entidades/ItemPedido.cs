using System.Collections.Generic;

namespace QuickBuy.Dominio.Entidades
{
    public class ItemPedido : Entidade
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }

        public ICollection<Pedido> Pedidos { get; set; }

        public override void Validate()
        {
            if(ProdutoId == 0)
                AdicionarMensagem("Não foi possivel indentificar qual referencia do produto");

            if (Quantidade == 0)
                AdicionarMensagem("Quantidade não foi informado");
            
        }
    }
}
