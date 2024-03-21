using UnityEngine;

public class FillCell : MonoBehaviour
{
    [SerializeField] float speed;
    public void OnInit()
    {
        transform.localPosition = Vector3.zero;
    }
    public void OnDespawn()
    {

    }

    private void Update()
    {
        if(transform.localPosition != Vector3.zero && GameManager.IsState(GameState.GamePlay))
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, Vector3.zero, speed * Time.deltaTime);
        }
    }
}
