using Discord_Package_Explorer.ViewModels;
using DiscordDataPackageLoader.Classes;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Discord_Package_Explorer
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        MainViewModel ViewModel;
        public MainWindow()
        {
            this.InitializeComponent();
            ViewModel = new MainViewModel();
        }

        private void LoadPackageButton_Click(object sender, RoutedEventArgs e)
        {
            string path = PathInputBox.Text;
            if (Directory.Exists(path))
            {
                var dirs = Directory.GetDirectories(path);
                if(dirs.Contains($"{path}\\account"))
                {
                    LoadProgress.Visibility = Visibility.Visible;
                    Thread t = new Thread(DataPackageManager.LoadGuilds);
                    t.Start(path);
                    DataPackageManager.IsActive = true;
                    Thread d = new Thread(DisplayGuilds);
                    d.Start(path);
                }
            }
        }

        private void DisplayGuilds(object path)
        {
            while (DataPackageManager.IsActive) { }

            this.DispatcherQueue.TryEnqueue(() =>
            {
                ViewModel.Guilds.Add(new Guild() { name = "Direct Messages"});
            });
            foreach (var guild in DataPackageManager.Guilds)
            {
                this.DispatcherQueue.TryEnqueue(() =>
                {
                    ViewModel.Guilds.Add(guild);
                });
            }

            DataPackageManager.LoadAccount(path);

            this.DispatcherQueue.TryEnqueue(() =>
            {
                IdRun.Text = DataPackageManager.UserAccount.id;
                UsernameRun.Text = DataPackageManager.UserAccount.username;
                DiscriminatorRun.Text = DataPackageManager.UserAccount.discriminator.ToString();
                EmailRun.Text = DataPackageManager.UserAccount.email;
                VerifiedRun.Text = DataPackageManager.UserAccount.verified.ToString();
                AvatarHashRun.Text = DataPackageManager.UserAccount.avatar_hash;
                HasMobileRun.Text = DataPackageManager.UserAccount.has_mobile.ToString();
                NeedsEmailVerificationRun.Text = DataPackageManager.UserAccount.needs_email_verification.ToString();
                PremiumUntilRun.Text = DataPackageManager.UserAccount.premium_until.ToString();
                FlagsRun.Text = DataPackageManager.UserAccount.flags.ToString();
                PhoneRun.Text = DataPackageManager.UserAccount.phone;
                IPRun.Text = DataPackageManager.UserAccount.ip;

                UserName.Text = DataPackageManager.UserAccount.username;
                UserIcon.ImageSource = new BitmapImage(new Uri(DataPackageManager.ImagePath));
            });

            foreach (Connection connection in DataPackageManager.UserAccount.connections)
            {
                this.DispatcherQueue.TryEnqueue(() =>
                {
                    ViewModel.Connections.Add(connection);
                });
            }
            foreach (var rel in DataPackageManager.UserAccount.relationships)
            {
                this.DispatcherQueue.TryEnqueue(() =>
                {
                    ViewModel.Relationships.Add(rel);
                });
            }
            foreach (var pay in DataPackageManager.UserAccount.payments)
            {
                this.DispatcherQueue.TryEnqueue(() =>
                {
                    ViewModel.Payments.Add(pay);
                });
            }

            DataPackageManager.LoadMessages(path);

            this.DispatcherQueue.TryEnqueue(() =>
            {
                PackageLoadGrid.Visibility = Visibility.Collapsed;
                LoadProgress.Visibility = Visibility.Collapsed;
            });
        }

        private void GuildsList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var guild = e.ClickedItem as Guild;

            ViewModel.Channels.Clear();

            if (guild.name == "Direct Messages")
            {
                foreach (var channel in DataPackageManager.Messages)
                {
                    if (channel.Key.guild == null)
                    {
                        ViewModel.Channels.Add(channel.Key);
                    }
                }
            }
            else
            {
                foreach (var channel in DataPackageManager.Messages)
                {
                    if (channel.Key.guild != null)
                    {
                        if (channel.Key.guild.id == guild.id)
                        {
                            ViewModel.Channels.Add(channel.Key);
                        }
                    }
                }
            }
        }

        private void ChannelsList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var channel = e.ClickedItem as Channel;

            ViewModel.Messages.Clear();
            foreach (var msg in DataPackageManager.Messages)
            {
                if (msg.Key.id == channel.id)
                {
                    var msglst = new List<Message>(msg.Value);
                    msglst.Reverse();
                    foreach (var message in msglst)
                    {
                        if(message.Attachments == null)
                        {
                            message.Attachments = "";
                        }
                        ViewModel.Messages.Add(message);
                    }
                    break;
                }
            }
            try
            {
                MessagesList.ScrollIntoView(ViewModel.Messages.Last());
            }
            catch (Exception ex)
            {

            }
        }

        private void UserInfoButton_Click(object sender, RoutedEventArgs e)
        {
            ActivityGrid.Visibility = Visibility.Visible;
        }

        private void ClosePanelButton_Click(object sender, RoutedEventArgs e)
        {
            ActivityGrid.Visibility = Visibility.Collapsed;
        }
    }
}
