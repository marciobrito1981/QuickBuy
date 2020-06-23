using Microsoft.EntityFrameworkCore;
using QuickBuy.Dominio.Entidades;
using QuickBuy.Dominio.ObjetoDeValor;
using QuickBuy.Repositorio.Config;

namespace QuickBuy.Repositorio.Context
{
    public class QuickBuyContext : DbContext
    {
        

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }
        public DbSet<FormaPagamento> FormaPagamentos { get; set; }

        public QuickBuyContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoConfiguration());
            modelBuilder.ApplyConfiguration(new ItemPedidoConfiguration());
            modelBuilder.ApplyConfiguration(new FormaPagamentoConfiguration());

            //dar carga inicial no banco
            modelBuilder.Entity<FormaPagamento>().HasData(
                new FormaPagamento(){ Id = 1, Nome = "Boleto", Descricao = "Forma de Pagamento Boleto" },
                new FormaPagamento(){ Id = 2, Nome = "Cartão de Credito", Descricao = "Forma de Pagamento Cartao de Credito" },
                new FormaPagamento(){ Id = 3, Nome = "Deposito", Descricao = "Forma de Pagamento Deposito" });

            base.OnModelCreating(modelBuilder);
        }

    }
}
