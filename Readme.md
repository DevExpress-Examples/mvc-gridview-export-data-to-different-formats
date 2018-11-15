<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/DXWebApplication1/Controllers/HomeController.vb))
* [Model.cs](./CS/Models/Model.cs) (VB: [Model.vb](./VB/DXWebApplication1/Models/Model.vb))
* [Index.cshtml](./CS/Views/Home/Index.cshtml)
* [TypedListDataBindingPartial.cshtml](./CS/Views/Home/TypedListDataBindingPartial.cshtml)
<!-- default file list end -->
# How to export GridView data to different text formats


<p>This example is standalone implementation of the online <a href="http://demos.devexpress.com/MVC/GridView/Export"><u>Grid View - Exporting Data</u></a> demo.<br />
It illustrates how to export the GridView 's content to several rich text formats via the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebMvcGridViewExtensionMembersTopicAll"><u>ExportTo***</u></a> methods.</p><p>This example is an illustration of the <a href="https://www.devexpress.com/Support/Center/p/KA18639">KA18639: How to export GridView rows and keep end-user modifications (such as sorting, grouping, filtering, selection)</a> KB Article. Refer to the Article for an explanation.</p><p>Please note the following key moments:<br />
- The <strong>GridView Extension</strong> should be defined via a separate <strong>PartialView without any</strong> additional tags (see the <a href="http://documentation.devexpress.com/#AspNet/CustomDocument9052"><u>Using Callbacks</u></a> help topic for more information);<br />
- The <strong>GridView's PartialView</strong> should be <strong>wrapped within a form</strong> in order to apply the client layout state (sorting, filtering, etc.);<br />
- An export trigger should submit this form to the corresponding Controller Action (i.e., make a POST request);<br />
- The <strong>GridViewSettings</strong> (especially the <strong>Name</strong> property) should be the same in PartialView and Controller;<br />
- The <strong>datasouce/Model</strong> should be the same in PartialView and Controller.</p>

<br/>


