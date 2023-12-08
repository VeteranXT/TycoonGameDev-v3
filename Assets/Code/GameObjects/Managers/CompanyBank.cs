using System;
using UnityEngine;


//Question for myself.
//Do player only has bank? Or do we simulate other companies banks balance?
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
    public float MaxLoan { get { return maxLoanTaken; } private set { maxLoanTaken = value; } }
    public float Currency { get { return currency; } set{ currency = value; EventCurrencyChanged?.Invoke(currency); } }

    public float IntrestRate { get { return intrestRate; } private set {  intrestRate = value; } }

    private void Awake()
    {
        DontDestroyOnLoad(this);
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
    public void PayWages(float wages)
    {
        Currency -= wages;
    }
    public void SetIntrestRate(float rate)
    {
        IntrestRate = rate;
    }

    public void SetMaxLoan(float maxLoan)
    {
        MaxLoan = maxLoan;
    }
    public void TakeLoan(float amount)
    {
        LoanTaken += amount;
    }

    public void PayLoan(float amount)
    {
        LoanTaken -= amount;
    }

    public void ExtendLoanLimit(float amount)
    {
        MaxLoan += amount;
    }

    public void ReduceLoanLimit(float amount)
    {
        MaxLoan -= amount;
    }
    public void WarnBankrupcy()
    {
       //CHeck if we are below certan limit
       //50% of max loan? 3+ months in minus?
    }

    public void SetLoanMaxBasedOnYear(int year)
    {
        switch(year)
        {
            case 1978:
                MaxLoan = 250_000;
                break;
        }
    }

    public void Bankrupt()
    {
        //Game over? 
    }
}

