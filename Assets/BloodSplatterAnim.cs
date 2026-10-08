using UnityEngine;

public class BloodSplatterAnim : MonoBehaviour
{
    [SerializeField] private float lifetime = 0.5f; // set to the clip length

    private void Start() { Destroy(gameObject, lifetime); }
}