﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CIPMSBC
{
	/// <summary>
	/// Summary description for CIPRSDataAccess
	/// </summary>
	public class SQLDBAccess
	{
		private SqlDataAdapter da;

		public SQLDBAccess(string ConnectionStrinKey)
		{
			SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[ConnectionStrinKey].ConnectionString);

			da = new SqlDataAdapter();

			da.SelectCommand = new SqlCommand();
			da.SelectCommand.Connection = connection;
			da.SelectCommand.CommandType = CommandType.StoredProcedure;

			da.InsertCommand = new SqlCommand();
			da.InsertCommand.Connection = connection;
			da.InsertCommand.CommandType = CommandType.StoredProcedure;

			da.UpdateCommand = new SqlCommand();
			da.UpdateCommand.Connection = connection;
			da.UpdateCommand.CommandType = CommandType.StoredProcedure;

			da.DeleteCommand = new SqlCommand();
			da.DeleteCommand.Connection = connection;
			da.DeleteCommand.CommandType = CommandType.StoredProcedure;
		}

		/// <summary>
		/// Add input parameter
		/// </summary>
		/// <param name="paramname"></param>
		/// <param name="paramvalue"></param>
		public void AddParameter(string paramname, Object paramvalue)
		{
			SqlParameter param = new SqlParameter();
			param.ParameterName = paramname;
			param.Value = paramvalue;
			da.SelectCommand.Parameters.Add(param);
		}

		public SqlDataReader ExecuteReader(String strSelectCommand)
		{
			SqlCommand cmd = da.SelectCommand;
			SqlDataReader reader = null;
			try
			{
				cmd.CommandText = strSelectCommand;
				if (cmd.Connection.State == ConnectionState.Closed)
					cmd.Connection.Open();
				reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			}
			catch
			{
				throw;
			}

			return reader;
		}

		public Object ExecuteScalar(string strSelectCommand)
		{
			SqlCommand cmd = da.SelectCommand;
			Object ret = null;
			try
			{
				cmd.CommandText = strSelectCommand;
				if (cmd.Connection.State == ConnectionState.Closed)
					cmd.Connection.Open();
				ret = cmd.ExecuteScalar();
				cmd.Connection.Close();
			}
			catch
			{
				throw;
			}
			return ret;
		}

		public int ExecuteNonQuery(string strSelectCommand)
		{
			SqlCommand cmd = da.SelectCommand;
			int ret = 0;
			try
			{
				cmd.CommandText = strSelectCommand;
				if (cmd.Connection.State == ConnectionState.Closed)
					cmd.Connection.Open();
				ret = cmd.ExecuteNonQuery();
				cmd.Connection.Close();
			}
			catch
			{
				throw;
			}

			return ret;
		}

		public DataTable FillDataTable(string strSelectCommand)
		{
			DataTable dt = new DataTable();
			da.SelectCommand.CommandText = strSelectCommand;
			da.Fill(dt);
			return dt;
		}

		public DataSet FillDataSet(string strSelectCommand)
		{
			DataSet ds = new DataSet();
			da.SelectCommand.CommandText = strSelectCommand;
			da.Fill(ds);
			return ds;
		}
	}

}
