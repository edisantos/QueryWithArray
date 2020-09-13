using Microsoft.Ajax.Utilities;
using samsung.Rh.Employee.Domain.Entities;
using samsung.Rh.Employee.Reposiory.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace samsung.Rh.Employee.UI.Controllers
{
    public class ProdutosController : Controller
    {
        // GET: Produtos
        TesteRepository _repo = new TesteRepository();
        public ActionResult Index()
        {
            System.Web.UI.WebControls.GridView gView = new System.Web.UI.WebControls.GridView();
            gView.DataSource = _repo.GetProduto().ToList();

            gView.DataBind();
            using (System.IO.StringWriter sw = new System.IO.StringWriter())
            {
                using (System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw))
                {
                 
                    gView.RenderControl(htw);
                    ViewBag.GridViewString = sw.ToString();
                }
            }
            //string[] seriais = { ProdutoName };
            //string arrayStr = string.Concat(seriais);
           //string ProdutoName = "";
           // var result = _repo.GetProdutosTeste(ProdutoName);
            //Isso ocorre pois esta retornando vazio.  Aqui nao emplicara no resultado da pesquisa
            return View();
        }
        /// <summary>
        /// METODO PARA CONSULTA
        /// </summary>
        /// <param name="ProdutoName"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ListaProdutos mod)
        {
            //Aqui é codigo para testar
            // string[] dados = ProdutoName.Split(','); // faz o split
            // string sql = string.Empty;
            //string p  ="";

            //var produto = _repo.GetProduto();
            //if (produto != null)
            //{


            //    List<string> listP = new List<string>();

            //    foreach (var item in produto.ToArray())
            //    {

            //        //p += "'" + item.Nome + "',";
            //        listP.Add(item.Nome);
            //    }
            //    // p = "SSD','TV";
            //    string concat = String.Join("','",listP);
            //    var result = _repo.GetProdutosTeste(concat);

            //   return View(result);

            //}

            if (ModelState.IsValid)
            {
                _repo.EntradaPesquisa(mod);
                return RedirectToAction("Index");
            }
            return View(mod);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registros(ListaProdutos mod)
        {
          
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JsonResult getProdutosPorNome(string ProdutoName)
        {
            var produto = _repo.GetProduto();
            if (produto != null)
            {


                List<string> listP = new List<string>();

                foreach (var item in produto.ToArray())
                {

                    //p += "'" + item.Nome + "',";
                    listP.Add(item.Nome);
                }
                // p = "SSD','TV";
                string concat = String.Join("','", listP);
                var result = _repo.GetProdutosTeste(concat);

                return Json(result,JsonRequestBehavior.AllowGet);

            }
            return Json(null);
        }

    }


}

