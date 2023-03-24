Imports System.Web.Mvc
Imports DevExpress.Web.Mvc
Imports Export.Models

Namespace Export.Controllers

    Public Class HomeController
        Inherits Controller

        Public Function Index() As ActionResult
            If Session("TypedListModel") Is Nothing Then Session("TypedListModel") = InMemoryModel.GetTypedListModel()
            Return View(Session("TypedListModel"))
        End Function

        Public Function TypedListDataBindingPartial() As ActionResult
            Return PartialView(Session("TypedListModel"))
        End Function

        Public Function ExportTo(ByVal OutputFormat As String) As ActionResult
            Dim model = Session("TypedListModel")
            Select Case OutputFormat.ToUpper()
                Case "CSV"
                    Return GridViewExtension.ExportToCsv(ExportGridViewSettings, model)
                Case "PDF"
                    Return GridViewExtension.ExportToPdf(ExportGridViewSettings, model)
                Case "RTF"
                    Return GridViewExtension.ExportToRtf(ExportGridViewSettings, model)
                Case "XLS"
                    Return GridViewExtension.ExportToXls(ExportGridViewSettings, model)
                Case "XLSX"
                    Return GridViewExtension.ExportToXlsx(ExportGridViewSettings, model)
                Case Else
                    Return RedirectToAction("Index")
            End Select
        End Function
    End Class
End Namespace

Public Module GridViewHelper

    Private exportGridViewSettingsField As GridViewSettings

    Public ReadOnly Property ExportGridViewSettings As GridViewSettings
        Get
            If exportGridViewSettingsField Is Nothing Then exportGridViewSettingsField = CreateExportGridViewSettings()
            Return exportGridViewSettingsField
        End Get
    End Property

    Private Function CreateExportGridViewSettings() As GridViewSettings
        Dim settings As GridViewSettings = New GridViewSettings()
        settings.Name = "gvTypedListDataBinding"
        settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "TypedListDataBindingPartial"}
        settings.KeyFieldName = "ID"
        settings.Settings.ShowFilterRow = True
        settings.Columns.Add("ID")
        settings.Columns.Add("Text")
        settings.Columns.Add("Quantity")
        settings.Columns.Add("Price")
        Return settings
    End Function
End Module
