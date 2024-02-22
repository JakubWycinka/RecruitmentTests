using System.Text;

namespace DiamondKata
{
    internal class Diamond(char kind)
    {
        private const int DiamondMinKind = 'A';
        private const char Space = ' ';
        private const string TemporarySeparator = "_";

        public string ToDiamondString()
        {
            var diamondSize = GetIntegerSize();

            if (diamondSize == 0)
            {
                return "A";
            }

            var rowNumberOfTheRowInTheMiddle = diamondSize;
            var firstHalfDiamondStringBuilder = new StringBuilder();

            for (var rowNumber = 0; rowNumber < rowNumberOfTheRowInTheMiddle; rowNumber++)
            {
                if (rowNumber == 0)
                {
                    AppendSpaceNumberOfTimes(firstHalfDiamondStringBuilder, diamondSize);
                    firstHalfDiamondStringBuilder.Append('A');
                    AppendSpaceNumberOfTimes(firstHalfDiamondStringBuilder, diamondSize);
                    firstHalfDiamondStringBuilder.Append(TemporarySeparator);
                }
                else
                {
                    var letterToAppend = (char)(DiamondMinKind + rowNumber);
                    var numberOfSpacesBeforeOrAfterLetter = diamondSize - rowNumber;
                    var numberOfSpacesBetweenLetters = rowNumber * 2 - 1;

                    AppendSpaceNumberOfTimes(firstHalfDiamondStringBuilder, numberOfSpacesBeforeOrAfterLetter);
                    firstHalfDiamondStringBuilder.Append(letterToAppend);
                    AppendSpaceNumberOfTimes(firstHalfDiamondStringBuilder, numberOfSpacesBetweenLetters);
                    firstHalfDiamondStringBuilder.Append(letterToAppend);
                    AppendSpaceNumberOfTimes(firstHalfDiamondStringBuilder, numberOfSpacesBeforeOrAfterLetter);
                    firstHalfDiamondStringBuilder.Append(TemporarySeparator);
                }
            }

            var firstHalf = firstHalfDiamondStringBuilder.ToString();

            return firstHalf.Replace(TemporarySeparator, Environment.NewLine) +
                   CreateMiddleRow() +
                   new string(firstHalf.Reverse().ToArray()).Replace(TemporarySeparator, Environment.NewLine);
        }

        private int GetIntegerSize() => kind - DiamondMinKind;

        private void AppendSpaceNumberOfTimes(StringBuilder stringBuilder, int number)
        {
            for (var currentNumber = 0; currentNumber < number; currentNumber++)
            {
                stringBuilder!.Append(Space);
            }
        }

        private string CreateMiddleRow()
        {
            var rowNumberOfTheRowInTheMiddle = GetIntegerSize();

            var middleRowDiamondStringBuilder = new StringBuilder();
            var letterToAppendInTheMiddleRow = (char)(DiamondMinKind + rowNumberOfTheRowInTheMiddle);
            var numberOfSpacesBetweenLettersInTheMiddleRow = rowNumberOfTheRowInTheMiddle * 2 - 1;

            middleRowDiamondStringBuilder.Append(letterToAppendInTheMiddleRow);
            AppendSpaceNumberOfTimes(middleRowDiamondStringBuilder, numberOfSpacesBetweenLettersInTheMiddleRow);
            middleRowDiamondStringBuilder.Append(letterToAppendInTheMiddleRow);

            return middleRowDiamondStringBuilder.ToString();
        }
    }
}