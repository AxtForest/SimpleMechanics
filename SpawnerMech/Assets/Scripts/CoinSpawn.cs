using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    //---**-----**----RASGELE BÝR NOKTADA NESNE ÜRETME---**-----**----







    public GameObject Coin; // Coin objesini alýyoz
    public List<Transform> spawnPoints = new List<Transform>(); // Coin'in spawn edileceði noktalarý aldýk

    private System.Random random = new System.Random(); // Rastgele sayý üretmek için kullanýlacak nesnedir
                                                        // bu nesne spawn edilecek noktalar arasýnda rasgele bir seçim için kullanýlýr

    public float spawnSure = 0.2f; // Coin spawn aralýðý
                                   

    private float gecenSure = 0f; // gecen sureyi sýfýrlayalým ki bir loop olsun

    void Start()
    {
        
    }

    void Update()
    {
        gecenSure += Time.deltaTime;
        if (gecenSure >= spawnSure)  // yeterli süre geçtiyse coin oluþturma fonksiyonunu çaðýr
        {
            SpawnObj();
            gecenSure = 0f; // Zamaný sýfýrla
        }
        
    }

    void SpawnObj()
    {
        // Rasgele bir spawn noktasý seç
        Transform spawnPoint = spawnPoints[random.Next(spawnPoints.Count)]; //spawnpoints noktalarýndan rasgele birinin transformunu seçer
        // Seçilen spawn noktasýna Coini yerleþtirir ve oluþturur
        Instantiate(Coin, spawnPoint.position, spawnPoint.rotation);

    }
}
