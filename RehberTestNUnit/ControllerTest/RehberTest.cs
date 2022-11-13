using System;
using AutoMapper;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using RehberListesiWEBAPI.Controllers;
using RehberListesiWEBAPI.Models;
using RehberListesiWEBAPI.Models.Context;

namespace RehberTestNUnit.ControllerTest
{
	[TestFixture]
	public class RehberTest
	{

		[Test]
		public void TestKisiBilgileri()
		{
			var context = A.Fake<Context>();
			var mapper = A.Fake<IMapper>();
			var rehbers = A.Fake<Rehber>();
			

			var kisiBilgisi = new RehberController(context, mapper);
			var result = kisiBilgisi.KisiBilgileri(5);
			Assert.AreEqual(rehbers, result);


		}
		[Ignore("TestIgnore")]
		public void TestToIgnore()
		{

		}


		
	}
}

