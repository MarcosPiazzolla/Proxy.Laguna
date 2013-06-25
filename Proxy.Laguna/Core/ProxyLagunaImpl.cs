using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace Proxy.Laguna.Proxy.Laguna.Core
{
  class ProxyLagunaImpl : ProxyLaguna
  {
    [DllImport("wininet.dll")]
    public static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int dwBufferLength);
    public const int INTERNET_OPTION_SETTINGS_CHANGED = 39;
    public const int INTERNET_OPTION_REFRESH = 37;
    bool settingsReturn, refreshReturn;

    private RegistryKey chaveDeRegistro;

    public ProxyLagunaImpl(RegistryKey chaveDeRegistro)
    {
      this.chaveDeRegistro = chaveDeRegistro;
    }
    
    public void AtualizarValorDeChave()
    {
      object valorChave = chaveDeRegistro.GetValue("ProxyEnable");

      if (valorChave.Equals(1))
      {
        chaveDeRegistro.SetValue("ProxyEnable", 0);
        AtualizaRegistro();
        return;
      }
      
      chaveDeRegistro.SetValue("ProxyEnable", 1);
      AtualizaRegistro();
    }

    private void AtualizaRegistro()
    {
      settingsReturn = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_SETTINGS_CHANGED, IntPtr.Zero, 0);
      refreshReturn = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_REFRESH, IntPtr.Zero, 0);
    }
  }
}