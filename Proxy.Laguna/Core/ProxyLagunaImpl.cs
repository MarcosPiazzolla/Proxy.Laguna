using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Win32;

namespace Proxy.Laguna.Proxy.Laguna.Core
{
  class ProxyLagunaImpl : ProxyLaguna
  {
    private RegistryKey chaveDeRegistro;

    public ProxyLagunaImpl(Microsoft.Win32.RegistryKey chaveDeRegistro)
    {
      this.chaveDeRegistro = chaveDeRegistro;
    }

    public void AtualizarValorDeChave()
    {
      object valorChave = chaveDeRegistro.GetValue("ProxyEnable");

      if (valorChave.Equals(1))
      {
        chaveDeRegistro.SetValue("ProxyEnable", 0);
      }

      chaveDeRegistro.SetValue("ProxyEnable", 1);//we need to set the registry permissions here....
    }
  }
}