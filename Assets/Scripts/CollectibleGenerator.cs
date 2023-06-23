using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleGenerator : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject collectiblePrefab_1, player;

    [Header("General")]
    [SerializeField] private float minX, maxX, minY, maxY;
    [SerializeField] private int collectibleCount;
    private List<GameObject> collectibleList = new List<GameObject>();

    private void Update()
    {
        if (collectibleList.Count < collectibleCount)
        {
            CGenrator();
        }
    }

    private void CGenrator()
    {
        int i = 0;
        Vector3 spawnPos;
        bool isPositioned = false;
        while (!isPositioned && i <= 5)
        {
            spawnPos = new Vector3(Random.Range(minX, maxX), Random.Range(minY + player.transform.position.y,
                maxY + player.transform.position.y), 0);

            Collider2D[] colliders = Physics2D.OverlapCircleAll(spawnPos,
                collectiblePrefab_1.GetComponent<SpriteRenderer>().bounds.size.x + player.GetComponentInChildren<SpriteRenderer>().bounds.size.x);

            if (colliders.Length == 0)
            {
                collectibleList.Add(Instantiate(collectiblePrefab_1, spawnPos, Quaternion.identity));
                isPositioned = true;
            }
            else i++;
        }
    }
    public void CListRemover(GameObject collectible)
    {
        collectibleList.Remove(collectible);
    }

  
}
