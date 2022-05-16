using Xunit;

namespace TfL.Tests
{
    public class TfLDisruptionsApiTests
    {
        private readonly TfLClient client = new();

        [Fact]
        public async void Test_GetDisruptions()
        {
            var res = await client.Disruptions.GetDisruptionsAsync();
            Assert.NotNull(res);
            Assert.True(res.Length > 0);
        }
    }
}