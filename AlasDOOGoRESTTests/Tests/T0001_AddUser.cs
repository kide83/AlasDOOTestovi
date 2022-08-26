using RestSharp;
using System;
using System.Net;
using Xunit;

namespace AlasDOOGoRESTTests
{
    public class T0001_AddUser
    {
        [Fact(DisplayName = "Test: Add New User via REST API")]
        public void AddUserAPI()
        {
            //Arrange
            var client = new RestClient("https://gorest.co.in/public/v2/users");

            client.Timeout = -1;

            // I generate random email to avoid gorest.co.in limitation of email being unique
            Random randomNumber = new Random();
            int nekiBroj = randomNumber.Next(0, 100);
            var randomEmail = $"dejanm" + nekiBroj + "@gmail.com";

            var request = new RestRequest($"?name=Dejan Mir.&gender=male&email=" + randomEmail + "&status=active", Method.POST);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer fd9928a55c0199162b477b3dd9b72e6791a1557f793fac525f3f4931e55ae2ba");

            //Act
            var response = client.Execute(request);

            // Assert
            // Expected HTTP status code is: Created 201
            HttpStatusCode statusCode = HttpStatusCode.Created;

            Assert.Equal(statusCode, response.StatusCode);

        }

    }
}
