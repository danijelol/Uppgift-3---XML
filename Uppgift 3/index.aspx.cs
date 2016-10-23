using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Xml.Linq;

namespace Uppgift_3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnFiltrera_Click(object sender, EventArgs e)
        {
            LäggTillAllaAktier(XmlTillLista());

        }


        public void LäggTillAllaAktier(List<Aktier> aktielista)
        {
            string val = valTyp.SelectedValue;

            foreach (Aktier a in aktielista)
            {
                HtmlGenericControl div = new HtmlGenericControl("div");



                if (val == "1") //Visa alla
                {
                    div.InnerText = a.Aktienamn + " " + a.Aktietyp + " " + a.Köp + " " + a.Sälj;
                }
                else if (val == a.Aktietyp)
                {
                    div.InnerText = a.Aktienamn + " " + a.Köp + " " + a.Sälj;
                }


                aktieDiv.Controls.Add(div);
            }

        }


        public List<Aktier> XmlTillLista()
        {
            List<Aktier> aktielista = new List<Aktier>();

            string sökväg = Server.MapPath("aktier.xml");
            
            XmlDocument doc = new XmlDocument();
            doc.Load(sökväg);
            XmlNodeList allaAktier;

            if (valCap.SelectedValue == "1") //Visa alla
            {

                allaAktier = doc.SelectNodes("/Portfölj/*/Aktie");

                foreach (XmlNode node in allaAktier)
                {

                    Aktier a = new Aktier();
                    a.Aktietyp = node.Attributes["Aktietyp"].InnerText;
                    a.Aktienamn = node["Aktienamn"].InnerText;
                    a.Köp = Convert.ToInt32(node["Köp"].InnerText);
                    a.Sälj = Convert.ToInt32(node["Sälj"].InnerText);

                    aktielista.Add(a);

                }

            }

            else if (valCap.SelectedValue == "2") //2 = Small Cap
            {
                allaAktier = doc.SelectNodes("/Portfölj/SmallCap/Aktie");

                foreach (XmlNode node in allaAktier)
                {
                    Aktier a = new Aktier();
                    a.Aktietyp = node.Attributes["Aktietyp"].InnerText;
                    a.Aktienamn = node["Aktienamn"].InnerText;
                    a.Köp = Convert.ToInt32(node["Köp"].InnerText);
                    a.Sälj = Convert.ToInt32(node["Sälj"].InnerText);

                    aktielista.Add(a);

                }
            }
            else if (valCap.SelectedValue == "3") //3 = Mid Cap
            {
                allaAktier = doc.SelectNodes("/Portfölj/MidCap/Aktie");

                foreach (XmlNode node in allaAktier)
                {
                    Aktier a = new Aktier();
                    a.Aktietyp = node.Attributes["Aktietyp"].InnerText;
                    a.Aktienamn = node["Aktienamn"].InnerText;
                    a.Köp = Convert.ToInt32(node["Köp"].InnerText);
                    a.Sälj = Convert.ToInt32(node["Sälj"].InnerText);

                    aktielista.Add(a);

                }
            }
            else if (valCap.SelectedValue == "4") //4 = Large Cap
            {
                allaAktier = doc.SelectNodes("/Portfölj/LargeCap/Aktie");

                foreach (XmlNode node in allaAktier)
                {
                    Aktier a = new Aktier();
                    a.Aktietyp = node.Attributes["Aktietyp"].InnerText;
                    a.Aktienamn = node["Aktienamn"].InnerText;
                    a.Köp = Convert.ToInt32(node["Köp"].InnerText);
                    a.Sälj = Convert.ToInt32(node["Sälj"].InnerText);

                    aktielista.Add(a);

                }
            }

            return aktielista;

        }

    }

}