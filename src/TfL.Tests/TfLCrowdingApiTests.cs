using System;
using Xunit;

namespace TfL.Tests
{
    public class TfLCrowdingApiTests
    {
        private TfLClient client = new();

        #region Test_GetDayOfWeekCrowding
        // [Fact]
        // public async void Test_GetDayOfWeekCrowding_Success()
        // {
        //     client = new TfLClient("APP_KEY HERE");
        //     var res = await client.Crowding.GetDayOfWeekCrowding("940GZZLUBLR", "Tuesday");
        //     Assert.NotNull(res);
        //     // Assert.True() check some result property once result is no longer plain object

        //     res = await client.Crowding.GetDayOfWeekCrowding("940GZZLUBLR", DayOfWeek.Tuesday);
        //     Assert.NotNull(res);
        //     // Assert.True() check some result property once result is no longer plain object
        // }

        [Fact]
        public async void Test_GetDayOfWeekCrowding_Fail_Unauthorized()
        {
            client = new TfLClient();

            await Assert.ThrowsAsync<UnauthorizedAccessException>(async () =>
            {
                await client.Crowding.GetDayOfWeekCrowdingAsync("940GZZLUBLR", DayOfWeek.Tuesday);
            });

            await Assert.ThrowsAsync<UnauthorizedAccessException>(async () =>
            {
                await client.Crowding.GetDayOfWeekCrowdingAsync("940GZZLUBLR", "Tuesday");
            });
        }
        #endregion


        #region Test_GetLiveCrowding
        // [Fact]
        // public async void Test_GetLiveCrowding_Success()
        // {
        //     client = new TfLClient("APP_KEY HERE");
        //     var res = await client.Crowding.GetLiveCrowding("940GZZLUBLR");
        //     Assert.NotNull(res);
        //     // Assert.True() check some result property once result is no longer plain object
        // }

        [Fact]
        public async void Test_GetLiveCrowding_Fail_Unauthorized()
        {
            client = new TfLClient();

            await Assert.ThrowsAsync<UnauthorizedAccessException>(async () =>
            {
                await client.Crowding.GetLiveCrowdingAsync("940GZZLUBLR");
            });
        }
        #endregion


        #region Tets_GetCrowding
        // [Fact]
        // public async void Test_GetCrowding_Success()
        // {
        //     client = new TfLClient("APP_KEY HERE");
        //     var res = await client.Crowding.GetCrowding("940GZZLUBLR");
        //     Assert.NotNull(res);
        //     // Assert.True() check some result property once result is no longer plain object
        // }

        [Fact]
        public async void Test_GetCrowding_Fail_Unauthorized()
        {
            client = new TfLClient();

            await Assert.ThrowsAsync<UnauthorizedAccessException>(async () =>
            {
                await client.Crowding.GetCrowdingAsync("940GZZLUBLR");
            });
        }
        #endregion
    }
}