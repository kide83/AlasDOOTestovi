using AlasDOOGoRESTTests.Model;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using Xunit;

namespace AlasDOOGoRESTTests
{
    public class T0002_UpdateUser
    {
        [Fact(DisplayName = "Test: Update Created User via REST API")]
        public void UpdateUserAPI()
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
                if (item.Name == "Dejan Mir.")
                {
                    UserID = item.UserID;

                    // If Created User is found => Update it's "name" and "status" fields
                    var updateRequest = new RestRequest($"/" + UserID + "?name=Dejan M.&status=inactive", Method.PATCH);

                    updateRequest.AddHeader("Content-Type", "application/json");
                    updateRequest.AddHeader("Authorization", "Bearer fd9928a55c0199162b477b3dd9b72e6791a1557f793fac525f3f4931e55ae2ba");

                    var updateResponse = client.Execute(updateRequest);

                } else {

                    // Created user with "name" => Dejan Mir. was not found
                    

                }

            }

            // Fetch User data again, this time after it was updated
            var changesMadeRequest = new RestRequest($"/" + UserID + "", Method.GET);

            changesMadeRequest.AddHeader("Content-Type", "application/json");
            changesMadeRequest.AddHeader("Authorization", "Bearer fd9928a55c0199162b477b3dd9b72e6791a1557f793fac525f3f4931e55ae2ba");

            var changesMadeResponse = client.Execute(changesMadeRequest);

            var objchangesMadeResponse = JsonConvert.DeserializeObject<Users>(changesMadeResponse.Content);

            // Fetch updated "name" field, which should be "Dejan M." now
            var updatedName = objchangesMadeResponse.Name;

            //Assert
            Assert.Equal("Dejan M.", updatedName);
            // Assert.Equal("Utrecht", objResponse.Places[0].State);

        }

    }
}
