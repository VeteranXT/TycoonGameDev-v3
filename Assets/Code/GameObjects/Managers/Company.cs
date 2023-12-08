using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Company : MonoBehaviour
{
    private List<Employee> employees = new List<Employee>();
    private CompanyBank playerBank;
    private string companyName;
    private Sprite companyIcon;
    private List<GameDeveloped> developedgameList = new List<GameDeveloped>();
    private List<GameEngine> gameEngines = new List<GameEngine>();

    public string CompanyName { get { return companyName; } set {  companyName = value; } }
    public Sprite CompanyIcon { get {  return companyIcon; } set {  companyIcon = value; } }

    public void SetCompanyIcon(Sprite icon)
    {
        CompanyIcon = icon;
    }
    public void SetCompanyName(string name)
    {
        CompanyName = name;
    }
         
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        playerBank = GetComponent<CompanyBank>();
        TimeManager.EventMonthPassed += PayWagesMontly;

    }

    public void PayWagesMontly()
    {
        playerBank.PayWages(GetTotalWages());
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
            ;
        }
        return wages;
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