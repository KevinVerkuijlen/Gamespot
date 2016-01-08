<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/GameSpot_Master.Master" AutoEventWireup="true" CodeBehind="VideosPostes.aspx.cs" Inherits="Gamespot.VideosPostes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .auto-style1 {
            width: 35px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style35">&nbsp;</td>
                <td class="auto-style46">&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style23" colspan="4">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style35">&nbsp;</td>
                <td class="auto-style46">&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style23" colspan="4">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <h1>Video&nbsp; information</h1>
                </td>
                <td class="auto-style4">&nbsp;</td>
                <td>
                    <h1>Publisher information</h1>
                </td>
                <td class="auto-style4" colspan="2">&nbsp;</td>
                <td class="auto-style4" colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style51">
                    <p><asp:Label ID="VideoTitel_Label" runat="server" Text="Video Titel:"></asp:Label></p>
                    <p><asp:Label ID="InputTitel_Label" runat="server"></asp:Label></p>
                </td>
                <td class="auto-style52">&nbsp;</td>
                <td>
                    <p>
                        name</p>
                </td>
                <td class="auto-style40" colspan="4">
                    <p><asp:Label ID="InputName_Label" runat="server"></asp:Label></p>
                </td>
            </tr>
            <tr>
                <td class="auto-style51">
                    <p><asp:Label ID="Game_Label" runat="server" Text="Game:"></asp:Label></p>
                    <p><asp:Label ID="InputGame_Label" runat="server"></asp:Label></p>
                </td>
                <td class="auto-style52">&nbsp;</td>
                <td>
                    <p>
                        upload date</p>
                </td>
                <td class="auto-style40" colspan="4">
                    <p><asp:Label ID="InputDate_Label" runat="server"></asp:Label></p>
                </td>
            </tr>
            <tr>
                <td class="auto-style51">&nbsp;</td>
                <td class="auto-style52">&nbsp;</td>
                <td>
                    <asp:Button ID="Follow_Button" runat="server" Text="Follow" OnClick="Follow_Button_Click" />
                </td>
                <td class="auto-style25" colspan="2">&nbsp;</td>
                <td class="auto-style25" colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style51">&nbsp;</td>
                <td class="auto-style52">&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style40" colspan="4">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style51">
                    <h1>Latest videos&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </h1>
                </td>
                <td class="auto-style52">&nbsp;</td>
                <td>
                    <h1>My news</h1>
                </td>
                <td class="auto-style25" colspan="2">
                    <asp:Button ID="Create_Button" runat="server" Text="Create new video" OnClick="Create_Button_Click" />
                </td>
                <td class="auto-style25" colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style51" rowspan="2">
                    <br />
                    <br />
                    <asp:ListBox ID="AllVideos_ListBox" runat="server" Height="442px" Width="494px" AutoPostBack="True" OnSelectedIndexChanged="AllVideos_ListBox_SelectedIndexChanged"></asp:ListBox>
                </td>
                <td class="auto-style52" rowspan="2">&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td class="auto-style25" colspan="2">
                    <asp:Button ID="Remove_Button" runat="server" Text="Remove my video" OnClick="Remove_Button_Click" />
                </td>
                <td class="auto-style25" colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style31" colspan="2">
                    <asp:ListBox ID="MyVideos_ListBox" runat="server" Height="396px" Width="404px" AutoPostBack="True" OnSelectedIndexChanged="MyVideos_ListBox_SelectedIndexChanged"></asp:ListBox>
                </td>
                <td class="auto-style31" colspan="2">&nbsp;</td>
                <td class="auto-style31">&nbsp;</td>
            </tr>
        </table>
</asp:Content>
