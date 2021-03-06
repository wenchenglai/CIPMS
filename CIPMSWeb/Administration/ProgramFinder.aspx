﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="ProgramFinder.aspx.cs" Inherits="Administration_ProgramFinder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>          
            <div style="margin-left: 20px;" class="infotext3">
                <h3>Program Finder</h3>
                <div style="margin-bottom:20px">
                    Select a program: <asp:DropDownList ID="ddlFeds" runat="server" Width="375px" CssClass="text" />
                </div>
                <div style="margin-bottom:20px">
                   Or enter zip code: <asp:TextBox runat="server" ID="txtZipCode" MaxLength="7"></asp:TextBox><span class="infotext2">&nbsp;&nbsp;Program drop down list has higher precedence</span>
                </div>
                <div style="margin-bottom:20px;">
                    <asp:Button runat="server" Text="Find Program" ID="btnFind" OnClick="btnFind_Click"/>
                </div>
                <div>
                    <asp:Label runat="server" ID="lblError" ForeColor="Red"></asp:Label>
                </div>
                <asp:Panel runat="server" ID="pnlResult" Visible="false">
                    <ul style="list-style-type: none;">
                        <li><strong>Program:</strong> <asp:Label runat="server" ID="lblProgram"></asp:Label></li>
                        <li><strong>Contact:</strong> <asp:Label runat="server" ID="lblContact"></asp:Label></li>
                        <li><strong>Email:</strong> <asp:Label runat="server" ID="lblEmail"></asp:Label></li>
                        <li><strong>Phone:</strong> <asp:Label runat="server" ID="lblPhone"></asp:Label></li>
                        <li>
                            <br /><strong>Status:</strong> <asp:Label runat="server" ID="lblStatus"></asp:Label>
                            <br /><asp:Label ID="lbl19Only" runat="server" Visible="false" ForeColor="Red" Text="Eligibility: 19+ ONLY" />
                        </li>
                        <li><br /><strong>Availability:</strong> <asp:Label runat="server" ID="lblAvail"></asp:Label></li>
                        <li><strong>General Processing:</strong> <asp:Label runat="server" ID="lblGeneralProcessing"></asp:Label></li>
                        <li><br /><strong>Offers grants for JDS kids:</strong> <asp:Label runat="server" ID="lblJDS"></asp:Label></li>
                        <li><strong>JDS Processing:</strong> <asp:Label runat="server" ID="lblJDSProcessing"></asp:Label></li>
                        <li><strong>$500 Sibling Grant:</strong> <asp:Label runat="server" ID="lblSibling"></asp:Label></li>
                        <li><strong>Canadian Camps Only:</strong> <asp:Label runat="server" ID="lblCanadianCamps"></asp:Label></li>
                    </ul>
                </asp:Panel>
                <asp:Panel runat="server" ID="pnlEligibility" Visible="false">
                    <div style="margin-top:30px; margin-bottom:10px"><strong>Grant Amount Eligibility Rules</strong></div>
                    <div>
                        <div>First Time Campers</div>
                        <asp:GridView runat="server" ID="gvEli" CssClass="InfoText3">

                        </asp:GridView>
                    </div>
                    <br />
                    <div id="divEli2" runat="server">
                        <div>Second Time Campers</div>
                        <asp:GridView runat="server" ID="gvEli2" CssClass="InfoText3">

                        </asp:GridView>
                    </div>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

