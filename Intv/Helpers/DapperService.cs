using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Intv.Helpers
{
    public class DapperService
    {
        public string connectionString { get; set; }

        private ArrayList paramsList;

        public DapperService(string conn)
        {
            connectionString = conn;
            paramsList = new ArrayList();
        }

        public IEnumerable<T> Query<T>(string query, object parameters = null, CommandType commandType = CommandType.Text)
        {
            IDbConnection myConnection = new SqlConnection(connectionString);
            IDbCommand command = myConnection.CreateCommand();
            command.CommandText = query;
            command.CommandTimeout = 120;
            IEnumerable<T> ret = new List<T>();
            try
            {
                myConnection.Open();
                addParametersToCommand(command);
                ret = myConnection.Query<T>(query, parameters, commandType: commandType);
            }
            catch (SqlException exception)
            {
                string fileName = "Logs/" + DateTime.Now.ToString("dd.MM.yyyy") + "_sqlerror.log";
                if (!System.IO.File.Exists(fileName)) (System.IO.File.Create(fileName)).Close();
                string text = "\n" + DateTime.Now.ToShortTimeString() + "\n" + exception.Message;
                System.IO.File.AppendAllText(fileName, text);
                throw new Exception(exception.Message);
            }
            finally
            {
                myConnection.Close();
                command.Dispose();
                myConnection.Dispose();
            }
            return ret;
        }
        public T QueryFirst<T>(T ret, string query, object parameters = null,CommandType commandType = CommandType.Text)
        {
            IDbConnection myConnection = new SqlConnection(connectionString);
            IDbCommand command = myConnection.CreateCommand();
            command.CommandText = query;
            command.CommandTimeout = 120;
             
            try
            {
                myConnection.Open();
                addParametersToCommand(command);
                ret = myConnection.Query<T>(query, parameters, commandType: commandType).FirstOrDefault();
            }
            catch (SqlException exception)
            {
                string fileName = "Logs/" + DateTime.Now.ToString("dd.MM.yyyy") + "_sqlerror.log";
                if (!System.IO.File.Exists(fileName)) (System.IO.File.Create(fileName)).Close();
                string text = "\n" + DateTime.Now.ToShortTimeString() + "\n" + exception.Message;
                System.IO.File.AppendAllText(fileName, text);
                throw new Exception(exception.Message);
            }
            finally
            {
                myConnection.Close();
                command.Dispose();
                myConnection.Dispose();
            }
            return ret;
        }

        public IDataReader Select(string queryText)
        {
            IDbConnection myConnection = new SqlConnection(connectionString);
            IDbCommand command = myConnection.CreateCommand();
            command.CommandText = queryText;
            command.CommandTimeout = 120;
            IDataReader ret = null;
            try
            {
                myConnection.Open();

                addParametersToCommand(command);
                ret = command.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (SqlException exception)
            {
                string fileName = "Logs/" + DateTime.Now.ToString("dd.MM.yyyy") + "_sqlerror.log";
                if (!System.IO.File.Exists(fileName)) (System.IO.File.Create(fileName)).Close();
                string text = "\n" + DateTime.Now.ToShortTimeString() + "\n" + exception.Message;
                System.IO.File.AppendAllText(fileName, text);
                throw new Exception(exception.Message);
            }

            return ret;
        }

        public int Execute(string query, object parameters = null, CommandType commandType = CommandType.Text)
        {
            IDbConnection myConnection = new SqlConnection(connectionString);
            IDbCommand command = myConnection.CreateCommand();
            command.CommandText = query;
            command.CommandTimeout = 120;
            int ret = 0;
            try
            {
                myConnection.Open();
                addParametersToCommand(command);
                ret = myConnection.Execute(query, parameters, commandType: commandType);
            }
            catch (SqlException exception)
            {
                string fileName = "Logs/" + DateTime.Now.ToString("dd.MM.yyyy") + "_sqlerror.log";
                if (!System.IO.File.Exists(fileName)) (System.IO.File.Create(fileName)).Close();
                string text = "\n" + DateTime.Now.ToShortTimeString() + "\n" + exception.Message;
                System.IO.File.AppendAllText(fileName, text);
                throw new Exception(exception.Message);
            }
            finally
            {
                myConnection.Close();
                command.Dispose();
                myConnection.Dispose();
            }
            return ret;
        }

        private void addParametersToCommand(IDbCommand command)
        {
            foreach (Parameter p in this.paramsList)
            {
                IDbDataParameter iparam = command.CreateParameter();
                iparam.ParameterName = p.Name;
                iparam.DbType = p.Type;
                iparam.Size = p.Size;
                iparam.Value = p.Value;
                command.Parameters.Add(iparam);
            }
        }

        public void ClearParams()
        {
            this.paramsList.Clear();
        }
        public void AddParam(string name, DbType type, object value, int size = 0)
        {
            paramsList.Add(new Parameter(name, type, value, size));
        }
        public class Parameter
        {
            /// <summary>Название параметра @..</summary>
            public String Name;
            /// <summary>Значение параметра</summary>
            public object Value;
            /// <summary>Тип параметра</summary>
            public DbType Type;
            /// <summary>Длина значения</summary>
            public int Size;

            public Parameter(string Name, DbType Type, object Value, int Size)
            {
                this.Name = Name;
                this.Value = Value??DBNull.Value;
                this.Type = Type;
                this.Size = Size;
            }
        }
    }
}
