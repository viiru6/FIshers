using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMenuScript : MonoBehaviour
{
    public InventoryManager InventoryManager;
    public GameObject DebugMenu;
    bool DebugMenuActive;
    void Update()//debugmenun tiedot p‰ivitet‰‰n kun debugmenu on auki
    {
        if (DebugMenu.active) { InventoryManager.DebugInfo(); }

        if (Input.GetKeyDown(KeyCode.Q) == true)
        {
            if (DebugMenuActive)
            {
                DebugMenu.SetActive(false);
                DebugMenuActive = false;
            }
            else
            {
                DebugMenu.SetActive(true);
                DebugMenuActive = true;
            }
        }
        
    }
}
