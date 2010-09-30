using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e) {
    Wiki.Page page = DbServices.FindPageByUrlpath(Util.PathFromUrl);
    if (page != null) {
      litHeader.Text = NiceName(page.path);
      litContents.Text = page.contents;
      hlEdit.NavigateUrl = "edit.aspx?" + page.urlpath;
    }
    else {
      litHeader.Text = "Page not found";
      litContents.Text = "Page not found";
      hlEdit.Visible = false;
    }
  }

  string NiceName(string path) {
    if (path == "/") return "Home page";
    if (!path.Contains("/")) return path;
    return 
      "<small>" +
      path.Substring(0,path.LastIndexOf('/')+1) +
      "</small>" +
      path.Substring(path.LastIndexOf('/') + 1);
  }
}
