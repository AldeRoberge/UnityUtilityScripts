namespace TheBigParse
{
    public static class StringExtensionsLimit
    {
        public static string Limit(this string toOutput, int trimLength)
        {
            if (toOutput.Length > trimLength) toOutput = toOutput.Remove(trimLength);
            return toOutput;
        }
    }
}