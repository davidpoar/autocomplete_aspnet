using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace TestAutocompleteWeb
{
    /// <summary>
    /// Descripción breve de WSPaises
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
    // [System.Web.Script.Services.ScriptService]
    public class WSPaises : System.Web.Services.WebService
    {
        public static readonly String[] paises = { "Afghanistan", "Albania", "Algeria", "Andorra", "Angola", "Antigua and Barbuda", "Argentina", "Armenia", "Australia", "Ashmore and Cartier Islands", "Australian Antarctic Territory", "Christmas Island", "Cocos (Keeling) Islands", "Coral Sea Islands Territory", "Heard Island and McDonald Islands", "Norfolk Island", "Austria", "Azerbaijan", "Bahamas", " The", "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium", "Belize", "Benin", "Bhutan", "Bolivia", "Bosnia and Herzegovina", "Federation of Bosnia and Herzegovina", "Republika Srpska", "Botswana", "Brazil", "Brunei", "Bulgaria", "Burkina Faso", "Burma", "Burundi", "Cambodia", "Cameroon", "Canada", "Cape Verde", "Central African Republic", "Chad", "Chile", "China", "Hong Kong", "Macau", "Colombia", "Comoros", "Congo", " Democratic Republic of the", "Congo", " Republic of the", "Costa Rica", "Croatia", "Cuba", "Cyprus", "Czech Republic", "Denmark", "Faroe Islands", "Greenland", "Djibouti", "Dominica", "Dominican Republic", "East Timor", "Ecuador", "Egypt", "El Salvador", "Equatorial Guinea", "Eritrea", "Estonia", "Ethiopia", "Fiji", "Finland", "Åland", "France", "Clipperton Island", "French Polynesia", "New Caledonia", "Saint Barthélemy", "Saint Martin", "Saint Pierre and Miquelon", "Wallis and Futuna", "French Southern and Antarctic Lands", "Gabon", "Gambia", " The", "Georgia", "Germany", "Ghana", "Greece", "Grenada", "Guatemala", "Guinea", "Guinea-Bissau", "Guyana", "Haiti", "Honduras", "Hungary", "Iceland", "India", "Indonesia", "Iran", "Iraq", "Ireland", "Israel", "Italy", "Ivory Coast", "Jamaica", "Japan", "Jordan", "Kazakhstan", "Kenya", "Kiribati", "Korea", " North", "Korea", " South", "Kuwait", "Kyrgyzstan", "Laos", "Latvia", "Lebanon", "Lesotho", "Liberia", "Libya", "Cyrenaica", "Liechtenstein", "Lithuania", "Luxembourg", "Macedonia", "Madagascar", "Malawi", "Malaysia", "Maldives", "Mali", "Malta", "Marshall Islands", "Mauritania", "Mauritius", "Mexico", "Micronesia", " Federated States of", "Moldova", "Monaco", "Mongolia", "Montenegro", "Morocco", "Mozambique", "Namibia", "Nauru", "Nepal", "Netherlands", "Netherlands", "Aruba", "Curaçao", "Sint Maarten", "New Zealand", "Ross Dependency", "Tokelau", "Cook Islands", "Niue", "Nicaragua", "Niger", "Nigeria", "Norway", "Oman", "Pakistan", "Azad Kashmir", "Gilgit–Baltistan", "Palau", "Palestine", "Panama", "Papua New Guinea", "Paraguay", "Peru", "Philippines", "Poland", "Portugal", "Qatar", "Romania", "Russia", "Rwanda", "Saint Kitts and Nevis", "Saint Lucia", "Saint Vincent and the Grenadines", "Samoa", "San Marino", "São Tomé and Príncipe", "Saudi Arabia", "Senegal", "Serbia", "Seychelles", "Sierra Leone", "Singapore", "Slovakia", "Slovenia", "Solomon Islands", "Somalia", "South Africa", "South Sudan", "Spain", "Sri Lanka", "Sudan", "Suriname", "Swaziland", "Sweden", "Switzerland", "Syria", "Tajikistan", "Tanzania", "Thailand", "Togo", "Tonga", "Trinidad and Tobago", "Tunisia", "Turkey", "Turkmenistan", "Tuvalu", "Uganda", "Ukraine", "United Arab Emirates", "United Kingdom", "Akrotiri and Dhekelia", "Anguilla", "Bermuda", "British Indian Ocean Territory", "British Virgin Islands", "Cayman Islands", "Falkland Islands", "Gibraltar", "Montserrat", "Pitcairn Islands", "Saint Helena", " Ascension and Tristan da Cunha", "South Georgia and the South Sandwich Islands", "Turks and Caicos Islands", "British Antarctic Territory", "Guernsey", "Alderney", "Herm", "Sark", "Isle of Man", "Jersey", "United States", "American Samoa", "Guam", "Northern Mariana Islands", "Puerto Rico", "U.S. Virgin Islands", "Marshall Islands", "Micronesia", "Palau", "Uruguay", "Uzbekistan", "Vanuatu", "Vatican City", "Venezuela", "Vietnam", "Yemen", "Zambia", "Zimbabwe", "Abkhazia", "Cook Islands", "Kosovo", "Nagorno-Karabakh", "Niue", "Northern Cyprus", "Sahrawi Arab Democratic Republic", "Somaliland", "South Ossetia", "Taiwan", "Transnistria" };

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetPaises(string filtro)
        {
            var paises_filtrados = paises.Where(p => p.ToLower().Contains(filtro.ToLower())).Take(10).ToArray();

            this.Context.Response.ContentType = "application/json; charset=utf-8";

            List<Resultado> resultado = new List<Resultado>();
            int i = 1;
            foreach (var r in paises_filtrados)
            {
                resultado.Add(new Resultado(i, r));
                i++;
            }

            this.Context.Response.Write(new JavaScriptSerializer().Serialize(resultado));
        }

        [WebMethod]
        [ScriptMethod]
        public List<String> GetCompletionList(string prefixText, int count)
        {
            var paises_filtrados = paises.Where(p => p.ToLower().Contains(prefixText.ToLower())).Take(count).ToList();

            List<string> items = new List<string>(paises_filtrados.Count);
            int i = 1;
            foreach (var r in paises_filtrados)
            {
                items.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(r, i.ToString()));
                i++;
            }
            return items;
        }

        public class Resultado
        {
            public Resultado()
            {
            }

            public Resultado(int id, string nombre)
            {
                this.Id = id;
                this.Nombre = nombre;
            }

            public int Id { get; set; }
            public string Nombre { get; set; }
        }
    }
}