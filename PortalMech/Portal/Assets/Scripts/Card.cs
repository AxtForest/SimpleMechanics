using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    //toplanabilir scriptinden farklı sadece kartta kullan <3


    public float amplitude = 0.2f;  // Hareketin yüksekliği
    public float frequency = 5f;    // Hareketin hızı
    private Vector3 startPos;


    public Door doorController;
    bool canOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {




    }
    void hareket()
    {
        transform.Rotate(new Vector3(transform.rotation.x, 1f, transform.rotation.y));

        float newY = startPos.y + Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Kartın oyuncu ile etkileşime geçtiğini kontrol eder
        {


            canOpen = true;
            Destroy(gameObject);  
        }
    }

    public bool IsCardCollected() //door scripti için kontrolcu
    {
        return canOpen;
    }
}
