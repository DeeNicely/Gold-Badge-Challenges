using System;
using System.Collections.Generic;
using ClaimRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClaimsTest
{
    [TestClass]
    public class ClaimTest
    {
        [TestMethod]
        public void AddToList()
        {
            ClaimsRepository claimRepository = new ClaimsRepository();
            Claim contentOne = new Claim(12,ClaimType.Car, "house fire with roof damage", 5000m, new DateTime(2019, 4, 3), new DateTime(2019, 4, 21));

            claimRepository.AddToList(contentOne);
            List<Claim> content = claimRepository.GetClaimsList();

            int actual = claimRepository.GetClaimsList().Count;
            int expected = 1;

            Assert.AreEqual(expected, actual);
            Assert.IsTrue(claimRepository.GetClaimsList().Contains(contentOne));
        }

        [TestMethod]
        public void RemoveClaim()
        {
            ClaimsRepository claimRepo = new ClaimsRepository();
            Claim claim = new Claim();

            Claim claimThree = new Claim(33, ClaimType.Theft, "home break-in with jewelry taken", 822m, new DateTime(2019, 1, 3), new DateTime(2019, 2, 10));

            claimRepo.AddToList(claim);

            claimRepo.AddToList(claimThree);
            claimRepo.RemoveClaim(claimThree);

            int actual = claimRepo.GetClaimsList().Count;
            int expected = 1;

            Assert.AreEqual(expected, actual);
        }
    }
}
