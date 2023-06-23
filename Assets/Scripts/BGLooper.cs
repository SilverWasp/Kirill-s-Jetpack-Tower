using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class BGLooper : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private GameObject bgPrefab;
    private List<GameObject> bgList = new List<GameObject>();
    private float cameraPos;
    private float bgHeight;

    void Start()
    {
        cam = Camera.main;
        cameraPos = cam.transform.position.y;
        bgHeight = bgPrefab.GetComponent<SpriteRenderer>().bounds.size.y;
        BGCreate(cameraPos);
    }

    void Update()
    {
        float deltaY = cam.transform.position.y - cameraPos;
        if(Mathf.Abs(deltaY) >= bgHeight)
        {
            BGCreate(deltaY);
            BGDestroy();
        }
    }

    private void BGDestroy()
    {
        float camBottom = cam.transform.position.y - cam.orthographicSize;
        float camTop = cam.transform.position.y + cam.orthographicSize;
        for(int i = 0 ; i < bgList.Count ; i++)
        {
            if (bgList[i].transform.position.y + bgHeight/2 < camTop || bgList[i].transform.position.y - bgHeight/2 > camBottom)
            {
                Destroy(bgList[i]);
                bgList.RemoveAt(i);
            }
        }

    }

    private void BGCreate(float deltaY)
    {
        GameObject bgInstance = Instantiate(bgPrefab);
        //float newY = deltaY > 0 ? cameraPos + bgHeight : cameraPos - bgHeight;
        float newY = deltaY == 0 ? cameraPos : deltaY > 0 ? cameraPos + bgHeight : cameraPos - bgHeight;
            bgInstance.transform.position = new Vector3 (0,newY,0);
            cameraPos = cam.transform.position.y;
            bgList.Add(bgInstance);
    }


}
