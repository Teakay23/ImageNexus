using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageNexus
{
    internal class LazyThumbnailImageLoader : LazyImageLoader
    {
        private IImageLoader _imageLoader;

        public LazyThumbnailImageLoader(IImageLoader imageLoader) 
        {
            _imageLoader = imageLoader;
        }

        public LazyThumbnailImageLoader(List<string> imagePaths, IImageLoader imageLoader) : base(imagePaths) 
        {
            _imageLoader = imageLoader;
        }

        private bool ThumbnailCallback()
        {
            return false;
        }

        public override Image? LoadImage(string filePath)
        {
            if (_images[filePath] == null)
            {
                var fullImage = _imageLoader.LoadImage(filePath);
                if (fullImage == null)
                    return null;

                var callback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                _images[filePath] = fullImage.GetThumbnailImage(fullImage.Width * 110 / fullImage.Height, 110, callback, IntPtr.Zero);
            }

            return _images[filePath];
        }
    }
}
