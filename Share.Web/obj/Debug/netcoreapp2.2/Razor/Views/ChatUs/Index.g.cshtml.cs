#pragma checksum "C:\Users\RMB\Desktop\Share-master\Web\Share.Web\Views\ChatUs\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2af41c0153219d2ce188aa16a00ac3866c0d5ea0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ChatUs_Index), @"mvc.1.0.view", @"/Views/ChatUs/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ChatUs/Index.cshtml", typeof(AspNetCore.Views_ChatUs_Index))]
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
#line 1 "C:\Users\RMB\Desktop\Share-master\Web\Share.Web\Views\_ViewImports.cshtml"
using Share.Web;

#line default
#line hidden
#line 2 "C:\Users\RMB\Desktop\Share-master\Web\Share.Web\Views\_ViewImports.cshtml"
using Share.Web.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2af41c0153219d2ce188aa16a00ac3866c0d5ea0", @"/Views/ChatUs/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d158ddd2741cc048a15a90c542f959552d86d3b6", @"/Views/_ViewImports.cshtml")]
    public class Views_ChatUs_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/signalr/dist/browser/signalr.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/chat.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 2 "C:\Users\RMB\Desktop\Share-master\Web\Share.Web\Views\ChatUs\Index.cshtml"
  
    ViewData["Title"] = "工作组";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(83, 258, true);
            WriteLiteral(@"
<div class=""container"">
    <div class=""row"">
        <span class=""col-5"">&nbsp;</span>
        <span style=""font:600 16px '微软雅黑'"">工作讨论组</span>
    </div>
    <br />
    <div class=""row"">
        <div class=""col-4"">&nbsp;</div>

        <div class=""col-6"">
");
            EndContext();
#line 17 "C:\Users\RMB\Desktop\Share-master\Web\Share.Web\Views\ChatUs\Index.cshtml"
             if (Model.Name != null)
            {

#line default
#line hidden
            BeginContext(392, 90, true);
            WriteLiteral("                <span>用户：</span><input type = \"text\" id = \"userInput\" readonly= \"readonly\"");
            EndContext();
            BeginWriteAttribute("value", "  value = \"", 482, "\"", 504, 1);
#line 19 "C:\Users\RMB\Desktop\Share-master\Web\Share.Web\Views\ChatUs\Index.cshtml"
WriteAttributeValue("", 493, Model.Name, 493, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(505, 4, true);
            WriteLiteral(" />\n");
            EndContext();
#line 20 "C:\Users\RMB\Desktop\Share-master\Web\Share.Web\Views\ChatUs\Index.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(554, 102, true);
            WriteLiteral("                <span>用户：</span><input type=\"text\" id=\"userInput\" readonly=\"readonly\" value=\"默认用户\" />\n");
            EndContext();
#line 24 "C:\Users\RMB\Desktop\Share-master\Web\Share.Web\Views\ChatUs\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(670, 424, true);
            WriteLiteral(@"

            <br />
            信息：<input type=""text"" id=""messageInput"" />
            <input type=""button"" id=""sendButton"" value=""发送"" />
        </div>
    </div>
    <div class=""row"">
        <div class=""col-12"">
            <hr />
        </div>
    </div>
    <div class=""row"">
        <div class=""col-6"">&nbsp;</div>
        <div class=""col-6"">
            <ul id=""messagesList""></ul>
        </div>
    </div>
</div>
");
            EndContext();
            BeginContext(1094, 61, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2af41c0153219d2ce188aa16a00ac3866c0d5ea06288", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1155, 1, true);
            WriteLiteral("\n");
            EndContext();
            BeginContext(1156, 36, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2af41c0153219d2ce188aa16a00ac3866c0d5ea07465", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1192, 2, true);
            WriteLiteral("\n\n");
            EndContext();
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