<%@ Page Title="" Language="C#" MasterPageFile="~/UI/ManagerMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewComplainByManager.aspx.cs" Inherits="ComplainRegistrationSystem.ViewComplainByManager1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 99%;
            height: 154px;
        }
        .auto-style3 {
            width: 426px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" runat="server">
    
    
     <div>
    <script>
        function Check() {

            var z = document.getElementById("contentBody_viewDateTextBox1").value;
            var y = document.getElementById("contentBody_viewDateTextBox2").value;
            if (z.length < 1 || y.length < 1) {
                alert("Please Select the Dates");
                return false;
            }
            return true;

        }

        function CheckField() {

            var z = document.getElementById("contentBody_searchAssisDropDownList0");
            var y = document.getElementById("contentBody_summaryTextBox").value;
            if (y.length < 1) {
                alert("Please fill the remarks text Box!");
                return false;
            }
            if (z[z.selectedIndex].value == "Select") {
                alert("Pls select Any item from dropdown");
                return false;
            }
            return true;
        }
    </script>
         
        

        &nbsp;<br />
         <br />
         <br />
         &nbsp;&nbsp;&nbsp;<asp:Panel ID="Panel3" runat="server" BackColor="#CCCCCC">
             &nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#003300" Text="Search By Category  : "></asp:Label>
             &nbsp;
             <asp:DropDownList ID="searchCatDropDownList0" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#003399" Height="25px" Width="145px"/>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:TextBox ID="viewDateTextBox1" runat="server" Height="20px" style="margin-left: 0px" TextMode="Date" Width="131px"></asp:TextBox>
             &nbsp; To
             <asp:TextBox ID="viewDateTextBox2" runat="server" Height="22px" style="margin-left: 0px" TextMode="Date" Width="129px"></asp:TextBox>
             &nbsp;&nbsp;
             <asp:Button ID="searchDateButton" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#6600CC" Text="Search By Date" Width="144px" OnClick="searchDateButton_Click1" OnClientClick="return Check();" />
             <br />
             <br />
             <br />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:LinkButton ID="Nreq_LinkButton1" runat="server" Font-Size="Medium" OnClick="Nreq_LinkButton1_Click" Font-Bold="True" ForeColor="#003300"  >New Request</asp:LinkButton>
             &nbsp;&nbsp;&nbsp;&nbsp; :&nbsp;<asp:Label ID="NR_L1" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#FF3300"></asp:Label>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:LinkButton ID="pendingReqLinkButton" runat="server" Font-Size="Medium" OnClick="pendingReqLinkButton_Click" Font-Bold="True" ForeColor="#003300"  >Pending Request</asp:LinkButton>
             &nbsp;&nbsp; :&nbsp;&nbsp;
             <asp:Label ID="P_L2" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#FF3300"></asp:Label>
             &nbsp;&nbsp;&nbsp;
             <asp:LinkButton ID="solvedReqLinkButton" runat="server" Font-Size="Medium" OnClick="solvedReqLinkButton_Click" Font-Bold="True" ForeColor="#003300"  >Solved Request</asp:LinkButton>
             &nbsp;&nbsp; :&nbsp;&nbsp;
             <asp:Label ID="S_Ll3" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#FF3300"></asp:Label>
             &nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;<asp:LinkButton ID="cancelReqLinkButton" runat="server" Font-Size="Medium" OnClick="cancelReqLinkButton_Click" Font-Bold="True" ForeColor="#003300" >Cancel Request</asp:LinkButton>
             &nbsp;:&nbsp;
             <asp:Label ID="C_L4" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#FF3300"></asp:Label>
             <br />
             <br />
             &nbsp;&nbsp;&nbsp;
             <br />
             &nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Button ID="viewComplainButton" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#6600CC"  Text="View All Complain" Width="195px" OnClick="viewComplainButton_Click" />
             <br />
         </asp:Panel>
         <br />
         <br />
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
         <br />
         <table __designer:mapid="93" class="auto-style2" id="Table" style="background-color: #FFFFFF">
             <tr __designer:mapid="94">
                 <td id="AllocateTable" __designer:mapid="96" class="auto-style3">&nbsp;<asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#0066FF" Text="Allocate Assistant :" Visible="False"></asp:Label>
                     &nbsp;<asp:DropDownList ID="searchAssisDropDownList0" runat="server" AutoPostBack="True" Font-Bold="True" Font-Size="Medium" ForeColor="#003399" Height="25px" Width="182px" OnSelectedIndexChanged="searchAssisDropDownList0_SelectedIndexChanged1" Visible="False"> 
            </asp:DropDownList>
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <br />
&nbsp;&nbsp;
                     <br />
                     &nbsp;&nbsp;<br />
                     <br />
                     <br />
&nbsp; <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#0066FF" Text="Remarks  :" Visible="False"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="summaryTextBox" runat="server" Height="38px" TextMode="MultiLine" Width="181px" Visible="False"></asp:TextBox>
                     <br />
                     <br />
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <br />
                     <br />
                 </td>
                 <td __designer:mapid="97">
                     <asp:GridView ID="assistantGridView1" runat="server" AutoGenerateColumns="False" Height="148px" Width="467px">
                         <Columns>
                             <asp:BoundField DataField="AssistantID" HeaderText="Assistant ID" />
                             <asp:BoundField DataField="ContactNo" HeaderText="Contact No" />
                             <asp:BoundField DataField="SolvingReq" HeaderText="No Of Solved Request" />
                             <asp:BoundField DataField="PendingReq" HeaderText="No of Pending Request" />
                         </Columns>
                     </asp:GridView>
                     <br />
&nbsp;</td>
             </tr>
         </table>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
        <asp:Label ID="Please_Select_Label7" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#993399"></asp:Label>
        <br />
        <br />
        <asp:Panel ID="Panel2" runat="server" Height="451px" BackColor="White">
            <asp:GridView ID="complainGridView1" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" Height="254px"  PageSize="5" Width="617px" AllowPaging="True" OnPageIndexChanging="complainGridView1_PageIndexChanging" OnSelectedIndexChanging="complainGridView1_SelectedIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="Complain ID">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ComplainID") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("ComplainID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="PersonName" HeaderText="Person Name" />
                    <asp:BoundField DataField="HostelNo" HeaderText="Hostel No" />
                    <asp:BoundField DataField="RoomNo" HeaderText="Room No" />
                    <asp:TemplateField HeaderText="Category">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Category") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Subject" HeaderText="Subject" />
                    <asp:BoundField DataField="Summary" HeaderText="Summary" />
                    <asp:BoundField DataField="Priority" HeaderText="Priority" />
                    <asp:BoundField DataField="DateOfComplain" HeaderText="Date Of Complain" />
                    <asp:BoundField DataField="Status" HeaderText="Status" />
                    <asp:BoundField DataField="ContactNo" HeaderText="Contact No" />
                    <asp:BoundField DataField="AssistantName" HeaderText="Assistant Name" />
                    <asp:TemplateField HeaderText="Details" ShowHeader="False">
                        <ItemTemplate>
                            &nbsp;&nbsp;
                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                            &nbsp;
                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Select" Text="more" OnClick="LinkButton2_Click"></asp:LinkButton>
                            &nbsp;
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="AssistantContact" HeaderText="Assistant Contact" />
                    <asp:TemplateField HeaderText="Select Row">
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <RowStyle BackColor="White" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="allocateButton" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#3333CC" OnClick="allocateButton_Click1" Text="Allocate Assistant" OnClientClick="return CheckField();" Visible="False"/>
            &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="solvedButton" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#6600CC"  Text=" Solved The Request" OnClick="solvedButton_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="CancelButton" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#6600CC"  Text="Cancel  The Request" OnClick="CancelButton_Click" />
        </asp:Panel>
        <br />
        &nbsp;&nbsp;&nbsp;
         <asp:Panel ID="RemarksViewPanel3" runat="server" Height="98px" Visible="False" BackColor="White">
             &nbsp;
             <br />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Label ID="remarkLabel" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#0066FF" Text="Remarks View All :"></asp:Label>
             &nbsp;&nbsp;&nbsp;&nbsp;
             <asp:TextBox ID="ViewRemarksTextBox3" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#003399" Height="49px" TextMode="MultiLine" Width="306px" ReadOnly="True" ></asp:TextBox>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Button ID="EditRemarksButton2" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="#3366CC" Text="Edit" Width="120px" OnClick="NewRemarksButton1_Click" />
         </asp:Panel>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
         <asp:Panel ID="EditRemPanel4" runat="server" Visible="False" BackColor="White">
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <br />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:TextBox ID="EditRemarksTextBox4" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#003399" Height="46px" TextMode="MultiLine" Width="298px" ></asp:TextBox>
             <br />
             <br />
             &nbsp;
             <br />
             <br />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Button ID="NewRemarksButton1" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="#3366CC" Text="New Remarks" Width="120px" OnClick="NewRemarksButton1_Click1" />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         </asp:Panel>
         <br />
         <br />
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <br />
        <br />
        <br />
    
    </div>
</asp:Content>
