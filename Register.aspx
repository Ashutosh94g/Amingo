<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Datingapp.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table>
         <tr>
          <td >
              <asp:Label ID="Label6" runat="server" Text=" Enter Full Name"></asp:Label>     
          </td>
          <td>
              <asp:TextBox ID="TextBox5" TextMode="SingleLine" runat="server"></asp:TextBox>
          </td>
      </tr>
      <tr>
          <td >
              <asp:Label ID="Label1" runat="server" Text=" Enter Username"></asp:Label>     
          </td>
          <td>
              <asp:TextBox ID="TextBox1" TextMode="SingleLine" runat="server"></asp:TextBox>
          </td>
      </tr>
      <tr>
          <td >
              <asp:Label ID="Label2" runat="server" Text="Enter Password"></asp:Label>     
          </td>
          <td>
              <asp:TextBox ID="TextBox2" TextMode="Password" runat="server"></asp:TextBox>
          </td>
      </tr>
        <tr>
          <td >
              <asp:Label ID="Label3" runat="server" Text="Confirm Password"></asp:Label>     
          </td>
          <td>
              <asp:TextBox ID="TextBox3" TextMode="Password" runat="server"></asp:TextBox>
          </td>
      </tr>
        <tr>
          <td >
              <asp:Label ID="Label4" runat="server" Text="Select Date of birth"></asp:Label>     
          </td>
          <td>
              <asp:TextBox ID="TextBox4" TextMode="Date" runat="server"></asp:TextBox>
          </td>
      </tr>
          <tr>
          <td >
              <asp:Label ID="Label5" runat="server" Text="Select Gender"></asp:Label>     
          </td>
          <td>
              
              <asp:RadioButton ID="RadioButton1" runat="server" Text="Male" GroupName="g1" />
              <asp:RadioButton ID="RadioButton2" runat="server" Text="Female" GroupName="g1"/>
              
          </td>
      </tr>
       

  </table>
    <asp:Button ID="Button1" runat="server" Text="Submit" />
</asp:Content>
