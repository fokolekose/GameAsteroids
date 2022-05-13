using UnityEngine;

namespace GameAsteroids
{
    public sealed class Gun
    {
        private readonly Rigidbody2D _bulletRb;
        private readonly IViewServices _viewServices;

        public Gun(Rigidbody2D bulletRb, IViewServices viewServices)
        {
            _bulletRb = bulletRb;
            _viewServices = viewServices;
        }

        public void Fire()
        {
            var bullet = _viewServices.Instantiate<Rigidbody2D>(_bulletRb.gameObject);
            bullet.AddForce(Vector3.forward);
            _viewServices.Destroy(bullet.gameObject);
        }
    }
}
