using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Lab04_05
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {

        public class User
        {

            public string Login {  get; set; }
            protected string password {  get; set; }


            public bool IsLoggedIn = false;
            public bool isAdmin = false;

            public bool Loging(string name, string password)
            {

                if(name == "Admin" &&  password == "1234")
                {
                    isAdmin = true;
                    this.IsLoggedIn = true;
                    this.Login = name;
                    this.password = password;

                    return true;
                }
                else if (name =="Egor" &&  password == "1234")
                {
                    this.IsLoggedIn = true;
                    this.Login = name;
                    this.password = password;

                    return true;
                }


                return false;


            }

        }


        User user = new User();


        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            
            if (user.IsLoggedIn)
            {
                //new MainWindow().Show();
              
            }
            else
            {
                new Authorization().ShowDialog();
            }
        }
    }
}
