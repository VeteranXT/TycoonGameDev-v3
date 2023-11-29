using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EngineFeature : LockResearchables, IDevelop
{
    private float devTime;
    public float DevelopTimeNeeded { get { return devTime; } private set { devTime = value; } }

}
