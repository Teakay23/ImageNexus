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

        public ImageBrowser() 
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    SetFolderLocation(fbd.SelectedPath);
                }
            }
        }

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
            Console.WriteLine("Selected image: " + imagePath);
        }

        private void LoadImages()
        {
            if (folderPath == null)
                return;

            images = new List<string>();
            var filters = new string[] { "jpg", "jpeg", "png", "gif", "bmp" };
            var imageFiles = GetFilesFrom(folderPath, filters, false);
            images.AddRange(imageFiles);
        }

        private static List<string> GetFilesFrom(string searchFolder, string[] filters, bool isRecursive)
        {
            List<string> filesFound = new List<string>();
            var searchOption = isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;

            foreach (var filter in filters)
            {
                filesFound.AddRange(Directory.GetFiles(searchFolder, string.Format("*.{0}", filter), searchOption));
            }

            return filesFound.ToList();
        }
    }
}
