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

            // TODO: Read JSON file and create User object and return.


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

            // If unable to save user data return null.
            return null;
        }

        public void SaveUserData(User user)
        {
            // TODO: Save user object to JSON and then to file.
        }
    }
}
