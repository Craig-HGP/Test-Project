using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] int value;
    Player player;
    bool wasCollected;
    [SerializeField] float spinSpeed;


    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        transform.Rotate(spinSpeed * Time.deltaTime,0,0);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player" && !wasCollected)
        {
            player.glitter.Play();
            player.audioSource.Play();
            wasCollected = true;
            player.coinScore += value;
            Destroy(gameObject);
            
        }
    }
}
