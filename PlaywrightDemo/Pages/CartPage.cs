using Microsoft.Playwright;

namespace PlaywrightDemo.Pages;

public class CartPage
{
    private readonly IPage _page;

    public CartPage(IPage page)
    {
        _page = page;
    }

    public ILocator ItemNames => _page.Locator(".cart_item [data-test='inventory-item-name']");
}