using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public class EngineFeature : LockResearchables, IDevelop
{
    [SerializeField] private float devPoints;
    public float DevelopTimeNeeded { get { return devPoints; } }
}
