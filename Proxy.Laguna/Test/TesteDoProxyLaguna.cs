using System;
using Microsoft.Win32;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proxy.Laguna.Proxy.Laguna.Core;

namespace Proxy.Laguna.Test
{
  [TestClass]
  public class TesteDoProxyLaguna
  {
    private ProxyLaguna proxy;
    private const string caminho = @"Software\Microsoft\Windows\CurrentVersion\Internet Settings";

     [TestMethod]
     public void GetRegistryKeys()
     {
       RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(caminho);

       Assert.AreEqual(registryKey.GetValue("ProxyEnable"), 0);
     }

     [TestMethod]
     public void DeveAlterarValorDoRegistro()
     {
       RegistryKey chaveDeRegistro = Registry.CurrentUser.OpenSubKey(caminho, true);
       object antes = chaveDeRegistro.GetValue("ProxyEnable");

       Assert.AreEqual(antes, 0);

       proxy = new ProxyLagunaImpl(chaveDeRegistro);
       proxy.AtualizarValorDeChave();

       object depois = chaveDeRegistro.GetValue("ProxyEnable");

       Assert.AreEqual(depois, 1);
     }
  }
}