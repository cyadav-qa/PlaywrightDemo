using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using PlaywrightDemo.Config;

namespace PlaywrightDemo.Tests;

[TestFixture]
public class ApiTests : PlaywrightTest
{
    private IAPIRequestContext _request = null!;

    [SetUp]
    public async Task SetUpApi()
    {
        _request = await Playwright.APIRequest.NewContextAsync(new()
        {
            BaseURL = TestConfig.ApiBaseUrl
        });
    }

    [TearDown]
    public async Task TearDownApi()
    {
        await _request.DisposeAsync();
    }

    [Test]
    [Category("Api")]
    public async Task GetPost_Returns200AndCorrectId()
    {
        var response = await _request.GetAsync("/posts/1");

        Assert.That(response.Status, Is.EqualTo(200));

        var json = await response.JsonAsync();
        Assert.That(json?.GetProperty("id").GetInt32(), Is.EqualTo(1));
    }

    [Test]
    [Category("Api")]
    public async Task CreatePost_Returns201()
    {
        var response = await _request.PostAsync("/posts", new()
        {
            DataObject = new { title = "my title", body = "my body", userId = 1 }
        });

        Assert.That(response.Status, Is.EqualTo(201));

        var json = await response.JsonAsync();
        Assert.That(json?.GetProperty("title").GetString(), Is.EqualTo("my title"));
    }
}