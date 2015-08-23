﻿using System;
using System.Web;
using System.Web.Optimization;

namespace Surplus
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();
            AddDefaultIgnorePatterns(bundles.IgnoreList);

            bundles.Add(
                new StyleBundle("~/css/styles")
                  .Include("~/css/app.css")
            );

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/scripts/modernizrlib").Include(
                        "~/scripts/foundation/js/vendor/modernizr.js"));

            bundles.Add(
                new ScriptBundle("~/scripts/vendor")
                  .Include("~/scripts/foundation/js/vendor/jquery.js")
                  .Include("~/scripts/jquery.validate.js")
                  .Include("~/scripts/jquery.validate.unobtrusive.js")

                  .Include("~/scripts/foundation/js/vendor/fastclick.js")
                  .Include("~/scripts/foundation/js/foundation/foundation.js")
                  .Include("~/scripts/foundation/js/foundation/foundation.reveal.js")

                  .Include("~/scripts/app.js")
            );

        }

        private static void AddDefaultIgnorePatterns(IgnoreList ignoreList)
        {
            if (ignoreList == null)
            {
                throw new ArgumentNullException("BundleConfig ignore list.");
            }

            ignoreList.Ignore("*.intellisense.js");
            ignoreList.Ignore("*-vsdoc.js");
        }
    }
}
