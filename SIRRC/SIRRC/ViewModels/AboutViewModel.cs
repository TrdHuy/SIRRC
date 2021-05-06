using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SIRRC.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        IBluetoothLE ble;
        IAdapter adapter;
        ObservableCollection<IDevice> devices;

        public AboutViewModel()
        {
            ble = CrossBluetoothLE.Current;
            adapter = ble.Adapter;
            devices = new ObservableCollection<IDevice>();

            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
            ScanDeviceCommand = new Command(async (paramater) => {
                devices.Clear();
                adapter.DeviceDiscovered += (s, a) =>
                {
                    devices.Add(a.Device);
                };
                await adapter.StartScanningForDevicesAsync();
            });

            //LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        public ICommand OpenWebCommand { get; }

        public ICommand ScanDeviceCommand { get; }

        public Command LoadItemsCommand { get; }

        //async Task ExecuteLoadItemsCommand()
        //{
        //    IsBusy = true;

        //    try
        //    {
        //        devices.Clear();
        //        var items = await DataStore.GetItemsAsync(true);
        //        foreach (var item in items)
        //        {
        //            Items.Add(item);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex);
        //    }
        //    finally
        //    {
        //        IsBusy = false;
        //    }
        //}
    }
}