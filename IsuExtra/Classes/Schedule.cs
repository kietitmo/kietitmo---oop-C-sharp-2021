using System.Collections.Generic;
using Isu.Tools;

namespace IsuExtra.Classes
{
    public class Schedule
    {
        private List<Para> monday = new List<Para>();
        private List<Para> tuesday;
        private List<Para> wednesday;
        private List<Para> thursday;
        private List<Para> friday;
        private List<Para> saturday;

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
                        throw new IsuException("Another Para Exists Exception");
                    }

                case "tuesday":
                    if (!IsParaExists(para, Tuesday))
                    {
                        Tuesday.Add(para);
                        return para;
                    }
                    else
                    {
                        throw new IsuException("Another Para Exists Exception");
                    }

                case "wednesday":
                    if (!IsParaExists(para, Wednesday))
                    {
                        Wednesday.Add(para);
                        return para;
                    }
                    else
                    {
                        throw new IsuException("Another Para Exists Exception");
                    }

                case "thursday":
                    if (!IsParaExists(para, Thursday))
                    {
                        Thursday.Add(para);
                        return para;
                    }
                    else
                    {
                        throw new IsuException("Another Para Exists Exception");
                    }

                case "friday":
                    if (!IsParaExists(para, Friday))
                    {
                        Friday.Add(para);
                        return para;
                    }
                    else
                    {
                        throw new IsuException("Another Para Exists Exception");
                    }

                case "saturday":
                    if (!IsParaExists(para, Saturday))
                    {
                        Saturday.Add(para);
                        return para;
                    }
                    else
                    {
                        throw new IsuException("Another Para Exists Exception");
                    }

                default:
                    throw new IsuException("Add Para To Wrong Day Exception");
            }
        }

        private bool IsParaExists(Para para, List<Para> day)
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

                if (para.StartTime <= day[i].StartTime && para.EndTime <= day[i].EndTime)
                {
                    return true;
                }

                if (para.StartTime >= day[i].StartTime && para.EndTime >= day[i].EndTime)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
