using Aquality.Selenium.Core.Logging;
using ExamTest.TestSolution.Managers;
using RestSharp;

namespace ExamTest.Framework.Utils
{
    public static class APIUtils
    {
        private static readonly RestClient Сlient = new(TestDataGetter.Configs.ApiUrl);

        public static RestResponse Post(string urlParam, string parametrName = null, string parametrValue = null)
        {
            Logger.Instance.Info("Post method");
            var request = new RestRequest(urlParam, Method.Post);
            request.AddQueryParameter($"{parametrName}", $"{parametrValue}");
            return Сlient.Execute(request);
        }
    }
}