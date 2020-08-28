using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using DesktopManager.Annotations;

namespace DesktopManager
{
    class Viewer : INotifyPropertyChanged
    {
        public Viewer()
        {
            var ticker = new DispatcherTimer { Interval = TimeSpan.FromSeconds(5) };
            ticker.Tick += UpdateProcess;
            ticker.Start();
        }

        private Process selProcess;
        public Process SelectProcess
        {
            get => selProcess;
            set
            {
                selProcess = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ProcessItem> ProcessItems { get; } = new ObservableCollection<ProcessItem>();

        public void UpdateProcess(object sender, EventArgs e)
        {
            var currentIds = ProcessItems.Select(processes => processes.Id).ToList();

            foreach (var p in Process.GetProcesses())
            {
                if (!currentIds.Remove(p.Id))
                {
                    ProcessItems.Add(new ProcessItem(p));
                }
            }

            foreach (var id in currentIds)
            {
                var process = ProcessItems.First(p => p.Id == id);
                ProcessItems.Remove(process);
            }
        }

        public void KillProcess()
        {
            SelectProcess.Kill();
        }

        #region EventHandler
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
