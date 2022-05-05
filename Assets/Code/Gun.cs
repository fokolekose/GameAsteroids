using UnityEngine;

namespace GameAsteroids
{
    public sealed class Gun : MonoBehaviour
    {
        private Rigidbody2D _bulletRb;
        private GameObject _bullet;
        private float _force;

        private void Start()
        {
            _force = 70.0f;
            _bullet = Resources.Load("Bullet") as GameObject;
            _bulletRb = _bullet.GetComponent<Rigidbody2D>();
        }

        public void Fire()
        {
            var temAmmunition = Instantiate(_bulletRb, transform.position, transform.rotation);
            temAmmunition.AddForce(transform.up * _force);
        }
    }
}
