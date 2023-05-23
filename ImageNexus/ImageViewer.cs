using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageNexus
{
    internal class ImageViewer : IImageViewer
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

        public void NextImage()
        {
            if (currentIndex < imagePaths.Count - 1)
            {
                currentIndex++;
                GetSelectedImage();
            }
        }

        public void PreviousImage()
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                GetSelectedImage();
            }
        }

        public Image GetSelectedImage()
        {
            return loader.LoadImage(imagePaths[currentIndex]);
        }
    }
}
