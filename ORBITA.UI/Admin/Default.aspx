<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ORBITA.UI.Admin.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="box">
           <h3>Server Parameters</h3>
        <table >
            <thead>
					<tr>
                    	<th colspan="2" align="left"  >Server Information S<span><b>tatistics:</b></span></th>
                    </tr>
				</thead>
				
				<tbody>
					<tr>
                    	<td width="15%" >Server Name</td>
                        <td><%=System.Environment.MachineName%></td>
                    </tr>
                    <tr class="altrow">
                    	<td >Server Port</td>
                        <td><%= HttpContext.Current.Request.ServerVariables["Server_Port"].ToString() %></td>
                    </tr>
                    <tr>
                    	<td >Script Engine</td>
                        <td><%=System.Environment.Version%></td>
                    </tr>
                    <tr class="altrow">
                    	<td >Site Path</td>
                        <td><%=HttpContext.Current.Request.PhysicalApplicationPath.ToString() %></td>
                    </tr>
                    <tr>
                    	<td >CPU Number</td>
                        <td><%=System.Environment.ProcessorCount %></td>
                    </tr>
                    <tr class="altrow">
                    	<td >IIS Version</td>
                        <td><%=Request.ServerVariables["SERVER_SOFTWARE"]%></td>
                    </tr>
                    <tr>
                    	<td >Running Time</td>
                        <td><%=(System.Environment.TickCount/3600000).ToString("N2")%></td>
                    </tr>
                    
                    <tr class="altrow">
                    	<td >Server Time</td>
                        <td><%=DateTime.Now.ToString() %></td>
                    </tr>
                    
                    
                    <tr>
                    	<td >Operation System</td>
                        <td><%=System.Environment.OSVersion.ToString()%></td>
                    </tr>
                    
                 </tbody>
        </table>
    </div>
</asp:Content>
