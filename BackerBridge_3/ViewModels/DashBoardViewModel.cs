using BackerBridge_3.Models;
using BackerBridge_3.Views.BackerBridge_3.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BackerBridge_3.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        private readonly DashboardModel _dashboardModel;

        // Properties to bind to the view
        public DashboardStatistics Statistics { get; set; }
        public ObservableCollection<string> RecentActivities { get; set; }
        public ObservableCollection<KeyCampaignItem> KeyCampaigns { get; set; }
        public ObservableCollection<TopDonorItem> TopDonors { get; set; }

        // Command to refresh data
        public ICommand RefreshDataCommand { get; }

        public DashboardViewModel()
        {
            _dashboardModel = new DashboardModel();
            RecentActivities = new ObservableCollection<string>();
            KeyCampaigns = new ObservableCollection<KeyCampaignItem>();
            TopDonors = new ObservableCollection<TopDonorItem>();

            RefreshDataCommand = new RelayCommand(LoadDashboardData);

            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            // Load statistics
            Statistics = _dashboardModel.GetStatistics();

            // Load recent activities
            var activities = _dashboardModel.GetRecentActivities();
            RecentActivities.Clear();
            foreach (var activity in activities)
            {
                RecentActivities.Add(activity);
            }

            // Load key campaigns
            var campaigns = _dashboardModel.GetKeyCampaigns();
            KeyCampaigns.Clear();
            foreach (var campaign in campaigns)
            {
                KeyCampaigns.Add(campaign);
            }

            // Load top donors
            var donors = _dashboardModel.GetTopDonors();
            TopDonors.Clear();
            foreach (var donor in donors)
            {
                TopDonors.Add(donor);
            }
        }
    }
}
