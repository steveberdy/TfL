using System;
using Xunit;

namespace TfL.Tests
{
    public class TfLBikePointApiTests
    {
        private readonly TfLClient client = new();

        [Fact]
        public async void Test_GetAll()
        {
            var all = await client.BikePoint.GetAll();
            Assert.NotNull(all);
            Assert.True(all.Length > 0);
        }

        #region Test_Get
        [Fact]
        public async void Test_Get_Success()
        {
            var res = await client.BikePoint.Get("BikePoints_123");
            Assert.NotNull(res);
            Assert.NotNull(res.BikePoint);
        }

        [Fact]
        public async void Test_Get_Fail_ArgumentNullException()
        {
            // Throw null if bikePointId is null
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await client.BikePoint.Get(null);
            });

            // Throw null if bikePointId is empty
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await client.BikePoint.Get(string.Empty);
            });
        }
        #endregion

        #region Test_Search
        [Fact]
        public async void Test_Search_Success()
        {
            var res = await client.BikePoint.Search("Square");
            Assert.NotNull(res);
            Assert.True(res.Length > 0);
        }

        [Fact]
        public async void Test_Search_Fail_ArgumentNullException()
        {
            // Throw null if search is null
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await client.BikePoint.Search(null);
            });

            // Throw null if search is empty
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await client.BikePoint.Search(string.Empty);
            });
        }
        #endregion
    }
}