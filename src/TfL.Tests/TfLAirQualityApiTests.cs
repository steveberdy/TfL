using Xunit;

namespace TfLTests
{
    public class TfLAirQualityApiTests : TfLApiTestBase
    {
        [Fact]
        public async void Test_GetAirQuality()
        {
            var res = await client.AirQuality.GetAirQuality();
            Assert.NotNull(res);
        }
    }
}