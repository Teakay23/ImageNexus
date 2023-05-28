namespace ImageNexus
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var browser = new ImageBrowser();
            var imagePaths = browser.GetImages();

            if (imagePaths == null || imagePaths.Count <= 0)
                return;

            var loader = new LazyImageLoader();
            var thumbnailLoader = new LazyThumbnailImageLoader(loader);
            var viewer = new ImageViewer(imagePaths, loader);
            var thumbnailViewer = new ImageViewer(imagePaths, thumbnailLoader);

            Application.Run(new Display(imagePaths, viewer, thumbnailViewer, 10));
        }
    }
}