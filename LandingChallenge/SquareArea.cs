using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandingChallenge
{
    public class SquareArea
    {
        public Coordinate TopLeftCorner { get; set; }
        public int Size { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="topLeftCorner" type=Coordinate>(x,y) coordinate that represents the top left corner of the landing area</param>
        /// <param name="size" type=int>Landing Area Size</param>
        public SquareArea(Coordinate topLeftCorner, int size)
        {
            TopLeftCorner = topLeftCorner;
            Size = size;
        }
    }
}
