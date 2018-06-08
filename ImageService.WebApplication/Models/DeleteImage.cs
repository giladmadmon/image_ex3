using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using ImageService.Communication.Singleton;
using ImageService.Communication.Model;
using ImageService.Infrastructure.Enums;
using System.IO;

namespace ImageService.WebApplication.Models {
    public class DeleteImage {
        public DeleteImage(string image) {
            this.Image = image;
        }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Folder")]
        public string Image { get; set; }

        public void Delete() {
            try {
                Photos photos = new Photos();
                File.Delete(Image);
                File.Delete(Image.Replace(photos.OutputDirPath,photos.ThumbnailsDirPath));
                SpinWait.SpinUntil(() => !File.Exists(Image));
            } catch { }
        }
    }
}