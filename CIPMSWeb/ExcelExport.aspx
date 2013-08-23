<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExcelExport.aspx.cs" Inherits="ExcelExport" MasterPageFile="~/AdminMaster.master" %>

<asp:Content ContentPlaceHolderID="content" runat="server" ID="Content1">
    <table width="100%" class="text" cellpadding="0" cellspacing="0" style="border-right: thin solid;
        border-top: thin solid; border-left: thin solid; border-bottom: thin solid">
        <tr>
            <td style="height: 10px" colspan="3">
            </td>
        </tr>
        <tr>        
            <td class="text" colspan="3">
                &nbsp;<asp:Label runat="server" ID="lblMessage" Text="To download data for a particular year please select the year from the dropdownlist, or select <b>--All Years--</b>."></asp:Label>
            </td>
        </tr>
        <tr>
        <td style="width:10%" align="right">
            
        </td>
            <td style="width:60%" align="right">
                Year:&nbsp;
                <asp:DropDownList ID="ddlCampYear" runat="server" CssClass="text" Width="120px">
                </asp:DropDownList>
            </td>
            <td align="left" style="width:30%">
                &nbsp;<asp:Button ID="btnFinal" runat="server" CssClass="submitbtn" OnClick="btnSubmit_Click"
                    Text="Submit" CausesValidation="true" /></td>
        </tr>
        <tr><td style="height: 10px" colspan="3"></td></tr>
    </table>
    <table width="100%">
        <tr>
            <td style="height: 10px">
                <asp:GridView ID="gvExport" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CssClass="text"
                    ForeColor="Black" GridLines="Vertical" Width="100%" OnDataBound="gvExport_DataBound"
                    OnRowDataBound="gvExport_RowDataBound" OnRowCreated="GridView_Merge_Header_RowCreated"
                    Visible="false">
                    <AlternatingRowStyle BackColor="#CCCCCC" CssClass="alt" />
                    <Columns>
                        <asp:TemplateField HeaderText="FJCID">
                            <ItemTemplate>
                                <asp:Label ID="lblFJCID" Style="text-align: right" runat="server" Text='<%# Bind("FJCID", "{0:F0}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                        <asp:BoundField DataField="Federation_Name" HeaderText="Program Name" />
                        <asp:TemplateField HeaderText="Grant Amount">
                            <ItemTemplate>
                                <asp:Label ID="lblAmount" Style="text-align: right" runat="server" Text='<%# Bind("Amount") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="FJC Match Amount">
                            <ItemTemplate>
                                <asp:Label ID="lblFJCMatch" Style="text-align: right" runat="server" Text='<%# Bind("FJCMatch") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Incentive" HeaderText="Incentive Last Summer" />
                        <asp:BoundField DataField="Synagogue" HeaderText="Synagogue" />
                        <asp:BoundField DataField="FirstTimeCamper" HeaderText="First Time Camper" />
                        <asp:BoundField DataField="SecondTimeCamper" HeaderText="Second Time Camper" />
                        <asp:BoundField DataField="PJCode" HeaderText="PJ Code" />
                        <asp:BoundField DataField="MiiP_Code" HeaderText="MiiP Code" />
                        <asp:BoundField DataField="Camp_Name" HeaderText="Camp Name" />
                        <asp:BoundField DataField="SessionName" HeaderText="Session Name" />
                        <asp:BoundField DataField="StartDate" HeaderText="Start Date" />
                        <asp:BoundField DataField="EndDate" HeaderText="End Date" />
                        <asp:BoundField DataField="Days" HeaderText="# Days" />
                        <asp:BoundField DataField="CamperFirstName" HeaderText="Camper First Name" />
                        <asp:BoundField DataField="CamperLastName" HeaderText="Camper Last Name" />
                        <asp:TemplateField HeaderText="Date Of Birth">
                            <ItemTemplate>
                                <asp:Label ID="lblDateOfBirth" Style="text-align: right" runat="server" Text='<%# Bind("DateOfBirth") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Age" HeaderText="Age" />
                        <asp:BoundField DataField="Gender" HeaderText="Gender" />
                        <asp:BoundField DataField="Grade" HeaderText="Grade" />
                        <asp:BoundField DataField="SchoolType" HeaderText="School Type" />
                        <asp:BoundField DataField="School" HeaderText="School Name" />
                        <asp:BoundField DataField="Street" HeaderText="Street" />
                        <asp:BoundField DataField="City" HeaderText="City" />
                        <asp:BoundField DataField="State" HeaderText="State" />
                        <asp:BoundField DataField="Zip" HeaderText="Zip" />
                        <asp:BoundField DataField="CamperEmail" HeaderText="Camper Email" />
                        <asp:BoundField DataField="ParentFirstName" HeaderText="Parent First Name" />
                        <asp:BoundField DataField="ParentLastName" HeaderText="Parent Last Name" />
                        <asp:BoundField DataField="ParentPersonalEmail" HeaderText="Parent Personal Email" />
                        <asp:BoundField DataField="ParentWorkEmail" HeaderText="Parent Work Email" />
                        <asp:BoundField DataField="PrimaryPhone" HeaderText="Primary Phone" />
                        <asp:BoundField DataField="ParentHomePhone" HeaderText="Parent Home Phone" />
                        <asp:BoundField DataField="ParentWorkPhone" HeaderText="Parent Work Phone" />
                        <asp:BoundField DataField="Parent2FirstName" HeaderText="Parent 2 First Name" />
                        <asp:BoundField DataField="Parent2LastName" HeaderText="Parent 2 Last Name" />
                        <asp:BoundField DataField="Parent2PersonalEmail" HeaderText="Parent 2 Personal Email" />
                        <asp:BoundField DataField="Parent2WorkEmail" HeaderText="Parent 2 Work Email" />
                        <asp:BoundField DataField="Parent2HomePhone" HeaderText="Parent 2 Home Phone" />
                        <asp:BoundField DataField="Parent2WorkPhone" HeaderText="Parent 2 Work Phone" />
                        <asp:BoundField DataField="LoginEmail" HeaderText="Login Email" />
                        <asp:TemplateField HeaderText="Created Date">
                            <ItemTemplate>
                                <asp:Label ID="lblCreatedDate" Style="text-align: right" runat="server" Text='<%# Bind("CreatedDate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Submit Date">
                            <ItemTemplate>
                                <asp:Label ID="lblSubmitDate" Style="text-align: right" runat="server" Text='<%# Bind("SubmitDate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CampYear" HeaderText="Camp Year" />
                        <asp:BoundField DataField="HeardFromWordOfMouth" HeaderText="Word Of Mouth" />
                        <asp:BoundField DataField="HeardFromJewishOrg" HeaderText="Jewish Org" />
                        <asp:BoundField DataField="HeardFromWebEmail" HeaderText="Web/Email" />
                        <asp:BoundField DataField="HeardFromAd" HeaderText="Ad" />
                        <asp:BoundField DataField="HeardFromCamp" HeaderText="Camp" />
                        <asp:BoundField DataField="HeardFromOther" HeaderText="Other" />
                        <asp:BoundField DataField="MktRefCode" HeaderText="Mkt Ref Code" />
                        <asp:BoundField DataField="SectionIV_Q1" HeaderText="Congregational school affiliation" />
                        <asp:BoundField DataField="SectionIV_Q2" HeaderText="Temple synagogue affiliation" />
                        <asp:BoundField DataField="SectionIV_Q3" HeaderText="Name of synagogue" />
                        <asp:BoundField DataField="SectionIV_Q4" HeaderText="JCC affiliation" />
                        <asp:BoundField DataField="JCC" HeaderText="JCC" />
                        <asp:BoundField DataField="SectionIV_Q5" HeaderText="Two American born parents" />
                        <asp:BoundField DataField="SectionIV_Q6_pg1" HeaderText="Country of Origin Parent 1" />
                        <asp:BoundField DataField="SectionIV_Q6_pg2" HeaderText="Country of Origin Parent 2" />
                        <asp:BoundField DataField="SectionIV_Q7" HeaderText="Two Jewish Parents" />
                        <asp:BoundField DataField="SectionIV_Q8" HeaderText="Aware of Jewish overnight camp before incentive" />
                        <asp:BoundField DataField="SectionIV_Q9" HeaderText="Previously attended Jewish overnight camp" />
                        <asp:BoundField DataField="SectionIV_Q10" HeaderText="Previously attended non-sectarian overnight camp" />
                        <asp:BoundField DataField="SectionIV_Q11" HeaderText="Considered sending to overnight camp before incentive" />
                        <asp:BoundField DataField="SectionIV_Q12" HeaderText="Considered sending to Jewish overnight camp before incentive" />
                        <asp:BoundField DataField="Confirm3" HeaderText="Requested for additional information from the FJC" />
                        <asp:BoundField DataField="MemberOrAlum" HeaderText="MemberOrAlum" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
