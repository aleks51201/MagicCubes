using System;

namespace MagicCubes.Components.Ui
{
    public struct StarHolderComponent
    {
        private int _starCount;
        public int StarCount
        {
            get
            {
                return _starCount;
            }
            set
            {
                if (value > 3 || value < 0)
                {
                    throw new ArgumentOutOfRangeException($"Value can be '0 <= value <= 3', current value = {value}");
                }
                _starCount = value;
            }
        }
    }
}
