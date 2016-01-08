<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/GameSpot_Master.Master" AutoEventWireup="true" CodeBehind="ReviewsPostes.aspx.cs" Inherits="Gamespot.ReviewsPostes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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
                <td class="auto-style4">
                    <h1>Reviews information</h1>
                </td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style55">
                    <h1>Publisher information</h1>
                </td>
                <td class="auto-style4" colspan="2">&nbsp;</td>
                <td class="auto-style4" colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style51">
                    <p><asp:Label ID="ReviewTitel_Label" runat="server" Text="Review Titel:"></asp:Label></p>
                    <p><asp:Label ID="InputTitel_Label" runat="server"></asp:Label></p>
                </td>
                <td class="auto-style52">&nbsp;</td>
                <td class="auto-style56">
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
                <td class="auto-style56">
                    <p>
                        upload date</p>
                </td>
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
                <td class="auto-style25" colspan="2">&nbsp;</td>
                <td class="auto-style25" colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style51">
                    <asp:TextBox ID="GoodPoints_TextBox" runat="server" Height="142px" TextMode="MultiLine" Width="486px"></asp:TextBox>
                </td>
                <td class="auto-style52">&nbsp;</td>
                <td class="auto-style56">&nbsp;</td>
                <td class="auto-style40" colspan="4">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style51">
                    <asp:TextBox ID="BadPoints_TextBox" runat="server" Height="142px" TextMode="MultiLine" Width="486px"></asp:TextBox>
                </td>
                <td class="auto-style52">&nbsp;</td>
                <td class="auto-style56">&nbsp;</td>
                <td class="auto-style40" colspan="4">&nbsp;</td>
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
                <td class="auto-style51">
                    <h1>Latest reviews&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </h1>
                </td>
                <td class="auto-style52">&nbsp;</td>
                <td class="auto-style56">
                    <h1>My reviews</h1>
                </td>
                <td class="auto-style25" colspan="2">
                    <asp:Button ID="Create_Button" runat="server" Text="Create new review" OnClick="Create_Button_Click" />
                </td>
                <td class="auto-style25" colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style51" rowspan="2">
                    <br />
                    <br />
                    <asp:ListBox ID="AllReviews_ListBox" runat="server" Height="442px" Width="494px" AutoPostBack="True" OnSelectedIndexChanged="AllReviews_ListBox_SelectedIndexChanged"></asp:ListBox>
                </td>
                <td class="auto-style52" rowspan="2">&nbsp;</td>
                <td class="auto-style56">
                    &nbsp;</td>
                <td class="auto-style25" colspan="2">
                    <asp:Button ID="Remove_Button" runat="server" Text="Remove my review" OnClick="Remove_Button_Click" />
                </td>
                <td class="auto-style25" colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style31" colspan="2">
                    <asp:ListBox ID="MyReviews_ListBox" runat="server" Height="396px" Width="550px" AutoPostBack="True" OnSelectedIndexChanged="MyReviews_ListBox_SelectedIndexChanged"></asp:ListBox>
                </td>
                <td class="auto-style31" colspan="2">&nbsp;</td>
                <td class="auto-style31">&nbsp;</td>
            </tr>
        </table>
</asp:Content>
