//using System;
//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;
//using Object = UnityEngine.Object;

//namespace GameAsteroids
//{
//    internal sealed class BulletPool
//    {
//        private readonly Dictionary<string, HashSet<Bullet>> _bulletPool;
//        private readonly int _capacityPool;
//        private Transform _rootPool;
//        private Transform _transformGun;

//        public BulletPool(int capacityPool, Transform transformGun)
//        {
//            _transformGun = transformGun;
//            _bulletPool = new Dictionary<string, HashSet<Bullet>>();
//            _capacityPool = capacityPool;
//            if (!_rootPool)
//            {
//                _rootPool = new GameObject(NameManager.POOL_AMMUNITION).transform;
//            }
//        }

//        public Bullet GetBullet(string type)
//        {
//            Bullet result;
//            switch (type)
//            {
//                case "Bullet":
//                    result = GetBullet(GetListBullets(type));
//                    break;
//                default:
//                    throw new ArgumentOutOfRangeException(nameof(type), type, "Не предусмотрен в программе");
//            }
//            return result;
//        }

//        private HashSet<Bullet> GetListBullets(string type)
//        {
//            return _bulletPool.ContainsKey(type) ? _bulletPool[type] : _bulletPool[type] = new HashSet<Bullet>();
//        }

//        private Bullet GetBullet(HashSet<Bullet> bullets)
//        {
//            var bullet = bullets.FirstOrDefault(a => !a.gameObject.activeSelf);
//            if (bullet == null)
//            {
//                var laser = Resources.Load<Bullet>("Bullet");
//                for(var i = 0; i < _capacityPool; i++)
//                {
//                    var instantiate = Object.Instantiate(laser, _transformGun.position, _transformGun.rotation);
//                    ReturnToPool((instantiate.transform));
//                    bullets.Add(instantiate);
//                }
//                GetBullet(bullets);
//            }
//            bullet = bullets.FirstOrDefault(a => !a.gameObject.activeSelf);
//            return bullet;
//        }

//        private void ReturnToPool(Transform transform)
//        {
//            //transform.localPosition = Vector3.zero;
//            //transform.localRotation = Quaternion.identity;
//            transform.gameObject.SetActive(false);
//            transform.SetParent(_rootPool);
//        }

//        public void RemovePool()
//        {
//            Object.Destroy(_rootPool.gameObject);
//        }
//    }
//}
