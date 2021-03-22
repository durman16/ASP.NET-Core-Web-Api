using Altamira.Entities.Concrete;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.Build.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Altamira.DataAccess
{
    public class Data
    {
        public static void FakeData(AltamiraDbContext context)
        {
            if (!context.Users.Any())
            {
                string password = "abcdefghijklmnoprstuvwxyz0123456789";
                Random random = new Random();
                char[] newpass = new char[5];
                for (int i = 1; i < 11; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        newpass[j] = password[(int)(35 * random.NextDouble())];
                    }
                    var client = new WebClient();
                    var newUser = client.DownloadString("https://jsonplaceholder.typicode.com/users/" + i.ToString());
                    User user = JsonConvert.DeserializeObject<User>(newUser);
                    User createdUser = new User();
                    createdUser.name = user.name;
                    createdUser.username = user.username;
                    createdUser.email = user.email;
                    createdUser.password = new string(newpass);
                    createdUser.phone = user.phone;
                    createdUser.website = user.website;
                    createdUser.company = user.company;
                    createdUser.address = user.address;
                    context.Add(createdUser);
                    context.SaveChanges();
                }
            }
        }
    }
}
