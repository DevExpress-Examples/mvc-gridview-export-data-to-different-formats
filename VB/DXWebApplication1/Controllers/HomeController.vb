
Imports System.Web.Mvc
Imports DevExpress.Web.Mvc

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Public Function Index() As ActionResult
        If Session("TypedListModel") Is Nothing Then
            Session("TypedListModel") = InMemoryModel.GetTypedListModel()
        End If

        Return View(Session("TypedListModel"))
    End Function

    Public Function TypedListDataBindingPartial() As ActionResult
        Return PartialView(Session("TypedListModel"))
    End Function


    Public Function ExportTo(OutputFormat As String) As ActionResult
        Dim model = Session("TypedListModel")

        Select Case OutputFormat.ToUpper()
            Case "CSV"
                Return GridViewExtension.ExportToCsv(GridViewHelper.ExportGridViewSettings, model)
            Case "PDF"
                Return GridViewExtension.ExportToPdf(GridViewHelper.ExportGridViewSettings, model)
            Case "RTF"
                Return GridViewExtension.ExportToRtf(GridViewHelper.ExportGridViewSettings, model)
            Case "XLS"
                Return GridViewExtension.ExportToXls(GridViewHelper.ExportGridViewSettings, model)
            Case "XLSX"
                Return GridViewExtension.ExportToXlsx(GridViewHelper.ExportGridViewSettings, model)
            Case Else
                Return RedirectToAction("Index")
        End Select
    End Function

End Class


Public NotInheritable Class GridViewHelper
    Private Sub New()
    End Sub
    Private Shared m_exportGridViewSettings As GridViewSettings

    Public Shared ReadOnly Property ExportGridViewSettings() As GridViewSettings
        Get
            If m_exportGridViewSettings Is Nothing Then
                m_exportGridViewSettings = CreateExportGridViewSettings()
            End If
            Return m_exportGridViewSettings
        End Get
    End Property

    Private Shared Function CreateExportGridViewSettings() As GridViewSettings
        Dim settings As New GridViewSettings()

        settings.Name = "gvTypedListDataBinding"
        settings.CallbackRouteValues = New With { _
            Key .Controller = "Home", _
            Key .Action = "TypedListDataBindingPartial" _
        }

        settings.KeyFieldName = "ID"
        settings.Settings.ShowFilterRow = True

        settings.Columns.Add("ID")
        settings.Columns.Add("Text")
        settings.Columns.Add("Quantity")
        settings.Columns.Add("Price")

        Return settings
    End Function
End Class
