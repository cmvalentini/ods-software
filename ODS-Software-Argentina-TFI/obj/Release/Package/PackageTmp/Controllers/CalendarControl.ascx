<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CalendarControl.ascx.cs" Inherits="ODS_Software_Argentina_TFI.Controllers.CalendarControl" %>
<asp:Label ID="lblError" CssClass="text-danger" runat="server" Text=""></asp:Label>
<div class="row">
    <div class="col-sm-5">
        <asp:Label ID="lblDesde" CssClass="col-form-label col-md-3 col-sm-3 label-align" runat="server" Text="Desde:"></asp:Label>
        <asp:TextBox ID="tbDesde" runat="server" CssClass="col-sm-7 form-control" ReadOnly="true"></asp:TextBox>
        <asp:ImageButton ID="ibDesde" CssClass="col-sm-2" runat="server" ImageUrl="~/Images/Calendar.png" OnClick="ibDesde_Click" Height="31px" Width="24px" />
      <asp:Calendar ID="CalDesde" runat="server" BackColor="White" BorderColor="#49a128" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#5bbd00" Height="200px" Width="220px" OnSelectionChanged="CalDesde_SelectionChanged">
            <DayHeaderStyle BackColor="#84ff99" ForeColor="#336666" Height="1px" />
            <NextPrevStyle Font-Size="8pt" ForeColor="#336666" />
            <OtherMonthDayStyle ForeColor="#2da900" />
            <SelectedDayStyle BackColor="#2da900" Font-Bold="True" ForeColor="#2da900" />
            <SelectorStyle BackColor="#2da900" ForeColor="#336666" />
            <TitleStyle BackColor="#003399" BorderColor="#2da900" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
            <WeekendDayStyle BackColor="#CCCCFF" />
        </asp:Calendar>
    </div>
    <div class="col-sm-5">
        <asp:Label ID="lblHasta" CssClass="col-form-label col-md-3 col-sm-3 label-align" runat="server" Text="Hasta:"></asp:Label>
        <asp:TextBox ID="tbHasta" runat="server" CssClass="col-sm-7 form-control" ReadOnly="true"></asp:TextBox>
        <asp:ImageButton ID="ibHasta" CssClass="col-sm-2" runat="server" ImageUrl="~/images/calendar.png" OnClick="ibHasta_Click" Height="30px" Width="29px" />
        <asp:Calendar ID="CalHasta" runat="server" BackColor="White" BorderColor="#49a128" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#5bbd00" Height="200px" Width="220px" OnSelectionChanged="CalHasta_SelectionChanged">
            <DayHeaderStyle BackColor="#84ff99" ForeColor="#336666" Height="1px" />
            <NextPrevStyle Font-Size="8pt" ForeColor="#336666" />
            <OtherMonthDayStyle ForeColor="#2da900" />
            <SelectedDayStyle BackColor="#2da900" Font-Bold="True" ForeColor="#2da900" />
            <SelectorStyle BackColor="#2da900" ForeColor="#336666" />
            <TitleStyle BackColor="#003399" BorderColor="#2da900" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
            <WeekendDayStyle BackColor="#CCCCFF" />
        </asp:Calendar>
    </div>
</div>
<br />
<div class="row">
    <div class="col-sm-5">
        <asp:Label ID="lblUser" CssClass="col-form-label col-md-3 col-sm-3 label-align" runat="server" Text="Usuario:"></asp:Label>
        <asp:DropDownList ID="DropUsuario" CssClass="form-control col-sm-9" runat="server">
             <asp:ListItem Selected="True" Text="Todos" />
        </asp:DropDownList>
    </div>
    <div class="col-sm-5">
        <asp:Label ID="lblCriticidad" CssClass="col-form-label col-md-3 col-sm-3 label-align" runat="server" Text="Criticidad:"></asp:Label>
        <asp:DropDownList ID="DropCriticidad" CssClass="form-control col-sm-9" runat="server">
            <asp:ListItem Selected="True" Text="Todas" />
            <asp:ListItem Text="Critico" />
            <asp:ListItem Text="Muy Alta" />
            <asp:ListItem Text="Alta" />
            <asp:ListItem Text="Medio" />
            <asp:ListItem Text="Bajo" />
        </asp:DropDownList>
    </div>
</div>