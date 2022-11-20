using System.Text.Json;
using Entities;

namespace Application.DataBase;

//Simulate DataBase
public class UserFileContext
{

    
    private string userFilePath = "users.json";
    private ICollection<User>? users;
    public ICollection<User> Users
    {
        get
        {
            if (users == null)
            {
                LoadData();
            }

            return users!;
        }
    }

    public UserFileContext()
    {
        if (!File.Exists(userFilePath))
        {
            Seed();
        }
    }
    
    private void Seed()
    {
        User[] us = {
            new User("Andrei", "Ioanas", "Dev", "Lorem ipsum dolor sit amet, consectetur adipiscing elit.") {
                id = 1,
            },
            new User("Kayne", "Bostock", "Admin", "Lorem ipsum dolor sit amet, consectetur adipiscing elit.") {
                id = 2,
            },
            new User("Gideon", "Carter", "User", "Etiam tempus lacus sit amet lectus aliquet, vel dictum felis luctus."){
                id = 3,
            },
            new User("Henry", "Solomon", "User", "Quisque sed nunc posuere, auctor eros sed, iaculis turpis.") {
                id = 4,
            },
            new User("Aqsa", "Sanford", "User", "Aliquam scelerisque nisi vel erat ullamcorper, tempor vehicula turpis venenatis.") {
                id = 5,
            },
        };
        users = us.ToList();
        SaveChanges();
    }
    public async void SaveChanges()
    {
        string serialize = JsonSerializer.Serialize(Users, new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = false
        });
        await File.WriteAllTextAsync(userFilePath,serialize);
        users = null;
    }
    private void LoadData()
    {
        string content = File.ReadAllText(userFilePath);
        users = JsonSerializer.Deserialize<List<User>>(content);
    }

}