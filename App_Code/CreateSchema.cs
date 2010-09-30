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
/// This class updates the database to have the necessary tables etc
/// </summary>
public class CreateSchema
{
  const string sql = @"
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'pages') BEGIN
   
  CREATE TABLE [dbo].[pages](
    [id] [int] IDENTITY(1,1) NOT NULL,
    [contents] [text]  NULL,
    [author] [varchar](250)  NULL,
    [path] [varchar](250)  NULL,
    CONSTRAINT [pk_pages] PRIMARY KEY CLUSTERED ([id] ASC)
  );

  insert into pages(contents,author,path)
  values ('Wiki home page','wiki','/');

end

if not exists (select * from INFORMATION_SCHEMA.columns where table_name = 'pages' and column_name = 'urlpath') begin
  ALTER TABLE pages ADD urlpath varchar(250) NULL;
end

";

  public static void Go() {
    using (SqlConnection conn = Db.OpenConnection())
      new SqlCommand(sql, conn).ExecuteNonQuery();
  }
}
