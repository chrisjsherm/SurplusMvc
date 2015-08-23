using Surplus.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Surplus.Models
{
    [CustomValidation(typeof(FixedAssetValidationAttribute), "HasValidFixedAssetQuantity")]
    [CustomValidation(typeof(FixedAssetValidationAttribute), "HasValidFixedAssetQuantityDescription")]
    public class SurplusRequest
    {
        public SurplusRequest()
        {
            VTBarcode = WebConfigurationManager
                .AppSettings["notFixedAssetSentinel"];
            Quantity = 1;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [StringLength(200)]
        public string UserName { get; set; }

        [Required]
        [CustomValidation(typeof(FixedAssetValidationAttribute),
            "FixedAssetWithVTTitleExists")]
        [StringLength(9)]
        [Display(Name = "Virginia Tech asset number")]
        public string VTBarcode { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [StringLength(35)]
        public string Manufacturer { get; set; }

        [StringLength(30)]
        public string Model { get; set; }

        [StringLength(40)]
        [Display(Name = "Serial number")]
        public string SerialNumber { get; set; }

        [Range(0, Int16.MaxValue)]
        public int Quantity { get; set; }

        [Display(Name = "Quantity description")]
        public Guid QuantityDescriptionId { get; set; }

        public QuantityDescription QuantityDescription { get; set; }

        [DataType(DataType.Currency)]
        [Range(0, Int32.MaxValue)]
        [Display(Name = "Estimated value")]
        public int? EstimatedValue { get; set; }

        [Display(Name = "Condition")]
        public Guid ItemConditionId { get; set; }

        public ItemCondition ItemCondition { get; set; }

        [Required]
        [StringLength(6, MinimumLength = 6,
            ErrorMessage = DEPARTMENT_NUMBER_ERROR_MSG)]
        [RegularExpression(NUMERIC_ONLY_NO_SPACES_REGEX,
            ErrorMessage = DEPARTMENT_NUMBER_ERROR_MSG)]
        [Display(Name = "Organization code")]
        public string DepartmentNumber { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Department description")]
        public string DepartmentDescription { get; set; }

        [Required]
        [StringLength(200)]
        public string Building { get; set; }

        [Required]
        [Display(Name = "Room")]
        [StringLength(200)]
        public string FloorLevel { get; set; }

        [Required]
        [Display(Name = "Contact name")]
        [StringLength(200)]
        public string ContactName { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Contact phone")]
        [StringLength(14)]
        public string ContactPhone { get; set; }

        [Required]
        [Display(Name = "Authorizer name")]
        [StringLength(200)]
        public string AuthorizerName { get; set; }

        [StringLength(500)]
        [Display(Name = "Additional details")]
        public string AdditionalDetails { get; set; }

        private const string ACCOUNTING_FUND_ERROR_MSG =
            "A six digit accounting fund is required.";
        private const string DEPARTMENT_NUMBER_ERROR_MSG =
            "A six digit organization code is required.";
        private const string NUMERIC_ONLY_NO_SPACES_REGEX = @"^\d+$";
    }
}