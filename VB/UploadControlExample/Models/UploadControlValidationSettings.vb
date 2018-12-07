Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports DevExpress.Web

Public Class MyUploadControlValidationSettings
    Public Shared Settings As New UploadControlValidationSettings() With {.AllowedFileExtensions = New String() {
        ".jpg", ".jpeg", ".png", ".bmp", ".pdf", ".xml", ".txt", ".rtf", ".docx", ".xls", ".xlsx"},
        .MaxFileSize = 4194304}
End Class