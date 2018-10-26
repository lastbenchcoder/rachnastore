<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_onlineusers.ascx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.uc._onlineusers" %>

<div class="subnav-title">
    <a href="#" class='toggle-subnav'>
        <i class="fa fa-angle-down"></i>
        <span>Users Online</span>
    </a>
</div>
<ul class="subnav-menu">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <%
                if (HttpRuntime.Cache["LoggedInUsers"] != null)
                {
                    var loggedOnUsers = HttpRuntime.Cache["LoggedInUsers"] as Dictionary<string, DateTime>;
                    if (loggedOnUsers != null)
                    {
                        foreach (var item in loggedOnUsers)
                        {
            %>
            <li>
                <%if (item.Key.Length > 17)
                    { %>
                <span style="margin-left: 10px">
                    <img src="../../Content/loginuser.png" width="15" style="margin-right: 10px" /><%=item.Key.Substring(0,17) %>...</span>
                <%}
                    else
                    { %>
                <span style="margin-left: 10px">
                    <img src="../../Content/loginuser.png" width="15" style="margin-right: 10px" /><%=item.Key %></span>
                <%} %>
            </li>
            <%
                        }
                    }
                }

            %>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:Timer ID="Timer1" runat="server" Interval="5000" OnTick="Timer1_Tick"></asp:Timer>
</ul>
