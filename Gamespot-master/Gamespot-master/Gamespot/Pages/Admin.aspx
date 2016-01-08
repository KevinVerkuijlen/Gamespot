<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/GameSpot_Master.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Gamespot.Pages.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style9">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style9">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style9">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:DropDownList ID="PostType_DropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="PostType_DropDownList_SelectedIndexChanged">
                    <asp:ListItem>All</asp:ListItem>
                    <asp:ListItem>News</asp:ListItem>
                    <asp:ListItem>Video</asp:ListItem>
                    <asp:ListItem>Review</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style4">
                <asp:Button ID="RemovePost_Button" runat="server" Text="Remove post" OnClick="RemovePost_Button_Click" />
            </td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style9">
                <asp:Button ID="ConsoleAdd_Button" runat="server" OnClick="ConsoleAdd_Button_Click" Text="Add console" />
            </td>
            <td>
                <asp:Button ID="ConsoleRemove_Button" runat="server" OnClick="ConsoleRemove_Button_Click" Text="Remove console" />
            </td>
        </tr>
        <tr>
            <td class="auto-style3" colspan="2" rowspan="5">
                <asp:ListBox ID="Post_ListBox" runat="server" Height="224px" Width="446px"></asp:ListBox>
            </td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style9"><p>Console name:</p>
            </td>
            <td rowspan="6">
                <asp:ListBox ID="Console_ListBox" runat="server" Height="422px" Width="210px"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style9">
                <asp:TextBox ID="ConsoleName_TextBox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style9"><p>Console type:</p>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style9">
                <asp:RadioButtonList ID="ConsoleType_RadioButtonList" runat="server">
                    <asp:ListItem>Handheld</asp:ListItem>
                    <asp:ListItem>Home console</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style9">
                <p>Console description</p>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style9">
                <asp:TextBox ID="ConsoleDescription_TextBox" runat="server" Height="116px" TextMode="MultiLine" Width="184px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style9">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style9">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5"><p>Account ID:</p>                                 
            </td>
            <td class="auto-style4">
                <p><asp:Label ID="Account_ID_Label" runat="server"></asp:Label></p>
                </td>
            <td class="auto-style8">
                <asp:Button ID="AccountChange_Button" runat="server" Text="Change Account info" OnClick="ChangeAccount_Button_Click" />
            </td>
            <td class="auto-style9">
                <asp:Button ID="GenreAdd_Button" runat="server" OnClick="GenreAdd_Button_Click" Text="Add genre" />
            </td>
            <td>
                <asp:Button ID="GenreRemove_Button" runat="server" OnClick="GenreRemove_Button_Click" Text="Remove genre" />
            </td>
        </tr>
        <tr>
            <td class="auto-style5"><p>User name:</p></td>
            <td class="auto-style2">
                <asp:TextBox ID="UserName_TextBox" runat="server" ValidationGroup="Update"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="UserName_RequiredFieldValidator" runat="server" ControlToValidate="UserName_TextBox" ErrorMessage="You need to fill in a user name" ForeColor="Red" ValidationGroup="Update"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style8">
                <asp:Button ID="AccountRemove_Button" runat="server" Text="Remove account" OnClick="AccountRemove_Button_Click" />
            </td>
            <td class="auto-style9">
                <p>Genre name:</p>                                 
            </td>
            <td rowspan="4">
                <asp:ListBox ID="Genre_ListBox" runat="server" Height="366px" Width="236px"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style5"><p>Email:</p></td>
            <td class="auto-style2">
                <asp:TextBox ID="Email_TextBox" runat="server" TextMode="Email" ValidationGroup="Update"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="Email_RequiredFieldValidator" runat="server" ControlToValidate="Email_TextBox" ErrorMessage="You need to fill in a email adress" ForeColor="Red" ValidationGroup="Update"></asp:RequiredFieldValidator>
                <br />
                <asp:RegularExpressionValidator ID="Email_RegularExpressionValidator" runat="server" ControlToValidate="Email_TextBox" ErrorMessage="Enter a valit email adress" ForeColor="Red" ValidationGroup="Update"></asp:RegularExpressionValidator>
            </td>
            <td class="auto-style8" rowspan="5">
                <asp:ListBox ID="Account_ListBox" runat="server" Height="668px" Width="252px" AutoPostBack="True" OnSelectedIndexChanged="Account_ListBox_SelectedIndexChanged"></asp:ListBox>
            </td>
            <td class="auto-style9">
                <asp:TextBox ID="GenreName_TextBox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style5"><p>Password:</p></td>
            <td class="auto-style2">
                <asp:TextBox ID="Password_TextBox" runat="server" TextMode="Password" ValidationGroup="Update"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="Password_RequiredFieldValidator" runat="server" ErrorMessage="You need to fill in a password" ForeColor="Red" ValidationGroup="Update" ControlToValidate="Password_TextBox"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style9">
                <p>Genre description</p>
            </td>
        </tr>
        <tr>
            <td class="auto-style3"><p>Gendre:</p></td>
            <td class="auto-style4">
                <asp:RadioButtonList ID="Gendre_RadioButtonList" runat="server" ValidationGroup="Update">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                    <asp:ListItem>Not importent</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td class="auto-style9">
                <asp:TextBox ID="GenreDescription_TextBox" runat="server" Height="168px" TextMode="MultiLine" Width="236px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style5"><p>Birthdate:</p></td>
            <td class="auto-style6">
                <asp:TextBox ID="BirthDate_TextBox" runat="server" TextMode="Date"></asp:TextBox>
            </td>
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td class="auto-style3"><p>Country:</p></td>
            <td class="auto-style4">
                <asp:DropDownList ID="Country_DropDownList" runat="server" ValidationGroup="Update">
                    <asp:ListItem Value="Afghanistan">Afghanistan</asp:ListItem>
<asp:ListItem Value="Albania">Albania</asp:ListItem>
<asp:ListItem Value="Algeria">Algeria</asp:ListItem>
<asp:ListItem Value="American Samoa">American Samoa</asp:ListItem>
<asp:ListItem Value="Andorra">Andorra</asp:ListItem>
<asp:ListItem Value="Angola">Angola</asp:ListItem>
<asp:ListItem Value="Anguilla">Anguilla</asp:ListItem>
<asp:ListItem Value="Antarctica">Antarctica</asp:ListItem>
<asp:ListItem Value="Antigua And Barbuda">Antigua And Barbuda</asp:ListItem>
<asp:ListItem Value="Argentina">Argentina</asp:ListItem>
<asp:ListItem Value="Armenia">Armenia</asp:ListItem>
<asp:ListItem Value="Aruba">Aruba</asp:ListItem>
<asp:ListItem Value="Australia">Australia</asp:ListItem>
<asp:ListItem Value="Austria">Austria</asp:ListItem>
<asp:ListItem Value="Azerbaijan">Azerbaijan</asp:ListItem>
<asp:ListItem Value="Bahamas">Bahamas</asp:ListItem>
<asp:ListItem Value="Bahrain">Bahrain</asp:ListItem>
<asp:ListItem Value="Bangladesh">Bangladesh</asp:ListItem>
<asp:ListItem Value="Barbados">Barbados</asp:ListItem>
<asp:ListItem Value="Belarus">Belarus</asp:ListItem>
<asp:ListItem Value="Belgium">Belgium</asp:ListItem>
<asp:ListItem Value="Belize">Belize</asp:ListItem>
<asp:ListItem Value="Benin">Benin</asp:ListItem>
<asp:ListItem Value="Bermuda">Bermuda</asp:ListItem>
<asp:ListItem Value="Bhutan">Bhutan</asp:ListItem>
<asp:ListItem Value="Bolivia">Bolivia</asp:ListItem>
<asp:ListItem Value="Bosnia And Herzegowina">Bosnia And Herzegowina</asp:ListItem>
<asp:ListItem Value="Botswana">Botswana</asp:ListItem>
<asp:ListItem Value="Bouvet Island">Bouvet Island</asp:ListItem>
<asp:ListItem Value="Brazil">Brazil</asp:ListItem>
<asp:ListItem Value="British Indian Ocean Territory">British Indian Ocean Territory</asp:ListItem>
<asp:ListItem Value="Brunei Darussalam">Brunei Darussalam</asp:ListItem>
<asp:ListItem Value="Bulgaria">Bulgaria</asp:ListItem>
<asp:ListItem Value="Burkina">Burkina Faso</asp:ListItem>
<asp:ListItem Value="Burundi">Burundi</asp:ListItem>
<asp:ListItem Value="Cambodia">Cambodia</asp:ListItem>
<asp:ListItem Value="Cameroon">Cameroon</asp:ListItem>
<asp:ListItem Value="Canada">Canada</asp:ListItem>
<asp:ListItem Value="Cape Verde">Cape Verde</asp:ListItem>
<asp:ListItem Value="Cayman Islands">Cayman Islands</asp:ListItem>
<asp:ListItem Value="Central African Republic">Central African Republic</asp:ListItem>
<asp:ListItem Value="Chad">Chad</asp:ListItem>
<asp:ListItem Value="Chile">Chile</asp:ListItem>
<asp:ListItem Value="China">China</asp:ListItem>
<asp:ListItem Value="Christmas Island">Christmas Island</asp:ListItem>
<asp:ListItem Value="Cocos (Keeling) Islands">Cocos (Keeling) Islands</asp:ListItem>
<asp:ListItem Value="Colombia">Colombia</asp:ListItem>
<asp:ListItem Value="Comoros">Comoros</asp:ListItem>
<asp:ListItem Value="Congo">Congo</asp:ListItem>
<asp:ListItem Value="Cook Islands">Cook Islands</asp:ListItem>
<asp:ListItem Value="Costa Rica">Costa Rica</asp:ListItem>
<asp:ListItem Value="Cote D'Ivoire">Cote D'Ivoire</asp:ListItem>
<asp:ListItem Value="Croatia">Croatia (Local Name: Hrvatska)</asp:ListItem>
<asp:ListItem Value="Cuba">Cuba</asp:ListItem>
<asp:ListItem Value="Cyprus">Cyprus</asp:ListItem>
<asp:ListItem Value="Czech Republic">Czech Republic</asp:ListItem>
<asp:ListItem Value="Denmark">Denmark</asp:ListItem>
<asp:ListItem Value="Djibouti">Djibouti</asp:ListItem>
<asp:ListItem Value="Dominica">Dominica</asp:ListItem>
<asp:ListItem Value="Dominican Republic">Dominican Republic</asp:ListItem>
<asp:ListItem Value="East Timor">East Timor</asp:ListItem>
<asp:ListItem Value="Ecuador">Ecuador</asp:ListItem>
<asp:ListItem Value="Egypt">Egypt</asp:ListItem>
<asp:ListItem Value="El Salvador">El Salvador</asp:ListItem>
<asp:ListItem Value="Equatorial Guinea">Equatorial Guinea</asp:ListItem>
<asp:ListItem Value="Eritrea">Eritrea</asp:ListItem>
<asp:ListItem Value="Estonia">Estonia</asp:ListItem>
<asp:ListItem Value="Ethiopia">Ethiopia</asp:ListItem>
<asp:ListItem Value="Falkland Islands">Falkland Islands (Malvinas)</asp:ListItem>
<asp:ListItem Value="Faroe Islands">Faroe Islands</asp:ListItem>
<asp:ListItem Value="Fiji">Fiji</asp:ListItem>
<asp:ListItem Value="Finland">Finland</asp:ListItem>
<asp:ListItem Value="France">France</asp:ListItem>
<asp:ListItem Value="French Guiana">French Guiana</asp:ListItem>
<asp:ListItem Value="French Polynesia">French Polynesia</asp:ListItem>
<asp:ListItem Value="French Southern Territories">French Southern Territories</asp:ListItem>
<asp:ListItem Value="Gabon">Gabon</asp:ListItem>
<asp:ListItem Value="Gambia">Gambia</asp:ListItem>
<asp:ListItem Value="Georgia">Georgia</asp:ListItem>
<asp:ListItem Value="Germany">Germany</asp:ListItem>
<asp:ListItem Value="Ghana">Ghana</asp:ListItem>
<asp:ListItem Value="Gibraltar">Gibraltar</asp:ListItem>
<asp:ListItem Value="Greece">Greece</asp:ListItem>
<asp:ListItem Value="Greenland">Greenland</asp:ListItem>
<asp:ListItem Value="Grenada">Grenada</asp:ListItem>
<asp:ListItem Value="Guadeloupe">Guadeloupe</asp:ListItem>
<asp:ListItem Value="Guam">Guam</asp:ListItem>
<asp:ListItem Value="Guatemala">Guatemala</asp:ListItem>
<asp:ListItem Value="Guinea">Guinea</asp:ListItem>
<asp:ListItem Value="Guinea-Bissau">Guinea-Bissau</asp:ListItem>
<asp:ListItem Value="Guyana">Guyana</asp:ListItem>
<asp:ListItem Value="Haiti">Haiti</asp:ListItem>
<asp:ListItem Value="Heard And Mc Donald Islands">Heard And Mc Donald Islands</asp:ListItem>
<asp:ListItem Value="Vatican City">Holy See (Vatican City State)</asp:ListItem>
<asp:ListItem Value="Honduras">Honduras</asp:ListItem>
<asp:ListItem Value="Hong Kong">Hong Kong</asp:ListItem>
<asp:ListItem Value="Hungary">Hungary</asp:ListItem>
<asp:ListItem Value="Icel And">Icel And</asp:ListItem>
<asp:ListItem Value="India">India</asp:ListItem>
<asp:ListItem Value="Indonesia">Indonesia</asp:ListItem>
<asp:ListItem Value="Iran">Iran (Islamic Republic Of)</asp:ListItem>
<asp:ListItem Value="Iraq">Iraq</asp:ListItem>
<asp:ListItem Value="Ireland">Ireland</asp:ListItem>
<asp:ListItem Value="Israel">Israel</asp:ListItem>
<asp:ListItem Value="Italy">Italy</asp:ListItem>
<asp:ListItem Value="Jamaica">Jamaica</asp:ListItem>
<asp:ListItem Value="Japan">Japan</asp:ListItem>
<asp:ListItem Value="Jordan">Jordan</asp:ListItem>
<asp:ListItem Value="Kazakhstan">Kazakhstan</asp:ListItem>
<asp:ListItem Value="Kenya">Kenya</asp:ListItem>
<asp:ListItem Value="Kiribati">Kiribati</asp:ListItem>
<asp:ListItem Value="Korea, Dem People'S Republic">Korea, Dem People'S Republic</asp:ListItem>
<asp:ListItem Value="Korea, Republic Of">Korea, Republic Of</asp:ListItem>
<asp:ListItem Value="Kuwait">Kuwait</asp:ListItem>
<asp:ListItem Value="Kyrgyzstan">Kyrgyzstan</asp:ListItem>
<asp:ListItem Value="Lao People'S Dem Republic">Lao People'S Dem Republic</asp:ListItem>
<asp:ListItem Value="Latvia">Latvia</asp:ListItem>
<asp:ListItem Value="Lebanon">Lebanon</asp:ListItem>
<asp:ListItem Value="Lesotho">Lesotho</asp:ListItem>
<asp:ListItem Value="Liberia">Liberia</asp:ListItem>
<asp:ListItem Value="Libyan Arab Jamahiriya">Libyan Arab Jamahiriya</asp:ListItem>
<asp:ListItem Value="Liechtenstein">Liechtenstein</asp:ListItem>
<asp:ListItem Value="Lithuania">Lithuania</asp:ListItem>
<asp:ListItem Value="Luxembourg">Luxembourg</asp:ListItem>
<asp:ListItem Value="Macau">Macau</asp:ListItem>
<asp:ListItem Value="Macedonia">Macedonia</asp:ListItem>
<asp:ListItem Value="Madagascar">Madagascar</asp:ListItem>
<asp:ListItem Value="Malawi">Malawi</asp:ListItem>
<asp:ListItem Value="Malaysia">Malaysia</asp:ListItem>
<asp:ListItem Value="Maldives">Maldives</asp:ListItem>
<asp:ListItem Value="Mali">Mali</asp:ListItem>
<asp:ListItem Value="Malta">Malta</asp:ListItem>
<asp:ListItem Value="Marshall Islands">Marshall Islands</asp:ListItem>
<asp:ListItem Value="Martinique">Martinique</asp:ListItem>
<asp:ListItem Value="Mauritania">Mauritania</asp:ListItem>
<asp:ListItem Value="Mauritius">Mauritius</asp:ListItem>
<asp:ListItem Value="Mayotte">Mayotte</asp:ListItem>
<asp:ListItem Value="Mexico">Mexico</asp:ListItem>
<asp:ListItem Value="Micronesia, Federated States">Micronesia, Federated States</asp:ListItem>
<asp:ListItem Value="Moldova, Republic Of">Moldova, Republic Of</asp:ListItem>
<asp:ListItem Value="Monaco">Monaco</asp:ListItem>
<asp:ListItem Value="Mongolia">Mongolia</asp:ListItem>
<asp:ListItem Value="Montserrat">Montserrat</asp:ListItem>
<asp:ListItem Value="Morocco">Morocco</asp:ListItem>
<asp:ListItem Value="Mozambique">Mozambique</asp:ListItem>
<asp:ListItem Value="Myanmar">Myanmar</asp:ListItem>
<asp:ListItem Value="Namibia">Namibia</asp:ListItem>
<asp:ListItem Value="Nauru">Nauru</asp:ListItem>
<asp:ListItem Value="Nepal">Nepal</asp:ListItem>
<asp:ListItem Value="Netherlands">Netherlands</asp:ListItem>
<asp:ListItem Value="Netherlands Ant Illes">Netherlands Ant Illes</asp:ListItem>
<asp:ListItem Value="New Caledonia">New Caledonia</asp:ListItem>
<asp:ListItem Value="New Zealand">New Zealand</asp:ListItem>
<asp:ListItem Value="Nicaragua">Nicaragua</asp:ListItem>
<asp:ListItem Value="Niger">Niger</asp:ListItem>
<asp:ListItem Value="Nigeria">Nigeria</asp:ListItem>
<asp:ListItem Value="Niue">Niue</asp:ListItem>
<asp:ListItem Value="Norfolk Island">Norfolk Island</asp:ListItem>
<asp:ListItem Value="Northern Mariana Islands">Northern Mariana Islands</asp:ListItem>
<asp:ListItem Value="Norway">Norway</asp:ListItem>
<asp:ListItem Value="Oman">Oman</asp:ListItem>
<asp:ListItem Value="Pakistan">Pakistan</asp:ListItem>
<asp:ListItem Value="Palau">Palau</asp:ListItem>
<asp:ListItem Value="Panama">Panama</asp:ListItem>
<asp:ListItem Value="Papua New Guinea">Papua New Guinea</asp:ListItem>
<asp:ListItem Value="Paraguay">Paraguay</asp:ListItem>
<asp:ListItem Value="Peru">Peru</asp:ListItem>
<asp:ListItem Value="Philippines">Philippines</asp:ListItem>
<asp:ListItem Value="Pitcairn">Pitcairn</asp:ListItem>
<asp:ListItem Value="Poland">Poland</asp:ListItem>
<asp:ListItem Value="Portugal">Portugal</asp:ListItem>
<asp:ListItem Value="Puerto Rico">Puerto Rico</asp:ListItem>
<asp:ListItem Value="Qatar">Qatar</asp:ListItem>
<asp:ListItem Value="Reunion">Reunion</asp:ListItem>
<asp:ListItem Value="Romania">Romania</asp:ListItem>
<asp:ListItem Value="Russian Federation">Russian Federation</asp:ListItem>
<asp:ListItem Value="Rwanda">Rwanda</asp:ListItem>
<asp:ListItem Value="Saint K Itts And Nevis">Saint K Itts And Nevis</asp:ListItem>
<asp:ListItem Value="Saint Lucia">Saint Lucia</asp:ListItem>
<asp:ListItem Value="Saint Vincent, The Grenadines">Saint Vincent, The Grenadines</asp:ListItem>
<asp:ListItem Value="Samoa">Samoa</asp:ListItem>
<asp:ListItem Value="San Marino">San Marino</asp:ListItem>
<asp:ListItem Value="Sao Tome And Principe">Sao Tome And Principe</asp:ListItem>
<asp:ListItem Value="Saudi Arabia">Saudi Arabia</asp:ListItem>
<asp:ListItem Value="Senegal">Senegal</asp:ListItem>
<asp:ListItem Value="Seychelles">Seychelles</asp:ListItem>
<asp:ListItem Value="Sierra Leone">Sierra Leone</asp:ListItem>
<asp:ListItem Value="Singapore">Singapore</asp:ListItem>
<asp:ListItem Value="Slovakia">Slovakia (Slovak Republic)</asp:ListItem>
<asp:ListItem Value="Slovenia">Slovenia</asp:ListItem>
<asp:ListItem Value="Solomon Islands">Solomon Islands</asp:ListItem>
<asp:ListItem Value="Somalia">Somalia</asp:ListItem>
<asp:ListItem Value="South Africa">South Africa</asp:ListItem>
<asp:ListItem Value="South Georgia , S Sandwich Is.">South Georgia , S Sandwich Is.</asp:ListItem>
<asp:ListItem Value="Spain">Spain</asp:ListItem>
<asp:ListItem Value="Sri Lanka">Sri Lanka</asp:ListItem>
<asp:ListItem Value="St. Helena">St. Helena</asp:ListItem>
<asp:ListItem Value="St. Pierre And Miquelon">St. Pierre And Miquelon</asp:ListItem>
<asp:ListItem Value="Sudan">Sudan</asp:ListItem>
<asp:ListItem Value="Suriname">Suriname</asp:ListItem>
<asp:ListItem Value="Svalbard, Jan Mayen Islands">Svalbard, Jan Mayen Islands</asp:ListItem>
<asp:ListItem Value="Sw Aziland">Sw Aziland</asp:ListItem>
<asp:ListItem Value="Sweden">Sweden</asp:ListItem>
<asp:ListItem Value="Switzerland">Switzerland</asp:ListItem>
<asp:ListItem Value="Syrian Arab Republic">Syrian Arab Republic</asp:ListItem>
<asp:ListItem Value="Taiwan">Taiwan</asp:ListItem>
<asp:ListItem Value="Tajikistan">Tajikistan</asp:ListItem>
<asp:ListItem Value="Tanzania, United Republic Of">Tanzania, United Republic Of</asp:ListItem>
<asp:ListItem Value="Thailand">Thailand</asp:ListItem>
<asp:ListItem Value="Togo">Togo</asp:ListItem>
<asp:ListItem Value="Tokelau">Tokelau</asp:ListItem>
<asp:ListItem Value="Tonga">Tonga</asp:ListItem>
<asp:ListItem Value="Trinidad And Tobago">Trinidad And Tobago</asp:ListItem>
<asp:ListItem Value="Tunisia">Tunisia</asp:ListItem>
<asp:ListItem Value="Turkey">Turkey</asp:ListItem>
<asp:ListItem Value="Turkmenistan">Turkmenistan</asp:ListItem>
<asp:ListItem Value="Turks And Caicos Islands">Turks And Caicos Islands</asp:ListItem>
<asp:ListItem Value="Tuvalu">Tuvalu</asp:ListItem>
<asp:ListItem Value="Uganda">Uganda</asp:ListItem>
<asp:ListItem Value="Ukraine">Ukraine</asp:ListItem>
<asp:ListItem Value="United Arab Emirates">United Arab Emirates</asp:ListItem>
<asp:ListItem Value="United Kingdom">United Kingdom</asp:ListItem>
<asp:ListItem Value="United States">United States</asp:ListItem>
<asp:ListItem Value="United States Minor Is.">United States Minor Is.</asp:ListItem>
<asp:ListItem Value="Uruguay">Uruguay</asp:ListItem>
<asp:ListItem Value="Uzbekistan">Uzbekistan</asp:ListItem>
<asp:ListItem Value="Vanuatu">Vanuatu</asp:ListItem>
<asp:ListItem Value="Venezuela">Venezuela</asp:ListItem>
<asp:ListItem Value="Viet Nam">Viet Nam</asp:ListItem>
<asp:ListItem Value="Virgin Islands (British)">Virgin Islands (British)</asp:ListItem>
<asp:ListItem Value="Virgin Islands (U.S.)">Virgin Islands (U.S.)</asp:ListItem>
<asp:ListItem Value="Wallis And Futuna Islands">Wallis And Futuna Islands</asp:ListItem>
<asp:ListItem Value="Western Sahara">Western Sahara</asp:ListItem>
<asp:ListItem Value="Yemen">Yemen</asp:ListItem>
<asp:ListItem Value="Zaire">Zaire</asp:ListItem>
<asp:ListItem Value="Zambia">Zambia</asp:ListItem>
<asp:ListItem Value="Zimbabwe">Zimbabwe</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style9">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style9">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style9">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Button ID="GameAdd_Button" runat="server" Text="Add game" OnClick="GameAdd_Button_Click" />
            </td>
            <td class="auto-style4">
                <asp:Button ID="GameRemove_Button" runat="server" Text="Remove game" OnClick="GameRemove_Button_Click" />
            </td>
            <td class="auto-style8" rowspan="6">
                <asp:DropDownList ID="ConsoleSort_DropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ConsoleSort_DropDownList_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:ListBox ID="Game_ListBox" runat="server" Height="668px" Width="252px"></asp:ListBox>
            </td>
            <td class="auto-style9">
                <asp:Button ID="ThemeAdd_Button" runat="server" OnClick="ThemeAdd_Button_Click" Text="Add theme" />
            </td>
            <td>
                <asp:Button ID="ThemeRemove_Button" runat="server" OnClick="ThemeRemove_Button_Click" Text="Remove theme" />
            </td>
        </tr>
        <tr>
            <td class="auto-style5"><p>Game name:</p></td>
            <td class="auto-style4">
                <asp:TextBox ID="GameName_TextBox" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style9">
                <p>Theme name:</p>
            </td>
            <td rowspan="4">
                <asp:ListBox ID="Theme_ListBox" runat="server" Height="536px" Width="260px"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style5"><p>Game platform:</p></td>
            <td class="auto-style4">
                <asp:DropDownList ID="Platform_DropDownList" runat="server">
                </asp:DropDownList>
            </td>
            <td class="auto-style9">
                <asp:TextBox ID="ThemeName_TextBox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3"><p>Game genre:</p></td>
            <td class="auto-style4">
                <asp:DropDownList ID="Genre_DropDownList" runat="server">
                </asp:DropDownList>
            </td>
            <td class="auto-style9">
                <p>Theme description:</p>                                 
            </td>
        </tr>
        <tr>
            <td class="auto-style11"><p>Game theme:</p></td>
            <td class="auto-style12">
                <asp:DropDownList ID="Theme_DropDownList" runat="server">
                </asp:DropDownList>
            </td>
            <td class="auto-style14">
                <asp:TextBox ID="ThemeDescription_TextBox" runat="server" Height="180px" TextMode="MultiLine" Width="232px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3"><p>First release:</p></td>
            <td class="auto-style4">
                <asp:TextBox ID="FirstRelease_TextBox" runat="server" TextMode="Date"></asp:TextBox>
            </td>
            <td class="auto-style9">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5"><p>Game rating:</p></td>
            <td class="auto-style4">
                    <asp:DropDownList ID="Rating_DropDownList" runat="server">
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
            <td class="auto-style8" rowspan="4">
                &nbsp;</td>
            <td class="auto-style9">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5"><p>Game description:</p></td>
            <td class="auto-style4">
                <asp:TextBox ID="GameDescription_TextBox" runat="server" Height="118px" TextMode="MultiLine" Width="192px"></asp:TextBox>
            </td>
            <td class="auto-style9">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5"><p>Game publisher:</p></td>
            <td class="auto-style4">
                <asp:TextBox ID="GamePublischer_TextBox" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style9">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3"><p>Game designer:</p></td>
            <td class="auto-style4">
                <asp:TextBox ID="GameDesigner_TextBox" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style9">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style9">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style9">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style9">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style9">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style9">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
