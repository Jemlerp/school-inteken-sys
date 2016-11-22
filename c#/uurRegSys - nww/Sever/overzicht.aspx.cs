using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using funcZ;
using Sever.Models;
using System.Data;


namespace Sever {
    public partial class overzicht : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            try {
                funcZ.dataTableHelpFunc nyaaaaaaaa = new dataTableHelpFunc();
                GridView1.DataSource=nyaaaaaaaa.listToDataTableForDisplay(nyaaaaaaaa.loadEnfoFromApiSub(functions.overzigt()));
            } catch(Exception ex) {
                DataTable table = new DataTable();
                table.Columns.Add("error");
                DataRow row = table.NewRow();
                DataRow nyaaaaaan = table.NewRow();
                row[0]="^klopt^";
                nyaaaaaan[0]=ex.Message;
                table.Rows.Add(row);
                table.Rows.Add(nyaaaaaan);
                GridView1.DataSource=table;
            }
            GridView1.DataBind();
        }
    }
}