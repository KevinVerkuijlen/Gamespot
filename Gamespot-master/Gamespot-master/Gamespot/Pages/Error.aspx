<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/GameSpot_Master.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Gamespot.Pages.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td><h1>Error:</h1></td>
        </tr>
        <tr>
            <td>
                <p><asp:Label ID="ErrorMessage_Label" runat="server" Width="1000px"></asp:Label></p>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td><h3>Error details:</h3></td>
        </tr>
        <tr>
            <td>
                <p><asp:Label ID="Detail_Label" runat="server"></asp:Label></p>
            </td>
        </tr>
        <tr>
            <td><h3>Error source:</h3></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Source_Label" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td><h3>Full Error details:</h3></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="FullErrorDetails_Label" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
