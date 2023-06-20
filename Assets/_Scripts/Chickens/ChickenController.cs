using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChickenController : MonoBehaviour
{
    private GameManager gameManager;
    public bool onPoint;
    public bool funcStarted;
    public float currentCreateEggTime;

    private Animator chickenAnimator;

    private Transform currentPoint;

    private void Awake()
    {
        gameManager = GameObject.Find("Player").GetComponent<GameManager>();
        chickenAnimator = GetComponent<Animator>();
        GetNewPoint();
        transform.LookAt(currentPoint.position);
        currentCreateEggTime = 0f;
    }

    private void Update()
    {
        currentCreateEggTime += Time.deltaTime;
        
        if (Vector3.Distance(transform.position, currentPoint.position) <= 0.1f) onPoint = true;
        else
        {
            onPoint = false;
        }
        
        if (currentCreateEggTime >= gameManager.timeToCreateEgg && gameManager.eggsCount < gameManager.maxEggsCount)
        {
            CreateEgg();
            currentCreateEggTime = 0;
        }

        if (!onPoint)
        {
            transform.position =
                Vector3.MoveTowards(transform.position, currentPoint.position, 1f * Time.deltaTime);
        }

        if (onPoint)
        {
            if (funcStarted) return;
            funcStarted = true;
            chickenAnimator.SetBool("isMoving", false);
            Invoke("GetNewPoint", 3f);
        }
    }

    private void GetNewPoint()
    {
        int n = Random.Range(0, 8);
        currentPoint = gameManager.pointsChickens[n];
        chickenAnimator.SetBool("isMoving", true);
        funcStarted = false;
        transform.LookAt(currentPoint);
    }


    public void CreateEgg()
    {
        GameObject egg = Instantiate(gameManager.eggPrefab);
        egg.transform.position = transform.position - Vector3.right * 0.3f - Vector3.down * 0.2f;
        gameManager.eggsCount++;
        
    }
    
}
