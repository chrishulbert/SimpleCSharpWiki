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
/// Summary description for DbServices
/// </summary>
public class DbServices
{
  public static Wiki.Page FindPageByUrlpath(string urlpath) {
    using (SqlConnection conn = Db.OpenConnection()) {
      string sql = "select * from pages where urlpath = @urlpath";
      using (SqlCommand cmd = new SqlCommand(sql, conn)) {
        cmd.Parameters.AddWithValue("@urlpath", urlpath);
        using (SqlDataReader rdr = cmd.ExecuteReader()) {
          if (rdr.Read()) {
            return Wiki.Page.FromDataReader(rdr);
          }
        }
      }
    }
    return null;
  }

  public static Wiki.Page DeletePageByUrlpath(string urlpath) {
    using (SqlConnection conn = Db.OpenConnection()) {
      string sql = "delete from pages where urlpath = @urlpath";
      using (SqlCommand cmd = new SqlCommand(sql, conn)) {
        cmd.Parameters.AddWithValue("@urlpath", urlpath);
        cmd.ExecuteNonQuery();
      }
    }
    return null;
  }

  public static bool PageExistsWithUrlpath(string urlpath) {
    using (SqlConnection conn = Db.OpenConnection()) {
      string sql = "select count(*) from pages where urlpath = @urlpath";
      using (SqlCommand cmd = new SqlCommand(sql, conn)) {
        cmd.Parameters.AddWithValue("@urlpath", urlpath);
        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
      }
    }
  }
}
