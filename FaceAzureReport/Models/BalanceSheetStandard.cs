using Stylet;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceAzureReport.Models
{
    public class BalanceSheetStandard
    {
        public BalanceSheetStandard()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; }

        public int? Space1 { get; set; }

        public int? LineNumber { get; set; }

        public string RowType { get; set; } = string.Empty;

        public string TextRow1 { get; set; } = string.Empty;

        public string TextRow2 { get; set; } = string.Empty;

        public string TextRow3 { get; set; } = string.Empty;

        public string TextRow4 { get; set; } = string.Empty;

        public string TextRow5 { get; set; } = string.Empty;

        public string TextRow6 { get; set; } = string.Empty;

        public string TextRow7 { get; set; } = string.Empty;

        public string ObjectName { get; set; } = string.Empty;

        public int? ObjectNameWithLevel { get; set; }

        public string Column1 { get; set; } = string.Empty;

        public decimal? Column2 { get; set; }

        public int? Space2 { get; set; }

        public object? this[string propertyName]
        {
            get => this.GetType().GetProperty(propertyName)?.GetValue(this);
            set => this.GetType().GetProperty(propertyName)?.SetValue(this, value);
        }

        public int GetParentLevel()
        {
            if (!string.IsNullOrEmpty(TextRow1))
                return 0;

            if (!string.IsNullOrEmpty(TextRow2))
                return 1;

            if (!string.IsNullOrEmpty(TextRow3))
                return 2;

            if (!string.IsNullOrEmpty(TextRow4))
                return 3;

            if (!string.IsNullOrEmpty(TextRow5))
                return 4;

            if (!string.IsNullOrEmpty(TextRow6))
                return 5;

            if (!string.IsNullOrEmpty(TextRow7))
                return 6;

            return 0;
        }
    }
}
