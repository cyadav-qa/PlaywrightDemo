using Microsoft.Playwright;

namespace PlaywrightDemo.Pages;

public class ProductsPage
{
    private readonly IPage _page;

    public ProductsPage(IPage page)
    {
        _page = page;
    }

    public ILocator Title => _page.Locator("[data-test='title']");
    public ILocator CartBadge => _page.Locator("[data-test='shopping-cart-badge']");

    public async Task AddToCartAsync(string productSlug)
    {
        await _page.Locator($"[data-test='add-to-cart-{productSlug}']").ClickAsync();
    }

    public async Task OpenCartAsync()
    {
        await _page.Locator(".shopping_cart_link").ClickAsync();
        await _page.WaitForURLAsync("**/cart.html");
    }

    public async Task LogoutAsync()
    {
        await _page.Locator("#react-burger-menu-btn").ClickAsync();
        await _page.Locator("[data-test='logout-sidebar-link']").ClickAsync();
    }
}