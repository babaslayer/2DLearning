using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    // Start is called before the first frame update
   
    [SerializeField] Transform player_position;   
    [SerializeField] Transform gun_position;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        Aim();

    }
    void Aim()
    {



        Vector3 mousePos = (Camera.main.ScreenToWorldPoint(Input.mousePosition));
        mousePos.z = 0;
        gun_position.transform.right = (mousePos - player_position.position).normalized;

    }

}
