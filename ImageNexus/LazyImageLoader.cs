using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageNexus
{
    internal class LazyImageLoader : IImageLoader
    {
        protected Dictionary<string, Image?> _images = new Dictionary<string, Image?>();

        public LazyImageLoader() { }

        public LazyImageLoader(List<string> imagePaths) 
        {
            SetImages(imagePaths);
        }

        public void SetImages(List<string> imagePaths)
        {
            imagePaths.ForEach(path => _images.Add(path, null));
        }

        public virtual Image? LoadImage(string filePath)
        {
            try
            {
                if (_images[filePath] == null)
                    _images[filePath] = Image.FromFile(filePath);
            }
            catch
            {
                return null;
            }

            return _images[filePath];
        }
    }
}
