<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TriangleTest.aspx.cs" Inherits="TriangleTestClient.TriangleTest" %>

<link href="Content/bootstrap.min.css" rel="stylesheet" />

<div class="container border border-primary p-4">
    <form id="form1" runat="server">
        <div class="mt-4">
            <h1>Triangle side lengths</h1>
            <div class="form-group col-6">
                <asp:Label ID="LabelA" runat="server" Text="A" for="A"></asp:Label>
                <asp:TextBox ID="A" runat="server" type="number" class="form-control"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidatorA" runat="server"
                    ErrorMessage="A is required" ForeColor="Red"
                    ControlToValidate="A" Display="Dynamic">
                </asp:RequiredFieldValidator>
                <asp:CustomValidator ID="CustomValidatorA" runat="server"
                    ForeColor="Red"
                    ErrorMessage="Enter number greater than 0"
                    ControlToValidate="A" OnServerValidate="CustomValidator_ServerValidate">
                </asp:CustomValidator>               
            </div>
            <div class="form-group col-6">
                <asp:Label ID="LabelB" runat="server" Text="B" for="B"></asp:Label>
                <asp:TextBox ID="B" runat="server" type="number" class="form-control"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidatorB" runat="server"
                    ErrorMessage="B is required" ForeColor="Red"
                    ControlToValidate="B" Display="Dynamic">
                </asp:RequiredFieldValidator>
                <asp:CustomValidator ID="CustomValidatorB" runat="server"
                    ForeColor="Red"
                    ErrorMessage="Enter number greater than 0"
                    ControlToValidate="B" OnServerValidate="CustomValidator_ServerValidate">
                </asp:CustomValidator> 
            </div>
            <div class="form-group col-6">
                <asp:Label ID="LabelC" runat="server" Text="C" for="C"></asp:Label>
                <asp:TextBox ID="C" runat="server" type="number" class="form-control"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidatorC" runat="server"
                    ErrorMessage="C is required" ForeColor="Red"
                    ControlToValidate="C" Display="Dynamic">
                </asp:RequiredFieldValidator>
                <asp:CustomValidator ID="CustomValidatorC" runat="server"
                    ForeColor="Red"
                    ErrorMessage="Enter number greater than 0"
                    ControlToValidate="C" OnServerValidate="CustomValidator_ServerValidate">
                </asp:CustomValidator> 
            </div>
        </div>
        <asp:Button ID="BtnTriangleType" runat="server" OnClick="BtnTriangleType_Click" Text="CheckTriangleType" class="btn btn-success" />
        <hr />
        <div class="h2">
            <asp:Literal ID="Output" runat="server"></asp:Literal>
        </div>
    </form>
</div>


