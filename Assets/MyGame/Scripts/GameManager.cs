using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject target;
    public GameObject parentOfTargets;
    public GameObject objCounter;
    public GameObject wonObj;
    public GameObject shootSound;
    public GameObject hitSound;
    public GameObject deathTarget;
    public GameObject parentOfDeathTargets;

    private const int maxHit = 10;
    private Text textCounter;
    private bool won;
    private int score;

    void Start()
    {
        textCounter = objCounter.GetComponent<Text>();
        won = false;
        InvokeRepeating("Spawn", 1f, 2f);
        InvokeRepeating("DeathSpawn", 3f, 7f);
        wonObj.SetActive(false);
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

    private void DeathSpawn()
    {
        float randomXX = Random.Range(-375, 375);
        float randomYY = Random.Range(-180, 180);

        Vector2 random2DPositionTwo = new Vector2(randomXX, randomYY);

        GameObject myDeathTarget = Instantiate(deathTarget, parentOfDeathTargets.transform);
        myDeathTarget.transform.localPosition = random2DPositionTwo;
    }

    // Update is called once per frame
    void Update()
    {
       if(won == true)
        {
            CancelInvoke("Spawn");
            CancelInvoke("DeathSpawn");
            wonObj.SetActive(true);
        }
       else
        {
            Debug.Log(won);
        }

        

        
}
    public void IncrementScore()
    {
        score++;
        Debug.Log("increment ..." + score);
        textCounter.text = score.ToString();

        if(score == maxHit)
        {
            won = true;
            
        }
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse pressed");
            shootSound.GetComponent<AudioSource>().Play();

        }
    }

    public void DecrementScore()
    {
        score--;
        Debug.Log("decrement ..." + score);
        textCounter.text = score.ToString();

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse pressed");
            hitSound.GetComponent<AudioSource>().Play();

        }
    }
}
