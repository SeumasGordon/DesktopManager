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

namespace DesktopManager{
    class Viewer : INotifyPropertyChanged {
        public Viewer() {
            var ticker = new DispatcherTimer { Interval = TimeSpan.FromSeconds(SettingsOptions.RefreshTime) };
            ticker.Tick += UpdateProcess;
            ticker.Start();
        }

        private Process selProcess;
        public Process SelectProcess {
            get => selProcess;
            set {
                selProcess = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ProcessItem> ProcessItems { get; } = new ObservableCollection<ProcessItem>();

        private int processCount;
        public int ProcessCount
        {
            get => processCount;
            set
            {
                processCount = value;
                OnPropertyChanged();
            }
        }

        private decimal GetUsedMemory()
        {
            Int64 phav = PerformanceInfoClass.GetPhysAvailableMemory();
            Int64 tot = PerformanceInfoClass.GetTotalMemory();
            decimal percentFree = ((decimal)phav / (decimal)tot) * 100;
            decimal percentOccupied = 100 - percentFree;
            percentOccupied = Decimal.Round(percentOccupied, 1);
            return percentOccupied;
        }

        
        public string UsedMemory{
            get => GetUsedMemory().ToString() + "%";
            set
            {
                UsedMemory = value;
                OnPropertyChanged();
            }
        }

        public void UpdateProcess(object sender, EventArgs e){
            var currentIds = ProcessItems.Select(processes => processes.Id).ToList();
            var processlist = Process.GetProcesses();
            ProcessCount = processlist.Length;

            foreach (var p in processlist){
                if (!currentIds.Remove(p.Id))
                    ProcessItems.Add(new ProcessItem(p));
            }

            foreach (var id in currentIds){
                var process = ProcessItems.First(p => p.Id == id);
                ProcessItems.Remove(process);
            }
        }

        public void KillProcess(){//Kill a process
            SelectProcess.Kill();
        }

        #region EventHandler
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null){
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion


    }
}
