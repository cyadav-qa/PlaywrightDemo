using System.Text.RegularExpressions;
using Microsoft.Playwright.NUnit;
using PlaywrightDemo.Config;
using PlaywrightDemo.Pages;

namespace PlaywrightDemo.Tests;

[TestFixture]
public class LoginTests : PageTest
{
    private LoginPage _loginPage = null!;
    private ProductsPage _productsPage = null!;

    [SetUp]
    public async Task SetUpPages()
    {
        _loginPage = new LoginPage(Page);
        _productsPage = new ProductsPage(Page);
        await _loginPage.GotoAsync();
    }

    [Test]
    [Category("Smoke")]
    public async Task ValidLogin_OpensProductsPage()
    {
        await _loginPage.LoginAsync(TestConfig.ValidUser, TestConfig.ValidPassword);

        await Expect(Page).ToHaveURLAsync(new Regex("inventory"));
        await Expect(_productsPage.Title).ToHaveTextAsync("Products");
    }

    [TestCase("wrong_user", "wrong_pass", "do not match")]
    [TestCase("locked_out_user", "secret_sauce", "locked out")]
    [TestCase("", "", "Username is required")]
    [TestCase("standard_user", "", "Password is required")]
    [Category("Regression")]
    public async Task InvalidLogin_ShowsError(string user, string password, string expectedError)
    {
        await _loginPage.LoginAsync(user, password);

        await Expect(_loginPage.ErrorMessage).ToBeVisibleAsync();
        await Expect(_loginPage.ErrorMessage).ToContainTextAsync(expectedError);
    }
}