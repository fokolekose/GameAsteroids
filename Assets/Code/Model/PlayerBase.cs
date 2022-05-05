using UnityEngine;

namespace GameAsteroids
{
    public abstract class PlayerBase : MonoBehaviour
    {
        protected float Hp = 100.0f;
        protected float Speed = 10.0f;
        protected readonly float _acceleration = 50.0f;

        public abstract void Move(float x, float y);
        public abstract void AddAcceleration();
        public abstract void RemoveAcceleration();
        public abstract void Rotation(Vector2 direction);
        public abstract void GetDamage(float damage);
    }
}
