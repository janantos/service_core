# service_core
## .NET Core Windows service using Microsoft.Windows.Compatibility
Simple example of self installing Windows service. While Microsoft.Windows.Compatibility does not implement Installer, installutil.exe can't be used for installing service. Install and uninstall process is made by SC.EXE
