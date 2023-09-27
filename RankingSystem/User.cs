namespace RankingSystem;
sealed class User
{
    // NOTE: names for rank, progress and incProgress are mandatory as they are used in tests :(
    public int rank { get; private set; }
    public int progress { get; private set; }

    public User()
    {
        rank = -8;
        progress = 0;
    }

    public void incProgress(int actRank)
    {
        if (IsRankInvalid(actRank))
        {
            throw new ArgumentException();
        }

        if (rank < 8)
        {
            int difference = CalculateRankDifference(actRank);
            int reward = CalculateProgress(difference);
            progress += reward;
        }

        if (progress >= 100)
        {
            IncreaseRank();
        }
    }

    private int CalculateProgress(int difference)
    {
        switch (difference)
        {
            case <= -2:
                return 0;
            case -1:
                return 1;
            case 0:
                return 3;
            default:
                return 10 * difference * difference;
        }
    }

    private int CalculateRankDifference(int activityRank)
    {
        int result = 0;

        if (activityRank < rank)
        {
            for (int i = activityRank; i < rank; i++)
            {
                if (i == 0)
                {
                    continue;
                }

                result -= 1;
            }

            return result;
        }


        for (int i = rank; i < activityRank; i++)
        {
            if (i == 0)
            {
                continue;
            }

            result += 1;
        }

        return result;
    }

    private bool IsRankInvalid(int activityRank)
    {
        return activityRank < -8 || activityRank == 0 || activityRank > 8;
    }

    private void IncreaseRank()
    {
        while (progress > 100)
        {
            progress -= 100;
            rank += 1;
            if (rank == 0)
            {
                rank = 1;
            }

            if (rank == 8)
            {
                progress = 0;
            }
        }
    }
}