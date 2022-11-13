using System;
using AutoMapper;
using FakeItEasy;
using NUnit.Framework;
using RehberListesiWEBAPI.Controllers;
using RehberListesiWEBAPI.Models.Context;

namespace RehberTestNUnit.ControllerTest
{
	[TestFixture]
	public class RehberTest
	{

		[Test]
		public void TestKisiBilgileri()
		{
			//var rehber = new RehberController(_context,_mapper);
			var context = A.Fake<Context>();
			var mapper = A.Fake<IMapper>();

			var rehber = new RehberController(context,mapper);
			var result = rehber.KisiBilgileri(5);
			Assert.Equals(8,result);
			
			
		}
		[Ignore("TestIgnore")]
		public void TestToIgnore()
		{

		}
		
	}
}

