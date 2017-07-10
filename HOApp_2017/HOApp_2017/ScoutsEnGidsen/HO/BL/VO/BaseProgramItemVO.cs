using System;
namespace HOApp_2017.ScoutsEnGidsen.HO.BL.VO
{
    public class BaseProgramItemVO
    {
        public BaseProgramItemVO()
        {
        }
        public string Title
        {
            get;
            set;
        }

        public virtual bool HasChildProgramItems{
            get{
                return false;
            }
        }
    }
}
