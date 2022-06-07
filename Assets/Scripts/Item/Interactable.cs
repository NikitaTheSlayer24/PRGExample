using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private Transform _interactionTransform;
    [SerializeField] private Transform _player;

    private bool _isFocus = false;
    private bool _hasInteracted = false;

    public virtual void Interact()
    {
       // Debug.Log("Interacting with " + transform.name);
    }

    private void Update()
    {
       
            float distance = Vector2.Distance(_player.position, _interactionTransform.position);           
            _hasInteracted = true;        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            Interact();
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        _isFocus = true;
        _player = playerTransform;
        _hasInteracted = false;
    }

    public void Defocused()
    {
        _isFocus = false;
        _player = null;
        _hasInteracted = false;
    }
}
