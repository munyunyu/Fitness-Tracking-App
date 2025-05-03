using Fitness_Tracking_App.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fitness_Tracking_App
{
    public partial class Form1 : Form
    {
        private readonly AppDbContext context;
        public Form1()
        {
            InitializeComponent();

            context = new AppDbContext();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            //seed database with admin user if the user table is empty
            SeedDatabaseWithAdminUser();

            //perform login functionality
            //get the user by username and then compare the password
            var record = context.TblUser.SingleOrDefault(x => x.Username == usernameTxt.Text.ToLower());

            if (record != null)
            {
                //dispay error message
                //user with email addess was not found
            }
            else
            {
                if(passwordTxt.Text == record.Password)
                {
                    //login was successful
                    //navigate user to next page
                }
                else
                {
                    //dispay error message
                    //user with email and password does not match
                }
            }


        }

        private void SeedDatabaseWithAdminUser()
        {
            //check if table has any record
            var exists = context.TblUser.Any();

            //if record was found, abort user creation
            if (exists) return;

            //else create admin ser
            var record = new TblUser
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                Username = "percy.munyunyu@gmail.com".ToLower(),
                Password = "Pass$123"
            };

            //add new record to the TblUser table
            context.TblUser.Add(record);

            //Save changes to the database
            context.SaveChanges();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            
            context.Dispose();

            base.OnFormClosing(e);
        }




    }
}
