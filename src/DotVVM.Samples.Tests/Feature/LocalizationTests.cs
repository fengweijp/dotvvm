﻿using Dotvvm.Samples.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Riganti.Utils.Testing.SeleniumCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotVVM.Samples.Tests.Feature
{
    [TestClass]
    public class LocalizationTests : SeleniumTestBase
    {
        [TestMethod]
        public void Feature_Localization()
        {
            RunInAllBrowsers(browser =>
            {
                browser.NavigateToUrl(SamplesRouteUrls.FeatureSamples_Localization_Localization);

                ChangeAndTestLocalization(browser);
            });
        }

        private static void ChangeAndTestLocalization(BrowserWrapper browser)
        {
            browser.First("p").CheckIfInnerTextEquals("This comes from resource file!", false, true);
            // change language
            browser.Last("a").Click();
            browser.First("p").CheckIfInnerTextEquals("Tohle pochází z resource souboru!", false, true);
        }

        [TestMethod]
        public void Feature_Localization_ResourceTypeAndNamespaceDirectives()
        {
            RunInAllBrowsers(browser =>
            {
                browser.NavigateToUrl(SamplesRouteUrls.FeatureSamples_Localization_Localization_ResourceTypeAndNamespaceDirectives);

                browser.First("h1")
                    .CheckIfInnerText(s => s.Contains("Server Error"),
                        "Element should contain 'Server Error', because directives cannot be combined.");
                browser.First(".exceptionMessage").CheckIfInnerTextEquals("@resourceType and @resourceNamespace directives cannot be used in the same time!", false);
            });
        }
        [TestMethod]
        public void Feature_Localization_ResourceNamespaceDirective()
        {
            RunInAllBrowsers(browser =>
            {
                browser.NavigateToUrl(SamplesRouteUrls.FeatureSamples_Localization_Localization_ResourceNamespaceDirective);

                ChangeAndTestLocalization(browser);
            });
        }
        [TestMethod]
        public void Feature_Localization_ResourceTypeDirectives()
        {
            RunInAllBrowsers(browser =>
            {
                browser.NavigateToUrl(SamplesRouteUrls.FeatureSamples_Localization_Localization_ResourceTypeDirective);

                ChangeAndTestLocalization(browser);
            });
        }
    }
}
