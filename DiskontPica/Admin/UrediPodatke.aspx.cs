using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;

namespace DiskontPica.Admin
{
    public partial class UrediPodatke : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            PrikaziDiskonte();
            PrikaziPica();
            PopuniVrste();
        }

        protected void PopuniVrste()
        {
            if (!IsPostBack)
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
                    Label8.Text = "Greska.";
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        protected void PrikaziDiskonte()
        {
            try
            {
                con.Open();
                string upit = "select * from diskont";
                SqlDataAdapter ad = new SqlDataAdapter(upit, con);
                DataTable t = new DataTable();
                ad.Fill(t);
                GridView1.DataSource = t;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Label4.Text = "Greska.";
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
            finally
            {
                con.Close();
            }
        }

        protected void PrikaziPica()
        {
            try
            {
                con.Open();
                string upit = "select * from pice";
                SqlDataAdapter ad = new SqlDataAdapter(upit, con);
                DataTable t = new DataTable();
                ad.Fill(t);
                GridView2.DataSource = t;
                GridView2.DataBind();
            }
            catch (Exception ex)
            {
                Label8.Text = "Greska.";
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
            finally
            {
                con.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(TextBox2.Text != "" && TextBox3.Text != "")
            {
                try
                {
                    con.Open();

                    SqlParameter p1 = new SqlParameter();
                    SqlParameter p2 = new SqlParameter();
                    p1.Value = TextBox2.Text;
                    p2.Value = TextBox3.Text;
                    p1.ParameterName = "ime";
                    p2.ParameterName = "mesto";

                    string upit = "update diskont set ime = @ime, mesto = @mesto where diskontID = " + TextBox1.Text;
                    SqlCommand cmd = new SqlCommand(upit, con);
                    cmd.Parameters.Add(p1);
                    cmd.Parameters.Add(p2);
                    cmd.ExecuteNonQuery();
                    Response.Redirect("~/Admin/UrediPodatke.aspx", false);
                }
                catch (Exception ex)
                {
                    Label4.Text = "Greska";
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                }
                finally
                {
                    con.Close();
                    PrikaziDiskonte();
                }
            }
            else
            {
                Label4.Text = "Popunite polja";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string upit = $"delete from diskont where diskontID = {TextBox1.Text}";
                SqlCommand cmd = new SqlCommand(upit, con);
                cmd.ExecuteNonQuery();
                Response.Redirect("~/Admin/UrediPodatke.aspx", false);
            }
            catch(Exception ex)
            {
                Label4.Text = "Greska";
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
            finally
            {
                con.Close();
                PrikaziDiskonte();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(GridView1.SelectedRow != null)
            {
                TextBox1.Text = GridView1.SelectedRow.Cells[1].Text;
                TextBox2.Text = GridView1.SelectedRow.Cells[2].Text;
                TextBox3.Text = GridView1.SelectedRow.Cells[3].Text;

                TextBox2.ReadOnly = false;
                TextBox3.ReadOnly = false;
            }
            else
            {
                Label4.Text = "Please select row";
            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GridView2.SelectedRow != null)
            {
                TextBox4.Text = GridView2.SelectedRow.Cells[1].Text;
                TextBox5.Text = GridView2.SelectedRow.Cells[2].Text;
                DropDownList1.SelectedItem.Text = GridView2.SelectedRow.Cells[3].Text;

                TextBox5.ReadOnly = false;
                DropDownList1.Enabled = true;
            }
            else
            {
                Label8.Text = "Please select row";
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if(TextBox5.Text != "")
            {
                try
                {
                    con.Open();

                    SqlParameter p1 = new SqlParameter();
                    SqlParameter p2 = new SqlParameter();
                    p1.Value = TextBox5.Text;
                    p2.Value = DropDownList1.SelectedItem.Value;
                    p1.ParameterName = "ime";
                    p2.ParameterName = "imeVrste";

                    string upit = "update pice set ime = @ime, imeVrste = @imeVrste where piceID = " + TextBox4.Text;
                    SqlCommand cmd = new SqlCommand(upit, con);
                    cmd.Parameters.Add(p1);
                    cmd.Parameters.Add(p2);
                    cmd.ExecuteNonQuery();
                    Response.Redirect("~/Admin/UrediPodatke.aspx", false);
                }
                catch (Exception ex)
                {
                    Label8.Text = "Greska";
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                }
                finally
                {
                    con.Close();
                    PrikaziPica();
                }
            }
            else
            {
                Label8.Text = "Popunite polja";
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();

                string upit = $"delete from pice where piceID = {TextBox4.Text}";
                SqlCommand cmd = new SqlCommand(upit, con);
                cmd.ExecuteNonQuery();
                Response.Redirect("~/Admin/UrediPodatke.aspx", false);
            }
            catch (Exception ex)
            {
                Label8.Text = "Greska";
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
            finally
            {
                con.Close();
                PrikaziPica();
            }
        }
    }
}