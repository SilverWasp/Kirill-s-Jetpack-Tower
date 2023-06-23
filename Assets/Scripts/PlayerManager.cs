using System;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int height { get; private set; } = 0;
    public float score { get; private set; } = 0;
    private CollectibleGenerator collectibleGenerator;
    private TrapGenerator trapGenerator;

    [Header("Collectible No.1")]
    [SerializeField] private GameObject collPrefab1;
    [SerializeField] private float collMult1;

    [Header("Collectible No.2")]
    [SerializeField] private GameObject collPrefab2;
    [SerializeField] private float collMult2;


    private void Start()
    {
        trapGenerator = FindObjectOfType<TrapGenerator>();
        collectibleGenerator = FindObjectOfType<CollectibleGenerator>();
    }

    private void Update()
    {
        if (transform.position.y > height)
        {
            height = (int)transform.position.y;
            OnHeightChange?.Invoke(height);
        }
    }

    public static event Action<float> OnScoreChange;
    public static event Action<float> OnHeightChange;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Traps"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (collider.gameObject.CompareTag("CollCoin"))
        {
            score += collMult1;
            OnScoreChange?.Invoke(score);
            Destroy(collider.gameObject);
            collectibleGenerator.CListRemover(collider.gameObject);
        }
        
        if (collider.gameObject.CompareTag("CollExtra"))
        {
            score += collMult2;
            OnScoreChange?.Invoke(score);
            Destroy(collider.gameObject);
            collectibleGenerator.CListRemover(collider.gameObject);
        }
    }

    
}
