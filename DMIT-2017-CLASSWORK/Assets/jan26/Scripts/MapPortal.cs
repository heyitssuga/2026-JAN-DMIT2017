using System;
using UnityEngine;

public class MapPortal : MonoBehaviour
{
    public int targetMapID = 0;
    public int targetPortalID = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player") return;
        MapNavigation.instance.GoToMap(targetMapID, targetPortalID);
    }
}
