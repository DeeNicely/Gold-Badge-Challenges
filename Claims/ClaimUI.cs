using ClaimRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_02_Console
{

    class ClaimUI
    {
        private ClaimsRepository _claimRepo = new ClaimsRepository();
        private List<Claim> _listOfAccidents;

        public ClaimUI()
        {
            _listOfAccidents = _claimRepo.GetClaimsList();
        }

        public void Run()
        {
            //StartDialogue();
            SeedClaimList();
            bool running = true;
            while (running)
            {
                Console.Clear();
                running = Claim();
            }
        }
        public bool Claim()
        {
            Console.WriteLine("1. Add claim to list\n" +
                "2. Remove claim by name\n" +
                "3. Print list of claims\n" +
                "4. Exit");
            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    AddToList();
                    break;
                case 2:
                    RemoveClaim();
                    break;
                case 3:
                    PrintClaim();
                    break;
                case 4:
                    return false;
                default:

                    break;
            }
            return true;
        }

        public void AddToList()
        {
            Console.WriteLine("What is the Claim ID?");
            string claimIDAsString = Console.ReadLine();
            int claimID = int.Parse(claimIDAsString);

            Console.WriteLine("What is the Claim type?\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            //int claimType = int.Parse(Console.ReadLine());

            string claimTypeAsString = Console.ReadLine();
            int claimTypeAsInt = int.Parse(claimTypeAsString);

            ClaimType type;
            switch (claimTypeAsInt)
            {
                default:
                case 1:
                    type = ClaimType.Car;
                    break;
                case 2:
                    type = ClaimType.Home;
                    break;
                case 3:
                    type = ClaimType.Theft;
                    break;
            }

            Console.WriteLine("Describe the accident");
            string description = Console.ReadLine();

            Console.WriteLine("How much is the claim amount?");
            string claimAmountAsString = Console.ReadLine();
            decimal claimAmount = decimal.Parse(claimAmountAsString);

            Console.WriteLine("What was the date of the accident? (MM/DD/YYYY)");
            string dateOfIncidentAsString = Console.ReadLine();
            DateTime dateOfIncident = DateTime.Parse(dateOfIncidentAsString);

            Console.WriteLine("What was the date of the claim? (MM/DD/YYYY)");
            string dateOfClaimAsString = Console.ReadLine();
            DateTime dateOfClaim = DateTime.Parse(dateOfClaimAsString);

            //Console.WriteLine("Is the claim valid? (True/False)");
            //bool isValid = bool.Parse(Console.ReadLine());

            Claim newClaimItem = new Claim(claimID, type, description, claimAmount, dateOfIncident, dateOfClaim);
            _claimRepo.AddToList(newClaimItem);
        }

        public void RemoveClaim()
        {
            Console.Clear();
            PrintClaim();

            Console.WriteLine("What do you want to remove?");
            int claimID = int.Parse(Console.ReadLine());
            foreach (var claim in _listOfAccidents)
            {
                if (claimID == claim.ClaimID)
                {
                    _claimRepo.RemoveClaim(claim);
                    break;
                }
            }

            Console.ReadLine();
            Console.WriteLine("The claim has been removed.");
            Console.ReadKey();
        }

        public void PrintClaim()
        {
            List<Claim> claim = _claimRepo.GetClaimsList();
            foreach (Claim information in _listOfAccidents)
            {
                Console.WriteLine($"{information.ClaimID} {information.TypeOfClaim} {information.Description} {information.ClaimAmount} {information.DateOfIncident} {information.DateOfClaim} {information.IsValid}");
                {
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                }
            }
        }

        private void SeedClaimList()
        {
            Claim contentOne = new Claim(12, ClaimType.Home, "house fire with roof damage", 5000m, new DateTime(2019, 4, 3), new DateTime(2019, 4, 21));
            Claim contentTwo = new Claim(20, ClaimType.Car, "car collision with tree", 675.5m, new DateTime(2019, 3, 15), new DateTime(2019, 3, 28));
            Claim contentThree = new Claim(33, ClaimType.Theft, "home break-in with jewelry taken", 822m, new DateTime(2019, 1, 3), new DateTime(2019, 2, 10));

            _claimRepo.AddToList(contentOne);
            _claimRepo.AddToList(contentTwo);
            _claimRepo.AddToList(contentThree);

        }

        //Queue Peek

        //        Claim Type
        //        Description
        //        ClaimAmount
        //        DateOfIncident
        //        DateOfClaim
        //        IsValid
        //         ***Not sure how to write the queue in UI. Josh said not necessary for challenge. But go back and figure this out.
        //        Console.WriteLine(Do you want to deal with this claim?)
        //        yes or no   //dequ

        //        Queue Next

        //        Claim Type
        //        Description
        //        ClaimAmount
        //        DateOfIncident
        //        DateOfClaim
        //        IsValid
    }
}


