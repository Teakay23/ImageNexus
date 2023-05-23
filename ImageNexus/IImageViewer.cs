using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageNexus
{
    internal interface IImageViewer
    {
        void NextImage();
        void PreviousImage();
        Image GetSelectedImage();
    }
}
