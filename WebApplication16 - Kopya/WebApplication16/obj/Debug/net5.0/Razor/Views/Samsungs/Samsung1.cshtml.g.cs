#pragma checksum "C:\Users\sehen\OneDrive\Masaüstü\WebApplication16 - Kopya\WebApplication16\Views\Samsungs\Samsung1.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8d280922d802f81b7689676e78599dd77dc72f72"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Samsungs_Samsung1), @"mvc.1.0.view", @"/Views/Samsungs/Samsung1.cshtml")]
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
#line 1 "C:\Users\sehen\OneDrive\Masaüstü\WebApplication16 - Kopya\WebApplication16\Views\_ViewImports.cshtml"
using WebApplication16;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\sehen\OneDrive\Masaüstü\WebApplication16 - Kopya\WebApplication16\Views\_ViewImports.cshtml"
using WebApplication16.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d280922d802f81b7689676e78599dd77dc72f72", @"/Views/Samsungs/Samsung1.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b74af06d72a0bdc74080c2bcf2df46290f42bcea", @"/Views/_ViewImports.cshtml")]
    public class Views_Samsungs_Samsung1 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebApplication16.Models.Samsung>>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\sehen\OneDrive\Masaüstü\WebApplication16 - Kopya\WebApplication16\Views\Samsungs\Samsung1.cshtml"
  
    ViewData["Title"] = "Samsung1";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container\">\r\n\r\n    <div class=\"row \">\r\n");
#nullable restore
#line 10 "C:\Users\sehen\OneDrive\Masaüstü\WebApplication16 - Kopya\WebApplication16\Views\Samsungs\Samsung1.cshtml"
         foreach (var item in Model)
        {




#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-lg-4\">\r\n\r\n                <div class=\"card\" style=\"width: 18rem;margin-top:60px\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8d280922d802f81b7689676e78599dd77dc72f724146", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper);
            BeginWriteTagHelperAttribute();
            WriteLiteral("~/image/Samsung/");
#nullable restore
#line 18 "C:\Users\sehen\OneDrive\Masaüstü\WebApplication16 - Kopya\WebApplication16\Views\Samsungs\Samsung1.cshtml"
                                  WriteLiteral(item.imageName);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("src", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 18 "C:\Users\sehen\OneDrive\Masaüstü\WebApplication16 - Kopya\WebApplication16\Views\Samsungs\Samsung1.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    <div class=\"card-body\">\r\n                        <h5 class=\"card-title\"> ");
#nullable restore
#line 20 "C:\Users\sehen\OneDrive\Masaüstü\WebApplication16 - Kopya\WebApplication16\Views\Samsungs\Samsung1.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.SamsungAciklama));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n\r\n                        <a href=\"#\" class=\"btn btn-primary\"> ");
#nullable restore
#line 22 "C:\Users\sehen\OneDrive\Masaüstü\WebApplication16 - Kopya\WebApplication16\Views\Samsungs\Samsung1.cshtml"
                                                        Write(item.SamsungFiyat);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 26 "C:\Users\sehen\OneDrive\Masaüstü\WebApplication16 - Kopya\WebApplication16\Views\Samsungs\Samsung1.cshtml"






        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebApplication16.Models.Samsung>> Html { get; private set; }
    }
}
#pragma warning restore 1591
