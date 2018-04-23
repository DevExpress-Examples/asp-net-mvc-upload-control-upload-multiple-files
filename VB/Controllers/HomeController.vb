Imports System.Web.Mvc
Imports System.Web.UI
Imports DevExpress.Web
Imports DevExpress.Web.Mvc

Namespace UploadControlExampleMvc.Controllers
	Public Class HomeController
		Inherits Controller

		Public Function Index() As ActionResult
			Return View()
		End Function

		Public Function UploadControlUpload() As ActionResult
            Dim errors() As String = {}

            Dim files() As UploadedFile = UploadControlExtension.GetUploadedFiles("UploadControl", MyUploadControlValidationSettings.Settings, errors, AddressOf UploadControl_FileUploadComplete, AddressOf UploadControl_FilesUploadComplete)

            Return Nothing
		End Function

        Public Sub UploadControl_FileUploadComplete(ByVal sender As Object, ByVal e As FileUploadCompleteEventArgs)

        End Sub

		Public Sub UploadControl_FilesUploadComplete(ByVal sender As Object, ByVal e As FilesUploadCompleteEventArgs)
			Dim files() As UploadedFile = DirectCast(sender, MVCxUploadControl).UploadedFiles

			For i As Integer = 0 To files.Length - 1
				If files(i).IsValid AndAlso (Not String.IsNullOrWhiteSpace(files(i).FileName)) Then
					Dim resultFilePath As String = "~/Content/" & files(i).FileName
                    'files(i).SaveAs(System.Web.HttpContext.Current.Request.MapPath(resultFilePath)) ' Code Central Mode - Uncomment This Line

					Dim file_Renamed As String = String.Format("{0} ({1}KB)", files(i).FileName, files(i).ContentLength / 1024)
					Dim url_Renamed As String = DirectCast(sender, IUrlResolutionService).ResolveClientUrl(resultFilePath)

					e.CallbackData += file_Renamed & "|" & url_Renamed & "|"
				End If
			Next i
		End Sub
	End Class
End Namespace
