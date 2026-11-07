# PlaywrightDemo: UI + API Test Automation

Test automation framework built with **Playwright, C# and NUnit**.
UI tests run on [saucedemo.com](https://www.saucedemo.com) and API tests on [jsonplaceholder](https://jsonplaceholder.typicode.com).

## Features
- Page Object Model (`Pages/`)
- Data-driven tests with `[TestCase]`
- Test categories: Smoke, Regression, Api
- Centralised config (`Config/TestConfig.cs`)
- CI with GitHub Actions: tests run on every push

## Project structure
```
PlaywrightDemo/
  Config/   -> URLs and test data
  Pages/    -> Page objects (LoginPage, ProductsPage, CartPage)
  Tests/    -> LoginTests, CartTests, ApiTests
.github/workflows/playwright.yml
```

## Tests (9)
| Area | Tests |
|---|---|
| Login | 1 valid, 4 invalid (data-driven) |
| Cart | Add to cart, logout |
| API | GET post, POST post |

## How to run
```
dotnet build
pwsh PlaywrightDemo/bin/Debug/net10.0/playwright.ps1 install
dotnet test
```
Run by category:
```
dotnet test --filter "Category=Smoke"
```

## Tech
C#, .NET 10, NUnit, Playwright for .NET, GitHub Actions
