using Xunit;

namespace TfLTests
{
    public class TfLJourneyApiTests : TfLApiTestBase
    {
        [Fact]
        public async void Test_GetJourneyPlannerModes()
        {
            var res = await client.Journey.GetJourneyPlannerModes();
            Assert.NotNull(res);
            Assert.True(res.Length > 0);
        }
    }
}