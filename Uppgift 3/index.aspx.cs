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
            //XmlSwitchCase();

            //aktieDiv.InnerHtml

            string sökväg = Server.MapPath("aktier.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(sökväg);

            txtXml.Text = doc.OuterXml;
        }

        protected void btnFiltrera_Click(object sender, EventArgs e)
        {
            //LäggTillAllaAktier(XmlTillLista());


        }


        public void XmlSwitchCase()
        {
            string aktier = "";
            string sökväg = Server.MapPath("aktier.xml");

            XmlTextReader xreader = new XmlTextReader(sökväg);

            while (xreader.Read())
            {
                switch (xreader.Name)
                {
                    case "Aktienamn":
                        aktier += xreader.ReadString() + " ";
                        break;
                }
                switch (xreader.Name)
                {
                    case "Aktietyp":
                        aktier += xreader.ReadString() + " ";
                        break;
                }
                switch (xreader.Name)
                {
                    case "Köp":
                        aktier += xreader.ReadString() + " ";
                        break;
                }
                switch (xreader.Name)
                {
                    case "Sälj":
                        aktier += xreader.ReadString() + " ";
                        break;
                }


            }

            aktieDiv.InnerHtml = aktier;
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
            string nodSökväg;
            
            XmlDocument doc = new XmlDocument();
            doc.Load(sökväg);
            XmlNodeList allaAktier = null;

            XmlNode root = doc.DocumentElement;



            if (valCap.SelectedValue == "1") //Visa alla
            {

                allaAktier = doc.SelectNodes("/Portfölj/LargeCap/Aktie");

                foreach (XmlNode node in allaAktier)
                {

                    //aktieDiv.InnerText = "Node: " + node.Name;
                    Aktier a = new Aktier();
                    a.Aktietyp = node.Attributes["Aktietyp"].InnerText;
                    a.Aktienamn = node["Aktienamn"].InnerText;
                    a.Köp = Convert.ToInt32(node["Köp"].InnerText);
                    a.Sälj = Convert.ToInt32(node["Sälj"].InnerText);

                    aktielista.Add(a);

                }

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