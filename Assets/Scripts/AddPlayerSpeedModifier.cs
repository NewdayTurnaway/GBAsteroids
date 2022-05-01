using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GBAsteroids
{
    internal sealed class AddPlayerSpeedModifier : PlayerModifier
    {
        private readonly float _maxSpeed;
        private readonly float _increaseSpeed;

        public AddPlayerSpeedModifier(PlayerModel playerModel, float maxSpeed, float increaseSpeed) : base(playerModel)
        {
            _maxSpeed = maxSpeed;
            _increaseSpeed = increaseSpeed;
        }

        public override void Handle()
        {
            if (_playerModel.Speed <= _maxSpeed)
            {
                _playerModel.Speed += _increaseSpeed;
            }

            base.Handle();
        }
    }
}