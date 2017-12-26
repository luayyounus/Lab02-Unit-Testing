using System;
using Xunit;
using Anagrams;

namespace XUnitTestAnagrams
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(new[] { "PEACH cheap", "" }, new[] { "PEACH", "sheep", "cheap", "preaCH" })]
        public void Return_Longest_Words_Anagrams(string[] expectedResult, string[] dummyInput)
        {
            string[] result = AnagramsApp.FindAnagrams(dummyInput);
            Assert.Equal(expectedResult[0], result[0]);
        }

        [Theory]
        [InlineData(new[] {"", "least"}, new[] { "least", "setal", "slate", "stale", "steal", "artels", "estral", "laster" })]
        public void Return_Set_With_Most_Words_Anagrams(string[] expectedResult, string[] dummyInput)
        {
            string[] result = AnagramsApp.FindAnagrams(dummyInput);
            Assert.StartsWith(expectedResult[1], result[1]);
        }
    }
}
