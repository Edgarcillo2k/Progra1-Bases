#pragma checksum "C:\Users\Edgar\Desktop\Importante\TEC\IV SEMESTRE\BASES DE DATOS I\Progra1-Bases\Progra1-Bases\Progra1-bases\Views\TipoCuentas\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d2e9efebbe22026355cdffa86396164e86ee1750"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TipoCuentas_Delete), @"mvc.1.0.view", @"/Views/TipoCuentas/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/TipoCuentas/Delete.cshtml", typeof(AspNetCore.Views_TipoCuentas_Delete))]
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
#line 1 "C:\Users\Edgar\Desktop\Importante\TEC\IV SEMESTRE\BASES DE DATOS I\Progra1-Bases\Progra1-Bases\Progra1-bases\Views\_ViewImports.cshtml"
using Progra1_bases;

#line default
#line hidden
#line 2 "C:\Users\Edgar\Desktop\Importante\TEC\IV SEMESTRE\BASES DE DATOS I\Progra1-Bases\Progra1-Bases\Progra1-bases\Views\_ViewImports.cshtml"
using Progra1_bases.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d2e9efebbe22026355cdffa86396164e86ee1750", @"/Views/TipoCuentas/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d63c1d9972582c8fc1b2e004f170d4bdb0f9ef80", @"/Views/_ViewImports.cshtml")]
    public class Views_TipoCuentas_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Progra1_bases.Models.TipoCuenta>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(40, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Edgar\Desktop\Importante\TEC\IV SEMESTRE\BASES DE DATOS I\Progra1-Bases\Progra1-Bases\Progra1-bases\Views\TipoCuentas\Delete.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
            BeginContext(84, 180, true);
            WriteLiteral("\r\n<h1>Delete</h1>\r\n\r\n<h3>Are you sure you want to delete this?</h3>\r\n<div>\r\n    <h4>TipoCuenta</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(265, 42, false);
#line 15 "C:\Users\Edgar\Desktop\Importante\TEC\IV SEMESTRE\BASES DE DATOS I\Progra1-Bases\Progra1-Bases\Progra1-bases\Views\TipoCuentas\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Nombre));

#line default
#line hidden
            EndContext();
            BeginContext(307, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(371, 38, false);
#line 18 "C:\Users\Edgar\Desktop\Importante\TEC\IV SEMESTRE\BASES DE DATOS I\Progra1-Bases\Progra1-Bases\Progra1-bases\Views\TipoCuentas\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Nombre));

#line default
#line hidden
            EndContext();
            BeginContext(409, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(472, 47, false);
#line 21 "C:\Users\Edgar\Desktop\Importante\TEC\IV SEMESTRE\BASES DE DATOS I\Progra1-Bases\Progra1-Bases\Progra1-bases\Views\TipoCuentas\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.SaldoMinimo));

#line default
#line hidden
            EndContext();
            BeginContext(519, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(583, 43, false);
#line 24 "C:\Users\Edgar\Desktop\Importante\TEC\IV SEMESTRE\BASES DE DATOS I\Progra1-Bases\Progra1-Bases\Progra1-bases\Views\TipoCuentas\Delete.cshtml"
       Write(Html.DisplayFor(model => model.SaldoMinimo));

#line default
#line hidden
            EndContext();
            BeginContext(626, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(689, 66, false);
#line 27 "C:\Users\Edgar\Desktop\Importante\TEC\IV SEMESTRE\BASES DE DATOS I\Progra1-Bases\Progra1-Bases\Progra1-bases\Views\TipoCuentas\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.MultaIncumplimientoSaldoMinimo));

#line default
#line hidden
            EndContext();
            BeginContext(755, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(819, 62, false);
#line 30 "C:\Users\Edgar\Desktop\Importante\TEC\IV SEMESTRE\BASES DE DATOS I\Progra1-Bases\Progra1-Bases\Progra1-bases\Views\TipoCuentas\Delete.cshtml"
       Write(Html.DisplayFor(model => model.MultaIncumplimientoSaldoMinimo));

#line default
#line hidden
            EndContext();
            BeginContext(881, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(944, 61, false);
#line 33 "C:\Users\Edgar\Desktop\Importante\TEC\IV SEMESTRE\BASES DE DATOS I\Progra1-Bases\Progra1-Bases\Progra1-bases\Views\TipoCuentas\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.MontoMensualCargosServico));

#line default
#line hidden
            EndContext();
            BeginContext(1005, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1069, 57, false);
#line 36 "C:\Users\Edgar\Desktop\Importante\TEC\IV SEMESTRE\BASES DE DATOS I\Progra1-Bases\Progra1-Bases\Progra1-bases\Views\TipoCuentas\Delete.cshtml"
       Write(Html.DisplayFor(model => model.MontoMensualCargosServico));

#line default
#line hidden
            EndContext();
            BeginContext(1126, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1189, 58, false);
#line 39 "C:\Users\Edgar\Desktop\Importante\TEC\IV SEMESTRE\BASES DE DATOS I\Progra1-Bases\Progra1-Bases\Progra1-bases\Views\TipoCuentas\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.MaxRetirosCajeroHumano));

#line default
#line hidden
            EndContext();
            BeginContext(1247, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1311, 54, false);
#line 42 "C:\Users\Edgar\Desktop\Importante\TEC\IV SEMESTRE\BASES DE DATOS I\Progra1-Bases\Progra1-Bases\Progra1-bases\Views\TipoCuentas\Delete.cshtml"
       Write(Html.DisplayFor(model => model.MaxRetirosCajeroHumano));

#line default
#line hidden
            EndContext();
            BeginContext(1365, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1428, 65, false);
#line 45 "C:\Users\Edgar\Desktop\Importante\TEC\IV SEMESTRE\BASES DE DATOS I\Progra1-Bases\Progra1-Bases\Progra1-bases\Views\TipoCuentas\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.MultaRetiroCajeroHumanoExceso));

#line default
#line hidden
            EndContext();
            BeginContext(1493, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1557, 61, false);
#line 48 "C:\Users\Edgar\Desktop\Importante\TEC\IV SEMESTRE\BASES DE DATOS I\Progra1-Bases\Progra1-Bases\Progra1-bases\Views\TipoCuentas\Delete.cshtml"
       Write(Html.DisplayFor(model => model.MultaRetiroCajeroHumanoExceso));

#line default
#line hidden
            EndContext();
            BeginContext(1618, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1681, 47, false);
#line 51 "C:\Users\Edgar\Desktop\Importante\TEC\IV SEMESTRE\BASES DE DATOS I\Progra1-Bases\Progra1-Bases\Progra1-bases\Views\TipoCuentas\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.TasaInteres));

#line default
#line hidden
            EndContext();
            BeginContext(1728, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1792, 43, false);
#line 54 "C:\Users\Edgar\Desktop\Importante\TEC\IV SEMESTRE\BASES DE DATOS I\Progra1-Bases\Progra1-Bases\Progra1-bases\Views\TipoCuentas\Delete.cshtml"
       Write(Html.DisplayFor(model => model.TasaInteres));

#line default
#line hidden
            EndContext();
            BeginContext(1835, 38, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    \r\n    ");
            EndContext();
            BeginContext(1873, 206, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d2e9efebbe22026355cdffa86396164e86ee175012168", async() => {
                BeginContext(1899, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(1909, 36, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d2e9efebbe22026355cdffa86396164e86ee175012561", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 59 "C:\Users\Edgar\Desktop\Importante\TEC\IV SEMESTRE\BASES DE DATOS I\Progra1-Bases\Progra1-Bases\Progra1-bases\Views\TipoCuentas\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ID);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1945, 83, true);
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Delete\" class=\"btn btn-danger\" /> |\r\n        ");
                EndContext();
                BeginContext(2028, 38, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d2e9efebbe22026355cdffa86396164e86ee175014528", async() => {
                    BeginContext(2050, 12, true);
                    WriteLiteral("Back to List");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2066, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2079, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Progra1_bases.Models.TipoCuenta> Html { get; private set; }
    }
}
#pragma warning restore 1591
