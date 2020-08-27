using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Bluetooth;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;
using LinkOS.Plugin;
using LinkOS.Plugin.Abstractions;
using zebra_bluetooth.Dependencies;
using zebra_bluetooth.Droid.Dependencies;

[assembly: Xamarin.Forms.Dependency(typeof(PrinterDiscovery))]
namespace zebra_bluetooth.Droid.Dependencies
{
    public class PrinterDiscovery : IPrinterDiscovery
    {
        public PrinterDiscovery() { }

        public void CancelDiscovery()
        {
            if (BluetoothAdapter.DefaultAdapter.IsDiscovering)
            {
                BluetoothAdapter.DefaultAdapter.CancelDiscovery();
                System.Diagnostics.Debug.WriteLine("Cancelling Discovery");
            }
        }

        public void FindBluetoothPrinters(IDiscoveryHandler handler)
        {
            const string permission = Manifest.Permission.AccessCoarseLocation;
            if (ContextCompat.CheckSelfPermission(Android.App.Application.Context, permission) == (int)Permission.Granted)
            {
                BluetoothDiscoverer.Current.FindPrinters(Android.App.Application.Context, handler);
                return;
            }
            TempHandler = handler;
            //Finally request permissions with the list of permissions and Id
            ActivityCompat.RequestPermissions(MainActivity.GetActivity(), PermissionsLocation, RequestLocationId);
        }
        public static IDiscoveryHandler TempHandler { get; set; }

        public readonly string[] PermissionsLocation =
        {
          Manifest.Permission.AccessCoarseLocation
        };
        public const int RequestLocationId = 0;



        public void FindUSBPrinters(IDiscoveryHandler handler)
        {
            // UsbDiscoverer.Current.FindPrinters(Android.App.Application.Context, handler);
        }

        public void RequestUSBPermission(IDiscoveredPrinterUsb printer)
        {
            //if (!printer.HasPermissionToCommunicate)
            //{
            //    printer.RequestPermission(Android.App.Application.Context);
            //}
        }
    }
}