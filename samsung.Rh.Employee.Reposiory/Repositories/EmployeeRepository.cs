using samsung.Rh.Employee.Data.Contexto;
using samsung.Rh.Employee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;

namespace samsung.Rh.Employee.Reposiory.Repositories
{
	public class EmployeeRepository:DataContexto
    {
        public void Registro(Employees mod)
        {
			try
			{
				OpenConnnection();
				string strInsert = string.Format(@"INSERT INTO Employee VALUES(@nome,@sobrenome,@bairroId)");
				using (Cmd = new SqlCommand(strInsert, con))
				{
					Cmd.Parameters.AddWithValue("@nome", mod.Nome);
					Cmd.Parameters.AddWithValue("@sobrenome", mod.SobreNome);
					Cmd.Parameters.AddWithValue("@bairroid", mod.BairroId);
					Cmd.ExecuteNonQuery();

				}


			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
			finally
			{
				CloseConnnection();
			}
        }
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Employees> GetEmployeesPerName(string Name)
		{
			try
			{
				OpenConnnection();
				string strSelect = string.Format(@"SELECT * FROM Clientes WHERE Name IN (@Name)");
				using(Cmd = new SqlCommand(strSelect, con))
				{
					Cmd.Parameters.AddWithValue("@Name", Name);
					List<Employees> lista = new List<Employees>();
					using (Dr = Cmd.ExecuteReader())
					{
						Employees mod = null;
						while (Dr.Read())
						{
							mod = new Employees();
							mod.Id = Convert.ToInt32(Dr[0]);
							mod.Nome = Convert.ToString(Dr[1]);
							mod.SobreNome = Convert.ToString(Dr[2]);
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
				CloseConnnection();
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Employees GetEmployees(int id)
		{
			try
			{
				OpenConnnection();
				string strSelect = string.Format(@"SELECT Id,Nome,SobreNome FROM Employee WHERE Id =@id");
				using (Cmd = new SqlCommand(strSelect, con))
				{
					Cmd.Parameters.AddWithValue("@id", id);
					//List<Employees> lista = new List<Employees>();
					using (Dr = Cmd.ExecuteReader())
					{
						Employees mod = null;
						while (Dr.Read())
						{
							mod = new Employees();
							mod.Id = Convert.ToInt32(Dr[0]);
							mod.Nome = Convert.ToString(Dr[1]);
							mod.SobreNome = Convert.ToString(Dr[2]);
							//lista.Add(mod);
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
				CloseConnnection();
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Employees GetId(int id)
		{
			try
			{
				OpenConnnection();
				string StrSelect = string.Format(@"SELECT Id FROM Employee WHERE Id =@id");
				using(Cmd = new SqlCommand(StrSelect, con))
				{
					Cmd.Parameters.AddWithValue("@id", id);
					Employees mod = null;
					using(Dr = Cmd.ExecuteReader())
					{
						while (Dr.Read())
						{
							mod = new Employees();
							mod.Id = Convert.ToInt32(Dr[0]);
						}
						
					}
					return mod;
				}
			}
			catch (Exception ex)
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
