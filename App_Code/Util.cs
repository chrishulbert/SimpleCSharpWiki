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
/// Summary description for Util
/// </summary>
public class Util
{
	public Util()
	{

	}

  /// <summary>
  /// Get the path: to the right of the ? in the address bar
  /// </summary>
  public static string PathFromUrl {
    get {
      string path = "/";
      string rawUrl = HttpContext.Current.Request.RawUrl;
      if (rawUrl.Contains("?"))
        path = rawUrl.Substring(rawUrl.IndexOf('?') + 1);
      path = HttpContext.Current.Server.UrlDecode(path);
      if (!path.StartsWith("/")) path = "/" + path;
      return path;
    }
  }
}
