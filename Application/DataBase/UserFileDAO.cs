using Entities;
using System.Collections;

namespace Application.DataBase;

public class UserFileDao : IUserDAO 
{
    //Placeholder for database access
    private UserFileContext fileContext;
    
    public UserFileDao(UserFileContext fileContext)
    {
        this.fileContext = fileContext;
    }

    public async Task<ICollection<User>> GetAsync()
    {
        Console.WriteLine("GetAsync");
        ICollection<User> users = fileContext.Users;
        return users;
        
    }
    //Not used by current client
    public async Task<User> GetUserByUsername(string username)
    {
        return  fileContext.Users.First(t => t.username==username);
    }
    //Not used by current client
    public async Task<User> GetUserById(int id)
    {
        return  fileContext.Users.First(t => t.id==id);
    }

    public async Task AddUserAsync(User user)
    {
        if (fileContext.Users.Contains(user))
        {
            throw new Exception("Username already in use. Pleas try another one");
        }
        int largestId = fileContext.Users.Max(t => t.id);
        int nextId = largestId + 1;
        user.id = nextId;
        fileContext.Users.Add(user);
        fileContext.SaveChanges();
    }
    //Not used by current client
    public async Task DeleteAsync(int id)
    {
        User toDelete = fileContext.Users.First(t => t.id == id);
        fileContext.Users.Remove(toDelete);
        fileContext.SaveChanges();
    }
    //Not used by current client
    public async Task UpdateAsync(User user)
    {
        User toUpdate = fileContext.Users.First(t => t.id == user.id);
        toUpdate.username = user.username;
        toUpdate.lName = user.lName;
        toUpdate.role = user.role;
        toUpdate.description = user.description;

        fileContext.SaveChanges();
    }
}