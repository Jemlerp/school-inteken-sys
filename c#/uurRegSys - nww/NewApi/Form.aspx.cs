using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewApi.Controllers;

namespace NewApi {
    public partial class WebFormOverzight : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            GridView1.DataSource=IntekenSysController.webGetOverzicht();
            GridView1.DataBind();
        }
    }
}