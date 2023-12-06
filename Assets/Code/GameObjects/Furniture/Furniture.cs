using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Furniture : MonoBehaviour
{
    [SerializeField] private Employee takenBy = null;
    [SerializeField] private bool isAssignable = false;
    [SerializeField] private float FuntintureCost;
    [SerializeField] private string nameOfFurniture;
    [SerializeField] private bool isWorkStation = true;
    [SerializeField] private bool[,] furnitureSize;
    public bool IsWorkStation { get { return isWorkStation; } }
    public bool IsAssignable { get { return isAssignable; }}
    public virtual bool IsAssiged(){ return takenBy != null;}
    public virtual void UnAssign() { takenBy = null; }
    public virtual void Assign(Employee e) { takenBy = e; }

    
}

