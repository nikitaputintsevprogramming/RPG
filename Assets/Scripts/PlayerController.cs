using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{    
    public PlayerMovement _playerMovement;
    public Interactable focus;

    public Camera camera;
    public LayerMask movementMask;

    void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        camera = Camera.main;
    }
    
    void Update()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if(Input.GetMouseButtonDown(0))
        {
            // Создаем луч
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            Debug.DrawRay(ray.origin, ray.direction * 1000f, Color.blue);
            // Если луч ударяется 
            if(Physics.Raycast(ray, out hit, 1000f))
            {                    
                _playerMovement.MoveToPoint(hit.point);

                RemoveFocus();
            }
        }
        if(Input.GetMouseButtonDown(1))
        {
            // Создаем луч
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            

            // Если луч ударяется 
            if(Physics.Raycast(ray, out hit, movementMask))
            {         
                // Фокусировка направления игрока

                Interactable _interactable = hit.collider.gameObject.GetComponent<Interactable>();
                if(_interactable != null)
                {
                    SetFocus(_interactable);
                }
            }
        }
    }

    void SetFocus(Interactable newFocus)
    {
        if(newFocus != focus)
        {
            if(focus != null)
            {
                focus.OnDefocused();
            }
            
            focus = newFocus;
            _playerMovement.FollowTarget(newFocus);
        }
        
        newFocus.OnFocused(transform);        
    }

    void RemoveFocus()
    {
        if(focus != null)
        {
            focus.OnDefocused();   
        }

        // focus.OnDefocused();
        focus = null;
        _playerMovement.StopFollowingTarget();
    }
}