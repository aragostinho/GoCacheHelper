using System;
using GoCacheHelper.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoCacheHelper.Tests
{
    [TestClass]
    public class TestGoCacheHelper
    {

        [TestMethod]
        public void RemoveCacheFromOneUrl()
        {
            GoCacheService goCacheService = new GoCacheService();
            var response = goCacheService.Remove("https://cdn.magnadev.com.br/EmpresaPerfil/125/Logo/portrait_g.jpg");
            Assert.IsTrue(response.CacheExpired);
        }

        [TestMethod]
        public void RemoveCacheFromManyUrls()
        {
            GoCacheService goCacheService = new GoCacheService();
            string[] urls = new string[3];
            urls[0] = "https://cdn.magnadev.com.br/EmpresaPerfil/125/Logo/portrait_g.jpg";
            urls[1] = "https://cdn.magnadev.com.br/UsuarioPerfil/335/Fotos/portrait_g.jpg";
            urls[2] = "https://cdn.magnadev.com.br/EmpresaPerfil/125/Fotos/fe322a10-f549-4381-8e80-809c79cf01c9-t.jpg";
            var response = goCacheService.Remove(urls);
            Assert.IsTrue(response.CacheExpired);
        }

    }
}
