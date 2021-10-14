using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace ExpenseTracker.Model
{
    //validation (check for user name and password if present)
    //create a new user if not already present
    //save data to file of specific user


    public class UserManager
    {
        User currentUser = null;
        FileManager fileManager;

        public UserManager()
        {
            this.fileManager = new FileManager();
        }

        public bool IsValidUser(string username, string password)
        {
            //check if user exists or not in .json
            string userJson = this.fileManager.ReadFileData(username);
            if (userJson != null)
            {
                return true;
            }
            return false;
        }

        public User GetUser(string username)
        {
            if (!string.IsNullOrWhiteSpace(username))
            {
                var filestring = this.fileManager.ReadFileData(username);
                if (!string.IsNullOrEmpty(filestring))
                {
                    this.currentUser = JsonSerializer.Deserialize<User>(filestring);
                    return this.currentUser;
                }
            }

            return null;
        }

        public User CreatenewUser(string username, string password)
        {
            this.currentUser = new User()
            {
                UserName = username,
                Password = password,
                Budgets = new List<Budget>()
            };

            var userJsonString = JsonSerializer.Serialize(this.currentUser);

            // Save user data to File
            if (this.fileManager.SaveDataToFile(username, userJsonString))
            {
                return this.currentUser;
            }

            return null;
        }

        public void SaveUserData(User user)
        {
            var serializedJsonstring = JsonSerializer.Serialize<User>(user);
            this.fileManager.SaveDataToFile(user.UserName, serializedJsonstring);
        }
    }
}
