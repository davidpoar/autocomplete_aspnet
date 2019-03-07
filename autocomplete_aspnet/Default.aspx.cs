using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestAutocompleteWeb
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<Usuario> lstUsuarios = new List<Usuario>(
                    new Usuario[] {
                            new Usuario("Jose", "Rodrighez","Spain"),
                            new Usuario("David", "Porqueriñas", "Norfolk Island")
                        }
                    );

                GridView1.DataSource = lstUsuarios;
                GridView1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            lblSeleccionados.Text = "SELECCIONADOS: ";
            foreach (GridViewRow r in GridView1.Rows)
            {
                lblSeleccionados.Text += (r.Cells[2].Controls.OfType<UCAutotomplete>().First() as UCAutotomplete).Texto + ",";
            }
        }
    }

    public class Usuario
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Valor { get; set; }

        public Usuario(string nombre, string apellidos, string valor)
        {
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Valor = valor;
        }
    }
}