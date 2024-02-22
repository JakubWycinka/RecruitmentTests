namespace DiamondKata.UnitTests
{
    public class DiamondTests
    {
        public static IEnumerable<object[]> GetDiamondStringTestCases()
        {
            yield return new object[] { new DiamondStringTestCase(
                DiamondKind: 'A',
                ExpectedDiamondString: "A") };

            yield return new object[] { new DiamondStringTestCase(
                DiamondKind: 'B',
                ExpectedDiamondString: " A " + Environment.NewLine +
                                       "B B" + Environment.NewLine +
                                       " A ") };
            
            yield return new object[] { new DiamondStringTestCase(
                DiamondKind: 'C',
                ExpectedDiamondString: "  A  " + Environment.NewLine +
                                       " B B " + Environment.NewLine +
                                       "C   C" + Environment.NewLine +
                                       " B B " + Environment.NewLine +
                                       "  A  ") };
        }

        [Theory]
        [MemberData(nameof(GetDiamondStringTestCases), MemberType = typeof(DiamondTests))]
        public void GivenDiamondOfSomeKind_WhenToDiamondString_ThenReturnString(DiamondStringTestCase testCase)
        {
            // Arrange
            var diamond = new Diamond(testCase.DiamondKind);

            // Act
            var actualDiamondString = diamond.ToDiamondString();

            // Assert
            Assert.Equal(testCase.ExpectedDiamondString, actualDiamondString);
        }

        public record DiamondStringTestCase(char DiamondKind, string ExpectedDiamondString);
    }
}