using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TallerSeguridad.ControladoraWeb;

namespace TallerSeguridadInformatica.Paginas
{
    public partial class Promociones : System.Web.UI.Page
    {
        ControladoraWeb unaControladora = new ControladoraWeb();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void altaPromocion(object sender, EventArgs e)
        {
            if (titulo.Text == "" || desc.Text == "" || preO.Text == "" || preP.Text == "" || descuento.Text == "" || img.HasFile == false || dtlls.Text == "" || condic.Text == "")
            {
                lblMensaje.Text = "Ingrese todos los datos.";
            }
            else
            {
                string Titulo = titulo.Text;
                string Desc = desc.Text;
                double PreO = double.Parse(preO.Text);
                double PreP = double.Parse(preP.Text);
                int Descuento = int.Parse(descuento.Text);
                string Imagen = "";
                if (img.HasFile)
                {
                    img.SaveAs(Server.MapPath("~/BookImg/") + System.IO.Path.GetFileName(img.FileName));
                    string linkPath = HttpContext.Current.Server.MapPath("~/BookImg/") + System.IO.Path.GetFileName(img.FileName);

                    byte[] imageArray = File.ReadAllBytes(linkPath);
                    string base64ImageRepresentation = Convert.ToBase64String(imageArray);

                    Imagen = base64ImageRepresentation.ToString();

                }

            string Detalles = dtlls.Text;
            string Condicion = condic.Text;
            if (unaControladora.altaPromocion(Titulo, Desc, PreO, PreP, Descuento, Imagen, Detalles, Condicion))
            {
                lblMensaje.Text = "Promocion creada con exito!!";
            }
            else
            {
                lblMensaje.Text = "No se pudo crear la Promocion!!";
            }

        }

        }
    }
}