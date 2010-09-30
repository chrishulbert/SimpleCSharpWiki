using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Helper database functions
/// </summary>
public class Db
{
  /// <summary>
  /// Use this eg:
  /// using (SqlConnection c = Db.OpenConnection()) {...}
  /// </summary>
  public static SqlConnection OpenConnection() {
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["Wiki"].ConnectionString);
    c.Open();
    return c;
  }

  /// <summary>
  /// Does a record from the given table exist with the given id?
  /// </summary>
  public static bool Exists(string table, int id) {
    using (SqlConnection conn = Db.OpenConnection()) {
      string sql = string.Format("select count(*) from {0} where id={1}", table, id);
      return Convert.ToInt32(new SqlCommand(sql, conn).ExecuteScalar()) > 0;
    }
  }
}
