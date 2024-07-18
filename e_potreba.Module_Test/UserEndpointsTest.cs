using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Text;
using e_potreba.Application.DTO.User;
using e_potreba.Domain.Enum;
using Newtonsoft.Json;
using Xunit.Abstractions;
using System.Net;

namespace e_potreba.Test;

public class ApiEndpointTest
{
    readonly static Uri api_v1 = new Uri("http://localhost:5000");

    private readonly ITestOutputHelper _output;

    public ApiEndpointTest(ITestOutputHelper output) =>
		_output = output;


	[Fact]
    public async void RegistryCommonUser_Returns_The_Okay_Repsonse_With_UserData()
    {
        var client = GetHttpClient();

        UserRequest newUserData = new UserRequest(
            login: "123",
            email: "123",
            password: "123");
        

        StringContent jsonContent = new(
            JsonSerializer.Serialize(newUserData),
            Encoding.UTF8, 
            "application/json");

        var response = await client.PostAsync("/api/v1/users/auth", jsonContent);

        //Assert successful request
		Assert.Equal(HttpStatusCode.OK, response.StatusCode);

		var jsonString = await response.Content.ReadAsStringAsync();
        var deserialized = JsonConvert.DeserializeObject<UserResponse>(jsonString);

        // Assert response login and email data
        Assert.Equal(
            new string[] {newUserData.login, newUserData.email}, 
            new string[] {deserialized!.login, deserialized.email});
        
        // Assert user role
        Assert.Equal(UserRole.common, deserialized.role);
    }

    [Fact]
    public async void GetAllUser_Returns_The_Okay_Response()
    {
        var client = GetHttpClient();

        var response = await client.GetAsync("/api/v1/users");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    private HttpClient GetHttpClient()
    {
        return new HttpClient()
        {
            BaseAddress = api_v1
        };
    }
}