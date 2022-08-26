using AlasDOOGoRESTTests.Model;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace AlasDOOGoRESTTests
{
    public class T0003_DeleteUser
    {

        [Fact(DisplayName = "Test: Delete Created User via REST API")]
        public void DeleteUserAPI()
        {
            //Arrange
            var client = new RestClient("https://gorest.co.in/public/v2/users");

            client.Timeout = -1;

            var request = new RestRequest(Method.GET);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer fd9928a55c0199162b477b3dd9b72e6791a1557f793fac525f3f4931e55ae2ba");

            //Act (Looking for previously created User by "name", and extracting "id" if User we created is found
            var response = client.Execute(request);

            var objResponse = JsonConvert.DeserializeObject<List<Users>>(response.Content);

            var UserID = 0;

            foreach (var item in objResponse)
            {
                // Looking for both variations of my name: Dejan Mir. (original name after Test #1) & Dejan M. (updated name after Test 2)
                if (item.Name == "Dejan M." || item.Name == "Dejan Mir.")
                {
                    UserID = item.UserID;

                }
                else
                {

                    // No users with "name" => Dejan M. or Dejan Mir. were found
                    

                }

            }

            var deleteRequest = new RestRequest($"/" + UserID + "", Method.DELETE);

            deleteRequest.AddHeader("Content-Type", "application/json");
            deleteRequest.AddHeader("Authorization", "Bearer fd9928a55c0199162b477b3dd9b72e6791a1557f793fac525f3f4931e55ae2ba");

            var deleteResponse = client.Execute(deleteRequest);

            // Assert
            // Expected HTTP status code is: NoContent 204
            HttpStatusCode statusCode = HttpStatusCode.NoContent;

            Assert.Equal(statusCode, deleteResponse.StatusCode);

        }

    }
}
