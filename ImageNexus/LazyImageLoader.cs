using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageNexus
{
    internal class LazyImageLoader : IImageLoader
    {
        private Dictionary<string, Image?> _images = new Dictionary<string, Image?>();

        public void SetImages(List<string> imagePaths)
        {
            imagePaths.ForEach(path => _images.Add(path, null));
        }

        public Image LoadImage(string filePath)
        {
            if (_images[filePath] == null)
                _images[filePath] = Image.FromFile(filePath);

            return _images[filePath];
        }
    }
}
