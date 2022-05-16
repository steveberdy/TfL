using Xunit;

namespace TfL.Tests
{
    public class TfLAirQualityApiTests
    {
        private readonly TfLClient client = new();

        [Fact]
        public async void Test_GetAirQuality()
        {
            var res = await client.AirQuality.GetAirQualityAsync();
            Assert.NotNull(res);
        }
    }
}