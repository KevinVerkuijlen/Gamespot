<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/GameSpot_Master.Master" AutoEventWireup="true" CodeBehind="Publish post.aspx.cs" Inherits="Gamespot.Pages.Publish_post" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 37px;
        }
        .auto-style3 {
            width: 210px;
        }
        .auto-style4 {
            height: 37px;
            width: 210px;
        }
        .auto-style5 {
            width: 105px;
        }
        .auto-style6 {
            height: 37px;
            width: 105px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4"><h1>Create new post</h1>
                </td>
                <td class="auto-style6">
                    &nbsp;</td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td class="auto-style3"><p>Post type:</p>
                </td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:RadioButtonList ID="PostType_RadioButtonList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="PostType_RadioButtonList_SelectedIndexChanged" Width="227px">
                        <asp:ListItem>News</asp:ListItem>
                        <asp:ListItem>Review</asp:ListItem>
                        <asp:ListItem>Video</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td class="auto-style5">
                    <p><asp:Label ID="Titel_Label" runat="server" Text="Titel:"></asp:Label></p>
                </td>
                <td>
                    <asp:TextBox ID="Titel_TextBox" runat="server"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="Titel_RequiredFieldValidator" runat="server" ControlToValidate="Titel_TextBox" ErrorMessage="You need to fill in a titel for the post" ForeColor="Red" ValidationGroup="Post"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Button ID="Place_Button" runat="server" OnClick="Place_Button_Click" Text="Place post" />
                </td>
                <td class="auto-style5">
                    <p><asp:Label ID="Game_Label" runat="server" Text="Game:"></asp:Label></p>
                </td>
                <td>
                    <asp:ListBox ID="Game_ListBox" runat="server" Height="354px" Width="308px"></asp:ListBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style5">
                    <p><asp:Label ID="UploadDate_Label" runat="server" Text="Upload date:"></asp:Label></p>
                </td>
                <td>
                    <p><asp:Label ID="Date_Label" runat="server"></asp:Label></p>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style5">
                   <p> <asp:Label ID="NewsContent_Label" runat="server" Text="News content:"></asp:Label></p>
                   <p> <asp:Label ID="ReviewContent_Label" runat="server" Text="Review content:"></asp:Label></p>
                   <p><asp:Label ID="VideoURL_Label" runat="server" Text="VideoURL:"></asp:Label></p>
                </td>
                <td>
                    <asp:TextBox ID="NewsContent_TextBox" runat="server" Height="158px" TextMode="MultiLine" Width="366px"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="NewsContent_RequiredFieldValidator" runat="server" ControlToValidate="NewsContent_TextBox" ErrorMessage="You need to fill in some content for your news post" ForeColor="Red" ValidationGroup="Post"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="ReviewContent_TextBox" runat="server" Height="158px" TextMode="MultiLine" Width="366px"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="ReviewContent_RequiredFieldValidator" runat="server" ControlToValidate="ReviewContent_TextBox" ErrorMessage="You need to fill in some content for the review" ForeColor="Red" ValidationGroup="Post"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="VideoURL_TextBox" runat="server" TextMode="Url"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="VideoURL_RequiredFieldValidator" runat="server" ControlToValidate="VideoURL_TextBox" ErrorMessage="You need to enter a video url" ForeColor="Red" ValidationGroup="Post"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style5">
                    <p><asp:Label ID="NewsRating_Label" runat="server" Text="Rating:"></asp:Label></p>
                    <p><asp:Label ID="ReviewGood_Label" runat="server" Text="The good:"></asp:Label></p>
                </td>
                <td>
                    <asp:DropDownList ID="NewsRating_DropDownList" runat="server">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="ReviewGood_TextBox" runat="server" Height="116px" TextMode="MultiLine" Width="266px"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="ReviewGood_RequiredFieldValidator" runat="server" ControlToValidate="ReviewGood_TextBox" ErrorMessage="You need to fill in some good points for the review" ForeColor="Red" ValidationGroup="Post"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style5">
                    <p><asp:Label ID="ReviewBad_Label" runat="server" Text="The bad:"></asp:Label></p>
                </td>
                <td>
                    <asp:TextBox ID="ReviewBad_TextBox" runat="server" Height="116px" TextMode="MultiLine" Width="266px"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="ReviewBad_RequiredFieldValidator" runat="server" ControlToValidate="ReviewBad_TextBox" ErrorMessage="You need to fill in some bad point for the review" ForeColor="Red" ValidationGroup="Post"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style5">
                    <p><asp:Label ID="ReviewRating_Label" runat="server" Text="Reviewer Rating:"></asp:Label></p>
                </td>
                <td>
                    <asp:DropDownList ID="ReviewRating_DropDownList" runat="server">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
</asp:Content>
