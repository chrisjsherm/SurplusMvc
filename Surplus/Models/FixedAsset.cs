using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Surplus.Models
{
    public class FixedAsset
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(9)]
        public string AssetNumber { get; set; }

        [StringLength(10)]
        public string TitleCode { get; set; }

        [StringLength(200)]
        public string TitleDescription { get; set; }
    }
}