using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

public class Speakeasy : MonoBehaviour
{

    public FloatReference Money;
    public IntVariable HourTime;
    public FloatReference GameSpeed;
    public int Customers;
    public float MoneyPerCustomer;
    public int MaxCapacity;
    public float Supply;
    public float Popularity = 0.1f;
    void Start()
    {
        
    }


    void Update()
    {
        if (Supply > 0f)
        {
            float MaxCustomersToServe = Mathf.Min(Customers * Time.deltaTime * GameSpeed.Value, Supply);
            Money.Value += MoneyPerCustomer * MaxCustomersToServe;
            Supply -= MaxCustomersToServe;

        }

    }

    public void SetCustomers(int Customers)
    {
        this.Customers = Mathf.Min(Customers, MaxCapacity);
    }

    public void AddCustomers(int AdditionalCustomers)
    {
        this.Customers = Mathf.Min(Customers + AdditionalCustomers, MaxCapacity);
    }

    public void RemoveCustomers(int Reduction)
    {
        Customers = Mathf.Max(0, Customers - Reduction);
    }

   

}
