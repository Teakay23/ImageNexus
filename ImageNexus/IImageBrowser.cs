using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageNexus
{
    internal interface IImageBrowser
    {
        void SetFolderLocation(string folderPath);
        List<string>? GetImages();
        void SelectImage(string imagePath);
    }
}
