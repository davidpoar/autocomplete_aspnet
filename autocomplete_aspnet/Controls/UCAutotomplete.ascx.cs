using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TestAutocompleteWeb
{
    public partial class UCAutotomplete : System.Web.UI.UserControl
    {
        [Bindable(true, BindingDirection.TwoWay)]
        [Browsable(true)]
        public string Valor
        {
            get
            {
                return hfValor.Value;
            }
            set
            {
                hfValor.Value = value;
            }
        }

        [Bindable(true, BindingDirection.TwoWay)]
        [Browsable(true)]
        public string Texto
        {
            get
            {
                return hfTexto.Value;
            }
            set
            {
                tbTexto.Text = value;
                hfTexto.Value = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var clientScriptManager = Page.ClientScript;

            if (!clientScriptManager.IsStartupScriptRegistered("a_plugin"))
            {
                clientScriptManager.RegisterStartupScript(Page.GetType(), "a_plugin", "<script src=\"Scripts/autocomplete.js\"></script>");
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            this.addStyleSheet("Content/autocomplete.css");
        }

        private void addStyleSheet(String href)
        {
            if (String.IsNullOrWhiteSpace(Convert.ToString(HttpContext.Current.Items[href])))
            {
                HttpContext.Current.Items[href] = href;
                HtmlLink sheet = new HtmlLink()
                {
                    Href = href
                };
                sheet.Attributes["rel"] = "stylesheet";
                sheet.Attributes["type"] = "text/css";
                this.Page.Header.Controls.Add(sheet);
            }
        }
    }
}