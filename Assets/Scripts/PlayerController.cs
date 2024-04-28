using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask whatIsGem;
    public float pickupDistance;
    void Start()
    {
        
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, pickupDistance))
        {
            if (hit.collider.CompareTag("Gem"))
            {
                //change cursor icon

                if (Input.GetMouseButtonDown(0))
                {
                    //pickup
                    //spawn enemy
                }
            }
        }
    }
}
