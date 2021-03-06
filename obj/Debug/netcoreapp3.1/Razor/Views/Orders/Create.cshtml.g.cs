#pragma checksum "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2427d44f5e15f3fc2bd8cc4c98c6a75b770dd21f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Orders_Create), @"mvc.1.0.view", @"/Views/Orders/Create.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\_ViewImports.cshtml"
using CuddlyWombat;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\_ViewImports.cshtml"
using CuddlyWombat.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2427d44f5e15f3fc2bd8cc4c98c6a75b770dd21f", @"/Views/Orders/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce658bd8f1afafa52e3e4103743f9c1be8072474", @"/Views/_ViewImports.cshtml")]
    public class Views_Orders_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CuddlyWombat.ViewModel.OrderViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
  
    ViewData["Title"] = "Create";
    int itemCounter = 0;
    int menuCounter = 0;
    double TotalPrice = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    .option-button {
        height: 100%;
    }

    .media-object {
        margin-top: 10px;
        margin-bottom: 10px
    }

    .mainMenu {
        margin: auto;
    }
</style>
<script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js""></script>

<div class=""row mainMenu"">

    <div class=""col"">
        <h2>Order detail</h2>
        <table class=""container"">
            <tr class=""row"">
                <td class=""col-3"">
                    <p>
                        ");
#nullable restore
#line 33 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
                   Write(Html.LabelFor(x => x.Order.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </p>\r\n                </td>\r\n\r\n                <td class=\"col-8\">\r\n                    <p>\r\n                        ");
#nullable restore
#line 39 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
                   Write(Html.TextBoxFor(x => x.Order.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </p>\r\n                </td>\r\n            </tr>\r\n            <tr class=\"row\">\r\n                <td class=\"col-3\">\r\n                    <p>\r\n                        ");
#nullable restore
#line 46 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
                   Write(Html.LabelFor(x => x.Order.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </p>\r\n                </td>\r\n\r\n                <td class=\"col-8\">\r\n                    <p>\r\n                        ");
#nullable restore
#line 52 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
                   Write(Html.TextBoxFor(x => x.Order.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </p>\r\n                </td>\r\n\r\n            </tr>\r\n            <tr class=\"row\">\r\n                <td class=\"col-3\">\r\n                    <p>\r\n                        ");
#nullable restore
#line 60 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
                   Write(Html.LabelFor(x => x.Order.CustomerName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </p>\r\n                </td>\r\n\r\n                <td class=\"col-8\">\r\n                    <p>\r\n                        ");
#nullable restore
#line 66 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
                   Write(Html.TextBoxFor(x => x.Order.CustomerName));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </p>
                </td>

            </tr>

        </table>

        <table class=""container"">
            <thead>
                <tr class=""row col-12 table-active"">
                    <th class=""col-4"">
                        <p>Item</p>
                    </th>
                    <th class=""col-1"">
                        <p>Qty</p>
                    </th>
                    <th class=""col-3"">
                        <p>Price per unit</p>
                    </th>
                    <th class=""col-2"">
                        <p>Price</p>
                    </th>

                    <th class=""col-1"">

                    </th>

                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 97 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
                  
                    if (Nullable.Equals(Model.Order.OrderItems, null) == false ||
                        Model.Order.OrderItems.Count > 0)
                    {
                        foreach (var item in Model.Order.OrderItems)
                        {
                            if (item.ItemsSold > 0)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr class=\"table-primary row col-12\">\r\n                                    <th scope=\"row\" class=\"col-4\">\r\n                                        ");
#nullable restore
#line 107 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </th>\r\n\r\n                                    <td class=\"col-1\">\r\n                                        ");
#nullable restore
#line 111 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.ItemsSold));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td class=\"col-3\">\r\n                                        ");
#nullable restore
#line 114 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Item.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td class=\"col-2\">\r\n");
#nullable restore
#line 117 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
                                          
                                            double totalItemPrice = item.ItemsSold * item.Item.Price;
                                            TotalPrice += totalItemPrice;
                                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        ");
#nullable restore
#line 121 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
                                   Write(totalItemPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n\r\n                                    <td class=\"col-1\">\r\n                                        <button type=\"button\" class=\"btn btn-danger\"");
            BeginWriteAttribute("onclick", " onclick=\"", 4064, "\"", 4139, 6);
            WriteAttributeValue("", 4074, "AddOneBackToAvailableList(\'", 4074, 27, true);
#nullable restore
#line 125 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
WriteAttributeValue("", 4101, item.ItemID, 4101, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4113, "\',", 4113, 2, true);
            WriteAttributeValue(" ", 4115, "\'", 4116, 2, true);
#nullable restore
#line 125 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
WriteAttributeValue("", 4117, item.OrderID, 4117, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4130, "\',\'Item\')", 4130, 9, true);
            EndWriteAttribute();
            WriteLiteral(">Remove</button>\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 128 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"

                            }

                        }
                    }


                

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 137 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
                  
                    if (Nullable.Equals(Model.Order.OrderMenus, null) == false ||
                        Model.Order.OrderMenus.Count > 0)
                    {
                        foreach (var menu in Model.Order.OrderMenus)
                        {
                            if (menu.MenusSold > 0)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr class=\"table-success row col-12\">\r\n                                    <th scope=\"row\" class=\"col-4\">\r\n                                        ");
#nullable restore
#line 147 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
                                   Write(Html.DisplayFor(modelItem => menu.Menu.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </th>\r\n                                    <td class=\"col-1\">\r\n                                        ");
#nullable restore
#line 150 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
                                   Write(Html.DisplayFor(modelItem => menu.MenusSold));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td class=\"col-3\">\r\n                                        ");
#nullable restore
#line 153 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
                                   Write(Html.DisplayFor(modelItem => menu.Menu.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td class=\"col-2\">\r\n");
#nullable restore
#line 156 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
                                          
                                            double totalMenuPrice = menu.MenusSold * menu.Menu.Price;
                                            TotalPrice += totalMenuPrice;
                                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        ");
#nullable restore
#line 160 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
                                   Write(totalMenuPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td class=\"col-1\">\r\n                                        <button type=\"button\" class=\"btn btn-danger\"");
            BeginWriteAttribute("onclick", " onclick=\"", 5919, "\"", 5994, 6);
            WriteAttributeValue("", 5929, "AddOneBackToAvailableList(\'", 5929, 27, true);
#nullable restore
#line 163 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
WriteAttributeValue("", 5956, menu.MenuID, 5956, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5968, "\',", 5968, 2, true);
            WriteAttributeValue(" ", 5970, "\'", 5971, 2, true);
#nullable restore
#line 163 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
WriteAttributeValue("", 5972, menu.OrderID, 5972, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5985, "\',\'Menu\')", 5985, 9, true);
            EndWriteAttribute();
            WriteLiteral(">Remove</button>\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 166 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
                            }

                        }
                    }


                

#line default
#line hidden
#nullable disable
#nullable restore
#line 173 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
                  
                    int checkIfExist = 0;
                    foreach (OrderJMenu om in Model.Order.OrderMenus)
                    {
                        if (om.MenusSold > 0)
                        {
                            checkIfExist++;
                        }

                    }
                    foreach (OrderJItem oi in Model.Order.OrderItems)
                    {
                        if (oi.ItemsSold > 0)
                        {
                            checkIfExist++;
                        }
                    }
                    if (checkIfExist > 0)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <tr class=""row"">
                            <td class=""col-7"">
                                Total Price
                            </td>
                            <th class=""col-5"" scope=""row"">
                                ");
#nullable restore
#line 197 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
                           Write(TotalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </th>
                        </tr>
                        <tr class=""row"">
                            <td class=""col"">
                                <button type=""button"" class=""btn btn-warning"" onclick=""CompleteOrder('Pending','Takeaway')"">Pay Later</button>
                            </td>
                            <td class=""col"">
                                <button type=""button"" class=""btn btn-info"" onclick=""CompleteOrder('Pending','Dinein')"">Pay Now</button>
                            </td>
                        </tr>
");
#nullable restore
#line 208 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"

                    }
                

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n            </tbody>\r\n        </table>\r\n\r\n\r\n\r\n    </div>\r\n\r\n    <div class=\"col\">\r\n        <div>\r\n            <h2>Available Items</h2>\r\n            <div>\r\n                <div>\r\n                    <div class=\"row media-object\">\r\n");
#nullable restore
#line 229 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
                         foreach (var item in Model.Items)
                        {
                            if (itemCounter != 0 && itemCounter % 4 == 0)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            WriteLiteral("</div>\r\n                            ");
            WriteLiteral("<div class=\"row media-object\">\r\n");
#nullable restore
#line 235 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"col-md-3 button-clicked\"");
            BeginWriteAttribute("onclick", " onclick=\"", 8387, "\"", 8464, 7);
            WriteAttributeValue("", 8397, "SubtractOneFromAvailableList(\'", 8397, 30, true);
#nullable restore
#line 236 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
WriteAttributeValue("", 8427, item.ID, 8427, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 8435, "\',", 8435, 2, true);
            WriteAttributeValue(" ", 8437, "\'", 8438, 2, true);
#nullable restore
#line 236 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
WriteAttributeValue("", 8439, Model.Order.ID, 8439, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 8454, "\',\'Item\')", 8454, 9, true);
            WriteAttributeValue(" ", 8463, "", 8464, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <button type=\"button\" class=\"btn btn-primary btn-block option-button\">\r\n                                    ");
#nullable restore
#line 238 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral(":\r\n                                    ");
#nullable restore
#line 239 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("$\r\n                                </button>\r\n                            </div>\r\n");
#nullable restore
#line 242 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
                            itemCounter++;
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n\r\n                </div>\r\n\r\n            </div>\r\n        </div>\r\n        <div>\r\n            <h2>Available Menus</h2>\r\n            <div>\r\n                <div>\r\n                    <div class=\"row media-object\">\r\n");
#nullable restore
#line 255 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
                         foreach (var menu in Model.Menus)
                        {
                            if (menuCounter != 0 && menuCounter % 4 == 0)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            WriteLiteral("</div>\r\n                            ");
            WriteLiteral("<div class=\"row media-object\">\r\n");
#nullable restore
#line 261 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"col-md-3 button-clicked\">\r\n                                <button type=\"button\" class=\"btn btn-success btn-block option-button\"");
            BeginWriteAttribute("onclick", " onclick=\"", 9612, "\"", 9688, 6);
            WriteAttributeValue("", 9622, "SubtractOneFromAvailableList(\'", 9622, 30, true);
#nullable restore
#line 263 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
WriteAttributeValue("", 9652, menu.ID, 9652, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 9660, "\',", 9660, 2, true);
            WriteAttributeValue(" ", 9662, "\'", 9663, 2, true);
#nullable restore
#line 263 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
WriteAttributeValue("", 9664, Model.Order.ID, 9664, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 9679, "\',\'Menu\')", 9679, 9, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    ");
#nullable restore
#line 264 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
                               Write(Html.DisplayFor(modelItem => menu.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral(":\r\n                                    ");
#nullable restore
#line 265 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
                               Write(Html.DisplayFor(modelItem => menu.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("$\r\n                                </button>\r\n                            </div>\r\n");
#nullable restore
#line 268 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
                            menuCounter++;
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </div>

                </div>

            </div>
        </div>

        <div class=""modal fade"" id=""GOAOne"" tabindex=""-1"" role=""dialog"" aria-hidden=""true"">
            <div class=""modal-dialog"" role=""document"">
                <div class=""modal-content"">
                    <div class=""modal-header"">
                        <h5 class=""modal-title"">Alert</h5>
                        <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                            <span aria-hidden=""true"">&times;</span>
                        </button>
                    </div>
                    <div class=""modal-body"">
                        <p>Someone is waiting longer than he should be</p>
                    </div>
                    <div class=""modal-footer"">

                        <button type=""button"" class=""btn btn-warning"" onclick=""RedirectToGOA()"">Go to GOA</button>
                        <button type=""button"" class=""btn btn-secondary"" data-d");
            WriteLiteral(@"ismiss=""modal"">Close</button>
                    </div>
                </div>
            </div>
        </div>
        <div class=""modal fade"" id=""GOAMany"" tabindex=""-1"" role=""dialog"" aria-hidden=""true"">
            <div class=""modal-dialog"" role=""document"">
                <div class=""modal-content"">
                    <div class=""modal-header"">
                        <h5 class=""modal-title"">Alert</h5>
                        <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                            <span aria-hidden=""true"">&times;</span>
                        </button>
                    </div>
                    <div class=""modal-body"">
                        <p> More than two people are waiting longer than they should be</p>
                    </div>
                    <div class=""modal-footer"">
                        <button type=""button"" class=""btn btn-warning"" onclick=""RedirectToGOA()"">Go to GOA</button>
                        <button type=");
            WriteLiteral(@"""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                    </div>
                </div>
            </div>
        </div>

    </div>
</div>



<script>
    function SubtractOneFromAvailableList(id,orderID,type )
    {
        var url = """);
#nullable restore
#line 325 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
              Write(Url.Action("SubtractOneFromAvailableList", "Orders"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""";
        var customerName = $(""#Order_CustomerName"").val();
        var description = $(""#Order_Description"").val();
        var name = $(""#Order_Name"").val();
        var data =
        {
            OrderID: orderID,
            ID: id,
            Type: type,
            CustomerName: customerName,
            Description: description,
            Name : name

        };
        console.log(orderID);
        $.post(url, data, function (response) {

            var orderID = response.order.id;
            var url = ""/Orders/Create?orderID="" + orderID;
            window.location.replace(url);
        });
    }
    function AddOneBackToAvailableList(id,orderID,type )
    {
        var url = """);
#nullable restore
#line 349 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
              Write(Url.Action("AddOneBackToAvailableList", "Orders"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""";
        var customerName = $(""#Order_CustomerName"").val();
        var description = $(""#Order_Description"").val();
        var name = $(""#Order_Name"").val();
        var data =
        {
            OrderID: orderID,
            ID: id,
            Type: type,
            CustomerName: customerName,
            Description: description,
            Name : name
        };
        console.log(orderID);
        $.post(url, data, function (response) {

            var orderID = response.order.id;
            var url = ""/Orders/Create?orderID="" + orderID;
            window.location.replace(url);
        });
    }
    function CompleteOrder(status,orderType) {
        var url = """);
#nullable restore
#line 371 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
              Write(Url.Action("CompleteOrder", "Orders"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\";\r\n        var customerName = $(\"#Order_CustomerName\").val();\r\n        var description = $(\"#Order_Description\").val();\r\n        var name = $(\"#Order_Name\").val();\r\n        var data =\r\n        {\r\n            OrderID: \'");
#nullable restore
#line 377 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
                 Write(Model.Order.ID.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
            Status: status,
            Name: name,
            CustomerName: customerName,
            OrderType: orderType,
            Description: description
        };
        $.post(url, data, function (response) {
            if (response == ""TakeNewOrder"") {
                var url = ""/Orders/Create"";
                window.location.replace(url);
            }
            else if (response == ""GoToPayment"") {
                var url = """);
#nullable restore
#line 390 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
                      Write(Url.Action("Index", "Payments"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\";\r\n                url = url + \"?orderId=\" + \"");
#nullable restore
#line 391 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
                                      Write(Model.Order.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""";
                window.location.replace(url);

            }
            else {
                alert(""Internal Server Problem. Try again later"");
            }

        });
    }

  
    var IsGOAOneShown = false;
    var IsGOAManyShown = false;

    function AnyOverdueOrder() {
        var url = '");
#nullable restore
#line 407 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
              Write(Url.Action("AnyOverdueOrder", "GOAs"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n        $.get(url);\r\n\r\n    }\r\n    function RedirectToGOA() {\r\n        var url = \'");
#nullable restore
#line 412 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
              Write(Url.Action("Index","GOAs"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n        window.location.replace(url);\r\n\r\n    }\r\n    $(document).ready(function () {\r\n        // Handler for .ready() called.\r\n        setInterval(AnyOverdueOrder, 5000);\r\n    });\r\n\r\n\r\n\r\n</script>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 426 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Orders\Create.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
            WriteLiteral("\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CuddlyWombat.ViewModel.OrderViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
