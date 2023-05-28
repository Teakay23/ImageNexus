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

        public string GetSelectedImageName();
    }
}
