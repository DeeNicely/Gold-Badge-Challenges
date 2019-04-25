using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace ClaimRepository
{
    public class ClaimsRepository
    {
        public List<Claim> _listOfAccidents = new List<Claim>();

        public void AddToList(Claim information)
        {
            information.IsValid = CheckValidity(information);
            _listOfAccidents.Add(information);
        }
        public List<Claim> GetClaimsList()
        {
            return _listOfAccidents;
        }


        public void RemoveClaim(Claim information)
        {
            _listOfAccidents.Remove(information);
        }
        public bool RemoveClaim(int claimID)
        {
            bool removed = false;
            foreach (Claim information in _listOfAccidents)
            {
                if (information.ClaimID == claimID)
                {
                    RemoveClaim(information);
                    removed = true;
                    break;
                }
            }
            return true;
        }


        public void DateDiff() { }

        public bool CheckValidity(Claim claim)
        {
            //establish DateTimes
            DateTime start = claim.DateOfIncident;
            DateTime end = claim.DateOfClaim;

            TimeSpan difference = end - start; //create TimeSpan object

            if (difference.Days > 30)
            {
                return false;
            }
            else
            {
                return true;
            }

            //Console.WriteLine("Difference in days: " + difference.Days); //Extract days, write to Console.
        }
    }

    public class ClaimQueueRepository
    {
        private Queue<Claim> _informationQueue = new Queue<Claim>();

        public void AddToQueue(Claim information)
        {
            _informationQueue.Enqueue(information);
        }

        public Claim GetNextContent()
        {
            Claim nextInformation = _informationQueue.Dequeue();
            return nextInformation;
        }

        public Claim PeekNextContent()
        {
            return _informationQueue.Peek();
        }

        public Queue<Claim> GetInformationQueue()
        {
            return _informationQueue;
        }

        public int GetQueueInformationCount()
        {
            int queueInformationCount = _informationQueue.Count;
            return queueInformationCount;
        }
    }
}