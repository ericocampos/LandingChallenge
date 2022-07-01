using LandingChallenge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandingChallangeTests
{
    public class LandingControlTests
    {
        public static IEnumerable<object[]> LandingOneRocketTests =>
            new List<object[]>
            {
                new object[]
                {
                    new Coordinate(5,5),
                    LandingStatusResponse.OkForLanding
                },
                new object[]
                {
                    new Coordinate(10,10),
                    LandingStatusResponse.OkForLanding
                },
                new object[]
                {
                    new Coordinate(14,14),
                    LandingStatusResponse.OkForLanding
                },
                new object[]
                {
                    new Coordinate(4,5),
                    LandingStatusResponse.OutOfPlatform
                },
                new object[]
                {
                    new Coordinate(5,4),
                    LandingStatusResponse.OutOfPlatform
                },
                new object[]
                {
                    new Coordinate(15,15),
                    LandingStatusResponse.OutOfPlatform
                }
            };

        public static IEnumerable<object[]> LandingWithPreviousRocketTests =>
            new List<object[]>
            {
                new object[]
                {
                    new Coordinate(5,5),
                    new Coordinate(10,10),
                    LandingStatusResponse.OkForLanding
                },
                new object[]
                {
                    new Coordinate(5,5),
                    new Coordinate(5,5),
                    LandingStatusResponse.Clash
                },
                new object[]
                {
                    new Coordinate(7,7),
                    new Coordinate(7,8),
                    LandingStatusResponse.Clash
                },
                new object[]
                {
                    new Coordinate(7,7),
                    new Coordinate(6,7),
                    LandingStatusResponse.Clash
                },
                new object[]
                {
                    new Coordinate(7,7),
                    new Coordinate(6,6),
                    LandingStatusResponse.Clash
                }
            };

        [Theory]
        [MemberData(nameof(LandingOneRocketTests))]
        public void LandingRequestWithOneRocketShouldReturnExpectedValue(Coordinate coordinate, LandingStatusResponse expectedStatus)
        {
            var control = new LandingControl();
            Assert.Equal(expectedStatus, control.LandingRequest(coordinate));
        }

        [Theory]
        [MemberData(nameof(LandingWithPreviousRocketTests))]
        public void LandingRequestWithPreviousRocketShouldReturnExpectedValue(Coordinate coordinateRocket1, Coordinate coordinateRocket2, LandingStatusResponse expectedStatus)
        {
            var control = new LandingControl();
            control.LandingRequest(coordinateRocket1);

            Assert.Equal(expectedStatus, control.LandingRequest(coordinateRocket2));
        }

        [Theory]
        [InlineData(25, 16, 16, LandingStatusResponse.OkForLanding)]        
        public void LandingControlShouldCreateBiggerPlatform(int platformSize, int coordinateX, int coordinateY, LandingStatusResponse expectedResult)
        {
            var control = new LandingControl(platformSize);
            Assert.Equal(expectedResult, control.LandingRequest(new Coordinate(coordinateX, coordinateY)));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(96)]
        public void LandingControlShouldThrowException(int platformSize)
        {
            var ex = Assert.Throws<Exception>(() => new LandingControl(platformSize));
            Assert.Equal("ERROR: Landing platform must be inside landing area.", ex.Message);
        }
        
    }
}
