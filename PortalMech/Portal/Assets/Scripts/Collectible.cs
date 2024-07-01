using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float amplitude = 0.2f;  // Hareketin yüksekliği
    public float frequency = 5f;    // Hareketin hızı
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        hareket();
    }
    void hareket()
    {
        transform.Rotate(new Vector3(transform.rotation.x, 1f, transform.rotation.y));

        float newY = startPos.y + Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // oyuncu ile etkileşime geçtiğini kontrol eden kısım
        {                                  //farklı nesneler için tag ile oynamak yeterli


            //score++;

            
        }
    }
}
