using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enable : MonoBehaviour
{

    public GameObject Player; // Grabs reference to player

    private Movement checkStatus; // Checks if the movement script is enabled 
    private bool isActive = true;

    // Start is called before the first frame update
    void Start()
    {
        Player.SetActive(isActive);
        checkStatus = GetComponent<Movement>(); 
        
    }

    // Update is called once per frame
    void Update()

    {

        //The code below sets the player gameObject active.
        if (Input.GetKeyDown(KeyCode.Q))
        {
            switch (Player.activeInHierarchy)
            {
                case false:
                    Player.SetActive(true);
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.P))
                    checkStatus.enabled = !checkStatus.enabled; // toggles movement script
        
    }
}
