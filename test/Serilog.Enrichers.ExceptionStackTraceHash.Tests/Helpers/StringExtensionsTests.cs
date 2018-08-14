using Serilog.Enrichers;

using Xunit;

namespace Serilog.Tests.Helpers
{
    public class StringExtensionsTests
    {
        [Theory]
        [InlineData("", "")]
        [InlineData("Still no guids here", "Still no guids here")]
        [InlineData("8908da8e-6d2f-44b6-a5d3-90c36b4051d1", "")]
        [InlineData("a8908da8e-6d2f-44b6-a5d3-90c36b4051d1bc8908da8e-6d2f-44b6-a5d3-90c36b4051d1d", "abcd")]  
        [InlineData("8908da8e-6d2f-44b6-a5d3-90c36b4051d", "8908da8e-6d2f-44b6-a5d3-90c36b4051d")]
        public void TestRemoveGuids(string initial, string expected)
        {
            Assert.Equal(expected, initial.RemoveGuids());
        }
    }
}