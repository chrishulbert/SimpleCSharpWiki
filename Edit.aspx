<%@ Page ValidateRequest="false" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" Runat="Server">

<div class="header">
  <h1>Edit - <asp:Literal ID="litHeader" runat="server"></asp:Literal></h1>
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
  <asp:Button ID="bnSaveClose" runat="server" Text="Save & Close" OnClick="bnSaveClose_Click"  />
  <asp:Button ID="bnDelete" runat="server" Text="Delete" OnClick="bnDelete_Click" />
  <asp:HyperLink ID="hlCancel" runat="server">Cancel</asp:HyperLink>
</p>

</div>
 
</asp:Content>

