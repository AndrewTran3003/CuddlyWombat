#pragma checksum "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Registration\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ecb99969ed9f5a921c2820b5c7e8b142350f199d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Registration_Index), @"mvc.1.0.view", @"/Views/Registration/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ecb99969ed9f5a921c2820b5c7e8b142350f199d", @"/Views/Registration/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce658bd8f1afafa52e3e4103743f9c1be8072474", @"/Views/_ViewImports.cshtml")]
    public class Views_Registration_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CuddlyWombat.Models.SystemUserRegistration>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Registration\Index.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Registration\Index.cshtml"
  

    IEnumerable<SystemUserRole> systemUserRoles = new List<SystemUserRole>
{
        new SystemUserRole
        {
            RoleValue = "Admin",
            DisplayName = "Administrator"
        },
        new SystemUserRole
        {
            RoleValue = "FOH",
            DisplayName = "Front of house"
        },
        new SystemUserRole
        {
            RoleValue = "BOH",
            DisplayName = "Back of house"
        },
        new SystemUserRole
        {
            RoleValue = "AR",
            DisplayName = "All Rounder"
        },
        new SystemUserRole
        {
            RoleValue = "Acc",
            DisplayName = "Accountant"
        },
    };

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<fieldset>\r\n");
#nullable restore
#line 40 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Registration\Index.cshtml"
     using (Html.BeginForm())
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <table>\r\n            <tr>\r\n                <td>\r\n                    <p>\r\n                        ");
#nullable restore
#line 46 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Registration\Index.cshtml"
                   Write(Html.LabelFor(x => x.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </p>\r\n                </td>\r\n\r\n                <td>\r\n                    <p>\r\n                        ");
#nullable restore
#line 52 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Registration\Index.cshtml"
                   Write(Html.TextBoxFor(x => x.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </p>\r\n                </td>\r\n\r\n            </tr>\r\n            <tr>\r\n                <td>\r\n                    <p>\r\n                        ");
#nullable restore
#line 60 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Registration\Index.cshtml"
                   Write(Html.LabelFor(x => x.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </p>\r\n                </td>\r\n\r\n                <td>\r\n                    <p>\r\n                        ");
#nullable restore
#line 66 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Registration\Index.cshtml"
                   Write(Html.PasswordFor(x => x.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </p>\r\n                </td>\r\n\r\n            </tr>\r\n            <tr>\r\n                <td>\r\n                    <p>\r\n                        ");
#nullable restore
#line 74 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Registration\Index.cshtml"
                   Write(Html.LabelFor(x => x.ConfirmPassWord));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </p>\r\n                </td>\r\n\r\n                <td>\r\n                    <p>\r\n                        ");
#nullable restore
#line 80 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Registration\Index.cshtml"
                   Write(Html.PasswordFor(x => x.ConfirmPassWord));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </p>\r\n                </td>\r\n\r\n            </tr>\r\n            <tr>\r\n                <td>\r\n                    <p>\r\n                        ");
#nullable restore
#line 88 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Registration\Index.cshtml"
                   Write(Html.LabelFor(x => x.UserRole));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </p>\r\n                </td>\r\n\r\n                <td>\r\n                    <p>\r\n                        ");
#nullable restore
#line 94 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Registration\Index.cshtml"
                   Write(Html.DropDownListFor(x => x.UserRole, new SelectList(systemUserRoles, "RoleValue", "DisplayName")));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </p>\r\n                </td>\r\n            </tr>\r\n            <tr>\r\n                <td>\r\n                    <button type=\"submit\">Create </button>\r\n                </td>\r\n            </tr>\r\n        </table>\r\n");
#nullable restore
#line 104 "C:\Side Projects\CuddlyWombat\CuddlyWombat\Views\Registration\Index.cshtml"

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</fieldset>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CuddlyWombat.Models.SystemUserRegistration> Html { get; private set; }
    }
}
#pragma warning restore 1591
