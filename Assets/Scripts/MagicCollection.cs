using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCollection : MonoBehaviour
{

    public GameObject player;

    public void OnTriggerEnter(Collider other)
    {
        player.GetComponent<Player>().MagicCollected();
    }


}
