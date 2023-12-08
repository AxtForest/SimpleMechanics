using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGun : MonoBehaviour
{

    [SerializeField]
    [Range(1, 50)]
    float rotationSpeed;

    [SerializeField]
    [Range(1, 50)]
    float throwForce;

    public Transform turnBackPoint;
    public GameObject darth;
    public float distance;

    Rigidbody rb;
    float rot = 0;
    float direct = 0;
    bool isThrowed;
    bool turnBack;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, turnBackPoint.transform.position); //mesafeyi hesapla 8e esit buyukse geri donmeyi true yap gidisi false
        if (distance >= 8)
        {
            isThrowed = false;
            turnBack = true;

        }
        if (isThrowed == false && turnBack == false && distance >0.2f) //hiçbir islem yapýlmadan kullanýcý oynar ise takip etmeli
        {

            //transform.position = turnPoint.position; //problem burasý bunun ilede yapýlabilir fakat sýkýntýlar çýkarýyor
            Vector3 newPosition = turnBackPoint.position + (turnBackPoint.forward * 0.5f);
            transform.position = newPosition;

        }
        if (distance <= 1) 
        {
            turnBack = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        if (turnBack) // degerleri yukarýda kontrol ettik bu ise fonksiyonu cagiriyor
        {
            TurnBack();
        }
        if (Input.GetButton("Jump"))// space basildigi an mermi firlatilir distance hesaplamalari calisir
        {
            isThrowed = true;
        }
        if (isThrowed) //Yukaridan gelen true degeri ile istenilen fonksiyonlari cagirir
        {
            //Rotation();
            Throw();
        }
    }
    public void TurnBack() //atilan nesnenin pozisyonunu nesnenin geriye donmesi gereken pozisyona esitliyor
                           //donme islemi gerceklestiriyor
                           // vector3.lerp ile iki pozisyon arasinda bir lineer interpolasyon gerceklestirir smooth geri donus saglar
    {
        transform.position = Vector3.Lerp(transform.position, turnBackPoint.transform.position, Time.deltaTime * 2);
        //Rotation();
    }
    //public void Rotation() //frizbi gorunumu verilebilir bu kod parcacigi ile rotasyonu ile oynanir ve frizbi gibi gorunur
    //{
    //    rot += rotationSpeed * Time.deltaTime * 20;
    //    transform.rotation = Quaternion.Euler(0, rot, 0);
    //}
    public void Throw()//nesnenin atilmasindan sorumlu turnpoint nesnenin atilmaya basladigi noktadir 
    {
        Vector3 hare = new Vector3(turnBackPoint.position.x, turnBackPoint.position.y, (turnBackPoint.position.z + 20));//nereye kadar gidecek ve donecek burada 20 yaziyor fakat distanceyi 8 ayarladigim icin 8 birim gidebiliyor
        direct += throwForce * Time.deltaTime; 
        transform.position = Vector3.Lerp(transform.position, hare, Time.deltaTime * 2);//yine smooth bir hareket icin lerp kullandik
    }


}
