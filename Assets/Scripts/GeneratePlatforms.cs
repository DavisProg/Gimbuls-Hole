using System.Collections.Generic;
using NUnit.Framework.Interfaces;
using UnityEngine;
using UnityEngine.UIElements;

public class GeneratePlatforms : MonoBehaviour
{
    [SerializeField] private GameObject testPrefab;
    [SerializeField] private List<GameObject> patternList;
    [SerializeField] private GameObject spawnArea1;
    [SerializeField] private GameObject spawnArea2;
    [SerializeField] private GameObject spawnArea3;
    private BackgroundController bg;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bg = GetComponent<BackgroundController>();
        bg.backgroundMoved += generatePlatforms;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            generateTestPlatforms();
        }
    }
    void generateTestPlatforms()
    {
        Debug.Log("Generated");
        Object.Instantiate(testPrefab, spawnArea1.transform.position, Quaternion.identity);
        Object.Instantiate(testPrefab, spawnArea2.transform.position, Quaternion.identity);
        Object.Instantiate(testPrefab, spawnArea3.transform.position, Quaternion.identity);
    }
    void generatePlatforms()
    {
        Object.Instantiate(getRandomPattern(), spawnArea1.transform.position, Quaternion.identity);
        Object.Instantiate(getRandomPattern(), spawnArea2.transform.position, Quaternion.identity);
        Object.Instantiate(getRandomPattern(), spawnArea3.transform.position, Quaternion.identity);
    }
    GameObject getRandomPattern()
    {
        return patternList[Random.Range(0, patternList.Count)];
    }
}
