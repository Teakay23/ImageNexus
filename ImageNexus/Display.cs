using ImageNexus.Properties;

namespace ImageNexus

{
    public partial class Display : Form
    {
        private IImageViewer imageFetcher;
        private IImageViewer thumbnailFetcher;
        private ThumbnailBoxPool thumbnailBoxPool;

        public Display(List<string> imageFilePaths, IImageViewer viewer, IImageViewer thumbnailViewer, int thumbnailPoolSize)
        {
            InitializeComponent();
            imageFetcher = viewer;
            thumbnailFetcher = thumbnailViewer;
            thumbnailBoxPool = new ThumbnailBoxPool(thumbnailPoolSize);
            SetMainImage();
            SetThumbnailImages();
        }

        private void SetThumbnailImages()
        {
            var thumbnailCount = GetDisplayThumbnailCount();
            thumbnailCount = thumbnailCount <= thumbnailBoxPool.PoolSize ? thumbnailCount : thumbnailBoxPool.PoolSize;
            //thumbnailCount = thumbnailCount <= thumbnailFetcher.GetImageCount() ? thumbnailCount : thumbnailFetcher.GetImageCount();

            var thumbnailImages = thumbnailFetcher.GetBulkImages(thumbnailCount);

            for (int i = 0; i < thumbnailCount; i++)
            {
                var picBox = thumbnailBoxPool.TakeOut();
                picBox.Image = thumbnailImages[i] ?? Resources.image_not_found_icon;

                thumbnailPanel.Controls.Add(picBox);
            }
        }

        private int GetDisplayThumbnailCount()
        {
            var widthPanel = thumbnailPanel.Size.Width;
            var widthThumbnail = thumbnailBoxPool.ThumbnailBoxSize.Width;
            var thumbnailPanelPadding = thumbnailPanel.Padding.Left + thumbnailPanel.Padding.Right;

            return widthPanel / (widthThumbnail + thumbnailPanelPadding);
        }

        private void SetMainImage()
        {
            MainImage = imageFetcher.GetSelectedImage();
        }

        private void SetNextImage()
        {
            MainImage = imageFetcher.NextImage();
        }

        private void SetPreviousImage()
        {
            MainImage = imageFetcher.PreviousImage();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            SetNextImage();
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            SetPreviousImage();
        }

        private void Display_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                case Keys.D:
                    SetNextImage();
                    break;
                case Keys.Left:
                case Keys.A:
                    SetPreviousImage();
                    break;
                default:
                    break;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left || keyData == Keys.Right)
            {
                object sender = FromHandle(msg.HWnd);
                var e = new KeyEventArgs(keyData);
                Display_KeyDown(sender, e);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        public Image? MainImage
        {
            get
            {
                return mainPictureBox.Image;
            }
            set
            {
                mainPictureBox.Image = value ?? Resources.image_not_found_icon;

                if (mainPictureBox.Image.Size.Height > mainPictureBox.Size.Height || mainPictureBox.Image.Size.Width > mainPictureBox.Size.Width)
                    mainPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                else
                    mainPictureBox.SizeMode = PictureBoxSizeMode.CenterImage;

                imageNameLabel.Text = imageFetcher.GetSelectedImageName();
            }
        }
    }
}