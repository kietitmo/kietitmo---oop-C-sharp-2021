using System.Collections.Generic;
using Isu.Tools;

namespace IsuExtra.Classes
{
    public class Schedule //// this class is schedule for group and learning stream of ognp
    {
        //// Every day of week hava a list of pair
        private List<Pair> pairOfMonday;
        private List<Pair> pairOfTuesday;
        private List<Pair> pairOfWednesday;
        private List<Pair> pairOfThursday;
        private List<Pair> pairOfFriday;
        private List<Pair> pairOfSaturday;

        public Schedule()
        {
            PairOfMonday = new List<Pair>();
            PairOfTuesday = new List<Pair>();
            PairOfWednesday = new List<Pair>();
            PairOfThursday = new List<Pair>();
            PairOfFriday = new List<Pair>();
            PairOfSaturday = new List<Pair>();
        }

        public List<Pair> PairOfMonday { get => pairOfMonday; set => pairOfMonday = value; }
        public List<Pair> PairOfTuesday { get => pairOfTuesday; set => pairOfTuesday = value; }
        public List<Pair> PairOfWednesday { get => pairOfWednesday; set => pairOfWednesday = value; }
        public List<Pair> PairOfThursday { get => pairOfThursday; set => pairOfThursday = value; }
        public List<Pair> PairOfFriday { get => pairOfFriday; set => pairOfFriday = value; }
        public List<Pair> PairOfSaturday { get => pairOfSaturday; set => pairOfSaturday = value; }

        //// Add pair into a day of week

        public Pair Addpair(Pair pair, DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Monday:
                    if (!IsThispairInvalid(pair, PairOfMonday))
                    {
                        PairOfMonday.Add(pair);
                        return pair;
                    }

                    throw new IsuException("(Monday) Another pair Exists Exception");

                case DayOfWeek.Tuesday:
                    if (!IsThispairInvalid(pair, PairOfTuesday))
                    {
                        PairOfTuesday.Add(pair);
                        return pair;
                    }

                    throw new IsuException("(Tuesday) Another pair Exists Exception");

                case DayOfWeek.Wednesday:
                    if (!IsThispairInvalid(pair, PairOfWednesday))
                    {
                        PairOfWednesday.Add(pair);
                        return pair;
                    }

                    throw new IsuException("(Wednesday) Another pair Exists Exception");

                case DayOfWeek.Thursday:
                    if (!IsThispairInvalid(pair, PairOfThursday))
                    {
                        PairOfThursday.Add(pair);
                        return pair;
                    }

                    throw new IsuException("(Thursday) Another pair Exists Exception");

                case DayOfWeek.Friday:
                    if (!IsThispairInvalid(pair, PairOfFriday))
                    {
                        PairOfFriday.Add(pair);
                        return pair;
                    }

                    throw new IsuException("(Friday) Another pair Exists Exception");

                case DayOfWeek.Saturday:
                    if (!IsThispairInvalid(pair, PairOfSaturday))
                    {
                        PairOfSaturday.Add(pair);
                        return pair;
                    }

                    throw new IsuException("(Saturday) Another pair Exists Exception");

                default:
                    throw new IsuException("Add pair To Wrong Day Exception");
            }
        }

        //// Checking pair is cut other pair in List pair (of one day)
        public bool IsThispairInvalid(Pair pair, List<Pair> pairsOfday)
        {
            foreach (Pair tempPair in pairsOfday)
            {
                if (pair.StartTime <= tempPair.StartTime && pair.EndTime >= tempPair.EndTime)
                {
                    return true;
                }

                if (pair.StartTime >= tempPair.StartTime && pair.EndTime <= tempPair.EndTime)
                {
                    return true;
                }

                if (pair.StartTime < tempPair.StartTime && pair.EndTime > tempPair.StartTime)
                {
                    return true;
                }

                if (pair.StartTime > tempPair.EndTime && pair.EndTime < tempPair.EndTime)
                {
                    return true;
                }
            }

            return false;
        }

        //// Check 2 Schedule are intersect each other (to check schedule of group INTERSECT schedule of learning stream?)
        public bool IsIntersectOther(Schedule other)
        {
            foreach (Pair tempPair in PairOfMonday)
            {
                if (IsThispairInvalid(tempPair, other.PairOfMonday))
                {
                    return true;
                }
            }

            foreach (Pair tempPair in PairOfTuesday)
            {
                if (IsThispairInvalid(tempPair, other.PairOfTuesday))
                {
                    return true;
                }
            }

            foreach (Pair tempPair in PairOfWednesday)
            {
                if (IsThispairInvalid(tempPair, other.PairOfWednesday))
                {
                    return true;
                }
            }

            foreach (Pair tempPair in PairOfThursday)
            {
                if (IsThispairInvalid(tempPair, other.PairOfThursday))
                {
                    return true;
                }
            }

            foreach (Pair tempPair in PairOfFriday)
            {
                if (IsThispairInvalid(tempPair, other.PairOfFriday))
                {
                    return true;
                }
            }

            foreach (Pair tempPair in PairOfSaturday)
            {
                if (IsThispairInvalid(tempPair, other.PairOfSaturday))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
