using UnityEngine;

public class ChestController : MonoBehaviour
{
    private Animator _animator;
    private bool _isOpened;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!_isOpened && collision.gameObject.tag == "Player")
        {           
            _animator.SetTrigger("ToOpening");
            _isOpened = true;
        }
    }
}
