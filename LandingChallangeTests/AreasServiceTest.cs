using LandingChallenge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandingChallangeTests
{
    public class AreasServiceTest
    {

        [Fact]
        public void CreateSafetyAreaShouldReturnSquareArea()
        {
            var sa = AreasService.CreateSafetyArea(new Coordinate(5, 5));
            Assert.True(sa.Size == 3);
            Assert.Equal(sa.TopLeftCorner, new Coordinate(4, 4));
        }

        [Fact]
        public void IsCoordinateSafeToLandShouldReturnTrue()
        {
            var sa = AreasService.CreateSafetyArea(new Coordinate(5, 5));
            Assert.True(AreasService.IsCoordinateSafeToLand(sa, new Coordinate(4, 4)));
        }

        [Fact]
        public void IsCoordinateSafeToLandShouldReturnFalse()
        {
            var sa = AreasService.CreateSafetyArea(new Coordinate(5, 5));
            Assert.False(AreasService.IsCoordinateSafeToLand(sa, new Coordinate(11,11)));
        }


    }
}
