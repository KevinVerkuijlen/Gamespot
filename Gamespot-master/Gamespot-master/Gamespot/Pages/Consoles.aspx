<%@ Page Title="" Language="C#" MaintainScrollPositionOnPostback="true" MasterPageFile="~/Pages/GameSpot_Master.Master" AutoEventWireup="true" CodeBehind="Consoles.aspx.cs" Inherits="Gamespot.Consoles"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 1648px;
        }
        .auto-style2 {
        }
        .auto-style3 {
        }
        .auto-style5 {
        }
        .auto-style12 {
            width: 179px;
            height: 37px;
        }
        .auto-style16 {
            height: 37px;
            width: 488px;
        }
        .auto-style19 {
            width: 488px;
        }
        .auto-style20 {
            width: 150px;
        }
        .auto-style26 {
            width: 102px;
        }
        .auto-style27 {
            width: 128px;
        }
        .auto-style28 {
            width: 241px;
        }
        .auto-style29 {
            width: 100px;
        }
        .auto-style31 {
            width: 156px;
        }
        .auto-style32 {
            width: 157px;
        }
        .auto-style33 {
            width: 16px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2" colspan="2">&nbsp;</td>
                <td class="auto-style26" colspan="2">&nbsp;</td>
                <td class="auto-style27" colspan="2">&nbsp;</td>
                <td class="auto-style28" colspan="2">&nbsp;</td>
                <td class="auto-style19">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">&nbsp;</td>
                <td class="auto-style26" colspan="2">&nbsp;</td>
                <td class="auto-style27" colspan="2">&nbsp;</td>
                <td class="auto-style28" colspan="2">&nbsp;</td>
                <td class="auto-style19">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <h2>Select the console:</h2>
                </td>
                <td class="auto-style26" colspan="2">
                    <asp:DropDownList ID="Console_DropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Console_DropDownList_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td class="auto-style27" colspan="2">&nbsp;</td>
                <td class="auto-style28" colspan="2">&nbsp;</td>
                <td class="auto-style19">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <h2>Post information</h2>
                </td>
                <td class="auto-style3" colspan="4">
                    <h2>Publisher information</h2>
                </td>
                <td class="auto-style28" colspan="2">
                    &nbsp;</td>
                <td class="auto-style19">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <p><asp:Label ID="PostTitel_Label" runat="server" Text="Post Titel:"></asp:Label></p>
                    <p><asp:Label ID="InputTitel_Label" runat="server"></asp:Label></p>
                </td>
                <td class="auto-style26" colspan="2">
                    <p>
                        name</p>
                </td>
                <td class="auto-style27" colspan="2">
                    <p> <asp:Label ID="InputName_Label" runat="server"></asp:Label></p>
                </td>
                <td class="auto-style28" rowspan="3" colspan="2">
                    &nbsp;</td>
                <td class="auto-style19">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                   <p><asp:Label ID="Game_Label" runat="server" Text="Game:"></asp:Label></p>
                   <p> <asp:Label ID="InputGame_Label" runat="server"></asp:Label></p>
                </td>
                <td class="auto-style26" colspan="2">
                    <p>
                        upload date</p>
                </td>
                <td class="auto-style27" colspan="2">
                    <p> <asp:Label ID="InputDate_Label" runat="server"></asp:Label></p>
                </td>
                <td class="auto-style19">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <asp:TextBox ID="Content_TextBox" runat="server" Height="142px" TextMode="MultiLine" Width="486px"></asp:TextBox>
                </td>
                <td class="auto-style5" colspan="4">
                    <asp:Button ID="Follow_Button" runat="server" Text="Follow" OnClick="Follow_Button_Click" />
                </td>
                <td class="auto-style19">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <p> <asp:Label ID="NewsRating_Label" runat="server" Text="Rating:"></asp:Label></p>
                    <p> <asp:Label ID="NewsInputRating_Label" runat="server"></asp:Label></p>
                    <asp:TextBox ID="GoodPoints_TextBox" runat="server" Height="142px" TextMode="MultiLine" Width="486px"></asp:TextBox>
                </td>
                <td class="auto-style26" colspan="2">
                    <h2>Recent postes</h2>
                    <p>&nbsp;</p>
                    <asp:ListBox ID="AllPost_ListBox" runat="server" Height="126px" Width="228px" AutoPostBack="True" OnSelectedIndexChanged="AllPost_ListBox_SelectedIndexChanged"></asp:ListBox>
                </td>
                <td class="auto-style27" colspan="2">&nbsp;</td>
                <td class="auto-style28" colspan="2">&nbsp;</td>
                <td class="auto-style19">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <asp:TextBox ID="BadPoints_TextBox" runat="server" Height="142px" TextMode="MultiLine" Width="486px"></asp:TextBox>
                </td>
                <td class="auto-style26" colspan="2">&nbsp;</td>
                <td class="auto-style27" colspan="2">&nbsp;</td>
                <td class="auto-style28" colspan="2">&nbsp;</td>
                <td class="auto-style19">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                   <p>  <asp:Label ID="ReviewRating_Label" runat="server" Text="Rating:"></asp:Label></p>
                   <p>  <asp:Label ID="ReviewInputRating_Label" runat="server"></asp:Label></p>
                </td>
                <td class="auto-style26" colspan="2">&nbsp;</td>
                <td class="auto-style27" colspan="2">&nbsp;</td>
                <td class="auto-style28" colspan="2">&nbsp;</td>
                <td class="auto-style19">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">&nbsp;</td>
                <td class="auto-style26" colspan="2">&nbsp;</td>
                <td class="auto-style27" colspan="2">&nbsp;</td>
                <td class="auto-style28" colspan="2">&nbsp;</td>
                <td class="auto-style19">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <h2>Top rated</h2>
                </td>
                <td class="auto-style26" colspan="2">
                    <h2>Coming soon</h2>
                </td>
                <td class="auto-style27" colspan="2">
                    <h2>New releases</h2>
                </td>
                <td class="auto-style28" colspan="2">
                    <h2>All console games</h2>
                </td>
                <td class="auto-style19">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2" rowspan="4">
                    <asp:ListBox ID="TopRated_ListBox" runat="server" Height="160px" Width="280px" AutoPostBack="True" OnSelectedIndexChanged="TopRated_ListBox_SelectedIndexChanged"></asp:ListBox>
                </td>
                <td class="auto-style26" colspan="2" rowspan="4">
                    <asp:ListBox ID="ComingSoon_ListBox" runat="server" Height="160px" Width="280px" AutoPostBack="True" OnSelectedIndexChanged="ComingSoon_ListBox_SelectedIndexChanged"></asp:ListBox>
                </td>
                <td class="auto-style27" colspan="2" rowspan="4">
                    <asp:ListBox ID="NewReleases_ListBox" runat="server" Height="160px" Width="280px" AutoPostBack="True" OnSelectedIndexChanged="NewReleases_ListBox_SelectedIndexChanged"></asp:ListBox>
                </td>
                <td class="auto-style28" rowspan="4" colspan="2">
                    <asp:ListBox ID="AllGames_ListBox" runat="server" Height="178px" Width="228px" AutoPostBack="True" OnSelectedIndexChanged="AllGames_ListBox_SelectedIndexChanged"></asp:ListBox>
                </td>
                <td class="auto-style19">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style19">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style19">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style19">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style31">
                    <asp:Button ID="TopWant_Button" runat="server" Text="Add to want" OnClick="TopWant_Button_Click" />
                </td>
                <td class="auto-style31">
                    <asp:Button ID="TopHave_Button" runat="server" Text="Add to have" OnClick="TopHave_Button_Click" />
                </td>
                <td>
                    <asp:Button ID="ComingWant_Button" runat="server" Text="Add to want" OnClick="ComingWant_Button_Click" Width="110px" />
                </td>
                <td class="auto-style33">
                    <asp:Button ID="ComingHave_Button" runat="server" Text="Add to have" OnClick="ComingHave_Button_Click" />
                </td>
                <td class="auto-style31">
                    <asp:Button ID="ReleaseWant_Button" runat="server" Text="Add to want" OnClick="ReleaseWant_Button_Click" />
                </td>
                <td class="auto-style31">
                    <asp:Button ID="ReleaseHave_Button" runat="server" Text="Add to have" OnClick="ReleaseHave_Button_Click" />
                </td>
                <td class="auto-style31">
                    <asp:Button ID="AllWant_Button" runat="server" Text="Add to want" OnClick="AllWant_Button_Click" />
                </td>
                <td class="auto-style32">
                    <asp:Button ID="AllHave_Button" runat="server" Text="Add to have" OnClick="AllHave_Button_Click" />
                </td>
                <td class="auto-style19">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">&nbsp;</td>
                <td class="auto-style26" colspan="2">&nbsp;</td>
                <td class="auto-style27" colspan="2">&nbsp;</td>
                <td class="auto-style28" colspan="2">&nbsp;</td>
                <td class="auto-style19">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="4">
                    <h2>Selected game info</h2>
                </td>
                <td class="auto-style27" colspan="2">
                    <h3>Explore games by genre</h3>
                </td>
                <td class="auto-style28" colspan="2">
                    <h3>Explore games by theme</h3>
                </td>
                <td class="auto-style19">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <p>
                        Game name:</p>
                </td>
                <td class="auto-style29" colspan="2">
                  <p><asp:Label ID="Game_Name_Label" runat="server"></asp:Label></p>
                </td>
                <td class="auto-style27" colspan="2" rowspan="9">
                    <asp:RadioButtonList ID="Genre_RadioButtonList" runat="server" Height="420px" Width="220px" OnSelectedIndexChanged="Genre_RadioButtonList_SelectedIndexChanged" AutoPostBack="True">
                    </asp:RadioButtonList>
                </td>
                <td class="auto-style28" rowspan="9" colspan="2">
                    <asp:RadioButtonList ID="Theme_RadioButtonList" runat="server" Height="420px" Width="220px" OnSelectedIndexChanged="Theme_RadioButtonList_SelectedIndexChanged" AutoPostBack="True">
                    </asp:RadioButtonList>
                </td>
                <td class="auto-style19">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <p>
                        Game platform:</p>
                </td>
                <td class="auto-style29" colspan="2">
                   <p><asp:Label ID="Platform_Label" runat="server"></asp:Label></p>
                </td>
                <td class="auto-style19">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <p>
                        Game genre:</p>
                </td>
                <td class="auto-style29" colspan="2">
                    <p><asp:Label ID="Genre_Label" runat="server"></asp:Label></p>
                </td>
                <td class="auto-style19">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <p>
                        Game theme:</p>
                </td>
                <td class="auto-style20" colspan="2">
                    <p><asp:Label ID="Thema_Label" runat="server"></asp:Label></p>
                </td>
                <td class="auto-style19">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <p>
                        First release:</p>
                </td>
                <td class="auto-style29" colspan="2">
                    <p><asp:Label ID="FirstRelease_Label" runat="server"></asp:Label></p>
                </td>
                <td class="auto-style19">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style12" colspan="2">
                    <p>
                        Game rating:</p>
                </td>
                <td class="auto-style29" colspan="2">
                    <p><asp:Label ID="Rating_Label" runat="server"></asp:Label></p>
                </td>
                <td class="auto-style16"></td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <p>
                        Game description:</p>
                </td>
                <td class="auto-style29" colspan="2">
                    <asp:TextBox ID="Description_TextBox" runat="server" Enabled="False" Height="138px" TextMode="MultiLine" Width="296px"></asp:TextBox>
                </td>
                <td class="auto-style19">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <p>
                        Game publisher:</p>
                </td>
                <td class="auto-style29" colspan="2">
                    <p><asp:Label ID="Publisher_Label" runat="server"></asp:Label></p>
                </td>
                <td class="auto-style19">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <p>
                        Game designer:</p>
                </td>
                <td class="auto-style29" colspan="2">
                    <p><asp:Label ID="Designer_Label" runat="server"></asp:Label></p>
                </td>
                <td class="auto-style19">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">&nbsp;</td>
                <td class="auto-style26" colspan="2">&nbsp;</td>
                <td class="auto-style27" colspan="2">&nbsp;</td>
                <td class="auto-style28" colspan="2">&nbsp;</td>
                <td class="auto-style19">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">&nbsp;</td>
                <td class="auto-style26" colspan="2">&nbsp;</td>
                <td class="auto-style27" colspan="2">&nbsp;</td>
                <td class="auto-style28" colspan="2">&nbsp;</td>
                <td class="auto-style19">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">&nbsp;</td>
                <td class="auto-style26" colspan="2">&nbsp;</td>
                <td class="auto-style27" colspan="2">&nbsp;</td>
                <td class="auto-style28" colspan="2">&nbsp;</td>
                <td class="auto-style19">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">&nbsp;</td>
                <td class="auto-style26" colspan="2">&nbsp;</td>
                <td class="auto-style27" colspan="2">&nbsp;</td>
                <td class="auto-style28" colspan="2">&nbsp;</td>
                <td class="auto-style19">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">&nbsp;</td>
                <td class="auto-style26" colspan="2">&nbsp;</td>
                <td class="auto-style27" colspan="2">&nbsp;</td>
                <td class="auto-style28" colspan="2">&nbsp;</td>
                <td class="auto-style19">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">&nbsp;</td>
                <td class="auto-style26" colspan="2">&nbsp;</td>
                <td class="auto-style27" colspan="2">&nbsp;</td>
                <td class="auto-style28" colspan="2">&nbsp;</td>
                <td class="auto-style19">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">&nbsp;</td>
                <td class="auto-style26" colspan="2">&nbsp;</td>
                <td class="auto-style27" colspan="2">&nbsp;</td>
                <td class="auto-style28" colspan="2">&nbsp;</td>
                <td class="auto-style19">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">&nbsp;</td>
                <td class="auto-style26" colspan="2">&nbsp;</td>
                <td class="auto-style27" colspan="2">&nbsp;</td>
                <td class="auto-style28" colspan="2">&nbsp;</td>
                <td class="auto-style19">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">&nbsp;</td>
                <td class="auto-style26" colspan="2">&nbsp;</td>
                <td class="auto-style27" colspan="2">&nbsp;</td>
                <td class="auto-style28" colspan="2">&nbsp;</td>
                <td class="auto-style19">&nbsp;</td>
            </tr>
        </table>
</asp:Content>

