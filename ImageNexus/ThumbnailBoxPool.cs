using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageNexus
{
    public class ThumbnailBoxPool
    {
        private List<PictureBox> _pool;
        private int _poolSize = 10;
        private int currentIndex = 0;
        private Size _thumbnailBoxSize = new(150, 110);

        public int PoolSize 
        { 
            get { return _poolSize; }
        }

        public Size ThumbnailBoxSize
        {
            get { return _thumbnailBoxSize; }
        }

        public ThumbnailBoxPool(int poolSize) 
        {
            _poolSize = poolSize;
            _pool = new List<PictureBox>();

            for(int i = 0; i < _poolSize; i++)
            {
                _pool.Add(new PictureBox()
                {
                    Size = _thumbnailBoxSize,
                    Anchor = AnchorStyles.Left,
                    SizeMode = PictureBoxSizeMode.CenterImage,
                    BorderStyle = BorderStyle.FixedSingle
                });
            }
        }

        public PictureBox? TakeOut()
        {
            if (currentIndex >= _poolSize)
                return null;

            var picBox = _pool[currentIndex];
            currentIndex++;
            return picBox;
        }

        public void TakeIn()
        {
            _pool[currentIndex].Image = null;
            currentIndex--;
        }
    }
}
