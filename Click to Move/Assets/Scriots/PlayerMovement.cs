using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    bool move;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            move = true;
        }
        if(move)
        {
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition); // ýþýn oluþturduk

            RaycastHit hitInfo;

            if(Physics.Raycast(camRay, out hitInfo ,1000)) //kesiþme kontrolu
            {
                //sadece x ve z ekseni üstünde hareket etmelisin dedik
                Vector3 targetPosition = new Vector3(hitInfo.point.x, transform.position.y,
                    hitInfo.point.z);

                transform.position = Vector3.Lerp(transform.position, targetPosition,
                    Time.deltaTime * 3);
            }
             //mesafe hesaplanýr (imleç ile nesne arasý sadece x ve z ekseni)
            float distance = Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z),
                                      new Vector3(hitInfo.point.x, 0, hitInfo.point.z));
            if (distance <=0.3f)   //nesne yeterince yakýnsa çalýþma
            {
                move = false;
            }
        }
    }
}
