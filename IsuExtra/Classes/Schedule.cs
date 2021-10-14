using System.Collections.Generic;
using Isu.Tools;

namespace IsuExtra.Classes
{
    public class Schedule
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
        public Pair Addpair(Pair pair, string day)
        {
            switch (day)
            {
                case "monday":
                    if (!IsThispairInvalid(pair, PairOfMonday))
                    {
                        PairOfMonday.Add(pair);
                        return pair;
                    }
                    else
                    {
                        throw new IsuException("(Monday) Another pair Exists Exception");
                    }

                case "tuesday":
                    if (!IsThispairInvalid(pair, PairOfTuesday))
                    {
                        PairOfTuesday.Add(pair);
                        return pair;
                    }
                    else
                    {
                        throw new IsuException("(Tuesday) Another pair Exists Exception");
                    }

                case "wednesday":
                    if (!IsThispairInvalid(pair, PairOfWednesday))
                    {
                        PairOfWednesday.Add(pair);
                        return pair;
                    }
                    else
                    {
                        throw new IsuException("(Wednesday) Another pair Exists Exception");
                    }

                case "thursday":
                    if (!IsThispairInvalid(pair, PairOfThursday))
                    {
                        PairOfThursday.Add(pair);
                        return pair;
                    }
                    else
                    {
                        throw new IsuException("(Thursday) Another pair Exists Exception");
                    }

                case "friday":
                    if (!IsThispairInvalid(pair, PairOfFriday))
                    {
                        PairOfFriday.Add(pair);
                        return pair;
                    }
                    else
                    {
                        throw new IsuException("(Friday) Another pair Exists Exception");
                    }

                case "saturday":
                    if (!IsThispairInvalid(pair, PairOfSaturday))
                    {
                        PairOfSaturday.Add(pair);
                        return pair;
                    }
                    else
                    {
                        throw new IsuException("(Saturday) Another pair Exists Exception");
                    }

                default:
                    throw new IsuException("Add pair To Wrong Day Exception");
            }
        }

        //// Checking pair is cut other pair in List pair (of one day)
        public bool IsThispairInvalid(Pair pair, List<Pair> day)
        {
            for (int i = 0; i < day.Count; i++)
            {
                if (pair.StartTime <= day[i].StartTime && pair.EndTime >= day[i].EndTime)
                {
                    return true;
                }

                if (pair.StartTime >= day[i].StartTime && pair.EndTime <= day[i].EndTime)
                {
                    return true;
                }

                if (pair.StartTime < day[i].StartTime && pair.EndTime > day[i].StartTime)
                {
                    return true;
                }

                if (pair.StartTime > day[i].EndTime && pair.EndTime < day[i].EndTime)
                {
                    return true;
                }
            }

            return false;
        }

        //// Check 2 Schedule are intersect each other
        public bool IsIntersectOther(Schedule other)
        {
            for (int i = 0; i < PairOfMonday.Count; i++)
            {
                if (IsThispairInvalid(PairOfMonday[i], other.PairOfMonday))
                {
                    return true;
                }
            }

            for (int i = 0; i < PairOfTuesday.Count; i++)
            {
                if (IsThispairInvalid(PairOfTuesday[i], other.PairOfTuesday))
                {
                    return true;
                }
            }

            for (int i = 0; i < PairOfWednesday.Count; i++)
            {
                if (IsThispairInvalid(PairOfWednesday[i], other.PairOfWednesday))
                {
                    return true;
                }
            }

            for (int i = 0; i < PairOfThursday.Count; i++)
            {
                if (IsThispairInvalid(PairOfThursday[i], other.PairOfThursday))
                {
                    return true;
                }
            }

            for (int i = 0; i < PairOfFriday.Count; i++)
            {
                if (IsThispairInvalid(PairOfFriday[i], other.PairOfFriday))
                {
                    return true;
                }
            }

            for (int i = 0; i < PairOfSaturday.Count; i++)
            {
                if (IsThispairInvalid(PairOfSaturday[i], other.PairOfSaturday))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
