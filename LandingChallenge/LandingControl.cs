using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandingChallenge
{
    public class LandingControl
    {

        private const int DEFAULT_LANDING_AREA_SIZE = 100;
        private const int DEFAULT_LANDING_PLATFORM_SIZE = 10;

        private const int LANDING_AREA_TOP_LEFT_CORNER = 0;
        private const int LANDING_PLATFORM_TOP_LEFT_CORNER = 5;

        public SquareArea LandingArea { get; private set; } = new(new Coordinate(LANDING_AREA_TOP_LEFT_CORNER, LANDING_AREA_TOP_LEFT_CORNER), DEFAULT_LANDING_AREA_SIZE);
        public SquareArea LandingPlatform { get; private set; }
        private SquareArea PreviousLanding { get; set; }

        public LandingControl() => LandingPlatform = new(new Coordinate(LANDING_PLATFORM_TOP_LEFT_CORNER, LANDING_PLATFORM_TOP_LEFT_CORNER), DEFAULT_LANDING_PLATFORM_SIZE);

        public LandingControl(int sizeOfLandingPlatform)
        {
            if (sizeOfLandingPlatform < 1 || sizeOfLandingPlatform + LANDING_PLATFORM_TOP_LEFT_CORNER > DEFAULT_LANDING_AREA_SIZE)
                throw new Exception("ERROR: Landing platform must be inside landing area.");

            LandingPlatform = new(new Coordinate(LANDING_PLATFORM_TOP_LEFT_CORNER, LANDING_PLATFORM_TOP_LEFT_CORNER), sizeOfLandingPlatform);

        }

        public LandingStatusResponse LandingRequest(Coordinate landingRequestPosition)
        {
            LandingStatusResponse response;

            if (PreviousLanding is not null && AreasService.IsCoordinateSafeToLand(PreviousLanding, landingRequestPosition))
                response = LandingStatusResponse.Clash;
            else if (AreasService.IsCoordinateSafeToLand(LandingPlatform, landingRequestPosition))
                response = LandingStatusResponse.OkForLanding;
            else
                response = LandingStatusResponse.OutOfPlatform;

            PreviousLanding = AreasService.CreateSafetyArea(landingRequestPosition);

            return response;
        }
    }
}
