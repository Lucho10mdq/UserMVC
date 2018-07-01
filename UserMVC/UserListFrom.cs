using Controlador;
using Modelo;
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
    public partial class UserListFrom : Form
    {
        UserController cUser = new UserController();
        public UserListFrom()
        {
            InitializeComponent();
        }

        private void UserListFrom_Load(object sender, EventArgs e)
        {
            
            foreach (User oUser in cUser.ReturnAll())
            {
                dtgGetAllUser.Rows.Add(oUser.Id,oUser.LastName, oUser.Name, oUser.Email, oUser.Password, oUser.CreationTime, oUser.AccessLast, oUser.LevelAccess1);
            }
        }

        private void dtgGetAllUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string emails = txtEmails.Text;
            var result = 0;
            var message = String.Empty;
            if (!String.IsNullOrEmpty(txtEmails.Text))
                result = cUser.BorrarUsuario(emails);
            else
                message = "Debe llenar los campocs vacios";
            if (result==0 && String.IsNullOrEmpty(message))
                message = "El usuario no existe";
            else if (result!=0)
                message = "El usuario fue borrado correctamente";
            MessageBox.Show(message);
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string lastname = txtApellido.Text;
            
            foreach (User oUser in cUser.ReturnUsuariosPorApellido(lastname))
            {
                dtgGetAllUser.Rows.Clear();
                dtgGetAllUser.Rows.Add(oUser.LastName, oUser.Name, oUser.Email, oUser.Password, oUser.CreationTime, oUser.AccessLast, oUser.LevelAccess1);
            }
        }
    }
}
