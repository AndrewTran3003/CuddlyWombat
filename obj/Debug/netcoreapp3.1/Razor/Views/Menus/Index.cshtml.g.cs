#pragma checksum "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Menus\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0f59b1dfca69f5af78b81dc08276ca2612e0bbda"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Menus_Index), @"mvc.1.0.view", @"/Views/Menus/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0f59b1dfca69f5af78b81dc08276ca2612e0bbda", @"/Views/Menus/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce658bd8f1afafa52e3e4103743f9c1be8072474", @"/Views/_ViewImports.cshtml")]
    public class Views_Menus_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CuddlyWombat.Models.Menu>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Menus\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Menus\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Menus\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Menus\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Menus\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DateCreated));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                Item List\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 34 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Menus\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 37 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Menus\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 40 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Menus\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 43 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Menus\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 46 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Menus\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.DateCreated));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n");
#nullable restore
#line 49 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Menus\Index.cshtml"
                 foreach (var i in item.ItemMenus)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 51 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Menus\Index.cshtml"
               Write(Html.DisplayFor(modelItem => i.Item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n");
#nullable restore
#line 52 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Menus\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </td>\r\n           \r\n        </tr>\r\n");
#nullable restore
#line 56 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Menus\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CuddlyWombat.Models.Menu>> Html { get; private set; }
    }
}
#pragma warning restore 1591
