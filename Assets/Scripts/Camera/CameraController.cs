using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private void Update()
    {
        transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, transform.position.z);
    }
}
