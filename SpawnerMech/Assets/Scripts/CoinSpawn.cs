using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    //---**-----**----RASGELE B�R NOKTADA NESNE �RETME---**-----**----







    public GameObject Coin; // Coin objesini al�yoz
    public List<Transform> spawnPoints = new List<Transform>(); // Coin'in spawn edilece�i noktalar� ald�k

    private System.Random random = new System.Random(); // Rastgele say� �retmek i�in kullan�lacak nesnedir
                                                        // bu nesne spawn edilecek noktalar aras�nda rasgele bir se�im i�in kullan�l�r

    public float spawnSure = 0.2f; // Coin spawn aral���
                                   

    private float gecenSure = 0f; // gecen sureyi s�f�rlayal�m ki bir loop olsun

    void Start()
    {
        
    }

    void Update()
    {
        gecenSure += Time.deltaTime;
        if (gecenSure >= spawnSure)  // yeterli s�re ge�tiyse coin olu�turma fonksiyonunu �a��r
        {
            SpawnObj();
            gecenSure = 0f; // Zaman� s�f�rla
        }
        
    }

    void SpawnObj()
    {
        // Rasgele bir spawn noktas� se�
        Transform spawnPoint = spawnPoints[random.Next(spawnPoints.Count)]; //spawnpoints noktalar�ndan rasgele birinin transformunu se�er
        // Se�ilen spawn noktas�na Coini yerle�tirir ve olu�turur
        Instantiate(Coin, spawnPoint.position, spawnPoint.rotation);

    }
}
