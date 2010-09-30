using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
  protected void Page_Load(object sender, EventArgs e) {
    StringBuilder sb = new StringBuilder();

    using (SqlConnection conn = Db.OpenConnection()) {
      string sql = "select path,urlpath from pages order by path";
      using (SqlCommand comm = new SqlCommand(sql, conn)) {
        using (SqlDataReader rdr = comm.ExecuteReader()) {
          string last = "";
          while (rdr.Read()) {
            string path = rdr.GetString(0);
            string text = SpanSameStart(last, path).Replace(" ", "&nbsp;");
            string url = rdr.GetString(1);
            last = path;
            sb.AppendFormat("<a href='./?{0}'>{1}</a>", url, text);
          }
        }
      }
    }
    litTree.Text = sb.ToString();
  }

  /// <summary>
  /// Figure out which parts of the path are the same, so we can shade out (with a span) the common parts
  /// of the tree view
  /// </summary>
  string SpanSameStart(string last, string path) {
    if (path == "/") return "Home page";

    // Split the paths into each subfolder
    string[] pathLast = last.Split('/');
    string[] pathThis = path.Split('/');
    string span = "", rest = "";
    // Figure out which bits of the path are the same
    for (int i = 0; i < Math.Min(pathLast.Length, pathThis.Length); i++) {
      if (pathLast[i].ToLower() == pathThis[i].ToLower())
        span += pathThis[i] + "/";
      else
        break;
    }
    // Grab the rest of the path that is different - this is the more visible bit
    if (span.Length >= path.Length) return path; // Just so it doesn't crash in the event we have 2 of the same name
    rest = path.Substring(span.Length);
    // HTML-ise it
    return "<span>" + span + "</span>" + rest;
  }
}
