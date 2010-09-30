<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" Runat="Server">
 
 <div class="header">
   <h1><asp:Literal ID="litHeader" runat="server"></asp:Literal></h1>
 </div>
 
 <div class="contents">
   <asp:HyperLink ID="hlEdit" runat="server" CssClass='edit'>edit</asp:HyperLink>
   <asp:Literal ID="litContents" runat="server"></asp:Literal>
 </div>

</asp:Content>

