using System.Collections.Generic;

namespace Arithmetics.Algorithms.Problems.StableMarriage
{
    public class Proposer
    {
        public Accepter? EngagedTo { get; set; }

        public LinkedList<Accepter> PreferenceOrder { get; set; } = new();
    }
}