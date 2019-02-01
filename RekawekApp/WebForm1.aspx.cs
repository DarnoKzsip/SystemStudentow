using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RekawekApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
      
        ControlLayer cal = new ControlLayer();
        List<string> QueryList = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
           // GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
            if (!IsPostBack) { 
                Session["update"] = Server.UrlEncode(System.DateTime.Now.ToString());
        }
            Refresh_page();
            //< HeaderStyle CssClass =”thead - dark” />


        }

        void Page_PreRender(object obj, EventArgs e)
        {
            ViewState["update"] = Session["update"];
        }

        protected void BTN_WczytajStudenta_Click(object sender, EventArgs e)
        {
            try
            {
                QueryList = cal.DisplayData(Convert.ToInt16(TB_Id.Text));
            }
            catch (Exception ae)
            {
                QueryList = null;
                string message = "Wprowadzono nie prawidłowe ID";
                ShowMessage(message);
            }
            if (QueryList != null)
            {
                TB_Imie.Text = QueryList[0];
                TB_Nazwisko.Text = QueryList[1];
                TB_NrAlbumu.Text = QueryList[2];
            }
            else {
                string message = "Wprowadzono nie prawidłowe ID";
                ShowMessage(message);


            }

        }

        protected void BTN_Wstaw_Click(object sender, EventArgs e)
        {
            if (FormValidation() == true) { 

            if (Session["update"].ToString() == ViewState["update"].ToString()) { 
            bool insert = cal.InsertData(TB_Imie.Text, TB_Nazwisko.Text, TB_NrAlbumu.Text);
                if (insert == true) {
                    Session["update"] = Server.UrlEncode(System.DateTime.Now.ToString());
                }
            }
            }
            Refresh_page();
            Clean_Textbox();
        }

        protected void Refresh_page() {

            GridView1.DataSource = cal.DisplayData();
            GridView1.DataBind();
           

        }

        protected void Clean_Textbox() {

            TB_Imie.Text = "";
            TB_Nazwisko.Text = "";
            TB_NrAlbumu.Text = "";
        }

        protected void Btn_usun_Click(object sender, EventArgs e)
        {
            bool delete = cal.DeletData(TB_Id.Text);
            if (delete == true) {
                Refresh_page();
                Clean_Textbox();

            }
            else
            {
                string message = "Nie prawidłowa wartość ID";
                ShowMessage(message);
            }

        }

        protected void Btn_Modyfikuj_Click(object sender, EventArgs e)
        {
            bool update = cal.UpdateData(TB_Id.Text, TB_Imie.Text, TB_Nazwisko.Text, TB_NrAlbumu.Text);
            if (update == true)
            {
                Refresh_page();
                Clean_Textbox();

            }
            else
            {
                string message = "Nie prawidłowa wartość ID";
                ShowMessage(message);
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            if (Session["update"].ToString() == ViewState["update"].ToString())
            {
                bool insert = cal.InsertData(TB_Imie.Text, TB_Nazwisko.Text, TB_NrAlbumu.Text);

                if (insert == true)
                {
                    Session["update"] = Server.UrlEncode(System.DateTime.Now.ToString());
                }
                else {
                    string message = "Nie prawidłowa wartość ID";
                    ShowMessage(message);
                }
            }
            Refresh_page();
            Clean_Textbox();

        }

        protected bool FormValidation() {

            List<string> errorList = new List<string>();

            if (!Regex.IsMatch(TB_Id.Text, @"^[0-9]+$"))
            {
                errorList.Add("Id");
            }

            if (!Regex.IsMatch(TB_NrAlbumu.Text, @"^[0-9]+$"))
            {
                errorList.Add("Numer albumu");
            }

            if (!Regex.IsMatch(TB_Imie.Text, @"^[a-zA-Z]+$")) {

                errorList.Add("Imię");

            }

            if (!Regex.IsMatch(TB_Nazwisko.Text, @"^[a-zA-Z]+$"))
            {

                errorList.Add("Nazwisko");

            }

            if (errorList == null || errorList.Count() == 0)
            {

                return true;
            }

            else {
                string pola  = String.Join(", ", errorList);
                string message = "Pola nmie wypełnione prawidłowo to: " + pola;
                ShowMessage(message);
                return false;
            }

           // return false;

        }

        protected void ShowMessage(string message) {

            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + message + "');", true);

        }
    }
}