using System.Collections.Generic;
using Isu.Tools;

namespace IsuExtra.Classes
{
    public class Schedule
    {
        private List<Para> monday;
        private List<Para> tuesday;
        private List<Para> wednesday;
        private List<Para> thursday;
        private List<Para> friday;
        private List<Para> saturday;
        public Schedule()
        {
            Monday = new List<Para>();
            Tuesday = new List<Para>();
            Wednesday = new List<Para>();
            Thursday = new List<Para>();
            Friday = new List<Para>();
            Saturday = new List<Para>();
        }

        public List<Para> Monday { get => monday; set => monday = value; }
        public List<Para> Tuesday { get => tuesday; set => tuesday = value; }
        public List<Para> Wednesday { get => wednesday; set => wednesday = value; }
        public List<Para> Thursday { get => thursday; set => thursday = value; }
        public List<Para> Friday { get => friday; set => friday = value; }
        public List<Para> Saturday { get => saturday; set => saturday = value; }

        public Para AddPara(Para para, string day)
        {
            switch (day)
            {
                case "monday":
                    if (!IsParaExists(para, Monday))
                    {
                        Monday.Add(para);
                        return para;
                    }
                    else
                    {
                        throw new IsuException("(Monday) Another Para Exists Exception");
                    }

                case "tuesday":
                    if (!IsParaExists(para, Tuesday))
                    {
                        Tuesday.Add(para);
                        return para;
                    }
                    else
                    {
                        throw new IsuException("(Tuesday) Another Para Exists Exception");
                    }

                case "wednesday":
                    if (!IsParaExists(para, Wednesday))
                    {
                        Wednesday.Add(para);
                        return para;
                    }
                    else
                    {
                        throw new IsuException("(Wednesday) Another Para Exists Exception");
                    }

                case "thursday":
                    if (!IsParaExists(para, Thursday))
                    {
                        Thursday.Add(para);
                        return para;
                    }
                    else
                    {
                        throw new IsuException("(Thursday) Another Para Exists Exception");
                    }

                case "friday":
                    if (!IsParaExists(para, Friday))
                    {
                        Friday.Add(para);
                        return para;
                    }
                    else
                    {
                        throw new IsuException("(Friday) Another Para Exists Exception");
                    }

                case "saturday":
                    if (!IsParaExists(para, Saturday))
                    {
                        Saturday.Add(para);
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

        public bool IsParaExists(Para para, List<Para> day)
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

        public bool IsIntersectOther(Schedule other)
        {
            for (int i = 0; i < Monday.Count; i++)
            {
                if (IsParaExists(Monday[i], other.Monday))
                {
                    return true;
                }
            }

            for (int i = 0; i < Tuesday.Count; i++)
            {
                if (IsParaExists(Tuesday[i], other.Tuesday))
                {
                    return true;
                }
            }

            for (int i = 0; i < Wednesday.Count; i++)
            {
                if (IsParaExists(Wednesday[i], other.Wednesday))
                {
                    return true;
                }
            }

            for (int i = 0; i < Thursday.Count; i++)
            {
                if (IsParaExists(Thursday[i], other.Thursday))
                {
                    return true;
                }
            }

            for (int i = 0; i < Thursday.Count; i++)
            {
                if (IsParaExists(Thursday[i], other.Thursday))
                {
                    return true;
                }
            }

            for (int i = 0; i < Friday.Count; i++)
            {
                if (IsParaExists(Friday[i], other.Friday))
                {
                    return true;
                }
            }

            for (int i = 0; i < Saturday.Count; i++)
            {
                if (IsParaExists(Saturday[i], other.Saturday))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
