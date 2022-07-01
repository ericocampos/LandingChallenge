using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandingChallenge
{
    public static class AreasService
    {
        /// <summary>
        /// Creates safe area to a given position, including adjacent tiles
        /// </summary>
        /// <param name="coordinate" type=Coordinate>(x,y) to create safety area</param>
        /// <returns>SquareArea representing the safety zone</returns>
        public static SquareArea CreateSafetyArea(Coordinate coordinate) => 
            new(new Coordinate(coordinate.X - 1, coordinate.Y - 1), 3);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="area"></param>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        public static bool IsCoordinateSafeToLand(SquareArea area, Coordinate coordinate)
        {
            var topLeftCorner = area.TopLeftCorner;
            var size = area.Size;

            return coordinate.X >= topLeftCorner.X &&
                    coordinate.X <= topLeftCorner.X + size - 1 &&
                    coordinate.Y >= topLeftCorner.Y &&
                    coordinate.Y <= topLeftCorner.Y + size - 1;
        }

        
    }
}
