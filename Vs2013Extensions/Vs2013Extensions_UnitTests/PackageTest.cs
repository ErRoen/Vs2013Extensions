﻿/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

using ErR.Vs2013Extensions;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VsSDK.UnitTestLibrary;

namespace Vs2013Extensions_UnitTests
{
	[TestClass()]
	public class PackageTest
	{
		[TestMethod()]
		public void CreateInstance()
		{
			Vs2013ExtensionsPackage package = new Vs2013ExtensionsPackage();
		}

		[TestMethod()]
		public void IsIVsPackage()
		{
			Vs2013ExtensionsPackage package = new Vs2013ExtensionsPackage();
			Assert.IsNotNull(package as IVsPackage, "The object does not implement IVsPackage");
		}

		[TestMethod()]
		public void SetSite()
		{
			// Create the package
			IVsPackage package = new Vs2013ExtensionsPackage() as IVsPackage;
			Assert.IsNotNull(package, "The object does not implement IVsPackage");

			// Create a basic service provider
			OleServiceProvider serviceProvider = OleServiceProvider.CreateOleServiceProviderWithBasicServices();

			// Site the package
			Assert.AreEqual(0, package.SetSite(serviceProvider), "SetSite did not return S_OK");

			// Unsite the package
			Assert.AreEqual(0, package.SetSite(null), "SetSite(null) did not return S_OK");
		}
	}
}
