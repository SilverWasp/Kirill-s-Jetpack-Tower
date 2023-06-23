using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shreder : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject shrederPrefab,player;
    private Vector3 shredPos = Vector3.zero, playerPos, shredOffSet = new Vector3(0,20,0);
    private TrapGenerator trapGenerator;  
    private CollectibleGenerator collectibleGenerator;

    private void Start()
    {
        trapGenerator = FindObjectOfType<TrapGenerator>();
        collectibleGenerator= FindObjectOfType<CollectibleGenerator>();
        playerPos = player.transform.position;
        shredPos.y = playerPos.y - shredOffSet.y;
    }
    private void Update()
    {
        playerPos = player.transform.position;
        if(playerPos.y > shredPos.y + shredOffSet.y)
        {
            shredPos.y = playerPos.y - shredOffSet.y;
        }
        shrederPrefab.transform.position = shredPos;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Traps"))
        {
            Destroy(collider.gameObject);
            trapGenerator.TListRemover(collider.gameObject);
        }
        if (collider.gameObject.CompareTag("CollCoin") || collider.gameObject.CompareTag("CollExtra"))
        {
            Destroy(collider.gameObject);
            collectibleGenerator.CListRemover(collider.gameObject);
        }
        if (collider.gameObject.CompareTag("Platforms")) Destroy(collider.gameObject);
        if (collider.gameObject.CompareTag("Player")) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
