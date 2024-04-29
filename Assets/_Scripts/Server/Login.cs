using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using TMPro;


public class Login : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public Text loginMessage;

    private MySqlConnection connection;
    private string connectionString = "Server=localhost;Database=Game;User=root;Password=zx19980611;";

    public GameObject LoginMenu;
    public GameObject StartMenu;

    public void ConnectToDatabase()
    {
        connection = new MySqlConnection(connectionString);
        connection.Open();
    }

    public void LoginUser()
    {
        ConnectToDatabase();

        string username = usernameInput.text;
        string password = passwordInput.text;

        string query = "SELECT * FROM user WHERE UserName = @username AND Password = @password";

        MySqlCommand command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@username", username);
        command.Parameters.AddWithValue("@password", password);

        MySqlDataReader reader = command.ExecuteReader();

        if (reader.Read())
        {
            loginMessage.text = "Login successful!";
            // Proceed with login success actions (e.g., load main game scene)
            LoginMenu.SetActive(false);
            StartMenu.SetActive(true);

        }
        else
        {
            loginMessage.text = "Invalid username or password!";
        }

        reader.Close();
        connection.Close();
    }
}
