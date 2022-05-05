using UnityEngine;

namespace GameAsteroids
{
    public class Reference
    {
        private PlayerShip _playerShip;
        private Gun _gun;

        public Gun Gun
        {
            get
            {
                if(_gun == null)
                {
                    _gun = _playerShip.GetComponentInChildren<Gun>();
                }
                return _gun;
            }
        }

        public PlayerShip PlayerShip
        {
            get
            {
                if( _playerShip == null)
                {
                    var gameObject = Resources.Load<PlayerShip>("Player");
                    _playerShip = Object.Instantiate(gameObject);
                }
                return _playerShip;
            }
        }
    }
}
