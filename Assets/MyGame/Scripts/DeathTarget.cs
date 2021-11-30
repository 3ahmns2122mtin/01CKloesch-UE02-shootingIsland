using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTarget : MonoBehaviour
{
    [SerializeField] private int secToDestroy;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnMouseDown()
    {
        gameManager.DecrementScore();
        Destroy(gameObject);

    }
}
