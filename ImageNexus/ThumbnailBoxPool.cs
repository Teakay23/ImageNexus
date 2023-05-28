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

        public int PoolSize
        {
            get { return _poolSize; }
            set
            {
                if (value <= 0)
                    _poolSize = 1;
                _poolSize = value;
            }
        }

        public ThumbnailBoxPool() 
        {
            _pool = new List<PictureBox>();
        }

        public PictureBox? TakeOut()
        {
            if (currentIndex >= _poolSize)
                return null;

            PictureBox picBox;

            try
            {
                picBox = _pool[currentIndex];
            }
            catch(IndexOutOfRangeException)
            {
                _pool.Add(new PictureBox());
                picBox = _pool[currentIndex];
            }

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
