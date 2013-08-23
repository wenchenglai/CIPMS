using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Configuration;
using System.Collections;


/// <summary>
/// Data Access layer for CIP Management System
/// </summary>
public class CIPDataAccess
{
    private SqlConnection conn;
	public CIPDataAccess()
	{
		//
		// TODO: Add constructor logic here
		//
        
	}

    //to open the Sql connection
    private void openConnection()
    {
        string strConn;
        strConn = ConfigurationManager.ConnectionStrings["CIPConnectionString"].ConnectionString;
        conn = new SqlConnection(strConn);
        conn.Open();
        
    }

    private void closeConnection()
    {
        conn.Close();
    }
    
    //to get the dataset filled in with the data using the stored procedure
    public DataSet getDataset(string SPName, params SqlParameter[] commandParams)
    {
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        try
        {
            openConnection();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.CommandTimeout = 2400;

            cmd.CommandText = SPName;
            
            if (commandParams != null)
            {
                foreach (SqlParameter p in commandParams)
                {
                    if (p.Value == null)
                    {
                        p.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(p);
                }
            }
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.Parameters.Clear();
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
        finally
        {
            //to close the sqlconnection and disposing the other objects
            closeConnection();
            cmd.Dispose();
            da.Dispose();
        }
    }

    //to execute a non query (insert, update, delete)
    public int ExecuteNonQuery(string SPName, params SqlParameter[] commandParams)
    {
        SqlCommand cmd=new SqlCommand();
        int rowsAffected;
        try
        {
            openConnection();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = SPName;

            cmd.CommandTimeout = 600;

            if (commandParams != null)
            {
                foreach (SqlParameter p in commandParams)
                {
                    if (p.Value == null)
                    {
                        p.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(p);
                }
            }
            rowsAffected=cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return rowsAffected;
        }
        catch (Exception ex)
        {
            throw ex;
        }

        finally
        {
            //to close the sqlconnection and disposing the other objects
            closeConnection();
            cmd.Dispose();
        }
    }

    //to execute a non query (insert, update, delete)
    public int ExecuteNonQuery(string SPName, out string OutValue, params SqlParameter[] commandParams)
    {
        SqlCommand cmd = new SqlCommand();
        int rowsAffected;
        string strOutParam="";
        try
        {
            openConnection();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = SPName;

            if (commandParams != null)
            {
                foreach (SqlParameter p in commandParams)
                {
                    if (p.Value == null)
                    {
                        p.Value = DBNull.Value;
                    }

                    if (p.Direction.Equals(ParameterDirection.Output))
                    {
                        strOutParam = p.ParameterName;
                    }
                    cmd.Parameters.Add(p);
                }
            }
            rowsAffected = cmd.ExecuteNonQuery();
            //to set the output parameter (1 output parameter) value from the stored procedure
            OutValue=(string)cmd.Parameters[strOutParam].Value;
            cmd.Parameters.Clear();
            return rowsAffected;
        }
        catch (Exception ex)
        {
            throw ex;
        }

        finally
        {
            //to close the sqlconnection and disposing the other objects
            closeConnection();
            cmd.Dispose();
        }
    }
}
