using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleLogin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string defUserName = "SISC";
        string defPassword = "sisc123";

        FileManipulators fm = new FileManipulators();
        Dictionary<string, string[]> userDirectory = new Dictionary<string, string[]>(); 

        public MainWindow()
        {
            List<string> cont = new List<string>();
            string[] temp = new string[] { };
            cont = fm.FileRead("simpleDB.csv");

            InitializeComponent();

            ButtonCheck();

            foreach(string c in cont)
            {
                temp = c.Split(',');
                userDirectory[temp[0]] = new string[] { temp[1], temp[2] };
            }
        }
        /// <summary>
        /// This method just checks if the textboxes have content
        /// if they do, the button is enabled
        /// otherwise, it disables the button
        /// </summary>
        public void ButtonCheck()
        {
            if (txtUserName.Text.Length <= 0 || txtPassword.Text.Length <= 0)
                btnLogin.IsEnabled = false;
            else
                btnLogin.IsEnabled = true;
        }

        private void txtUserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            ButtonCheck();
        }

        private void txtPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            ButtonCheck();
            lblMessage.Content = "";
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(userDirectory.ContainsKey(txtUserName.Text))
            {
                if (userDirectory[txtUserName.Text][0] == txtPassword.Text)
                {
                    //MessageBox.Show($"Login Success! Welcome {userDirectory[txtUserName.Text][1]}!");
                    Window1 w1 = new Window1(userDirectory[txtUserName.Text][1]);
                    w1.Show();
                    this.Close();
                }
                else
                {
                    //MessageBox.Show("Username/Password is incorrect!");
                    txtPassword.Text = "";
                    lblMessage.Content = "Username/Password is incorrect!";
                }
            }
            else
            {
                //MessageBox.Show("Username/Password is incorrect!");
                txtPassword.Text = "";
                lblMessage.Content = "Username/Password is incorrect!";
            }
        }
    }
}
