using DiscordDataPackageLoader.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Discord_Package_Explorer.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<Guild> Guilds = new ObservableCollection<Guild>();
        public ObservableCollection<Channel> Channels = new ObservableCollection<Channel>();
        public ObservableCollection<Message> Messages = new ObservableCollection<Message>();
        public ObservableCollection<Connection> Connections = new ObservableCollection<Connection>();
        public ObservableCollection<Relationship> Relationships = new ObservableCollection<Relationship>();
        public ObservableCollection<Payment> Payments = new ObservableCollection<Payment>();
        public ObservableCollection<DiscordEvent> Events = new ObservableCollection<DiscordEvent>();

    }
}
