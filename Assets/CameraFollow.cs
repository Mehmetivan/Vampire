using UnityEngine;

public class CameraFollow : MonoBehaviour, IUpdateable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float FollowSpeed = 5f;
    public Transform target;


    private void OnEnable()
    {
        GameUpdateManager.Instance.Register(this, UpdatePriority.High);
        
    }
    private void OnDisable()
    {
        GameUpdateManager.Instance.Unregister(this);
        
    }

    public void OnUpdate(float deltaTime) {

        Vector3 newPos = new Vector3(target.position.x, target.position.y, -10f);
        transform.position = Vector3.Lerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
        //transform.position = newPos;

    }

}
