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

        public override Image LoadImage(string filePath)
        {
            if (_images[filePath] == null)
                _images[filePath] = ResizeImage(_imageLoader.LoadImage(filePath), 400, 225);

            return _images[filePath];
        }

        private static Image ResizeImage(Image originalImage, int width, int height)
        {
            using var resizedImage = new Bitmap(width, height);
            using var graphics = Graphics.FromImage(resizedImage);

            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.DrawImage(originalImage, new Rectangle(0, 0, width, height));

            return resizedImage;
        }
    }
}
