using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using MySql.Data.MySqlClient;

namespace Login
{
    public partial class frmlogin : Form
    {
        MySqlConnection conectar = new MySqlConnection
            ("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand comando;
        MySqlDataReader mdr;
        public frmlogin()
        {
            InitializeComponent();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmlogin_Load(object sender, EventArgs e)
        {

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Fields missing to be filled");
            }
            else
            {
                conectar.Open();
                string seleccionar = "SELECT * FROM loginform.userinfo WHERE Usuario = '" + txtUsername.Text + "' AND Contraseña = '" + txtPassword.Text + "';";
                comando = new MySqlCommand(seleccionar, conectar);
                mdr = comando.ExecuteReader();

                if (mdr.Read())
                {
                    string conexion = "datasource=localhost;port=3306;username=root;password=";
                    string Query = "update loginform.userinfo set UltimaConexion='" + dtp.Value + "' where usuario='" + this.txtUsername.Text + "';";
                    MySqlConnection conect2 = new MySqlConnection(conexion);

                    MySqlCommand comm2 = new MySqlCommand(Query, conect2);
                    MySqlDataReader reader;
                    conect2.Open();
                    reader = comm2.ExecuteReader();
                    while (reader.Read())
                    {
                    }
                    conect2.Close();

                    MessageBox.Show("Session started successfully!");
                    this.Hide();

                    Inicio prin = new Inicio();
                    prin.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Data doesn't match");
                }
                conectar.Close();
            }
        }

        private void btncreate_Click(object sender, EventArgs e)
        {
            Register reg = new Register();
            reg.Show();
            this.Hide();
        }
    }
}
