<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="New.aspx.cs" Inherits="New" ValidateRequest="false"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" Runat="Server">

<div class="header">
  <h1>New Page</h1>
</div>
 
<div class="contents">

<p>Path and Title: (eg /MyApp/User Groups; must be unique)<br />
  <asp:TextBox ID="txtPath" runat="server" Columns="100"></asp:TextBox>
</p>

<asp:TextBox ID="txtRichEditor" runat="server" TextMode="MultiLine" CssClass="ckeditor"></asp:TextBox>

<script type="text/javascript">
  CKEDITOR.replace( 'ckeditor' );
</script>

<p class="buttons">
  <asp:Button ID="bnSave" runat="server" Text="Save" OnClick="bnSave_Click" />
  <a href="./">Cancel</a>
</p>

</div>

</asp:Content>

