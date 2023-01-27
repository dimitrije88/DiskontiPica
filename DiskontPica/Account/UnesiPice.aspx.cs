using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DiskontPica.Account
{
    public partial class UnesiPice : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            PopuniVrste();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(TextBox1.Text != "")
            {
                try
                {
                    con.Open();

                    UnosPica(TextBox1.Text, DropDownList1.SelectedItem.Value);

                    Response.Redirect("~/Account/UnesiPice.aspx", false);
                }
                catch (Exception ex)
                {
                    Label3.Text = "Greska.";
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                Label3.Text = "Popunite polja";
            }
        }

        protected void UnosPica(string ime, string imeVrste)
        {
            SqlParameter p1 = new SqlParameter();
            SqlParameter p2 = new SqlParameter();
            p1.Value = ime;
            p2.Value = imeVrste;
            p1.ParameterName = "ime";
            p2.ParameterName = "imeVrste";
            string upit = "insert into pice (ime, imeVrste) values (@ime,@imeVrste)";
            SqlCommand cmd = new SqlCommand(upit, con);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.ExecuteNonQuery();
        }

        protected void PopuniVrste()
        {
            if(!IsPostBack)
            {
                try
                {
                    con.Open();
                    string upit = "select ime from vrstaPica";
                    SqlCommand cmd = new SqlCommand(upit, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DropDownList1.Items.Add(reader[0].ToString());
                    }
                }
                catch (Exception ex)
                {
                    Label3.Text = "Greska.";
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}