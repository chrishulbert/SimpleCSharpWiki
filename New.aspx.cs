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

public partial class New : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e) {
    Auth.OnlyAdminAllowed();
  }

  protected void bnSave_Click(object sender, EventArgs e) {
    // Get the slashes correct and trim it
    txtPath.Text = txtPath.Text.Replace('\\', '/').Trim();
    // Ensure they start with a slash
    if (!txtPath.Text.StartsWith("/")) txtPath.Text = "/" + txtPath.Text;

    // Ensure its a unique name
    String path = txtPath.Text;
    string urlpath = Wiki.Page.PathToUrlPath(path);
    int uniqCount=2;
    while (DbServices.PageExistsWithUrlpath(urlpath)) {
      path = txtPath.Text + " " + uniqCount.ToString();
      urlpath = Wiki.Page.PathToUrlPath(path);
      uniqCount++;
    }

    // Save it
    Wiki.Page page = new Wiki.Page();
    page.path = path;
    page.contents = txtRichEditor.Text.Trim();
    page.author = Auth.UserName;
    page.Save();
    Response.Redirect("./?" + page.urlpath);
  }
}
