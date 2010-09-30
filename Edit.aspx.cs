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

public partial class Edit : System.Web.UI.Page
{
  string urlpath = "/";

  protected void Page_Load(object sender, EventArgs e) {
    Auth.OnlyAdminAllowed();

    urlpath = Util.PathFromUrl;

    if (!IsPostBack) {
      Wiki.Page page = DbServices.FindPageByUrlpath(urlpath);
      litHeader.Text = page.path;
      txtPath.Text = page.path;
      txtRichEditor.Text = page.contents;
      hlCancel.NavigateUrl = "./?" + urlpath;

      // If it's the home page, don't allow them to change the path or remove it
      if (urlpath == "/") {
        txtPath.Enabled = false;
        bnDelete.Enabled = false;
      }
    }
  }

  Wiki.Page Save() {
    // Get the slashes correct and trim it
    txtPath.Text = txtPath.Text.Replace('\\', '/').Trim();
    // Ensure they start with a slash
    if (!txtPath.Text.StartsWith("/")) txtPath.Text = "/" + txtPath.Text;

    // Ensure its a unique name
    String path = txtPath.Text;
    string newurlpath = Wiki.Page.PathToUrlPath(path);
    // Are they renaming it? If so, check for dupes
    if (urlpath.ToLower() != newurlpath.ToLower()) {
      int uniqCount = 2;
      while (DbServices.PageExistsWithUrlpath(newurlpath)) {
        path = txtPath.Text + " " + uniqCount.ToString();
        newurlpath = Wiki.Page.PathToUrlPath(path);
        uniqCount++;
      }
    }

    Wiki.Page page = DbServices.FindPageByUrlpath(urlpath);
    page.path = path;
    page.contents = txtRichEditor.Text.Trim();
    page.author = Auth.UserName;
    page.Save();

    return page;
  }

  protected void bnSave_Click(object sender, EventArgs e) {
    Wiki.Page page = Save();
    Response.Redirect("./edit.aspx?" + page.urlpath);
  }

  protected void bnSaveClose_Click(object sender, EventArgs e) {
    Wiki.Page page = Save();
    Response.Redirect("./?" + page.urlpath);
  }

  protected void bnDelete_Click(object sender, EventArgs e) {
    string confirm = "Really delete!";
    if (bnDelete.Text == confirm) {
      DbServices.DeletePageByUrlpath(urlpath);
      Response.Redirect("./");
    }
    bnDelete.Text = confirm;
  }

}
