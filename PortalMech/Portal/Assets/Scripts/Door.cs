using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public Transform door;  // Kapı objesi
    public float openYPosition; // Kapının açık pozisyonu
    public float speed = 2f;  // Kapının açılma hızı
    private Card cardCollect;
    public GameObject cardObject;
    public Text interactText; // UI Text elemanı
    public Text getthecard; // UI Text elemanı
    public Transform player; // Oyuncu objesi
    public float interactDistance = 3f; // Etkileşim mesafesi

    private bool shouldOpen = false;
    private bool isNearDoor = false;




    void Start()
    {
        cardCollect = cardObject.GetComponent<Card>();
        interactText.gameObject.SetActive(false); // Başlangıçta yazıyı gizle
        getthecard.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (shouldOpen)
        //{
        //    float newYPosition = Mathf.Lerp(door.position.y, openYPosition, Time.deltaTime * speed);
        //    door.position = new Vector3(door.position.x, newYPosition, door.position.z);
        //}

        Forupdate();

    }
    public void OpenDoor()
    {
        float newYPosition = Mathf.Lerp(door.position.y, openYPosition, Time.deltaTime * speed);
        door.position = new Vector3(door.position.x, newYPosition, door.position.z);

        // Eğer kapı tam olarak açık konumuna geldiyse açılma sürecini durdur
        if (Mathf.Abs(door.position.y - openYPosition) < 0.01f)
        {
            shouldOpen = false;
        }
    }
    void Forupdate()
    {
        float distance = Vector3.Distance(player.position, door.position);
        isNearDoor = distance <= interactDistance;

        if (isNearDoor && !shouldOpen)
        {
            if (cardCollect.IsCardCollected())
            {
                interactText.gameObject.SetActive(true); // Kart toplandıysa "Press E to open the door" yazısını göster
                getthecard.gameObject.SetActive(false); // "Get the card" yazısını gizle

                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Kapıyı açma sürecini başlat
                    shouldOpen = true;
                    interactText.gameObject.SetActive(false); // E'ye basınca yazıyı gizle
                }
            }
            else
            {
                getthecard.gameObject.SetActive(true); // Kart toplanmadıysa "Get the card" yazısını göster
                interactText.gameObject.SetActive(false); // "Press E to open the door" yazısını gizle
            }
        }
        else
        {
            interactText.gameObject.SetActive(false); // Mesafe uygun değilse yazıları gizle
            getthecard.gameObject.SetActive(false);
        }

        if (shouldOpen)
        {
            OpenDoor();
        }
    }

}
