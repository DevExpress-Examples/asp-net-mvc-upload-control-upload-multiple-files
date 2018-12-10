Imports Microsoft.VisualBasic
Imports DevExpress.Web
Imports DevExpress.Web.Mvc
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.UI

Namespace UploadControlExample.Controllers
	Public Class HomeController
		Inherits Controller
		Public Function Index() As ActionResult
			Return View()
		End Function
		Public Function UploadControlUpload() As ActionResult
			Dim errors() As String

			Dim files() As UploadedFile = UploadControlExtension.GetUploadedFiles("UploadControl", MyUploadControlValidationSettings.Settings, errors, Function(s, e) AnonymousMethod1(s, e), AddressOf UploadControl_FilesUploadComplete)

			Return Nothing
		End Function
		
		Private Function AnonymousMethod1(ByVal s As Object, ByVal e As Object) As Boolean
			Return True
		End Function

		Public Sub UploadControl_FilesUploadComplete(ByVal sender As Object, ByVal e As FilesUploadCompleteEventArgs)
			Dim files() As UploadedFile = (CType(sender, MVCxUploadControl)).UploadedFiles

			For i As Integer = 0 To files.Length - 1
				If files(i).IsValid AndAlso (Not String.IsNullOrWhiteSpace(files(i).FileName)) Then
					Dim resultFilePath As String = "~/Content/" & files(i).FileName
					files(i).SaveAs(System.Web.HttpContext.Current.Request.MapPath(resultFilePath))

					Dim file As String = String.Format("{0} ({1}KB)", files(i).FileName, files(i).ContentLength / 1024)
					Dim url As String = (CType(sender, IUrlResolutionService)).ResolveClientUrl(resultFilePath)

					e.CallbackData += file & "|" & url & "|"
				End If
			Next i
		End Sub
	End Class
End Namespace