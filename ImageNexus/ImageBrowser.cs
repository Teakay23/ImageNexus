using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageNexus
{
    public class ImageBrowser : IImageBrowser // TODO: add file monitor to include newly added images to the folder in the list 
    {
        private string? folderPath;
        private List<string>? images;

        public void SetFolderLocation(string folderPath)
        {
            this.folderPath = folderPath;
            LoadImages();
        }

        public List<string>? GetImages()
        {
            return images;
        }

        public void SelectImage(string imagePath)
        {
            // Perform the necessary operations when an image is selected
            Console.WriteLine("Selected image: " + imagePath);
        }

        private void LoadImages()
        {
            if (folderPath == null)
                return;

            images = new List<string>();
            string[] imageFiles = Directory.GetFiles(folderPath, "*.jpg|*.jpeg|*.png|*.gif|*.bmp", SearchOption.TopDirectoryOnly);
            images.AddRange(imageFiles);
        }
    }
}
