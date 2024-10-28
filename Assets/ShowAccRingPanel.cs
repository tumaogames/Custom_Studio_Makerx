using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAccRingPanel : MonoBehaviour
{
    public GameObject ring_menu2;
    public GameObject ring_menuItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowMenu2()
    {
        ring_menu2.SetActive(true);
        ring_menuItem.SetActive(false);
    }

    public void ShowMenu1()
    {
        ring_menu2.SetActive(false);
        ring_menuItem.SetActive(true);
    }
}
