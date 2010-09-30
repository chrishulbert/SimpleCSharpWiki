using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for Auth
/// </summary>
public class Auth
{
  /// <summary>
  /// return the logged on user eg jimsmith1
  /// </summary>
  public static string UserName {
    get {
      string fullname = HttpContext.Current.Request.ServerVariables["AUTH_USER"]; // eg 'MYDOMAIN\jimjones1'
      return fullname.Substring(fullname.IndexOf('\\') + 1); // remove the MYDOMAIN\, just leave the jimjones1
    }
  }

  /// <summary>
  /// Redirect tot the Denied.aspx if this isn't an admin user
  /// </summary>
  public static void OnlyAdminAllowed() {
    string AdminGroup = ConfigurationManager.AppSettings["AdminGroup"];
    if (!HttpContext.Current.User.IsInRole(AdminGroup)) {
      HttpContext.Current.Response.Redirect("denied.aspx");
    }
  }
}
