using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageNexus
{
    public interface IImageViewer
    {
        Image? NextImage();
        Image? PreviousImage();
        Image? GetSelectedImage();
        List<Image?> GetBulkImages(int imageCount);
        public string GetSelectedImageName();
        public int GetImageCount();
    }
}
