@Code
    ViewBag.Title = "Home Page"
End code

<script type="text/javascript">
    function OnFilesUploadComplete(s, e) {
        var data = e.callbackData.split('|');
        for (var i = 0; i < data.length; i += 2) {
            var file = data[i];
            var url = data[i + 1];
            var link = document.createElement('A');
            link.innerHTML = file;
            link.setAttribute('href', url);
            link.setAttribute('target', '_blank');
            var fileContainer = document.getElementById('fileContainer');
            fileContainer.appendChild(link);
            fileContainer.appendChild(document.createElement('BR'));
        }
    }
</script>

@Using Html.BeginForm("UploadControlUpload", "Home")
    @Html.DevExpress().UploadControl(
     Sub(settings)
         settings.Name = "UploadControl"
         settings.ShowUploadButton = True
         settings.ShowProgressPanel = True
         settings.AdvancedModeSettings.EnableMultiSelect = True
         settings.AdvancedModeSettings.EnableFileList = True
         settings.AdvancedModeSettings.EnableDragAndDrop = True
         settings.UploadMode = DevExpress.Web.UploadControlUploadMode.Advanced
         settings.ValidationSettings.Assign(MyUploadControlValidationSettings.Settings)
         settings.ClientSideEvents.FilesUploadComplete = "OnFilesUploadComplete"
     End Sub).GetHtml()
End Using

@Html.DevExpress().Label(
    Sub(settings)
        settings.Name = "lblAllowebMimeType"
        settings.Text = "Allowed file types: " + String.Join(", ", MyUploadControlValidationSettings.Settings.AllowedFileExtensions)
        settings.ControlStyle.Font.Size = System.Web.UI.WebControls.FontUnit.Point(8)
End Sub).GetHtml()

<br />

@Html.DevExpress().Label(
    Sub(settings)
        settings.Name = "lblMaxFileSize"
        settings.Text = "Maximum file size: " + (MyUploadControlValidationSettings.Settings.MaxFileSize / 1048576).ToString() + "Mb"
        settings.ControlStyle.Font.Size = System.Web.UI.WebControls.FontUnit.Point(8)
    End Sub).GetHtml()

<br />
<br />

@Html.DevExpress().RoundPanel(
     Sub(settings)
             settings.Name = "RoundPanel"
             settings.HeaderText = "Uploaded Files"
             settings.SetContent(Sub()
                                         ViewContext.Writer.Write("<div id='fileContainer'/>")
                                 End Sub)
     End Sub).GetHtml()