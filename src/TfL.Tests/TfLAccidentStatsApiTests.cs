using Xunit;

namespace TfLTests
{
    public class TfLAccidentStatsApiTests : TfLApiTestBase
    {
        [Fact]
        public async void Test_GetAccidents_Success()
        {
            var res = await client.AccidentStats.GetAccidents(2019);
            Assert.NotNull(res);
            Assert.True(res.Length > 0);
        }

        [Fact]
        public async void Test_GetAccidents_Success_No_Data()
        {
            // 2020 has no data
            var res = await client.AccidentStats.GetAccidents(2020);
            Assert.Null(res);
        }
    }
}