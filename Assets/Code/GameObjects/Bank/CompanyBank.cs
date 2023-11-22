using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class CompanyBank : MonoBehaviour
{
    //How much player has starting money
    [SerializeField] private float currency = 100_0000;
    //How much loan is taken
    [SerializeField] private float loanTaken = 0;
    //What is max loan
    [SerializeField] private float maxLoanTaken = 1_000_000;
    //intrest rate to pay based on loan
    [SerializeField] private float intrestRate = 0.04f;


    public static event Action<float> EventCurrencyChanged;
    public float LoanTaken { get { return loanTaken; } private set { loanTaken = value; } }
    public float MaxLoanTaken { get { return maxLoanTaken; } private set { maxLoanTaken = value; } }
    public float Currency { get { return currency; } set{ currency = value; EventCurrencyChanged?.Invoke(currency); } }

    public float IntrestRate { get { return intrestRate; } private set {  intrestRate = value; } }

 

    private void Start()
    {
        PlayerCompany.EventPayWages += PayWages;
    }
    public void PayIntrest()
    {
        if (LoanTaken > 0)
        {
            float intrestMoney = loanTaken * intrestRate;

        }
    }
    public void SetStartingMoney(float amount)
    {
        Currency = amount;
    }
    public void PayWages(float )
    {
        
    }
    public void SetIntrestRate(float rate)
    {

    }

    public void SetMaxLoan(float maxLoan)
    {
        MaxLoanTaken = maxLoan;
    }
    public void TakeLoan(float amount)
    {

    }

    public void PayLoan(float amount)
    {

    }

    public void ExtendLoanLimit(float amount)
    {

    }

    public void WarnBankrupcy()
    {

    }

    public void Bankrupt()
    {

    }
}

