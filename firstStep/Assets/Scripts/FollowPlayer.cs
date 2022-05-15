using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //[SerializeField]
    private GameObject player; 
    private Vector3 offset;  

    private void Start () 
    {
        player = GameObject.FindGameObjectWithTag("Player");

        gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);

        offset = transform.position - player.transform.position;
    }

    private void LateUpdate () 
    {        
        transform.position = player.transform.position + offset;
    }
}
