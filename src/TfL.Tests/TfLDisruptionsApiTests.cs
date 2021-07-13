using Xunit;

namespace TfLTests
{
    public class TfLDisruptionsApiTests : TfLApiTestBase
    {
        [Fact]
        public async void Test_GetDisruptions()
        {
            var res = await client.Disruptions.GetDisruptions();
            Assert.NotNull(res);
            Assert.True(res.Length > 0);
        }
    }
}