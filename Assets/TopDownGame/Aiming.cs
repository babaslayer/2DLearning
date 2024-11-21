using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    // Start is called before the first frame update
   
    [SerializeField] Transform player_position;   
    [SerializeField] Transform gun_pivot;
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



        Vector3 mousePos = (Camera.main.ScreenToWorldPoint(Input.mousePosition));//Mouseun pozisyonunu ekranda nerede olduðunu hesaplar.
        mousePos.z = 0;
        gun_pivot.transform.right = (mousePos - gun_pivot.position).normalized;//Mouseun pozisyonu ile karakterimizin arasýndaki yön vektörünü belirler.

    }

}
