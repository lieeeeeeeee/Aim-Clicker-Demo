namespace AimClicker.Domain.Entities
{
    public class Player
    {
        public long Currency { get; private set; }
        public long Experience { get; private set; }
        public int Level { get; private set; }

        public Player(long currency = 0, long experience = 0, int level = 1)
        {
            Currency = currency;
            Experience = experience;
            Level = level;
        }

        public void AddCurrency(long amount)
        {
            if (amount < 0) return; // 負数加算とか意味不明なバグ対策
            Currency += amount;
        }

        public bool AddExperience(long amount)
        {
            if (amount < 0) return false;
            Experience += amount;

            if (CanLevelUp())
            {
                Level++;
                Experience = 0; // 仮仕様：レベルアップで経験値リセット
                AddCurrency(GetLevelUpReward()); // レベルアップ報酬
                return true;
            }

            return false;
        }

        public bool CanLevelUp()
        {
            return Experience >= GetRequiredExperienceForNextLevel();
        }

        private long GetRequiredExperienceForNextLevel()
        {
            return 100 * Level;
        }

        private long GetLevelUpReward()
        {
            return 50 * Level; // 仮仕様：レベル × 50 通貨を報酬
        }
    }
} 