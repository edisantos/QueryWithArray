using samsung.Rh.Employee.Data.Contexto;
using samsung.Rh.Employee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace samsung.Rh.Employee.Reposiory.Repositories
{
	public class TesteRepository: DataContexto
    {
		public IEnumerable<ProdutosModels> GetProdutosTeste(string ProdutoName)
		{
			try
			{
				OpenConnnection();

				
				string strSelect = string.Format(@"SELECT * FROM Produtos WHERE ProdutoName IN ('" +ProdutoName +"')");
				
				
				using (Cmd = new SqlCommand(strSelect, con))
				{
					//string[] valor = ProdutoName.Split(',');
					//string p = "'TV','Celular','Notebook','Processador','memoria','HDD','SSD'";
					//Cmd.Parameters.AddWithValue("@Produto_", ProdutoName);
					//foreach (var item in valor)
					//{
					//	Cmd.Parameters.AddWithValue("@Produto_", item);

					//}

					List<ProdutosModels> lista = new List<ProdutosModels>();
					using (Dr = Cmd.ExecuteReader())
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

		/// <summary>
		/// 
		/// </summary>
		/// <param name=""></param>
		/// <returns></returns>
		public IEnumerable<ListaProdutos> GetProduto()
		{
			try
			{
				OpenConnnection();


				string strSelect = string.Format(@"SELECT Nome FROM ListaProdutos");


				using (Cmd = new SqlCommand(strSelect, con))
				{
					
					List<ListaProdutos> lista = new List<ListaProdutos>();
					using (Dr = Cmd.ExecuteReader())
					{
						ListaProdutos mod = null;
						while (Dr.Read())
						{
							mod = new ListaProdutos();
							
							mod.Nome = Convert.ToString(Dr[0]);
							
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
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public ListaProdutos GetNomeProduto()
		{
			try
			{
				OpenConnnection();


				string strSelect = string.Format(@"SELECT Nome FROM ListaProdutos");


				using (Cmd = new SqlCommand(strSelect, con))
				{

					
					using (Dr = Cmd.ExecuteReader())
					{
						ListaProdutos mod = null;
						while (Dr.Read())
						{
							mod = new ListaProdutos();

							mod.Nome = Convert.ToString(Dr["Nome"]);

							
						}

						return mod;
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

		public void EntradaPesquisa(ListaProdutos mod)
		{
			try
			{
				OpenConnnection();
				string strInsert = string.Format(@"INSERT INTO ListaProdutos VALUES(@ProdutoName)");
				using(Cmd = new SqlCommand(strInsert, con))
				{
					Cmd.Parameters.AddWithValue("@ProdutoName", mod.Nome);
					Cmd.ExecuteNonQuery();
				}
			}
			catch (SqlException ex)
			{

				throw new Exception(ex.Message);
			}
			finally
			{
				CloseConnnection();
			}
		}
	}
}

