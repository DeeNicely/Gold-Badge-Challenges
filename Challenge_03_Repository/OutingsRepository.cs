using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_03_Repository
{
    public class OutingsRepository
    {
            public List<Outing> _listOfOutings = new List<Outing>();

            public void AddOutingToList(Outing outing)
            {
                _listOfOutings.Add(outing);
            }

            public List<Outing> GetOutingsList()
            {
                return _listOfOutings;
            }

            public decimal TotalCostByOuting(string response)
            {
                var cost = 0.0m;
                var outingType = _listOfOutings.FindAll(l => l.OutingType == response);
                foreach (OutingType outing in)
                {
                    cost = cost + outing.CostPerEvent;
                }
                return cost;
            }

            public decimal TotalOutingCost()
            {
                var totalCost = 0.0m;
                foreach (var outing in _listOfOutings)
                {
                    totalCost += outing.CostPerOuting;
                }
                return totalCost;
            }
            
        }
    }

