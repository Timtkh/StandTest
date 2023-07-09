using Aquality.Selenium.Core.Logging;
using ExamTest.Framework.Utils;
using NUnit.Framework;

namespace ExamTest.TestSolution.Steps
{
    public static class APISteps
    {
        private const string GetTokenUrlParam = "token/get?";
        private const string Variant = "variant";

        public static string GetAndCheckToken(string variant)
        {
            Logger.Instance.Info("Get and check token");
            var token = APIUtils.Post(urlParam: GetTokenUrlParam, parametrName: Variant, parametrValue: variant).Content ?? throw new ArgumentNullException("Token is null");
            Assert.That(token, Is.Not.Empty, "Token is empty");
            return token;
        }
    }
}