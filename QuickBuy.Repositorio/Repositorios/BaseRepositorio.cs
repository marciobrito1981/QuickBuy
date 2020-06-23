﻿using QuickBuy.Dominio.Contratos;
using QuickBuy.Repositorio.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBuy.Repositorio.Repositorios
{
    public class BaseRepositorio<TEntity> : IBaseRpositorio<TEntity> where TEntity : class
    {
        protected readonly QuickBuyContext QuickBuyContext;
        public BaseRepositorio(QuickBuyContext quickBuyContext)
        {
            QuickBuyContext = quickBuyContext;
        }
        public void Adicionar(TEntity entity)
        {
            QuickBuyContext.Set<TEntity>().Add(entity);
            QuickBuyContext.SaveChanges();
        }

        public void Atualizar(TEntity entity)
        {
            QuickBuyContext.Set<TEntity>().Update(entity);
            QuickBuyContext.SaveChanges();
        }

        public void Dispose()
        {
            QuickBuyContext.Dispose();
        }

        public TEntity ObterPorId(int id)
        {
            return QuickBuyContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return QuickBuyContext.Set<TEntity>().ToList();
        }

        public void Remover(TEntity entity)
        {
            QuickBuyContext.Remove(entity);
            QuickBuyContext.SaveChanges();
        }
    }
}
