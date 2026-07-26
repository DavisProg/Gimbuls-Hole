using NUnit.Framework.Interfaces;
using UnityEngine;
using UnityEngine.UIElements;

public class GeneratePlatforms : MonoBehaviour
{
    [SerializeField] private GameObject testPrefab;
    [SerializeField] private GameObject spawnArea1;
    [SerializeField] private GameObject spawnArea2;
    [SerializeField] private GameObject spawnArea3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Object.Instantiate(testPrefab, spawnArea1.transform.position, Quaternion.identity);
            Object.Instantiate(testPrefab, spawnArea2.transform.position, Quaternion.identity);
            Object.Instantiate(testPrefab, spawnArea3.transform.position, Quaternion.identity);
        }
    }
}
