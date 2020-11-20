using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class snakeheadController : MonoBehaviour
{
    snakeGenerator mysnakegenerator;
    foodGenerator myfoodgenerator;

    private void Start()
    {
        mysnakegenerator = Camera.main.GetComponent<snakeGenerator>();
        myfoodgenerator = Camera.main.GetComponent<foodGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(1f,0);
            myfoodgenerator.eatFood(this.transform.position);
            Debug.Log(mysnakegenerator.hitTail(this.transform.position, mysnakegenerator.snakelength));

            if (mysnakegenerator.hitTail(this.transform.position, mysnakegenerator.snakelength))
            {
                SceneManager.LoadScene("endScene");
            }

        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1f, 0);
            myfoodgenerator.eatFood(this.transform.position);
            Debug.Log(mysnakegenerator.hitTail(this.transform.position, mysnakegenerator.snakelength));

            if (mysnakegenerator.hitTail(this.transform.position, mysnakegenerator.snakelength))
            {
                SceneManager.LoadScene("endScene");
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, 1f);
            myfoodgenerator.eatFood(this.transform.position);
            Debug.Log(mysnakegenerator.hitTail(this.transform.position, mysnakegenerator.snakelength));

            if (mysnakegenerator.hitTail(this.transform.position, mysnakegenerator.snakelength))
            {
                SceneManager.LoadScene("endScene");
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position -= new Vector3(0, 1f);
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
