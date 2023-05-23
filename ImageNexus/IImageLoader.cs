using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageNexus
{
    internal interface IImageLoader
    {
        public void SetImages(List<string> imagePaths);
        public Image LoadImage(string filePath);
    }
}
