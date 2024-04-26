using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{
    [SerializeField] float verticalMovement;
    [SerializeField] float moveSpeed;
    private Vector3 origPosition;
    [SerializeField] Vector3 tempPosition;
    [SerializeField] float tempY;
    
    // Start is called before the first frame update
    void Start()
    {
        origPosition = this.transform.position;
        tempPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //tempY = Mathf.Sin(origPosition.y * verticalMovement * moveSpeed * Time.deltaTime);
        tempPosition.y = tempY;
    }


}
