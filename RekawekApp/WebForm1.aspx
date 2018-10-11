<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="RekawekApp.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Konrad Rekawek</title>
         <meta charset="utf-8"/>

   <meta name="viewport" content="width=device-width, initial-scale=1"/>

   <link rel="stylesheet" href="/content/bootstrap.min.css"/>

   <script src="/Scripts/bootstrap.min.js"></script>

   <link rel="stylesheet" href="/content/bootstrap-theme.min.css"/>
   
</head>
<body>
    
     <div class="container body-content">
    <form id="form1" runat="server" class="col-sm-12">
    <div class="col-md-12">
     <asp:GridView ID="GridView1" runat="server" CssClass="table-striped table-hover col-sm-12" >
         <HeaderStyle CssClass="thead-dark" />
        </asp:GridView>
    </div>
       
       <br />
        
        
        <div class="form-group row">
            <label for="TB_Id1" class="col-sm-3 col-form-label">Id:</label>
            <asp:TextBox ID="TB_Id" runat="server" MaxLength="6" type="text" CssClass="col-sm-8"></asp:TextBox>
            </div>
        <div class="form-group row">
            <label for="TB_Imie" class="col-sm-3 col-form-label">Imię:</label>
            <asp:TextBox ID="TB_Imie" runat="server" MaxLength="20" CssClass="col-sm-8"></asp:TextBox>
            </div>
        <div class="form-group row">
            <label for="TB_Nazwisko" class="col-sm-3 col-form-label">Nazwisko:</label>
            <asp:TextBox ID="TB_Nazwisko" runat="server" MaxLength="30" CssClass="col-sm-8"></asp:TextBox>
            </div>
        <div class="form-group row">
            <label for="TB_NrAlbumu" class="col-sm-3 col-form-label">Numer albumu:</label>
            <asp:TextBox ID="TB_NrAlbumu" runat="server" MaxLength="6" CssClass="col-sm-8" ></asp:TextBox>
        </div>
        
         <asp:Button ID="BTN_WczytajStudenta" runat="server" OnClick="BTN_WczytajStudenta_Click" Text="Wczytaj" CssClass="btn btn-primary col-sm-3"/></span>
        <asp:Button ID="BTN_Wstaw" runat="server" OnClick="BTN_Wstaw_Click" Text="Wstaw" CssClass="btn btn-primary col-sm-3" /></span>
        <asp:Button ID="Btn_Modyfikuj" runat="server" OnClick="Btn_Modyfikuj_Click" Text="Modyfikuj" CssClass="btn btn-primary col-sm-3" /></span>
         <asp:Button ID="Btn_usun" runat="server" OnClick="Btn_usun_Click" Text="Usuń" CssClass="btn btn-danger col-sm-2" /></span>
        
    </form>

   </div>
</body>
</html>
