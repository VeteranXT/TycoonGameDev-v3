using Assets.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


   public class TaskDoResearchEngineParts : TaskDoResearch
   {
        private EngineFeature toResearch;
        


    public override void DoTask(float devPoints)
    {
        if(toResearch != null)
        {
            toResearch.Research(devPoints);       
        }
        base.DoTask(devPoints);
    }


}

