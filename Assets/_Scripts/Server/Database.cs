using UnityEngine;
using System;
using System.Data;
using MySql.Data.MySqlClient;

public class DatabaseManager : MonoBehaviour
{
    private MySqlConnection connection;
    private string server;
    private string database;
    private string uid;
    private string password;

    void Start()
    {
        Initialize();
        Connect();
        InsertData("ccc", "111");

        // Example usage of SQL SELECT query
        //SelectData();
    }

    void Initialize()
    {
        server = "127.0.0.1";
        database = "Game";
        uid = "root";
        password = "zx19980611";
        string connectionString;
        connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";

        connection = new MySqlConnection(connectionString);
    }

    void Connect()
    {
        try
        {
            connection.Open();
            Debug.Log("Connected to MySQL database.");
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error connecting to MySQL database: {ex.Message}");
        }
    }

    //void SelectData()
    //{
    //    string query = "SELECT * FROM YourTableName";

    //    MySqlCommand cmd = new MySqlCommand(query, connection);
    //    MySqlDataReader dataReader = null;

    //    try
    //    {
    //        dataReader = cmd.ExecuteReader();

    //        while (dataReader.Read())
    //        {
    //            // Access data by column name or index
    //            string column1Value = dataReader.GetString("column1");
    //            int column2Value = dataReader.GetInt32("column2");

    //            Debug.Log($"Column1: {column1Value}, Column2: {column2Value}");
    //        }

    //        // Close the reader when done
    //        dataReader.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        Debug.LogError($"Error selecting data: {ex.Message}");

    //        // Make sure to close the reader in case of exception
    //        if (dataReader != null && !dataReader.IsClosed)
    //            dataReader.Close();
    //    }
    //}

    void InsertData(string username, string password)
    {
        string query = $"INSERT INTO user (UserName, Password) VALUES ('{username}', '{password}')";

        MySqlCommand cmd = new MySqlCommand(query, connection);

        try
        {
            cmd.ExecuteNonQuery();
            Debug.Log("Data inserted successfully.");
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error inserting data: {ex.Message}");
        }
    }


    void OnApplicationQuit()
    {
        if (connection != null && connection.State != System.Data.ConnectionState.Closed)
        {
            connection.Close();
            Debug.Log("Disconnected from MySQL database.");
        }
    }
}
