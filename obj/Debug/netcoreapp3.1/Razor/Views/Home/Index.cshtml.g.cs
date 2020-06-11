#pragma checksum "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9216891330b82ba309ee540ac301dc7bb62fb633"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9216891330b82ba309ee540ac301dc7bb62fb633", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce658bd8f1afafa52e3e4103743f9c1be8072474", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CuddlyWombat.ViewModel.HomeViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 8 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Home\Index.cshtml"
 if (@User.Identity.IsAuthenticated)
{


#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"text-center\">\r\n        <h1 class=\"display-4\">Welcome</h1>\r\n\r\n        <h1>Helllo ");
#nullable restore
#line 14 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Home\Index.cshtml"
              Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n    </div>\r\n");
#nullable restore
#line 19 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Home\Index.cshtml"
     if (User.IsInRole("FOH") || User.IsInRole("BOH") || User.IsInRole("AR"))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""modal fade"" id=""GOAOne"" tabindex=""-1"" role=""dialog"" aria-hidden=""true"">
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


                        <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                    </div>
                </div>
            </div>
        </div>
        <div class=""modal fade"" id=""GOAMany"" tabindex=""-1"" role=""dialog"" aria-hidden=""tru");
            WriteLiteral(@"e"">
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
                        <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                    </div>
                </div>
            </div>
        </div>
        <script>
    var IsGOAOneShown = false;
    var IsGOAManyShown = false;

    function AnyOverdueOrder() {
        var url = '");
#nullable restore
#line 64 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Home\Index.cshtml"
              Write(Url.Action("AnyOverdueOrder", "GOAs"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';
        $.get(url, function (response) {
            if (response == ""OneOverdue"") {
                if (IsGOAOneShown == false) {
                    $(""#GOAOne"").modal();
                    IsGOAOneShown = true;
                }
            }
            else if (response == ""MultipleOverdue"") {
                if (IsGOAManyShown == false) {
                    $(""#GOAMany"").modal();
                    IsGOAManyShown = true;
                }

            }
        });

    }
    $(document).ready(function () {
        // Handler for .ready() called.
        setInterval(AnyOverdueOrder, 5000);
    });

        </script>
");
#nullable restore
#line 88 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Home\Index.cshtml"


    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 90 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Home\Index.cshtml"
     

    if (@User.IsInRole("Admin"))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h1>This Man is an Admin</h1>\r\n");
#nullable restore
#line 95 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Home\Index.cshtml"
    }
    if (@User.IsInRole("FOH"))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h1>This Man is the Front of House guy</h1>\r\n");
#nullable restore
#line 99 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Home\Index.cshtml"
    }
    if (@User.IsInRole("BOH"))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h1>This Man is the Back of House guy</h1>\r\n");
#nullable restore
#line 103 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Home\Index.cshtml"
    }
    if (@User.IsInRole("AR"))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h1>This Man is the All Rounder guy</h1>\r\n");
#nullable restore
#line 107 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Home\Index.cshtml"
    }
    if (@User.IsInRole("Acc"))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h1>This Man is an Accountant</h1>\r\n");
#nullable restore
#line 111 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Home\Index.cshtml"
    }

}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <h1> Welcome to Cuddly Wombat</h1>
    <h2>Today's menu</h2>
    <table class=""table"">
        <thead>
            <tr>



                <th>
                    Name
                </th>
                <th>
                    Description
                </th>
                <th>
                    Price
                </th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 136 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Home\Index.cshtml"
             foreach (var item in Model.Items)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n\r\n                    <td>\r\n                        ");
#nullable restore
#line 141 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Home\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 144 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Home\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 147 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Home\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 150 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Home\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </tbody>
    </table>
    <h2>Special Set!</h2>
    <table class=""table"">
        <thead>
            <tr>
                <th>
                    Name
                </th>
                <th>
                    Description
                </th>
                <th>
                    Item List
                </th>
                <th>
                    Price
                </th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 172 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Home\Index.cshtml"
             foreach (var menu in Model.Menus)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 176 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Home\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => menu.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 179 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Home\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => menu.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");
#nullable restore
#line 182 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Home\Index.cshtml"
                         foreach (var i in menu.ItemMenus)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 184 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Home\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => i.Item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n");
#nullable restore
#line 185 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Home\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 188 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Home\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => menu.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                    </td>\r\n\r\n                </tr>\r\n");
#nullable restore
#line 193 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Home\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 196 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Home\Index.cshtml"


}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CuddlyWombat.ViewModel.HomeViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
