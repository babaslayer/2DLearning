using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Punch : MonoBehaviour
{
    [SerializeField] float punchSpeed;
    [SerializeField] bool ispunching;
    [SerializeField] bool ispunchingDown;

    [SerializeField] Transform punch_transform;
    [SerializeField] float punch_target_distance;
    [SerializeField] Vector2 punch_size;//=new Vector2(3,1);
    [SerializeField] Transform targetTransform;
    [SerializeField] LayerMask ground;
    [SerializeField] PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        ispunching = false;
        ispunchingDown = false;
        punch_target_distance = Vector2.Distance(transform.position,targetTransform.position);

    }

    // Update is called once per frame
    void Update()
    {

        GetInput();
        MovePunch();
        

    }

    void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&!ispunching)
        {
            ispunching = true;
            ispunchingDown = true;
        }
    }


    void MovePunch()
    {
        if (ispunching)
        {
            
            if (ispunchingDown)
            {
                GoPunch();


            }
            else
            {

                PunchBack();

            }

            CheckPunch();
        }
    }



    void GoPunch()
    {
        
      
        punch_transform.position=Vector2.MoveTowards(punch_transform.position, targetTransform.position, punchSpeed * Time.deltaTime);
        //Bu fonksiyon iki pozisyon arasýnda yer deðiþtirmeyi saðlar.

    }
    void PunchBack()
    {


        punch_transform.position = Vector2.MoveTowards(punch_transform.position, transform.position, punchSpeed * Time.deltaTime);

    }

    void CheckPunch()
    {

        
        //vector.Distance sadece aradaki mesafeyi ölçer bu yüzden if içinde kullanýlýyor.
        if (Vector2.Distance(punch_transform.position, targetTransform.position)==0)
        {
            ispunchingDown = false;
        }
        if (Vector2.Distance(transform.position, punch_transform.position) ==0&&!ispunchingDown)
        {
            ispunching = false;

        }

        //Burada overlapbox un içinde herhangi bir collide olup olmadýðýný inceler.
        if (Physics2D.OverlapBox(punch_transform.position, punch_size,0f,ground))
        {
            ispunchingDown = false;
            float idealDistance = punch_target_distance / 2f;
            float currentPunchDistance = Vector2.Distance(transform.position, punch_transform.position);
            float jumpMultiplier = (idealDistance - Mathf.Abs(idealDistance-currentPunchDistance))/idealDistance;
           // jumpMultiplier=Mathf.Clamp(jumpMultiplier, 0.6f, 10f);
            playerMovement.Jumping(jumpMultiplier) ;

        }

        

    }

    private void OnDrawGizmos()//punchýn üzerine bir kare çizer.
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube( punch_transform.position,punch_size);
        
    }   


}


