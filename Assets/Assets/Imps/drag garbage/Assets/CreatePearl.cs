using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class CreatePearl : MonoBehaviour
{

    public GameObject spawn;
    public GameObject getPrefab;

    // Start is called before the first frame update
    public void createPearl()
    {
        Instantiate(getPrefab, spawn.transform.position, Quaternion.identity);
    }
}
