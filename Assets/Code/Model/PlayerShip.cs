using UnityEngine;

namespace GameAsteroids
{
    public sealed class PlayerShip : PlayerBase
    {
        private Rigidbody2D _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public override void Move(float x, float y)
        {
            _rigidbody.AddForce(new Vector2(x, y) * Speed);
        }

        public override void AddAcceleration()
        {
            Speed += _acceleration;
        }

        public override void RemoveAcceleration()
        {
            Speed -= _acceleration;
        }

        public override void Rotation(Vector2 direction)
        {
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        public override void GetDamage(float damage)
        {
            Hp -= damage;
            Debug.Log(Hp);
        }
    }
}
