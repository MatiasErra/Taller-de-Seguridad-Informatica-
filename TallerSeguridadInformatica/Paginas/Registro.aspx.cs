using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SeguridadInformatica.Dominio;
using TallerSeguridad.ControladoraWeb;
using static System.Net.Mime.MediaTypeNames;

namespace TallerSeguridadInformatica.Paginas
{
    public partial class Registro : System.Web.UI.Page
    {
        ControladoraWeb controladora = new ControladoraWeb();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void registro(object sender, EventArgs e)
        {
            if (usuario.Text == "" || contrasenia.Text == "")
            {
                lblMensaje.Text = "Complete todos los datos.";
            }
            else
            {
                List<Usuario> listaUsuarios = controladora.listarUsuarios();
                string Nombre = usuario.Text;
                string Contraseña = "";
                byte[] bytes = Encoding.Unicode.GetBytes(contrasenia.Text);
                SHA256Managed hashstring = new SHA256Managed();
                byte[] hash = hashstring.ComputeHash(bytes);
                foreach (byte x in hash)
                {
                    Contraseña += String.Format("{0:x2}", x);
                }
                int cont = 0;
                foreach (Usuario unUsuario in listaUsuarios)
                {
                    if (unUsuario.Nombre == Nombre)
                    {
                        cont++;
                    }
                }
                if (cont == 0)
                {
                    if (controladora.altaUsuario(Nombre, Contraseña))
                    {
                        Response.Redirect("~/Paginas/Ingreso.aspx");
                    }
                    else
                    {
                        lblMensaje.Text = "Error al registrarse";
                    }
                }
                else
                {
                    lblMensaje.Text = "Error al registrarse";
                }
            }
            

        }
    }
}