using Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserMVC
{
    public partial class UserAddFrom : Form
    {
        UserController cUser =new UserController();
        public UserAddFrom()
        {
            InitializeComponent();
            mskFecha.Text = Convert.ToString(DateTime.Now);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           var message = String.Empty;
            var result = false;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string pass = txtPass.Text;
            string email = txtEmail.Text;
            int nivelAcceso = cmbNivel.SelectedIndex;
            DateTime FechaAlta = DateTime.Now;
            DateTime UltimoAcceso = DateTime.Now;

            if (!String.IsNullOrEmpty(txtNombre.Text) && !String.IsNullOrEmpty(txtApellido.Text) && !String.IsNullOrEmpty(txtPass.Text) && !String.IsNullOrEmpty(txtEmail.Text))
            {
                result = cUser.UserAdd(nombre, apellido, pass, email, nivelAcceso, FechaAlta, UltimoAcceso);
            }
            else
                message = "Debe llenar los campos vacios";

            if (!result && String.IsNullOrEmpty(message))
                message = "El usuario ya existe";
            else if (result)
                message = "El usuario fue agreado correctamente";

            MessageBox.Show(message);
            txtNombre.Clear();
            txtApellido.Clear();
            txtApellido.Clear();
            txtEmail.Clear();
            txtPass.Clear();
        }

        private void btnlist_Click(object sender, EventArgs e)
        {
            UserListFrom UserList = new UserListFrom();
                UserList.Show();
        }
    }
}
