<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/GameSpot_Master.Master" AutoEventWireup="true" CodeBehind="NewsPostes.aspx.cs" Inherits="Gamespot.NewsPostes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .auto-style1 {
            width: 1648px;
            height: 705px;
            margin-right: 0px;
        }
        .auto-style4 {
            height: 123px;
        }
        .auto-style23 {
            width: 20px;
            height: 35px;
        }
        .auto-style25 {
            height: 37px;
        }
        .auto-style31 {
        }
        .auto-style35 {
            height: 35px;
            width: 186px;
        }
        .auto-style40 {
            height: 37px;
            width: 20px;
        }
        .auto-style46 {
            height: 35px;
            width: 5px;
        }
        .auto-style51 {
            width: 186px;
        }
        .auto-style52 {
            width: 5px;
        }
        .auto-style54 {
            height: 35px;
            width: 191px;
        }
        .auto-style55 {
            height: 123px;
            width: 191px;
        }
        .auto-style56 {
            width: 191px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style35">&nbsp;</td>
                <td class="auto-style46">&nbsp;</td>
                <td class="auto-style54">&nbsp;</td>
                <td class="auto-style23" colspan="4">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style35">&nbsp;</td>
                <td class="auto-style46">&nbsp;</td>
                <td class="auto-style54">&nbsp;</td>
                <td class="auto-style23" colspan="4">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4"><h1>News information</h1>
                </td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style55"><h1>Publisher information</h1>
                </td>
                <td class="auto-style4" colspan="2">&nbsp;</td>
                <td class="auto-style4" colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style51">
                    <p><asp:Label ID="NewsTitel_Label" runat="server" Text="News Titel:"></asp:Label></p>
                    <p><asp:Label ID="InputTitel_Label" runat="server"></asp:Label></p>
                </td>
                <td class="auto-style52">&nbsp;</td>
                <td class="auto-style56"><p>name</p></td>
                <td class="auto-style40" colspan="4">
                    <p><asp:Label ID="InputName_Label" runat="server"></asp:Label></p>
                </td>
            </tr>
            <tr>
                <td class="auto-style51">
                   <p> <asp:Label ID="Game_Label" runat="server" Text="Game:"></asp:Label></p>
                   <p> <asp:Label ID="InputGame_Label" runat="server"></asp:Label></p>
                </td>
                <td class="auto-style52">&nbsp;</td>
                <td class="auto-style56"><p>upload date</p></td>
                <td class="auto-style40" colspan="4">
                    <p><asp:Label ID="InputDate_Label" runat="server"></asp:Label></p>
                </td>
            </tr>
            <tr>
                <td class="auto-style51">
                    <asp:TextBox ID="Content_TextBox" runat="server" Height="142px" TextMode="MultiLine" Width="486px"></asp:TextBox>
                </td>
                <td class="auto-style52">&nbsp;</td>
                <td class="auto-style56">
                    <asp:Button ID="Follow_Button" runat="server" Text="Follow" OnClick="Follow_Button_Click" />
                </td>
                <td class="auto-style25" colspan="2">
                    &nbsp;</td>
                <td class="auto-style25" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style51">
                    <p><asp:Label ID="Rating_Label" runat="server" Text="Rating:"></asp:Label></p>
                    <p><asp:Label ID="InputRating_Label" runat="server"></asp:Label></p>
                </td>
                <td class="auto-style52">&nbsp;</td>
                <td class="auto-style56">&nbsp;</td>
                <td class="auto-style40" colspan="4">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style51">&nbsp;</td>
                <td class="auto-style52">&nbsp;</td>
                <td class="auto-style56">&nbsp;</td>
                <td class="auto-style40" colspan="4">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style51"><h1>Latest news&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </h1>
                </td>
                <td class="auto-style52">&nbsp;</td>
                <td class="auto-style56"><h1>My news</h1>
                    </td>
                <td class="auto-style25" colspan="2">
                    <asp:Button ID="Create_Button" runat="server" Text="Create new news" OnClick="Create_Button_Click" />
                </td>
                <td class="auto-style25" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style51" rowspan="2">
                    <br />
                    <br />
                    <asp:ListBox ID="AllNews_ListBox" runat="server" Height="442px" Width="494px" AutoPostBack="True" OnSelectedIndexChanged="AllNews_ListBox_SelectedIndexChanged"></asp:ListBox>
                </td>
                <td class="auto-style52" rowspan="2">&nbsp;</td>
                <td class="auto-style56">
                    &nbsp;</td>
                <td class="auto-style25" colspan="2">
                    <asp:Button ID="Remove_Button" runat="server" Text="Remove my news" OnClick="Remove_Button_Click" />
                </td>
                <td class="auto-style25" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style31" colspan="2">
                    <asp:ListBox ID="MyNews_ListBox" runat="server" Height="396px" Width="550px" AutoPostBack="True" OnSelectedIndexChanged="MyNews_ListBox_SelectedIndexChanged"></asp:ListBox>
                </td>
                <td class="auto-style31" colspan="2">
                    &nbsp;</td>
                <td class="auto-style31">
                    &nbsp;</td>
            </tr>
        </table>
</asp:Content>
