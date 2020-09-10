<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Datingapp.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server"  >
  <div ><table>
      <tr>
          <td >
              <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>     
          </td>
          <td>
              <asp:TextBox ID="TextBox1" TextMode="SingleLine" runat="server"></asp:TextBox>
          </td>
      </tr>
      <tr>
          <td >
              <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>     
          </td>
          <td>
              <asp:TextBox ID="TextBox2" TextMode="Password" runat="server"></asp:TextBox>
          </td>
      </tr>

  </table>
    <asp:Button ID="Button1" runat="server" Text="Log in"  /></div>
</asp:Content>
