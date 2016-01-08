<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/GameSpot_Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Gamespot.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .auto-style1 {
            width: 89%;
            margin-right: auto;
            margin-left: auto;
        }
        .auto-style2 {
        }
        .auto-style4 {
        }
        .auto-style8 {
        }
        .auto-style10 {
        }
        .auto-style11 {
        }
        .auto-style12 {
        }
        .auto-style14 {
        }
        .auto-style15 {
            width: 640px;
        }
        .auto-style16 {
        }
        .auto-style18 {
        }
        .auto-style19 {
            width: 525px;
        }
        .auto-style20 {
        }
        .auto-style21 {
            width: 359px;
        }
        .auto-style22 {
            width: 174px;
        }
        .auto-style23 {
            width: 142px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style21">&nbsp;</td>
                <td class="auto-style14">&nbsp;</td>
                <td class="auto-style15" colspan="2">&nbsp;</td>
                <td class="auto-style20">&nbsp;</td>
                <td class="auto-style19">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style21">&nbsp;</td>
                <td class="auto-style14">&nbsp;</td>
                <td class="auto-style15" colspan="2">&nbsp;</td>
                <td class="auto-style20">&nbsp;</td>
                <td class="auto-style19">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style12" colspan="4"><h1>Post information</h1></td>
                <td class="auto-style8" colspan="2"><h1>Publisher information</h1></td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="4">
                    <asp:Label ID="PostTitel_Label" runat="server" Text="Post Titel:"></asp:Label>
                    <asp:Label ID="InputTitel_Label" runat="server"></asp:Label>
                </td>
                <td class="auto-style20"><p>name</p></td>
                <td class="auto-style19">
                    <asp:Label ID="InputName_Label" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="4">
                    <p><asp:Label ID="Game_Label" runat="server" Text="Game:"></asp:Label></p>
                    <p><asp:Label ID="InputGame_Label" runat="server"></asp:Label></p>
                </td>
                <td class="auto-style20"><p>upload date</p></td>
                <td class="auto-style19">
                    <p><asp:Label ID="InputDate_Label" runat="server"></asp:Label></p>
                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="4">
                    <asp:TextBox ID="Content_TextBox" runat="server" Height="142px" TextMode="MultiLine" Width="486px"></asp:TextBox>
                </td>
                <td class="auto-style18" colspan="2">
                    <asp:Button ID="Follow_Button" runat="server" Text="Follow" OnClick="Follow_Button_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="4">
                    <p><asp:Label ID="NewsRating_Label" runat="server" Text="Rating:"></asp:Label></p>
                    <p><asp:Label ID="NewsInputRating_Label" runat="server"></asp:Label></p>
                    <asp:TextBox ID="GoodPoints_TextBox" runat="server" Height="142px" TextMode="MultiLine" Width="486px"></asp:TextBox>
                </td>
                <td class="auto-style20" colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style11" colspan="4">
                    <asp:TextBox ID="BadPoints_TextBox" runat="server" Height="142px" TextMode="MultiLine" Width="486px"></asp:TextBox>
                </td>
                <td class="auto-style11" colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style11" colspan="4">
                    <p><asp:Label ID="ReviewRating_Label" runat="server" Text="Rating:"></asp:Label></p>
                    <p><asp:Label ID="ReviewInputRating_Label" runat="server"></asp:Label></p>
                </td>
                <td class="auto-style11" colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style11" colspan="4">&nbsp;</td>
                <td class="auto-style11" colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style21"><h1>Recent postes</h1></td>
                <td class="auto-style10" colspan="3"><h1>Top games</h1></td>
                <td class="auto-style16" colspan="2"><h1>Selected Game info</h1></td>
            </tr>
            <tr>
                <td class="auto-style21" rowspan="9">
                    <asp:ListBox ID="Postes_ListBox" runat="server" Height="520px" Width="360px" AutoPostBack="True" OnSelectedIndexChanged="Postes_ListBox_SelectedIndexChanged"></asp:ListBox>
                </td>
                <td class="auto-style4" colspan="3" rowspan="9">
                    <asp:ListBox ID="Games_ListBox" runat="server" Height="520px" Width="360px" AutoPostBack="True" OnSelectedIndexChanged="Games_ListBox_SelectedIndexChanged"></asp:ListBox>
                </td>
                <td class="auto-style20"><p>Game name:</p></td>
                <td class="auto-style19">
                <p><asp:Label ID="Game_Name_Label" runat="server"></asp:Label></p>
                </td>
            </tr>
            <tr>
                <td class="auto-style20"><p>Game platform:</p></td>
                <td class="auto-style19">
                <p><asp:Label ID="Platform_Label" runat="server"></asp:Label></p>
                </td>
            </tr>
            <tr>
                <td class="auto-style20"><p>Game genre:</p></td>
                <td class="auto-style19">
                <p><asp:Label ID="Genre_Label" runat="server"></asp:Label></p>
                </td>
            </tr>
            <tr>
                <td class="auto-style20"><p>Game theme:</p></td>
                <td class="auto-style19">
                <p><asp:Label ID="Thema_Label" runat="server"></asp:Label></p>
                </td>
            </tr>
            <tr>
                <td class="auto-style20"><p>First release:</p></td>
                <td class="auto-style19">
                <p><asp:Label ID="FirstRelease_Label" runat="server"></asp:Label></p>
                </td>
            </tr>
            <tr>
                <td class="auto-style20"><p>Game rating:</p></td>
                <td class="auto-style19">
                <p><asp:Label ID="Rating_Label" runat="server"></asp:Label></p>
                </td>
            </tr>
            <tr>
                <td class="auto-style20"><p>Game description:</p></td>
                <td class="auto-style19">
                <asp:TextBox ID="Description_TextBox" runat="server" Enabled="False" Height="138px" TextMode="MultiLine" Width="154px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style20"><p>Game publisher:</p></td>
                <td class="auto-style19">
                <p><asp:Label ID="Publisher_Label" runat="server"></asp:Label></p>
                </td>
            </tr>
            <tr>
                <td class="auto-style20"><p>Game designer:</p></td>
                <td class="auto-style19">
                <p><asp:Label ID="Designer_Label" runat="server"></asp:Label></p>
                </td>
            </tr>
            <tr>
                <td class="auto-style21">&nbsp;</td>
                <td class="auto-style14">&nbsp;</td>
                <td class="auto-style23">
                    <asp:Button ID="Want_Button" runat="server" Text="Add to want list" OnClick="Want_Button_Click" />
                </td>
                <td class="auto-style22">
                    <asp:Button ID="Have_Button" runat="server" Text="Add to have list" OnClick="Have_Button_Click" />
                </td>
                <td class="auto-style20">&nbsp;</td>
                <td class="auto-style19">&nbsp;</td>
            </tr>
        </table>

</asp:Content>
