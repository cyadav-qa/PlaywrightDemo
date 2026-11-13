using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace PlaywrightDemo.Tests;

[TestFixture]
public class InternetTests : PageTest
{
    private const string BaseUrl = "https://the-internet.herokuapp.com";

    [Test]
    [Category("Regression")]
    public async Task Checkbox_CanBeChecked()
    {
        await Page.GotoAsync(BaseUrl + "/checkboxes");

        var first = Page.Locator("input[type='checkbox']").First;
        await first.CheckAsync();

        await Expect(first).ToBeCheckedAsync();
    }

    [Test]
    [Category("Regression")]
    public async Task Dropdown_SelectOption2()
    {
        await Page.GotoAsync(BaseUrl + "/dropdown");

        await Page.Locator("#dropdown").SelectOptionAsync("2");

        await Expect(Page.Locator("#dropdown")).ToHaveValueAsync("2");
    }

    [Test]
    [Category("Regression")]
    public async Task JsAlert_AcceptShowsSuccess()
    {
        await Page.GotoAsync(BaseUrl + "/javascript_alerts");

        Page.Dialog += async (_, dialog) => await dialog.AcceptAsync();
        await Page.GetByRole(AriaRole.Button, new() { Name = "Click for JS Alert" }).ClickAsync();

        await Expect(Page.Locator("#result")).ToContainTextAsync("successfully clicked an alert");
    }
}