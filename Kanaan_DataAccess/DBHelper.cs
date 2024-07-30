using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Kanaan_DataAccess
{
    public class DBHelper
    {
        SqlConnection ketnoi = new SqlConnection(ConfigurationManager.ConnectionStrings["KanaanDB"].ConnectionString);
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        SqlDataAdapter laydulieu;
        DataTable dt;

        public SqlConnection GetConnection()
        {
            try
            {
                ketnoi.Open();
            }
            catch(Exception ex)
            {
                throw (new Exception(ex.Message));
            }
            return ketnoi;
        }

        public void CloseConnection()
        {
            try
            {
                ketnoi.Close();
            }
            catch( Exception ex ) 
            {
                throw (new Exception(ex.Message));
            }
            finally
            {
                ketnoi.Close();
            }
        }

        public SqlDataReader ExcuteQuery(string procName)
        {
            GetConnection();

            thuchien = new SqlCommand(procName, ketnoi);
            return thuchien.ExecuteReader();
        }

        public SqlDataReader ExcuteReader(string procName,params SqlParameter[] procParams)
        {
            SqlDataReader reader = null;
            try
            {
                thuchien=new SqlCommand(procName, ketnoi);
                thuchien.CommandType = CommandType.StoredProcedure;
                if(procParams != null)
                {
                    for(int i=0; i < procParams.Length; i++)
                    {
                        thuchien.Parameters.Add(procParams[i]);
                    }
                }
                docdulieu=thuchien.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch
            {
                throw;
            }
            return reader;

        }

        public SqlDataReader ExcuteReaderSQL(string nameDB)
        {
            SqlDataReader reader = null;
            try
            {
                thuchien = new SqlCommand(@"Select * from " + nameDB, ketnoi);
                reader = thuchien.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch
            {
                throw;
            }
            return reader;
        }


        //lát đổi hết thành sqldbtype thay vì dbtype xem được không
        private static SqlDbType ToSqlDbType(Type type)
        {
            SqlParameter para1 = new SqlParameter();
            System.ComponentModel.TypeConverter tc;
            tc = System.ComponentModel.TypeDescriptor.GetConverter(para1.DbType);

            if (type.Name == "Byte[]") return SqlDbType.Image;
            if (tc.CanConvertFrom(type))
                para1.DbType = (DbType)tc.ConvertFrom(type.Name);
            else
            {
                try
                {
                    para1.DbType = (DbType)tc.ConvertFrom(type.Name);
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
            return para1.SqlDbType;
        }

        public int execStoreProcedure(string procName, string[] parametters, object[] values)
        {
            int affectedRows = 0;
            try
            {
                GetConnection();
                thuchien = new SqlCommand(procName, ketnoi);
                thuchien.CommandType = CommandType.StoredProcedure;

                for (int i = 0; i < parametters.Length; i++)
                {
                    if (parametters[i] != string.Empty)
                    {
                        SqlParameter pa_ram = new SqlParameter();
                        if (values[i] == null || values.Equals(string.Empty))
                        {
                            values[i] = DBNull.Value;
                        }
                        if (values[i] != DBNull.Value) pa_ram.SqlDbType = ToSqlDbType(values[i].GetType());
                        if (pa_ram.SqlDbType == SqlDbType.DateTime & values[i].Equals(Convert.ToDateTime("01/01/0001")))
                            values[i] = SqlDateTime.Null;
                        pa_ram.ParameterName = parametters[i];
                        pa_ram.Value = values[i];
                        thuchien.Parameters.Add(pa_ram);
                    }
                }
                affectedRows = thuchien.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw (new Exception(ex.Message));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (thuchien != null)
                {
                    thuchien.Dispose();

                }
                CloseConnection();
            }
            return affectedRows;
        }

        public DataTable return_Table(string procName, string[] parametters, object[] values)
        {
            try
            {
                GetConnection();
                thuchien = new SqlCommand(procName, ketnoi);
                thuchien.CommandType = CommandType.StoredProcedure;

                if (parametters != null)
                {
                    for (int i = 0; i < parametters.Length; i++)
                    {
                        if (parametters[i] != string.Empty)
                        {
                            thuchien.Parameters.Add(new SqlParameter(parametters[i], values[i]));
                        }
                    }
                }

                dt = new DataTable();
                laydulieu = new SqlDataAdapter();
                laydulieu.SelectCommand= thuchien;
                laydulieu.Fill(dt);
            }
            catch(Exception ex) 
            {
                dt = null;
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }
    }
}
