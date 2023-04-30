using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;
public class CityStats : MonoBehaviour
{
    [Tooltip("The population of this city")]
    public uint Population;

    [Tooltip("Possible Customers")]
    public uint PossibleCustomers;

    [Tooltip("Number of Distributors")]
    public uint Distributors;

    [Tooltip("The speakeasies")]
    public List<Speakeasy> speakeasies;

    public IntVariable TimeHour;

    public void Start()
    {
        StartCoroutine(CustomerManager());
    }


    private IEnumerator CustomerManager()
    {
        while (true)
        {
            if (TimeHour.Value >= 22f || (TimeHour.Value <= 4f))
            {
                foreach (var easy in speakeasies)
                {
                    easy.AddCustomers((int)(100*easy.Popularity));
                }
            }
            else if (TimeHour.Value == 5)
            {
                foreach (var easy in speakeasies)
                {
                    easy.SetCustomers(0);
                }
            }
            yield return new WaitForSeconds(1.0f);
        }
        
    }

}
