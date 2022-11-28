using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform player;
    private Vector3 offset;
    void Update()
    {
        transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z - 10); // Camera follows the player with specified offset position
    }
}