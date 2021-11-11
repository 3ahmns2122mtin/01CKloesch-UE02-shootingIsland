using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject target;
    public GameObject parentOfTargets;
    public GameObject objCounter;

    private Text textCounter;
    public bool won;
    public int score;

    void Start()
    {
        textCounter = objCounter.GetComponent<Text>();
        won = false;
        InvokeRepeating("Spawn", 1f, 2f);
        

    }

    //Spawn a target at a random position within a specified x and y range.
    //Instantiate (make a concrete GameObject, i.e., a clone from the given prefab target) the
    //target as child of the parentOfTargets. In this case transform.localPosition instead of
    //transform.position is important!!

    private void Spawn()
    {
        float randomX = Random.Range(-370, 370);
        float randomY = Random.Range(-197, 197);

        Vector2 random2DPosition = new Vector2(randomX, randomY);

        GameObject myTarget = Instantiate(target, parentOfTargets.transform);
        myTarget.transform.localPosition = random2DPosition;
    }

    // Update is called once per frame
    void Update()
    {
       if(won == true)
        {
            CancelInvoke("Spawn");
        }
       else
        {
            Debug.Log(won);
        }

        if (Input.GetMouseButtonDown(0)) 
        {
            Debug.Log("Mouse pressed");

        }

        
}
    public void IncrementScore()
    {
        score++;
        Debug.Log("increment ..." + score);
        textCounter.text = score.ToString();

        if(score == 10)
        {
            won = true;
            
        }
    }
}
