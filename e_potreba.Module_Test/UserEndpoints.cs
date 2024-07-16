namespace e_potreba.Test;

public class ApiEndpointTest
{
    Uri api_v1 = new Uri("http://localhost:5000/api/v1");

    [Fact]
    public async void GetAllUser_Returns_The_Okay_Response()
    {
        HttpClient client = new()
        {
            BaseAddress = api_v1
        };

        var response = await client.GetAsync("users");
        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
    }
}