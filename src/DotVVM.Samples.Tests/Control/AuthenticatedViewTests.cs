﻿using Dotvvm.Samples.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Riganti.Utils.Testing.SeleniumCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotVVM.Samples.Tests.Control
{
    [TestClass]
    public class AuthenticatedViewTests : SeleniumTestBase
    {

        [TestMethod]
        public void AuthenticatedViewTest()
        {
            RunInAllBrowsers(browser =>
            {
                browser.NavigateToUrl(SamplesRouteUrls.ControlSamples_AuthenticatedView_AuthenticatedViewTest);

                // make sure we are signed out
                browser.First("input[value='Sign Out']").Click().Wait();

                browser.First(".result").CheckIfInnerTextEquals("I am not authenticated!");
                browser.First("input[value='Sign In']").Click().Wait();
                browser.First(".result").CheckIfInnerTextEquals("I am authenticated!");
                browser.First("input[value='Sign Out']").Click().Wait();
                browser.First(".result").CheckIfInnerTextEquals("I am not authenticated!");
            });
        }

    }
}
