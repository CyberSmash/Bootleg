using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;
using Sirenix.OdinInspector;
public class Dealer : MonoBehaviour
{

    [Tooltip("The number of customers the dealer has.")]
    public float NumCustomers = 0;

    [Tooltip("The speed of the dealer.")]
    public float DealerSpeed = 0;

    [Tooltip("The number of customers that need to be serviced.")]
    public float UnservicedCustomers = 0;

    [Tooltip("The amount of supply the dealer has.")]
    public float Supply = 0;

    [Tooltip("The amount of money the dealer can purchase products for.")]
    public float PurchasePricePerUnit = 20f;

    [Tooltip("The amount the dealer sells the products for")]
    public float SalePricePerUnit = 25f;

    [Tooltip("The amount of money the dealer has.")]
    public float Money = 150f;

    [Tooltip("How long it takes the dealer to resupply.")]
    public float ResupplyCooldown = 2.5f;

    [Tooltip("True if the dealer is resupplying.")]
    public bool Resupplying = false;

    [Required]
    public FloatVariable GameSpeed = null;

    void Awake()
    {
        UnservicedCustomers = NumCustomers;
    }

    void Start()
    {
        StartCoroutine(Run());
    }

    public IEnumerator Run()
    {
        while(true)
        {
            if (Supply <= 0)
            {
                Resupplying = true;
                Resupply();

                Resupplying = false;
                continue;
            }

            float UnitsToSell = Mathf.Min(Supply, UnservicedCustomers);
            Sell(UnitsToSell);

            yield return new WaitForSeconds(GameSpeed.Value);
        }
    }

    public void Resupply()
    {
        float UnitsToBuy = Mathf.Floor(Money / PurchasePricePerUnit);

        Supply = UnitsToBuy;
        Money -= (UnitsToBuy * PurchasePricePerUnit);
    }

    public void Sell(float UnitsToSell)
    {
        Supply -= UnitsToSell;
        Money += UnitsToSell * SalePricePerUnit;
    }

    

}
