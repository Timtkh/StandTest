using Aquality.Selenium.Core.Logging;

namespace ExamTest.Framework.Utils
{
    public static class RandomUtils
    {
        private static readonly Random Random = new();
        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const int MinStringValue = 5;
        private const int MaxStringValue = 10;
        private const int MinIntValue = 5;
        private const int MaxIntValue = 1000;

        public static string GetRandomLatinString()
        {
            Logger.Instance.Info("Get random latin string");
            return new string(Enumerable.Repeat(Chars, Random.Next(MinStringValue, MaxStringValue)).Select(str => str[Random.Next(str.Length)]).ToArray());
        }

        public static int GetRandomInt()
        {
            Logger.Instance.Info("Get random int");
            return Random.Next(MinIntValue, MaxIntValue);
        }

        public static T RandomEnumValue<T>()
        {
            Logger.Instance.Info("Get random enum value");
            var values = Enum.GetValues(typeof(T));
            return (T)values.GetValue(Random.Next(values.Length));
        }
    }
}