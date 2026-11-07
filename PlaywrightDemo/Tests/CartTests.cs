using Microsoft.Playwright.NUnit;
using PlaywrightDemo.Config;
using PlaywrightDemo.Pages;

namespace PlaywrightDemo.Tests;

[TestFixture]
public class CartTests : PageTest
{
    private LoginPage _loginPage = null!;
    private ProductsPage _productsPage = null!;
    private CartPage _cartPage = null!;

    [SetUp]
    public async Task SetUpPages()
    {
        _loginPage = new LoginPage(Page);
        _productsPage = new ProductsPage(Page);
        _cartPage = new CartPage(Page);

        await _loginPage.GotoAsync();
        await _loginPage.LoginAsync(TestConfig.ValidUser, TestConfig.ValidPassword);
    }

    [Test]
    [Category("Smoke")]
    public async Task AddToCart_ShowsItemInCart()
    {
        await _productsPage.AddToCartAsync("sauce-labs-backpack");

        await Expect(_productsPage.CartBadge).ToHaveTextAsync("1");

        await _productsPage.OpenCartAsync();
        await Expect(_cartPage.ItemNames).ToHaveTextAsync("Sauce Labs Backpack");
    }

    [Test]
    [Category("Regression")]
    public async Task Logout_ReturnsToLoginPage()
    {
        await _productsPage.LogoutAsync();

        await Expect(_loginPage.LoginButton).ToBeVisibleAsync();
    }
}