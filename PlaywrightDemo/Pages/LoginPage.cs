using Microsoft.Playwright;
using PlaywrightDemo.Config;

namespace PlaywrightDemo.Pages;

public class LoginPage
{
    private readonly IPage _page;

    public LoginPage(IPage page)
    {
        _page = page;
    }

    public ILocator ErrorMessage => _page.Locator("[data-test='error']");
    public ILocator LoginButton => _page.Locator("[data-test='login-button']");

    public async Task GotoAsync()
    {
        await _page.GotoAsync(TestConfig.BaseUrl);
    }

    public async Task LoginAsync(string user, string password)
    {
        await _page.GetByPlaceholder("Username").FillAsync(user);
        await _page.GetByPlaceholder("Password").FillAsync(password);
        await LoginButton.ClickAsync();
    }
}