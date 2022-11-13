using System;
using RehberListesiWEBAPI.Controllers;
using RehberListesiWEBAPI.Models;

namespace RehberListesi.Test.ControllerTest
{
	public class RehberTest
	{
		[Fact]
		public void TestKisiBilgilei()
		{
			Rehber newRehber = new Rehber { RehberID = 1, Adi = "Oktay", Soyadi = "EFE", Firma = "OktayA.Ş" };
			List<Rehber> rehbers = new List<Rehber>();

			RehberController.


			PersonModel newPerson = new PersonModel { FirstName = "Tim", LastName = "Corey" };
			List<PersonModel> people = new List<PersonModel>();

			DataAccess.AddPersonToPeopleList(people, newPerson);

			Assert.True(people.Count == 1);
			Assert.Contains<PersonModel>(newPerson, people);
		}
	}
}

