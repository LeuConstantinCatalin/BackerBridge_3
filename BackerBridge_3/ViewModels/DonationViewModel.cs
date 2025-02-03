using BackerBridge_3.Views.BackerBridge_3.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BackerBridge_3.Models.UsersModel;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace BackerBridge_3.ViewModels
{
    public class DonationViewModel : BaseViewModel, IDataErrorInfo, INotifyPropertyChanged
    {
        private readonly int _campaignId;
        private readonly UsersViewModel _usersViewModel;

        public event Action RequestClose;
        public event Action DonationCompleted;

        public ObservableCollection<string> RecurringFrequencies { get; set; }

        public DonationViewModel(int campaignId, UsersViewModel usersViewModel)
        {
            _campaignId = campaignId;
            _usersViewModel = usersViewModel;

            RecurringFrequencies = new ObservableCollection<string>
            {
                "Weekly",
                "Monthly"
            };

            SubmitCommand = new RelayCommand(SubmitDonation, () => IsFormValid);
            CancelCommand = new RelayCommand(Cancel);

            DonationTypes = new List<string> { "One-Time", "Recurring" };
            SelectedDonationType = DonationTypes.First();
        }

        // Properties with PropertyChanged notification
        private string _cardNumber;
        public string CardNumber
        {
            get => _cardNumber;
            set
            {
                if (_cardNumber != value)
                {
                    _cardNumber = value;
                    OnPropertyChanged(nameof(CardNumber));
                }
            }
        }

        private string _expiryDate;
        public string ExpiryDate
        {
            get => _expiryDate;
            set
            {
                if (_expiryDate != value)
                {
                    _expiryDate = value;
                    OnPropertyChanged(nameof(ExpiryDate));
                }
            }
        }

        private string _cardHolderName;
        public string CardHolderName
        {
            get => _cardHolderName;
            set
            {
                if (_cardHolderName != value)
                {
                    _cardHolderName = value;
                    OnPropertyChanged(nameof(CardHolderName)); // Notify the UI about the change
                }
            }
        }

        private string _cvv;
        public string CVV
        {
            get => _cvv;
            set
            {
                if (_cvv != value)
                {
                    _cvv = value;
                    OnPropertyChanged(nameof(CVV));
                }
            }
        }

        private string _donationMessage;
        public string DonationMessage
        {
            get => _donationMessage;
            set
            {
                if (_donationMessage != value)
                {
                    _donationMessage = value;
                    OnPropertyChanged(nameof(DonationMessage));
                }
            }
        }

        private decimal _amount;
        public decimal Amount
        {
            get => _amount;
            set
            {
                if (_amount != value)
                {
                    _amount = value;
                    OnPropertyChanged(nameof(Amount));
                }
            }
        }

        private string _selectedDonationType;
        public string SelectedDonationType
        {
            get => _selectedDonationType;
            set
            {
                if (_selectedDonationType != value)
                {
                    _selectedDonationType = value;
                    OnPropertyChanged(nameof(SelectedDonationType));
                }
            }
        }

        public List<string> DonationTypes { get; }

        public bool IsFormValid => string.IsNullOrEmpty(Error);

        // Commands
        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        private void SubmitDonation()
        {
            var currentUser = _usersViewModel.Users.FirstOrDefault();
            if (currentUser == null) return;

            var donation = new Donations
            {
                UserID = currentUser.UserID,
                CampaignID = _campaignId,
                DonationDate = DateTime.Now,
                DonationMessage = DonationMessage,
                DonationType = SelectedDonationType,
                DonationStatus = "Completed"
            };

            using (var context = new BackerBridgeEntities())
            {
                context.Donations.Add(donation);
                context.SaveChanges();

                var campaign = context.Campaign.Find(_campaignId);
                campaign.CurrentAmount += (double)Amount;
                context.SaveChanges();
            }

            DonationCompleted?.Invoke();
            RequestClose?.Invoke();
        }

        private void Cancel() => RequestClose?.Invoke();

        // Validation
        public string Error => this[nameof(CardNumber)] ?? this[nameof(ExpiryDate)] ?? this[nameof(CVV)] ?? this[nameof(Amount)];

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(CardNumber):
                        if (string.IsNullOrWhiteSpace(CardNumber) || !CardNumber.All(char.IsDigit))
                            return "Invalid card number";
                        break;

                    case nameof(ExpiryDate):
                        if (!DateTime.TryParseExact(ExpiryDate, "MM/yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
                            return "Invalid expiry date";
                        break;

                    case nameof(CVV):
                        if (string.IsNullOrWhiteSpace(CVV) || CVV.Length != 3 || !CVV.All(char.IsDigit))
                            return "Invalid CVV";
                        break;

                    case nameof(Amount):
                        if (Amount <= 0)
                            return "Amount must be positive";
                        break;
                }
                return null;
            }
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
