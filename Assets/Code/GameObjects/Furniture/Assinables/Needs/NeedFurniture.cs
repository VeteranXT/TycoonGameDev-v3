
using UnityEngine;

public  class NeedFurniture : AssignableFurniture
{
    public bool IsReserved { get { return IsAssiged(); } }

    public void Unreserve()
    {
        if(IsAssiged())
        {
            UnAssign();
        }
    }

}