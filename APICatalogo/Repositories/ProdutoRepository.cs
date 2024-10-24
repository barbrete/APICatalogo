﻿using APICatalogo.Context;
using APICatalogo.Models;
using APICatalogo.Pagination;
using Microsoft.AspNetCore.Http.HttpResults;
using MySqlX.XDevAPI.CRUD;

namespace APICatalogo.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        //criando a injeção de dependência 
        public ProdutoRepository(AppDbContext contexto): base(contexto)
        {
        }

        //public IEnumerable<Produto> GetProduto(ProdutosParameters produtosParams)
        //{
        //    return GetAll()
        //    .OrderBy(p => p.Nome)
        //    .Skip((produtosParams.PageNumber - 1) * produtosParams.PageSize)
        //    .Take(produtosParams.PageSize).ToList();
        //}

        public PagedList<Produto> GetProduto(ProdutosParameters produtosParams)
        {
            var produtos = GetAll().OrderBy(p => p.ProdutoId).AsQueryable();
            var produtosOrdenados = PagedList<Produto>.ToPagedList(produtos,
                produtosParams.PageNumber,
                produtosParams.PageSize);
            return produtosOrdenados;
        }

        public IEnumerable<Produto> GetProdutosPorCategoria(int id)
        {
            return GetAll().Where(c => c.CategoriaId == id);
        }
    }
}
