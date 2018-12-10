using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Web;

public class MyUploadControlValidationSettings {
    public static UploadControlValidationSettings Settings = new UploadControlValidationSettings() {
        AllowedFileExtensions = new string[] { ".jpg", ".jpeg", ".png", ".bmp", ".pdf", ".xml", ".txt", ".rtf", ".docx", ".xls", ".xlsx" },
        MaxFileSize = 4194304
    };
}