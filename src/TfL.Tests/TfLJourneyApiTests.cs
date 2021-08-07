using Xunit;

namespace TfL.Tests
{
    public class TfLJourneyApiTests
    {
        private readonly TfLClient client = new();

        [Fact]
        public async void Test_GetJourneyPlannerModes()
        {
            var res = await client.Journey.GetJourneyPlannerModes();
            Assert.NotNull(res);
            Assert.True(res.Length > 0);
        }
    }
}