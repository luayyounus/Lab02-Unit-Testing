using System;
using Xunit;
using CodeCracker;

namespace XUnitCodeCracker
{
    public class UnitTestCodeCracker
    {
        [Fact]
        public void ReturnEncryptedMessage()
        {
            Assert.Equal("aj!n", Message.Encrypt("luay"));
        }

        [Theory]
        [InlineData("aj!n")]
        public void ReturnDecryptedMessage(string message)
        {
            Assert.Equal("luay", Message.Decrypt(message));
        }
    }
}
