using System.Collections.Generic;
using Olimpia.Business.Caculate;
using Olimpia.Business.Model;
using Xunit;

namespace Olimpia.Test.Test1
{
    public class Test1
    {
        [Theory]
        // [MemberData(nameof(CreationData))]
        [InlineData("aaaa", "aaab", 3, "HIT")]
        [InlineData("aaaa", "aaab", 4, "NO-HIT")]
        [InlineData("bnvmcd", "dcmvnb", 1, "NO-HIT")]
        [InlineData("abcdef", "azcxef", 4, "HIT")]
        [InlineData("qwerty", "q", 1, "HIT")]
        [InlineData("qwerty", "tyerq", 2, "HIT")]
        public void TestFirstPawPrint(string firstPawPrint, string secodPawPrint, int acceptanceParameter, string spectedValue)
        {
            DataTest data = new DataTest() { FirstPawPrint = firstPawPrint, SecodPawPrint = secodPawPrint, AcceptanceParameter = acceptanceParameter, SpectedValue = spectedValue };
            CalculateMatch newMarch = new CalculateMatch(data);
            string result = newMarch.GetValidation();
            Assert.True(data.SpectedValue.Equals(result));
        }

        public static IEnumerable<object[]> CreationData =>

            new List<object[]>
            {
                new object[] {
                    // new DataTest(){FirstPawPrint="aaaa",SecodPawPrint="aaab",AcceptanceParameter=3,SpectedValue ="HIT"},
                    // new DataTest(){FirstPawPrint="aaaa",SecodPawPrint="aaab",AcceptanceParameter=4,SpectedValue ="NO-HIT"},
                    // new DataTest(){FirstPawPrint="bnvmcd",SecodPawPrint="dcmvnb",AcceptanceParameter=1,SpectedValue ="NO-HIT"},
                    // new DataTest(){FirstPawPrint="abcdef",SecodPawPrint="azcxef",AcceptanceParameter=4,SpectedValue ="HIT"},
                    // new DataTest(){FirstPawPrint="qwerty",SecodPawPrint="q",AcceptanceParameter=1,SpectedValue ="HIT"},
                    // new DataTest(){FirstPawPrint="qwerty",SecodPawPrint="tyerq",AcceptanceParameter=2,SpectedValue ="HIT"},
            }};
    }
}