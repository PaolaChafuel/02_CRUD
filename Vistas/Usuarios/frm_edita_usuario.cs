using _02_CRUD.Controladores;
using _02_CRUD.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02_CRUD.Vistas.Usuarios
{
    public partial class frm_edita_usuario : Form
    {
        private readonly Usuarios_Controller _usuarios_controller = new Usuarios_Controller();
        private readonly AuthController _auth_controller = new AuthController();
        int _id;

        public frm_edita_usuario(int id_usuario)
        {
            InitializeComponent();
            _id = id_usuario;
        }

        private void frm_edita_usuario_Load(object sender, EventArgs e)
        {
            Usuario_Model usuario_Model = new Usuario_Model();
            usuario_Model = _usuarios_controller.uno(_id);
            txt_Apellidos.Text = usuario_Model.Apellido_Usuario;
            txt_Cedula.Text = usuario_Model.Cedula_Usuario;
            txt_Contrasenia.Text = usuario_Model.contasenia;
            txt_Correos.Text = usuario_Model.Correo_Usuario;
            txt_Nombres.Text = usuario_Model.Nombre_Usuario;
            chb_Estado.Checked = usuario_Model.Estado;
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            if (!validaciones())
            {
                MessageBox.Show("Complete los campos para guadar e usuario");
                return;
            }

            var usuario_model = new Usuario_Model
            {
                Apellido_Usuario = txt_Apellidos.Text.Trim(),
                Cedula_Usuario = txt_Cedula.Text.Trim(),
                contasenia = txt_Contrasenia.Text.Trim(),
                Correo_Usuario = txt_Correos.Text.Trim(),
                Estado = chb_Estado.Checked == true,
                Nombre_Usuario = txt_Nombres.Text.Trim(),
                Id_Usuario = _id
            };

            var nuevo_usuario = _usuarios_controller.editar(usuario_model);
            if (nuevo_usuario.Item1 == null)
            {
                MessageBox.Show(nuevo_usuario.error);
            }
            else
            {
                MessageBox.Show("Se guardo con éxito");
                limpiarcajas();
                var frm_lista = new frm_lista_usuarios();
                frm_lista.Show();
                this.Close();
            }
        }
        public void limpiarcajas()
        {
            txt_Apellidos.Text = "";
            txt_Cedula.Text = string.Empty;
            txt_Contrasenia.Text = "";
            txt_Correos.Text = "";
            txt_Nombres.Text = "";
            chb_Estado.Checked = false;
        }

        public bool validaciones()
        {
            if (txt_Apellidos.Text.Trim() == "" || txt_Cedula.Text.Trim() == ""
                 || txt_Contrasenia.Text.Trim() == "" || txt_Correos.Text.Trim() == ""
                 || txt_Nombres.Text.Trim() == "")
            {
                return false;
            }
            else
            {
                return true;
            }

        }


    }
}