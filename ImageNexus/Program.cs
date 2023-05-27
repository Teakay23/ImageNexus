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
            var viewer = new ImageViewer(imagePaths, loader);

            Application.Run(new Display(imagePaths, viewer));
        }
    }
}