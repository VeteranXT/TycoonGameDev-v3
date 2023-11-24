using System;
using System.Collections.Generic;
using UnityEngine;

public class Company : MonoBehaviour
{
    private List<Employee> employees = new List<Employee>();

    public static Action<float> EventPayWages;


    private void Start()
    {
        TimeManager.EventMonthPassed += PayWages;
    }
    public virtual float GetTotalWages()
    {
        float wages = 0;
        for (int i = 0; i < employees.Count; i++)
        {
            wages += employees[i].GetWage;
        }
        if(wages > 0)
        {
            EventPayWages?.Invoke(wages);
        }
        return wages;
    }

    public virtual  void PayWages()
    {
        GetTotalWages();
    }
    public virtual void HireEmplyeee(Employee newEmployee)
    {
        employees.Add(newEmployee);
    }
    public virtual void FireEmployee(int index)
    {
        employees.RemoveAt(index);
    }
}