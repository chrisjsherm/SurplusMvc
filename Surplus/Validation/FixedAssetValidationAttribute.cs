using Surplus.DataAccess;
using Surplus.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Configuration;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net;

namespace Surplus.Validation
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class FixedAssetValidationAttribute : ValidationAttribute
    {
        public static ValidationResult HasValidFixedAssetQuantity(SurplusRequest surplusRequest)
        {
            var barcode = surplusRequest.VTBarcode;
            if (barcode == WebConfigurationManager
                .AppSettings["notFixedAssetSentinel"])
            {
                return ValidationResult.Success;
            }
            else if (surplusRequest.Quantity == 1)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Fixed assets must have a " +
                "quantity of (1).",
                new List<string>() { "Quantity" });
        }

        public static ValidationResult HasValidFixedAssetQuantityDescription(SurplusRequest surplusRequest)
        {
            var barcode = surplusRequest.VTBarcode;
            if (barcode == WebConfigurationManager
                .AppSettings["notFixedAssetSentinel"])
            {
                return ValidationResult.Success;
            }
            else if (surplusRequest.QuantityDescriptionId.ToString().ToUpper() ==
                WebConfigurationManager
                .AppSettings["validFixedAssetQuantityDescriptionId"].ToUpper())
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Fixed assets must have a " +
                "quantity description of \"Each.\"",
                new List<string>() { "QuantityDescriptionId" });
        }

        public static ValidationResult FixedAssetWithVTTitleExists(string barcode)
        {
            // Check if the user left the VT# field as N/A.
            if (barcode == WebConfigurationManager
                .AppSettings["notFixedAssetSentinel"])
            {
                return ValidationResult.Success;
            }

            // Query the database to see if VT has title.
            var db = new SurplusDbContext();

            var fixedAsset = db.FixedAssets
                .FirstOrDefault(a => a.AssetNumber == barcode);

            // Check if VT has title.
            if (fixedAsset != null &&
                !String.IsNullOrWhiteSpace(fixedAsset.TitleCode))
            {
                switch (fixedAsset.TitleCode)
                {
                    case "A":
                    case "C":
                    case "T":
                    case "V":
                    case "E":
                        return ValidationResult.Success;
                }
            }

            // VT does not have title. Return error message.
            var errorMessage = "Virginia Tech does not have title " +
                "to a fixed asset with the number " +
                barcode;

            if (fixedAsset != null &&
                !String.IsNullOrWhiteSpace(fixedAsset.TitleDescription))
            {
                errorMessage += " (" +
                    fixedAsset.TitleDescription + ").";
            }
            else
            {
                errorMessage += " and no fixed asset matching this " +
                    "number was found. Enter a valid asset number " +
                    "or \"N/A\" if the item is not a tagged asset.";
            }

            return new ValidationResult(errorMessage,
                new List<string>() { "VTBarcode" });
        }
    }

    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
                actionContext.ModelState.AddModelError("VTBarcode", "Farts");

                actionContext.Response = actionContext.Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest, actionContext.ModelState);
        }
    }
}