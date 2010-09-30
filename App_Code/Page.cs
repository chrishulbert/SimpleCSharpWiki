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

namespace Wiki
{
  public class Page
  {
    /// <summary>
    /// Creates a new page, reading its values from the data reader row
    /// </summary>
    /// <returns></returns>
    public static Page FromDataReader(SqlDataReader rdr) {
      Page page = new Page();
      page.id = Convert.ToInt32(rdr["id"]);
      page.contents = Convert.ToString(rdr["contents"]);
      page.author = Convert.ToString(rdr["author"]);
      page.path = Convert.ToString(rdr["path"]);
      page.urlpath = Convert.ToString(rdr["urlpath"]);
      return page;
    }

    public int id = -1;
    public string contents, author, path, urlpath;

    public Page() {
    }

    public bool Exists() {
      return Db.Exists("pages", id);
    }

    public static string PathToUrlPath(string inputPath) {
      return inputPath.ToLower().Replace(' ', '-');
    }

    public void BeforeSave() {
      // Create the url path
      urlpath = PathToUrlPath(path);
    }

    public void Save() {
      BeforeSave();

      using (SqlConnection conn = Db.OpenConnection()) {

        string sql = Exists() ? @"
        update pages
        set
         contents = @contents,
         author = @author,
         path = @path,
         urlpath = @urlpath
        where id=@id
        " : @"
        insert into pages
         ( contents, author, path, urlpath)
        values
         (@contents,@author,@path,@urlpath)
        ";
        using (SqlCommand cmd = new SqlCommand(sql, conn)) {
          cmd.Parameters.AddWithValue("@contents", contents);
          cmd.Parameters.AddWithValue("@author", author);
          cmd.Parameters.AddWithValue("@path", path);
          cmd.Parameters.AddWithValue("@urlpath", urlpath);
          cmd.Parameters.AddWithValue("@id", id);
          cmd.ExecuteNonQuery();
        }
      }
    }
  }
}