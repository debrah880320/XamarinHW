using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlankApp3.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService navigationService;
        public string Question { get; set; }
        public int? Answer { get; set; }
        public string IsCorrect { get; set; }
        public DelegateCommand BtnCmdReCreate { get; set; }
        public DelegateCommand BtnCmdCheck { get; set; }
        private int firstNum;
        private int secondNum;
        private Random random = new Random();

        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            BtnCmdCheck = new DelegateCommand(OnCheckButtonClick);
            BtnCmdReCreate = new DelegateCommand(OnReCreateButtonClick);
            firstNum = random.Next(0,10);
            secondNum = random.Next(0,10);
            Question = $"數值{firstNum}+數值{secondNum}=?";

        }

        private void OnReCreateButtonClick()
        {
            firstNum = random.Next(0, 10);
            secondNum = random.Next(0, 10);
            Question = $"數值{firstNum}+數值{secondNum}=?";

        }

        private void OnCheckButtonClick()
        {
            if (Answer == null)
            {
                IsCorrect = "請輸入答案";
                return;
            }
            if (firstNum+secondNum == Answer)
                IsCorrect = "你的答案是正確的";
            else
                IsCorrect = "你的答案是錯誤的";
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
        }

    }
}
