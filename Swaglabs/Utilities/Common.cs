namespace Swaglabs.Utilities
{
    public class Common
    {
        public static Random Rand = new Random(Environments.Config.Seed);

        public static int GetRandom(int start, int stop)
        {
            return Rand.Next(start, stop);
        }
    }
}
