using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    [SerializeField] private Transform player;
    private float offset = 1f;

    // Update is called once per frame
    void Update()
    {
        PlayerRotation();
    }

    void PlayerRotation()
    {
        var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0, 0, 1));

        Vector3 playerToMouseDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.position;
        playerToMouseDirection.z = 0;
        transform.position = player.position + (offset * playerToMouseDirection.normalized);
    }
}
