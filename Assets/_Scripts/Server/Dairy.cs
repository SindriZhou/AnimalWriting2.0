using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using TMPro;

public class Dairy : MonoBehaviour
{
   
    public TMP_InputField contentInput;
    public TMP_Text successMessage;


    private MySqlConnection connection;
    private string connectionString = "Server=localhost;Database=Game;User=root;Password=zx19980611;";

    public void ConnectToDatabase()
    {
        connection = new MySqlConnection(connectionString);
        connection.Open();
    }

    public void Create()
    {
        ConnectToDatabase();

      
        string content = contentInput.text;

        string query = "INSERT INTO dairy (Content) VALUES (@content)";

        MySqlCommand command = new MySqlCommand(query, connection);
     
        command.Parameters.AddWithValue("@content", content);

        MySqlDataReader reader = command.ExecuteReader();

        if (reader.Read())
        {
            successMessage.text = "Create successful!";
            // Proceed with login success actions (e.g., load main game scene)
        }
        else
        {
            successMessage.text = "Successed!";
        }

        reader.Close();
        connection.Close();
    }
}
