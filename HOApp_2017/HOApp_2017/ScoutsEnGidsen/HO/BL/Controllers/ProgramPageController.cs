using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HOApp_2017.ScoutsEnGidsen.HO.BL.VO;

namespace HOApp_2017.ScoutsEnGidsen.HO.BL.Controllers
{
    public class ProgramPageController:BaseContentController
    {
        public delegate void ProgramLoadedDelegate(List<ProgramItemVO> ProgramItems);
        public event ProgramLoadedDelegate ProgramLoadedEvent;

        public ProgramPageController()
        {
            
        }

        public override string ContentPageName => "Programma";

        public void LoadData(){
            Task.Run(()=>{
				var items = AppController.Instance.GetAllProgramItems();
                if (ProgramLoadedEvent != null)
                    ProgramLoadedEvent(items);
            });
          
        }
    }
}
