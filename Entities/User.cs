namespace Entities;


public class User
{
    public  String username{ get;  set; }
    public  String lName{ get;  set; }
    public  String role{ get;  set; }
    public  String description{ get;  set; }

    public int id { get; set; }
    
    public User()
    {
    }
    //Constructor for client
    public User(string username, string lName, string role, string description)
    {
        this.username = username;
        this.lName = lName;
        this.role = role;
        this.description = description;

    }
    public User(string username, string lName, string role, string description, int id)
    {
        this.username = username;
        this.lName = lName;
        this.role = role;
        this.description = description;
        this.id = id;
    }
}