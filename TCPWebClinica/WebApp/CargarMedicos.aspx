<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CargarMedicos.aspx.cs" Inherits="WebApp.CargarMedicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display:flex; flex-direction:column; margin-top:1em; box-shadow : 0 0 10px black; padding:2em; justify-content:space-around; align-items:center; margin-top: 2em;">
   
    <div id="titulo" style="display:flex;  flex-direction:column; justify-content:space-between; width:100%;  margin-bottom: 2em;">
         <h3>Agregar nuevo Profesional</h3>
    </div>

    <div id="form" style="display:flex; flex-direction:row; justify-content:space-around; width:100%;">

                <div class="col-1" id="columna1" style="width:45%;" >
                   <div class="form-floating mb-3">
                        <asp:TextBox type="text" cssClass="form-control" id="nombre" placeholder="Nombre" required="true" runat="server" />
                        <label for="nombre">Nombre *</label>
                   </div>
        
                    <div class="form-floating mb-3">
                        <asp:TextBox type="text" cssClass="form-control" id="Apellido" placeholder="Apellido" required="true" runat="server" />
                        <label for="Apellido">Apellido *</label>
                   </div>
       
                    <div class="form-floating mb-3" >
                        <asp:TextBox type="text" class="form-control" id="Dni" placeholder="Dni" required="true" runat="server" />
                        <label for="Dni">Dni *</label>
                   </div> 

                   <div id="sexo">
              
                       <asp:RadioButtonList ID="rblist" runat="server" >
                           <asp:ListItem Value="m" cssClass="w3-radio" id="rbtnM" >Masculino</asp:ListItem>
                           <asp:ListItem Value="f" cssClass="w3-radio" id="rbtnF">Femenino</asp:ListItem>
                           <asp:ListItem Value="x" cssClass="w3-radio" id="rbtnX">Otro</asp:ListItem>
                       </asp:RadioButtonList>
                           
                    </div>
                    <div id="especialidad-ls" style="padding-top:20px;">
                        <asp:DropDownList id="ddlEspecialidad" runat="server" class="form-select" aria-label="Default select example" required="true">
                            <asp:ListItem Text="Especialidad *" />
                        </asp:DropDownList>


                     <%-- <select class="form-select" aria-label="Default select example" required>
                        <option selected>Especialidad *</option>
                               <%var id = 0;
                               foreach (var item in Especialidad) { %>                       
                                    <option value="<%: id %>"><%: item.Descripcion %></option>
                                    <%id ++ ;%> 
                               <%} %>
                      </select>--%>
                   </div>
   
               </div>
                <div class="col-2" id="columna2" style="display:flex; flex-direction:column; justify-content:space-around; width:45%;">

                    <div class="form-floating mb-3">
                        <asp:TextBox type="text" ID="email" placeholder="name@example.com" CssClass="form-control" runat="server" />
                        <label for="email">Email</label>
                   </div>

                    <div class="form-floating mb-3">
                        <asp:TextBox type="text" cssClass="form-control" id="codigoPostal" placeholder="Codigo Postal" runat="server" />
                        <label for="codigoPostal">Codigo Postal</label>
                    </div>
                
                     <div class="form-floating mb-3">
                        <asp:TextBox type="text" cssClass="form-control" id="direccion" placeholder="Direccion" runat="server" />
                        <label for="direccion">Direccion</label>
                    </div>
                     <div class="form-floating mb-3">
                        <asp:TextBox type="tel" cssClass="form-control" id="telefono" placeholder="Telefono" runat="server" />
                        <label for="telefono">Telefono</label>
                    </div>

                    
                </div>
         </div>

        <div id="agregar" class="col-3" style="display:flex; justify-content:space-between; width:100%;  margin-top: 2em;">
             <p>(*) Campos obligatorios</p>
             <%--<asp:Button Text="Agregar" cssClass="btn btn-outline-success" ID="Agregar" OnClick="btnAgregar_Click" runat="server" />--%>
        </div>


</div>
</asp:Content>
