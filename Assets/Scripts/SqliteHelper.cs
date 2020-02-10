using Mono.Data.Sqlite;
using UnityEngine;
using System.Data;

public class SqliteHelper
{
    private const string database_name = "epsic_simulator";

    private string db_connection_string;
    private IDbConnection db_connection;

    public SqliteHelper()
    {
        db_connection_string = "URI=file:" + Application.persistentDataPath + "/" + database_name;
        db_connection = new SqliteConnection(db_connection_string);
        db_connection.Open();
    }

    ~SqliteHelper()
    {
        close();
    }

    public void createQuestionsTable()
    {
        IDbCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS questions (id INTEGER PRIMARY KEY, question TEXT)";
        dbcmd.ExecuteReader();
    }

    public IDataReader getDataById(string table_name, string id)
    {
        return getDataByString(table_name, "id", id);
    }

    public IDataReader getDataByString(string table_name, string key, string value)
    {
        IDbCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "SELECT * FROM " + table_name + " WHERE " + key + " = '" + value + "'";
        return dbcmd.ExecuteReader();
    }

    public void deleteDataById(string table_name, string id)
    {
        deleteDataByString(table_name, "id", id);
    }

    public void deleteDataByString(string table_name, string key, string value)
    {
        IDbCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "DELETE FROM " + table_name + " WHERE " + key + " = '" + value + "'";
        dbcmd.ExecuteNonQuery();
    }

    public IDbCommand getDbCommand()
    {
        return db_connection.CreateCommand();
    }

    public IDataReader getAllData(string table_name)
    {
        IDbCommand dbcmd = db_connection.CreateCommand();
        dbcmd.CommandText = "SELECT * FROM " + table_name;
        return dbcmd.ExecuteReader();
    }

    public void deleteAllData(string table_name)
    {
        IDbCommand dbcmd = db_connection.CreateCommand();
        dbcmd.CommandText = "DROP TABLE IF EXISTS " + table_name;
        dbcmd.ExecuteNonQuery();
    }

    public IDataReader getNumOfRows(string table_name)
    {
        IDbCommand dbcmd = db_connection.CreateCommand();
        dbcmd.CommandText = "SELECT COALESCE(MAX(id)+1, 0) FROM " + table_name;
        return dbcmd.ExecuteReader();
    }

    public void close()
    {
        db_connection.Close();
    }
}