#pragma checksum "H:\MVC project\Asp.net-MVC-project\MVCFirstDemo\MVCFirstDemo\Views\Dashboard\BootstrapLayout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3ac6759d595e4285b1a9ef17a0025223b8d729e6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dashboard_BootstrapLayout), @"mvc.1.0.view", @"/Views/Dashboard/BootstrapLayout.cshtml")]
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
#line 1 "H:\MVC project\Asp.net-MVC-project\MVCFirstDemo\MVCFirstDemo\Views\_ViewImports.cshtml"
using MVCFirstDemo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "H:\MVC project\Asp.net-MVC-project\MVCFirstDemo\MVCFirstDemo\Views\_ViewImports.cshtml"
using MVCFirstDemo.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ac6759d595e4285b1a9ef17a0025223b8d729e6", @"/Views/Dashboard/BootstrapLayout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b01b5e4045fa7410e91b75922c0bfd2664e6e92", @"/Views/_ViewImports.cshtml")]
    public class Views_Dashboard_BootstrapLayout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "H:\MVC project\Asp.net-MVC-project\MVCFirstDemo\MVCFirstDemo\Views\Dashboard\BootstrapLayout.cshtml"
  
    ViewData["Title"] = "BootstrapLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>BootstrapLayout</h1>

<div class=""container px-4"">
    <div class=""row gx-5"">
        <div class=""col"">
            <div class=""p-3 border bg-light"">Custom column padding</div>
        </div>
        <div class=""col"">
            <div class=""p-3 border bg-light"">Custom column padding</div>
        </div>
    </div>
</div>

<p class=""lead"">
    This is a lead paragraph. It stands out from regular paragraphs.
</p>

<figure class=""text-end"">
    <blockquote class=""blockquote"">
        <p>A well-known quote, contained in a blockquote element.</p>
    </blockquote>
    <figcaption class=""blockquote-footer"">
        Someone famous in <cite title=""Source Title"">Source Title</cite>
    </figcaption>
</figure>

<table class=""table table-success table-hover"">
    <thead>
        <tr>
            <th scope=""col"">#</th>
            <th scope=""col"">First</th>
            <th scope=""col"">Last</th>
            <th scope=""col"">Handle</th>
        </tr>
    </thead>
    <tbody>
      ");
            WriteLiteral(@"  <tr>
            <th scope=""row"">1</th>
            <td>Mark</td>
            <td>Otto</td>
            <td>mdo</td>
        </tr>
        <tr>
            <th scope=""row"">2</th>
            <td>Jacob</td>
            <td>Thornton</td>
            <td>fat</td>
        </tr>
        <tr>
            <th scope=""row"">3</th>
            <td colspan=""2"">Larry the Bird</td>
            <td>twitter</td>
        </tr>
    </tbody>
</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
