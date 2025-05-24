using UnityEngine;

namespace Game.Scripts.Gameplay.ViewsLayer.Ships
{
    public class ShipSail : MonoBehaviour
    {
        [SerializeField] private Vector3 startPosition;
        [SerializeField] private Vector3 startScale;
        
        [SerializeField] private Vector3 finishPosition;
        [SerializeField] private Vector3 finishScale;


        private void Start()
        {
            LerpSail(0);
        }

        public void LerpSail(float lerpValue)
        {
            transform.localPosition = Vector3.Lerp(startPosition, finishPosition, lerpValue);
            transform.localScale = Vector3.Lerp(startScale, finishScale, lerpValue);
        }
    }
}