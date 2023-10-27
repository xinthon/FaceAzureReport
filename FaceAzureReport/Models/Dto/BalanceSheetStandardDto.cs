using Stylet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceAzureReport.Models.Dto
{
    public class BalanceSheetStandardDto : PropertyChangedBase
    {
        [DisplayName(displayName: "Testing")]
        public string Column1 { get; set; } = string.Empty;
        [Display(Name = "")]
        public decimal? Column2 { get; set; }

        public string Id { get; set; } = string.Empty;

        public string ParentId { get; set; } = string.Empty;
    }
}
