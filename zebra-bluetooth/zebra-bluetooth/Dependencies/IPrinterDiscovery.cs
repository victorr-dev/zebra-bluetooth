using LinkOS.Plugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace zebra_bluetooth.Dependencies
{
    public interface IPrinterDiscovery
    {
        void FindBluetoothPrinters(IDiscoveryHandler handler);
        void CancelDiscovery();

    }
}
