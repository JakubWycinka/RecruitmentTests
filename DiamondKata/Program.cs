namespace DiamondKata
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var diamondKind = args.First().First();

            var diamond = new Diamond(diamondKind);

            Console.Write(diamond.ToDiamondString());
        }
    }
}
