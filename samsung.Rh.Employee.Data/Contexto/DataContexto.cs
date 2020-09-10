using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace samsung.Rh.Employee.Data.Contexto
{
    public class DataContexto
    {

        protected SqlConnection con;
        protected SqlDataReader Adp;
        protected SqlDataReader Dr;
        protected SqlCommand Cmd;

        /// <summary>
        /// OPEN CONNNECTION WIHT DATABASE
        /// </summary>
        /// <returns></returns>
        public SqlConnection OpenConnnection()
        {
            try
            {
                /*afaa
                 afafafa
                 
                 afsas*/
                //string conn = string.Format(@"Source=DESKTOP-A900EN5\DBLEMOSINFOTEC;Initial Catalog=DbTeste;User ID=sa;Password=@Lemos318730");
                string strCon = ConfigurationManager.ConnectionStrings["Conexao"].ConnectionString;
                con = new SqlConnection(strCon);
                if(con.State== ConnectionState.Closed)
                {
                    con.Open();
                }
                return con;
            }
            catch (SqlException ex)
            {

                throw new Exception("Error to the open connection: " + ex.Message);
            }
        }
        /// <summary>
        /// CLOSED CONNNECT WITH DATABASE
        /// </summary>
        /// <returns></returns>
        public SqlConnection CloseConnnection()
        {
            try
            {
                
                if(con.State == ConnectionState.Open)
                {
                    con.Close();
                    con.Dispose();
                }
                return con;
            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }
}
