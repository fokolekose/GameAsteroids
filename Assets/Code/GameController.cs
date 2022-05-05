using UnityEngine;

namespace GameAsteroids
{
    internal sealed class GameController : MonoBehaviour
    {
        [SerializeField] private float _hp = 10;
        private InputController _inputController;
        private Reference _reference;

        private void Start()
        {
            _reference = new Reference();
            _inputController = new InputController(_reference.PlayerShip, _reference.Gun);
        }

        private void FixedUpdate()
        {
            _inputController.Execute();
        }

        private void Update()
        {
            _inputController.ExecuteUpdate();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.otherCollider.CompareTag("Player"))
            {
                return;
            }
            else
            {
                _reference.PlayerShip.GetDamage(_hp);
            }
        }
    }
}

