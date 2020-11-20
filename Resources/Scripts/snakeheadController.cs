using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;


public class snakeheadController : MonoBehaviour
{
    snakeGenerator mysnakegenerator;
    foodGenerator myfoodgenerator;


   
    public Vector3 findClosestFood()
    {
        if (myfoodgenerator.allTheFood.Count > 0)
        {
            List<positionRecord> sortedFoods = myfoodgenerator.allTheFood.OrderBy(
        x => Vector3.Distance(this.transform.position, x.Position)
       ).ToList();
            return sortedFoods[0].Position;
        }
        return new Vector3(0f, 0f);
    }

    public IEnumerator automoveCoroutine()
    {
        while(true)
        {
            Vector3 closestFoodPosition = findClosestFood();

            if (mysnakegenerator.hitTail(this.transform.position, mysnakegenerator.snakelength))
                {
                    SceneManager.LoadScene("endScene");
                }

                if (this.transform.position.x < closestFoodPosition.x)
                {
                //   Debug.LogWarning("Closest food" + findClosestFood());
                mysnakegenerator.savePosition();
                    transform.position += new Vector3(1f, 0);
                mysnakegenerator.drawTail(mysnakegenerator.snakelength);
                checkBounds();
                    myfoodgenerator.eatFood(this.transform.position);
                Debug.Log(mysnakegenerator.hitTail(this.transform.position, mysnakegenerator.snakelength));


            }

                else if (this.transform.position.x > closestFoodPosition.x)
                {
                // Debug.LogWarning("Closest food" + findClosestFood());
                mysnakegenerator.savePosition();
                transform.position -= new Vector3(1f, 0);
                mysnakegenerator.drawTail(mysnakegenerator.snakelength);
                checkBounds();
                    myfoodgenerator.eatFood(this.transform.position);
                Debug.Log(mysnakegenerator.hitTail(this.transform.position, mysnakegenerator.snakelength));

            }

                else if(this.transform.position.y < closestFoodPosition.y)
                {
                // Debug.LogWarning("Closest food" + findClosestFood());
                mysnakegenerator.savePosition();
                transform.position += new Vector3(0, 1f);
                mysnakegenerator.drawTail(mysnakegenerator.snakelength);
                checkBounds();
                    myfoodgenerator.eatFood(this.transform.position);
                Debug.Log(mysnakegenerator.hitTail(this.transform.position, mysnakegenerator.snakelength));
            }

                else if (this.transform.position.y > closestFoodPosition.y)
                {
                //Debug.LogWarning("Closest food" + findClosestFood());
                mysnakegenerator.savePosition();
                transform.position -= new Vector3(0, 1f);
                mysnakegenerator.drawTail(mysnakegenerator.snakelength);
                checkBounds();
                    myfoodgenerator.eatFood(this.transform.position);
                    Debug.Log(mysnakegenerator.hitTail(this.transform.position, mysnakegenerator.snakelength));
            }

                yield return new WaitForSeconds(1f);
            
            

           
        }

    }


    private void Start()
    {
        mysnakegenerator = Camera.main.GetComponent<snakeGenerator>();
        myfoodgenerator = Camera.main.GetComponent<foodGenerator>();
    }

    void checkBounds()
    {
        if ((transform.position.x < -(Camera.main.orthographicSize-1)) || (transform.position.x > (Camera.main.orthographicSize - 1)))
        {
            transform.position = new Vector3(-transform.position.x,transform.position.y);
        }

        if ((transform.position.y < -(Camera.main.orthographicSize - 1)) || (transform.position.y > (Camera.main.orthographicSize - 1)))
        {
            transform.position = new Vector3(transform.position.x, -transform.position.y);
        }


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
			Debug.LogWarning("Closest food" + findClosestFood());
            transform.position -= new Vector3(1f,0);
			checkBounds();
            myfoodgenerator.eatFood(this.transform.position);
            Debug.Log(mysnakegenerator.hitTail(this.transform.position, mysnakegenerator.snakelength));

            if (mysnakegenerator.hitTail(this.transform.position, mysnakegenerator.snakelength))
            {
                SceneManager.LoadScene("endScene");
            }

        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
			Debug.LogWarning("Closest food" + findClosestFood());
            transform.position += new Vector3(1f, 0);
			checkBounds();
            myfoodgenerator.eatFood(this.transform.position);
            Debug.Log(mysnakegenerator.hitTail(this.transform.position, mysnakegenerator.snakelength));

            if (mysnakegenerator.hitTail(this.transform.position, mysnakegenerator.snakelength))
            {
                SceneManager.LoadScene("endScene");
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
			Debug.LogWarning("Closest food" + findClosestFood());
            transform.position += new Vector3(0, 1f);
			checkBounds();
            myfoodgenerator.eatFood(this.transform.position);
            Debug.Log(mysnakegenerator.hitTail(this.transform.position, mysnakegenerator.snakelength));

            if (mysnakegenerator.hitTail(this.transform.position, mysnakegenerator.snakelength))
            {
                SceneManager.LoadScene("endScene");
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
			Debug.LogWarning("Closest food" + findClosestFood());
            transform.position -= new Vector3(0, 1f);
			checkBounds();
            myfoodgenerator.eatFood(this.transform.position);
            Debug.Log(mysnakegenerator.hitTail(this.transform.position, mysnakegenerator.snakelength));

            if (mysnakegenerator.hitTail(this.transform.position, mysnakegenerator.snakelength))
            {
                SceneManager.LoadScene("endScene");
            }
        }

        //Debug.Log(mysnakegenerator.hitTail(this.transform.position, mysnakegenerator.snakelength)); 
    }
}
