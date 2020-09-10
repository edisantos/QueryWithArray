using samsung.Rh.Employee.Data.Contexto;
using samsung.Rh.Employee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace samsung.Rh.Employee.Reposiory.Repositories
{
    public class ProdutosRepository:DataContexto
    {
        public IEnumerable<ProdutosModels> GetProdutos(string[] ProdutoName)
        {
			try
			{
				OpenConnnection();

				//para esclarecer quando tu for fazer a query, não usar o * ele manda a engine do banco fazer
				//uma indexação de todas as colunas da table e ai demora mais, 

				/*Não uso o * nas query só neste caso pois estou apenas usando para teste*/
				//entao tranquilo pensei que estava em todo o projeto espalhado ai dá um bo// aNao
				// Isso é aqui em casa só para este teste o projeto real mesmo é la do trampo
				//ah tranquilo então. vamos ver como esta este ProdutoName
				//Talvez o array tem que ser aqui. Veja que só pegou o TV
				//ops acabei por finalizar, mas voce notou como ficou a strSelect?
				//nao vou rodar novamenteo

				StringBuilder sb = new StringBuilder();

				string strSelect = null;// string.Format(@"SELECT * FROM Produtos WHERE ProdutoName IN (@Produto)");
										//sera que esta faldo o paramentro aqui, sim estou vendo como implementar certo
										//nao curto fazer desta forma concatenando string so pra ver se funciona
										//Que deixar sem virgula para ver, ou voce digita apenas 1, o produtoname deverias estar dividido em array e nao esta
										//ja fiz isso antes 2015, vou ver um um projeto como implementei
										//ok

				var y = ProdutoName;

				foreach (string produto in ProdutoName)
				{
					sb.Append('"' + produto + '"' + ',');
					
				}
				string sqlin = sb.ToString().TrimEnd(',');
				strSelect = @"SELECT * FROM Produtos WHERE ProdutoName IN (" + sqlin + ")";
				var x = strSelect;

				using (Cmd = new System.Data.SqlClient.SqlCommand(strSelect, con))
				{		

					List<ProdutosModels> lista = new List<ProdutosModels>();
					using(Dr = Cmd.ExecuteReader())
					{
						ProdutosModels mod = null;
						while (Dr.Read())
						{
							mod = new ProdutosModels();
							mod.ID = Convert.ToInt32(Dr[0]);
							mod.ProdutoName = Convert.ToString(Dr[1]);
							mod.Valor = Convert.ToDecimal(Dr[2]);
							mod.Descricao = Convert.ToString(Dr[3]);
							lista.Add(mod);
						}

						return lista;
					}
				}
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
			finally
			{
				OpenConnnection();
			}
        }
    }
}
