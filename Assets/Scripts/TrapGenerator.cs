using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapGenerator : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject trapPrefab_1, player;

    [Header("General")]
    [SerializeField] private float minX,maxX,minY,maxY;
    [SerializeField] private int trapCount;
    private List<GameObject> trapList = new List<GameObject>();

    private void Update()
    {
        if(trapList.Count < trapCount) 
        {
            TGenrator();
        }
    }

    private void TGenrator()
    {
        int i = 0;
        Vector3 spawnPos;
        bool isPositioned = false;
        while(!isPositioned && i <= 5)
        {
            spawnPos = new Vector3(Random.Range(minX, maxX), Random.Range(minY + player.transform.position.y,
                maxY + player.transform.position.y), 0);

            Collider2D[] colliders = Physics2D.OverlapCircleAll(spawnPos,
                trapPrefab_1.GetComponent<SpriteRenderer>().bounds.size.x + player.GetComponentInChildren<SpriteRenderer>().bounds.size.x);

            if(colliders.Length == 0) 
            {
                trapList.Add(Instantiate(trapPrefab_1, spawnPos, Quaternion.identity));
                isPositioned = true;
            }
            else i++;
        }
    }

    public void TListRemover(GameObject trap)
    {
        trapList.Remove(trap);
    }
}
