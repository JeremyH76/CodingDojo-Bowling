using System.Text.RegularExpressions;

namespace CodingDojo_Bowling
{
    public class BowlingGame
    {
        private enum Multiplier { None, DoubleOneTime, DoubleTwoTimes, TripleThenDouble };

        private readonly string Score;

        private List<String> Frames
        {
            get
            {
                return Score.Split(' ').ToList();
            }
        }

        public BowlingGame(string scoreString)
        {
            Score = scoreString;
        }


        private static int GetOneScore(char c)
        {
            if (c == '-') { return 0; }
            else
            {
                return c - '0';
            }
        }

        public int Result
        {
            get
            {
                int ret = 0;
                Multiplier mult = Multiplier.None;
                List<string> frames = Frames;
                for (int i = 0; i < 9; i++)
                {
                    if (frames[i] == "X")
                    {
                        switch (mult)
                        {
                            case Multiplier.None: ret += 10; mult = Multiplier.DoubleTwoTimes; break;
                            case Multiplier.DoubleOneTime: ret += 20; mult = Multiplier.DoubleTwoTimes; break;
                            case Multiplier.DoubleTwoTimes: ret += 20; mult = Multiplier.TripleThenDouble; break;
                            case Multiplier.TripleThenDouble: ret += 30; break;
                        }
                    }
                    else if (Regex.IsMatch(frames[i], @"[\d-]\/"))
                    {
                        switch (mult)
                        {
                            case Multiplier.None: ret += 10; break;
                            case Multiplier.DoubleOneTime:
                                int firstScore = GetOneScore(frames[i][0]);
                                ret += firstScore * 2 + (10 - firstScore);
                                break;
                            case Multiplier.DoubleTwoTimes: ret += 20; break;
                            case Multiplier.TripleThenDouble:
                                int firstScore2 = GetOneScore(frames[i][0]);
                                ret += firstScore2 * 3 + (10 - firstScore2) * 2;
                                break;
                        }
                        mult = Multiplier.DoubleOneTime;
                    }
                    else
                    {
                        switch (mult)
                        {
                            case Multiplier.None: ret += GetOneScore(frames[i][0]) + GetOneScore(frames[i][1]); break;
                            case Multiplier.DoubleOneTime: ret += GetOneScore(frames[i][0]) * 2 + GetOneScore(frames[i][1]); break;
                            case Multiplier.DoubleTwoTimes: ret += (GetOneScore(frames[i][0]) + GetOneScore(frames[i][1])) * 2; break;
                            case Multiplier.TripleThenDouble: ret += GetOneScore(frames[i][0]) * 3 + GetOneScore(frames[i][1]) * 2; break;
                        }
                        mult = Multiplier.None;
                    }
                }
                //lastTries
                switch (mult)
                {
                    case Multiplier.None:
                        if (frames[9][0]=='X') { ret += 10; }
                        else { ret += GetOneScore(frames[9][0]); }
                        if (frames[9][1] == 'X') { ret += 10; }
                        else if (frames[9][1] == '/') { ret += 10 - GetOneScore(frames[9][0]); }
                        else { ret += GetOneScore(frames[9][1]); }
                        break;
                    case Multiplier.DoubleOneTime:
                        if (frames[9][0] == 'X') { ret += 20; }
                        else { ret += GetOneScore(frames[9][0]) * 2; }
                        if (frames[9][1] == 'X') { ret += 10; }
                        else if (frames[9][1] == '/') { ret += 10 - GetOneScore(frames[9][0]); }
                        else { ret += GetOneScore(frames[9][1]); }
                        break;
                    case Multiplier.DoubleTwoTimes:
                        if (frames[9][0] == 'X') { ret += 20; }
                        else { ret += GetOneScore(frames[9][0]) * 2; }
                        if (frames[9][1] == 'X') { ret += 20; }
                        else if (frames[9][1] == '/') { ret += (10 - GetOneScore(frames[9][0])) * 2; }
                        else { ret += GetOneScore(frames[9][1]) * 2; }
                        break;
                    case Multiplier.TripleThenDouble:
                        if (frames[9][0] == 'X') { ret += 30; }
                        else { ret += GetOneScore(frames[9][0]) * 3; }
                        if (frames[9][1] == 'X') { ret += 20; }
                        else if (frames[9][1] == '/') { ret += (10 - GetOneScore(frames[9][0])) * 2; }
                        else { ret += GetOneScore(frames[9][1]) * 2; }
                        break;
                }
                if (frames[9].Length == 3)
                {
                    if (frames[9][2] == 'X') { ret += 10; }
                    else if (frames[9][2] == '/') { ret += 10 - GetOneScore(frames[9][1]); }
                    else { ret += GetOneScore(frames[9][2]); }
                }
                return ret;
            }
        }
    }
}
