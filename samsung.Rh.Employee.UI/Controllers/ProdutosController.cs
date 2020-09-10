using Microsoft.Ajax.Utilities;
using samsung.Rh.Employee.Reposiory.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace samsung.Rh.Employee.UI.Controllers
{
    public class ProdutosController : Controller
    {
        // GET: Produtos
        ProdutosRepository _repo = new ProdutosRepository();
        public ActionResult Index()
        {
            //string[] seriais = { ProdutoName };
            //string arrayStr = string.Concat(seriais);
           string[] ProdutoName  = { "" };
           var result = _repo.GetProdutos(ProdutoName);
           //Isso ocorre pois esta retornando vazio.  Aqui nao emplicara no resultado da pesquisa
            return View(result);
        }
        /// <summary>
        /// METODO PARA CONSULTA
        /// </summary>
        /// <param name="ProdutoName"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string ProdutoName)
        {
            //Aqui é codigo para testar
            string[] dados = ProdutoName.Split(','); // faz o split
            string sql = string.Empty;

            var result = _repo.GetProdutos(dados).ToList();

            //enviando um array de string podemos performar um foreach ou outro loop com 
            //a possivel contagem de elementos sem converter


            //melhor que fazer aqui faremos lá com o objeto nativo do sql
            //foreach (var item in dados)
            //{
            //var result = _repo.GetProdutos(item).ToList();
            //sql += result;
            //return View(result);
            //}

            return View();
        }
    }
}