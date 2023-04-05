using UnityEngine;

namespace Game
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform character;
        [SerializeField] private float smoothTime = 0.5f;

        private Vector3 _vel;

        private void Update()
        {
            var target = character.position;
            target.y = transform.position.y;
            target.z = transform.position.z;
            transform.position = Vector3.SmoothDamp(transform.position, target, ref _vel, smoothTime);
            //transform.forward = Vector3.SmoothDamp(transform.forward, character.forward, ref _vel, smoothTime);
        }
    }
}