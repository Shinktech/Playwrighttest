﻿using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest
{
    [SetUp]
    public async Task Setup()
    {
        await Page.GotoAsync(url: "http://www.eaapp.somee.com");
    }

    [Test]
    public async Task Test1()
    {
        await Page.ClickAsync(selector: "text=Login");
        await Page.FillAsync(selector: "#UserName", value: "admin");
        await Page.FillAsync(selector: "#Password", value: "password");
        await Page.ClickAsync(selector: "text=Log in");
        await Expect(Page.Locator(selector: "text='Log off'")).ToBeVisibleAsync();

    }
}