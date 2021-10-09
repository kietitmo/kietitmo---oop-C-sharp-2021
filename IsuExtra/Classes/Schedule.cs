using System.Collections.Generic;
using Isu.Tools;

namespace IsuExtra.Classes
{
    public class Schedule
    {
        private List<Para> paraOfMonday;
        private List<Para> paraOfTuesday;
        private List<Para> paraOfWednesday;
        private List<Para> paraOfthursday;
        private List<Para> paraOfFriday;
        private List<Para> paraOfSaturday;
        public Schedule()
        {
            ParaOfMonday = new List<Para>();
            ParaOfTuesday = new List<Para>();
            ParaOfWednesday = new List<Para>();
            ParaOfThursday = new List<Para>();
            ParaOfFriday = new List<Para>();
            ParaOfSaturday = new List<Para>();
        }

        public List<Para> ParaOfMonday { get => paraOfMonday; set => paraOfMonday = value; }
        public List<Para> ParaOfTuesday { get => paraOfTuesday; set => paraOfTuesday = value; }
        public List<Para> ParaOfWednesday { get => paraOfWednesday; set => paraOfWednesday = value; }
        public List<Para> ParaOfThursday { get => paraOfthursday; set => paraOfthursday = value; }
        public List<Para> ParaOfFriday { get => paraOfFriday; set => paraOfFriday = value; }
        public List<Para> ParaOfSaturday { get => paraOfSaturday; set => paraOfSaturday = value; }

        public Para AddPara(Para para, string day)
        {
            switch (day)
            {
                case "monday":
                    if (!IsThisParaInvalid(para, ParaOfMonday))
                    {
                        ParaOfMonday.Add(para);
                        return para;
                    }
                    else
                    {
                        throw new IsuException("(Monday) Another Para Exists Exception");
                    }

                case "tuesday":
                    if (!IsThisParaInvalid(para, ParaOfTuesday))
                    {
                        ParaOfTuesday.Add(para);
                        return para;
                    }
                    else
                    {
                        throw new IsuException("(Tuesday) Another Para Exists Exception");
                    }

                case "wednesday":
                    if (!IsThisParaInvalid(para, ParaOfWednesday))
                    {
                        ParaOfWednesday.Add(para);
                        return para;
                    }
                    else
                    {
                        throw new IsuException("(Wednesday) Another Para Exists Exception");
                    }

                case "thursday":
                    if (!IsThisParaInvalid(para, ParaOfThursday))
                    {
                        ParaOfThursday.Add(para);
                        return para;
                    }
                    else
                    {
                        throw new IsuException("(Thursday) Another Para Exists Exception");
                    }

                case "friday":
                    if (!IsThisParaInvalid(para, ParaOfFriday))
                    {
                        ParaOfFriday.Add(para);
                        return para;
                    }
                    else
                    {
                        throw new IsuException("(Friday) Another Para Exists Exception");
                    }

                case "saturday":
                    if (!IsThisParaInvalid(para, ParaOfSaturday))
                    {
                        ParaOfSaturday.Add(para);
                        return para;
                    }
                    else
                    {
                        throw new IsuException("(Saturday) Another Para Exists Exception");
                    }

                default:
                    throw new IsuException("Add Para To Wrong Day Exception");
            }
        }

        //// Checking Para is cut other para in List Para (of one day)
        public bool IsThisParaInvalid(Para para, List<Para> day)
        {
            for (int i = 0; i < day.Count; i++)
            {
                if (para.StartTime <= day[i].StartTime && para.EndTime >= day[i].EndTime)
                {
                    return true;
                }

                if (para.StartTime >= day[i].StartTime && para.EndTime <= day[i].EndTime)
                {
                    return true;
                }

                if (para.StartTime < day[i].StartTime && para.EndTime > day[i].StartTime)
                {
                    return true;
                }

                if (para.StartTime > day[i].EndTime && para.EndTime < day[i].EndTime)
                {
                    return true;
                }
            }

            return false;
        }

        //// Check 2 Schedule are intersect each other
        public bool IsIntersectOther(Schedule other)
        {
            for (int i = 0; i < ParaOfMonday.Count; i++)
            {
                if (IsThisParaInvalid(ParaOfMonday[i], other.ParaOfMonday))
                {
                    return true;
                }
            }

            for (int i = 0; i < ParaOfTuesday.Count; i++)
            {
                if (IsThisParaInvalid(ParaOfTuesday[i], other.ParaOfTuesday))
                {
                    return true;
                }
            }

            for (int i = 0; i < ParaOfWednesday.Count; i++)
            {
                if (IsThisParaInvalid(ParaOfWednesday[i], other.ParaOfWednesday))
                {
                    return true;
                }
            }

            for (int i = 0; i < ParaOfThursday.Count; i++)
            {
                if (IsThisParaInvalid(ParaOfThursday[i], other.ParaOfThursday))
                {
                    return true;
                }
            }

            for (int i = 0; i < ParaOfFriday.Count; i++)
            {
                if (IsThisParaInvalid(ParaOfFriday[i], other.ParaOfFriday))
                {
                    return true;
                }
            }

            for (int i = 0; i < ParaOfSaturday.Count; i++)
            {
                if (IsThisParaInvalid(ParaOfSaturday[i], other.ParaOfSaturday))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
