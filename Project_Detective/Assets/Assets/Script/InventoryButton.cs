using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButton : MonoBehaviour
{
    public GameObject menuToOpen;
    public GameObject menuToClose;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Switches inventory to the right tab when clicked
    // Click again to close
    public void OpenAndCloseMenu()
    {
        menuToOpen.gameObject.SetActive(!menuToOpen.gameObject.activeSelf);
        menuToClose.gameObject.SetActive(false);
    }
}
