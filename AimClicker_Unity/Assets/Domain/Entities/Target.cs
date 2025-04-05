using System;
using UnityEngine;

namespace AimClicker.Domain.Entities
{
    public class Target
    {
        public Guid Id { get; }
        public Vector2 Position { get; }
        public bool IsDestroyed { get; private set; }
        public float RewardMultiplier { get; private set; }

        public Target(Vector2 position, float rewardMultiplier = 1.0f)
        {
            Id = Guid.NewGuid();
            Position = position;
            RewardMultiplier = Mathf.Max(0.1f, rewardMultiplier); // 最低倍率を確保
            IsDestroyed = false;
        }

        public void Destroy()
        {
            IsDestroyed = true;
        }

        public void SetRewardMultiplier(float multiplier)
        {
            RewardMultiplier = Mathf.Max(0.1f, multiplier); // 再設定できる想定
        }
    }
} 