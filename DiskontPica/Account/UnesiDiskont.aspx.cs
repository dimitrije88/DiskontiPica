using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace DiskontPica.Account
{
    public partial class UnesiDiskont : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(TextBox1.Text != "" && TextBox2.Text != "")
            {
                try
                {
                    con.Open();

                    UnosDiskonta(TextBox1.Text, TextBox2.Text);

                    Response.Redirect("~/Account/UnesiDiskont.aspx", false);
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

        protected void UnosDiskonta(string ime, string mesto)
        {
            SqlParameter p1 = new SqlParameter();
            SqlParameter p2 = new SqlParameter();
            p1.Value = ime;
            p2.Value = mesto;
            p1.ParameterName = "ime";
            p2.ParameterName = "mesto";
            string upit = "insert into diskont (ime, mesto) values (@ime,@mesto)";
            SqlCommand cmd = new SqlCommand(upit, con);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.ExecuteNonQuery();
        }
    }
}