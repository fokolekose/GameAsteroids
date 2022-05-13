using UnityEngine;

namespace GameAsteroids
{
    internal sealed class GameController : MonoBehaviour
    {
        private InputController _inputController;
        private Reference _reference;
        private Gun _gun;
        private Rigidbody2D _bulletRb;
        private IViewServices _viewServices;

        private void Start()
        {
            _viewServices = new ViewServices();
            _bulletRb = _reference.Bullet.GetComponent<Rigidbody2D>();
            _reference = new Reference();
            _gun = new Gun(_bulletRb, _viewServices);
            _inputController = new InputController(_reference.PlayerShip, _gun);
            

            Enemy.CreateAsteroidEnemy(new Health(100.0f, 100.0f));

            //BulletPool bulletPool = new BulletPool(5);
            //var bullet = bulletPool.GetBullet("Bullet1");
            //bullet.transform.position = Vector3.one;
            //bullet.gameObject.SetActive(true);
        }

        private void FixedUpdate()
        {
            _inputController.ExecuteFixedUpdate();
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
            //else
            //{
            //    _reference.PlayerShip.GetDamage(_hp);
            //}
        }
    }
}

