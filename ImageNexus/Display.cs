using ImageNexus.Properties;

namespace ImageNexus

{
    public partial class Display : Form
    {
        private IImageViewer imageFetcher;
        private IImageViewer thumbnailFetcher;
        private ThumbnailBoxPool thumbnailBoxPool;
        private int _currentThumbnailCount = -1;

        private int currentThumbnailCount
        {
            get { return _currentThumbnailCount; }

            set
            {
                if (value != _currentThumbnailCount)
                {
                    _currentThumbnailCount = value <= thumbnailBoxPool.PoolSize ? value : thumbnailBoxPool.PoolSize;
                    SetThumbnailPictureBoxes();
                    SetThumbnailImages();
                }
            }
        }

        public Display(List<string> imageFilePaths, IImageViewer viewer, IImageViewer thumbnailViewer, int thumbnailPoolSize)
        {
            InitializeComponent();
            imageFetcher = viewer;
            thumbnailFetcher = thumbnailViewer;
            thumbnailBoxPool = new ThumbnailBoxPool(thumbnailPoolSize);
            currentThumbnailCount = GetDisplayThumbnailCount();
            SetMainImage();
            SetThumbnailImages();
        }

        private void SetThumbnailPictureBoxes()
        {
            foreach (PictureBox picBox in thumbnailPanel.Controls)
                thumbnailBoxPool.TakeIn();

            thumbnailPanel.Controls.Clear();

            for (int i = 0; i < currentThumbnailCount; i++)
            {
                var picBox = thumbnailBoxPool.TakeOut();
                if (picBox == null)
                    return;
                if (thumbnailPanel.Controls.Count == 0)
                    picBox.BorderStyle = BorderStyle.Fixed3D;
                thumbnailPanel.Controls.Add(picBox);
            }
        }

        private void SetThumbnailImages()
        {
            var thumbnailImages = thumbnailFetcher.GetBulkImages(thumbnailPanel.Controls.Count);

            for (int i = 0; i < thumbnailPanel.Controls.Count; i++)
            {
                var picBox = (PictureBox)thumbnailPanel.Controls[i];
                picBox.Image = thumbnailImages[i] ?? Resources.image_not_found_icon;
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
            thumbnailFetcher.NextImage();
            SetThumbnailImages();
        }

        private void SetPreviousImage()
        {
            MainImage = imageFetcher.PreviousImage();
            thumbnailFetcher.PreviousImage();
            SetThumbnailImages();
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

        private void Display_Resize(object sender, EventArgs e)
        {
            currentThumbnailCount = GetDisplayThumbnailCount();
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