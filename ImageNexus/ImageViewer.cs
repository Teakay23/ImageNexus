using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageNexus
{
    public class ImageViewer : IImageViewer
    {
        private IImageLoader loader;
        private List<string> imagePaths;
        private int currentIndex;

        public ImageViewer(List<string> images, IImageLoader loader)
        {
            this.imagePaths = images;
            this.loader = loader;
            this.loader.SetImages(images);
            currentIndex = 0;
        }

        public Image? NextImage()
        {
            if (currentIndex < imagePaths.Count - 1)
                currentIndex++;
            else
                currentIndex = 0;

            return GetSelectedImage();
        }

        public Image? PreviousImage()
        {
            if (currentIndex > 0)
                currentIndex--;
            else
                currentIndex = imagePaths.Count - 1;
            
            return GetSelectedImage();
        }

        public Image? GetSelectedImage()
        {
            return loader.LoadImage(imagePaths[currentIndex]);
        }

        public string GetSelectedImageName()
        {
            return Path.GetFileName(imagePaths[currentIndex]);
        }
    }
}
