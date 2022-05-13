using UnityEngine;

namespace GameAsteroids
{
    public interface IViewServices
    {
        public T Instantiate<T>(GameObject prefab);
        public void Destroy(GameObject value);
    }
}
