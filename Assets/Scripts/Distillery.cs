using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;
public class Distillery : MonoBehaviour
{
    public float ProductionRate;
    public float RawIngredients;
    public float ProductInStorage;
    public FloatVariable TimeScale;
    

    void Update()
    {
        ProductInStorage += ProductionRate * Time.deltaTime * TimeScale.Value;    
    }
}
