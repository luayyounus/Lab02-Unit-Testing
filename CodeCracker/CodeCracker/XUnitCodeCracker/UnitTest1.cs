using System;
using Xunit;

namespace XUnitCodeCracker
{
    public class UnitTestCodeCracker
    {
        [Fact]
        public void ReturnUnderstandablePhrase()
        {
            Assert.Equal("This challenge is not so challenging");
        }
    }
}
