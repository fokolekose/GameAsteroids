using UnityEngine;

namespace GameAsteroids
{
    internal sealed class InputController : IExecute
    {
        private PlayerBase _ship;
        private Gun _gun;
        private Camera _camera;

        public InputController(PlayerBase ship, Gun gun)
        {
            _ship = ship;
            _gun = gun;
            _camera = Camera.main;
        }

        public void ExecuteFixedUpdate()
        {
            _ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _ship.AddAcceleration();
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _ship.RemoveAcceleration();
            }

            var _direction = Input.mousePosition - _camera.WorldToScreenPoint(_ship.transform.position);
            _ship.Rotation(_direction);
        }

        public void ExecuteUpdate()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                _gun.Fire();
            }
        }
    }
}
