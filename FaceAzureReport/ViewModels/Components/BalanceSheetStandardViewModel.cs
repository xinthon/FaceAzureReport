using FaceAzureReport.Models.Dto;
using FaceAzureReport.Services;
using Stylet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace FaceAzureReport.ViewModels.Components
{
    public class BalanceSheetStandardViewModel : Screen
    {
        private readonly ReportBalanceSheetStandardService _reportBalanceSheetStandardService;
        private readonly ObservableCollection<BalanceSheetStandardDto> _balanceSheetStandardCollection;

        public ObservableCollection<BalanceSheetStandardDto> BalanceSheetStandardCollection => _balanceSheetStandardCollection;

        public BalanceSheetStandardViewModel(ReportBalanceSheetStandardService reportBalanceSheetStandardService)
        {
            _balanceSheetStandardCollection = new ObservableCollection<BalanceSheetStandardDto>();
            _reportBalanceSheetStandardService = reportBalanceSheetStandardService;
        }


        protected override void OnViewLoaded()
        {
            base.OnViewLoaded();
            this.InitializeData();
        }

        private async void InitializeData()
        {
            try
            {
                var balanceSheetStandards = await _reportBalanceSheetStandardService.GetReportBalanceSheetStandard();
                var balanceSheetStandardCollection = balanceSheetStandards.OrderBy(_ => _.LineNumber);

                var parentTreeID = new Dictionary<int, string>();

                foreach (var balanceSheetStandard in balanceSheetStandardCollection)
                {
                    var currentLevel = balanceSheetStandard.GetParentLevel() + 1;

                    if (!parentTreeID.ContainsKey(currentLevel))
                    {
                        parentTreeID.Add(currentLevel, balanceSheetStandard.Id);
                    }
                    else
                    {
                        parentTreeID[currentLevel] = balanceSheetStandard.Id;
                    }

                    if (currentLevel < balanceSheetStandard.GetParentLevel())
                    {
                        parentTreeID[balanceSheetStandard.GetParentLevel() - 1] = balanceSheetStandard.Id;
                    }

                    var balanceSheetStandardDto = new BalanceSheetStandardDto()
                    {
                        Id = balanceSheetStandard.Id,
                        Column1 = (string)balanceSheetStandard[$"TextRow{currentLevel}"]!,
                        Column2 = balanceSheetStandard.Column2,
                    };

                    if (balanceSheetStandard.GetParentLevel() == 0)
                    {
                        balanceSheetStandardDto.ParentId = "Root element";
                    }
                    else
                    {
                        balanceSheetStandardDto.ParentId = parentTreeID[balanceSheetStandard.GetParentLevel()];
                    }

                    _balanceSheetStandardCollection.Add(balanceSheetStandardDto);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
