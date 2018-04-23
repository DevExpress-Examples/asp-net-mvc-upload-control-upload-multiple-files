using System.Web.Mvc;
using System.Web.UI;
using DevExpress.Web;
using DevExpress.Web.Mvc;

namespace UploadControlExampleMvc.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        public ActionResult UploadControlUpload() {
            string[] errors;

            UploadedFile[] files = UploadControlExtension.GetUploadedFiles("UploadControl",
                MyUploadControlValidationSettings.Settings, out errors, (s, e) => { },
                UploadControl_FilesUploadComplete);

            return null;
        }

        public void UploadControl_FilesUploadComplete(object sender, FilesUploadCompleteEventArgs e) {
            UploadedFile[] files = ((MVCxUploadControl)sender).UploadedFiles;

            for (int i = 0; i < files.Length; i++) {
                if (files[i].IsValid && !string.IsNullOrWhiteSpace(files[i].FileName)) {
                    string resultFilePath = "~/Content/" + files[i].FileName;
                    // files[i].SaveAs(System.Web.HttpContext.Current.Request.MapPath(resultFilePath)); // Code Central Mode - Uncomment This Line

                    string file = string.Format("{0} ({1}KB)", files[i].FileName, files[i].ContentLength / 1024);
                    string url = ((IUrlResolutionService)sender).ResolveClientUrl(resultFilePath);

                    e.CallbackData += file + "|" + url + "|";
                }
            }
        }
    }
}
