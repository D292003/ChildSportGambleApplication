using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using ChildSportGambleApplication.Data;
using ChildSportGambleApplication.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Maps;
using static System.Runtime.InteropServices.JavaScript.JSType;
// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using ChildSportGambleApplication.Data;
using ChildSportGambleApplication.Models;
using System.Linq;
using Windows.System;

namespace ChildSportGambleApplication
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            using (var db = new AppDbContext())
            {
                //db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
        }

        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text.Trim();
            string password = PasswordTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password))
            {
                User_Info.Text = "Please enter both name and password.";
                return;
            }

            var newUser = new UserInfo
            {
                Name = name,
                Password = password,
                Points = 50
            };

            using (var db = new AppDbContext())
            {
                db.User_Info.Add(newUser);
                db.SaveChanges();
            }

            User_Info.Text = $"Created: {newUser.Id}: {newUser.Name} - ({newUser.Points} points){Environment.NewLine}";

            DisplayUsers();


            NameTextBox.Text = "";
            PasswordTextBox.Text = "";
        }

        private void DisplayUsers()
        {
            using (var db = new AppDbContext())
            {
                var users = db.User_Info.ToList();
                All_Info.Text = "";
                foreach (var u in users)
                {
                    All_Info.Text += $"{u.Id}: {u.Name} - ({u.Points} points){Environment.NewLine}";
                }
            }
        }


    }
}