﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodGenerator : MonoBehaviour
{
    positionRecord foodPosition;

    GameObject foodObject;

    List<positionRecord> allTheFood;


    snakeGenerator sn;


    int getVisibleFood()
    {
        int counter = 0;
        foreach(positionRecord f in allTheFood)
        {
            if (f.BreadcrumbBox != null)
            {
                counter++;
            }
        }

        return counter;
    }

    public void eatFood(Vector3 snakeHeadPosition)
    {
        positionRecord snakeHeadPos = new positionRecord();

        snakeHeadPos.Position = snakeHeadPosition;

        int foodIndex = allTheFood.IndexOf(snakeHeadPos);
        //

        if (foodIndex != -1)
        { 
            Destroy(allTheFood[foodIndex].BreadcrumbBox);

            //  allTheFood.RemoveAt(foodIndex);

            scoreManager.scoreValue++;

            sn.snakelength++;
        }



    }

    IEnumerator generateFood()
    {
        while(true)
        {
            if (getVisibleFood() < 6) { 
                yield return new WaitForSeconds(Random.Range(1f, 3f));

                foodPosition = new positionRecord();

                float randomX = Mathf.Floor(Random.Range(-9f, 9f));

                float randomY = Mathf.Floor(Random.Range(-9f, 9f));

                Vector3 randomLocation = new Vector3(randomX, randomY);

                //don't allow the food to be spawned on other food

                foodPosition.Position = randomLocation;

                if (!allTheFood.Contains(foodPosition) && !sn.hitTail(foodPosition.Position,sn.snakelength))

                {

                    foodPosition.BreadcrumbBox = Instantiate(foodObject, randomLocation, Quaternion.Euler(0f, 0f, 45f));

                    foodPosition.BreadcrumbBox.GetComponent<SpriteRenderer>().color = Random.ColorHSV();

                    foodPosition.BreadcrumbBox.transform.localScale = new Vector3(0.5f, 0.5f);

                    foodPosition.BreadcrumbBox.name = "Food Object";

                    allTheFood.Add(foodPosition);
                }

                yield return null;
            }


            yield return null;

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        foodPosition = new positionRecord();

        allTheFood = new List<positionRecord>();

        foodObject = Resources.Load<GameObject>("Prefabs/Square");

        sn = Camera.main.GetComponent<snakeGenerator>();

        StartCoroutine(checkStart());


    }

    IEnumerator checkStart()
    {
        while (true)
        {
            if (sn.firstrun == false)
            {
                StartCoroutine(generateFood());
                break;
            }
            yield return null;
        }
        yield return null;
    }


}
