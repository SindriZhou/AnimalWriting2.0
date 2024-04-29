using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using TMPro;

public class Write : MonoBehaviour
{
    public TMP_Text usernameText;
    public TMP_Text passwordText;

    private string connectionString;
    private MySqlConnection MS_Connection;

    public void sendInfo()
    {
        connection();

        // Get the username and password from the text fields
        string username = usernameText.text;
        string password = passwordText.text;

        // Ensure both username and password are not empty
        if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
        {
            // Construct the parameterized query to insert username and password
            string query = "INSERT INTO user (UserName, Password) VALUES (@username, @password)";

            // Create MySqlCommand object with the parameterized query and connection
            MySqlCommand command = new MySqlCommand(query, MS_Connection);

            // Add parameters to the command
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);

            // Execute the command
            command.ExecuteNonQuery();

            Debug.Log("User inserted successfully.");

            // Close the database connection
            MS_Connection.Close();
        }
        else
        {
            Debug.LogError("Username and password cannot be empty.");
        }
    }

    public void connection()
    {
        // Set up the connection string
        connectionString = "Server=localhost;Database=Game;User=root;Password=zx19980611;";

        // Create MySqlConnection object with the connection string
        MS_Connection = new MySqlConnection(connectionString);

        // Open the database connection
        MS_Connection.Open();
    }
}
