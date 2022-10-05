using CodingDojo_Bowling;

namespace TestProject
{
    public class UnitTest
    {
        [Fact]
        public void TestZeroPoint()
        {
            BowlingGame game = new BowlingGame("-- -- -- -- -- -- -- -- -- --");
            Assert.Equal(0, game.Result);
        }

        [Fact]
        public void TestOnePoint()
        {
            BowlingGame game = new BowlingGame("-- -- -1 -- -- -- -- -- -- --");
            Assert.Equal(1, game.Result);
        }

        [Fact]
        public void TestLotOfPoints()
        {
            BowlingGame game = new BowlingGame("41 81 4- 34 -8 14 9- -2 54 13");
            Assert.Equal(62, game.Result);
        }

        [Fact]
        public void TestOneSpare()
        {
            BowlingGame game = new BowlingGame("-- -- 3/ -- -- -- -- -- -- --");
            Assert.Equal(10, game.Result);
        }

        [Fact]
        public void TestOneSpareWithBonusPoints()
        {
            BowlingGame game = new BowlingGame("-- -- 3/ 5- -- -- -- -- -- --");
            Assert.Equal(20, game.Result);
        }

        [Fact]
        public void TestTwoSpares()
        {
            BowlingGame game = new BowlingGame("-- -- 3/ 5/ 5- -- -- -- -- --");
            Assert.Equal(35, game.Result);
        }

        [Fact]
        public void TestOneSpareAndNoBonusPoint()
        {
            BowlingGame game = new BowlingGame("-- -- 3/ -5 -- -- -- -- -- --");
            Assert.Equal(15, game.Result);
        }

        [Fact]
        public void TestOneStrike()
        {
            BowlingGame game = new BowlingGame("-- -- X -- -- -- -- -- -- --");
            Assert.Equal(10, game.Result);
        }
        [Fact]
        public void TestOneStrikeWithBonusPoints()
        {
            BowlingGame game = new BowlingGame("-- -- X 5- -- -- -- -- -- --");
            Assert.Equal(20, game.Result);
        }

        [Fact]
        public void TestOneStrikeWithBonusPointsSecondTry()
        {
            BowlingGame game = new BowlingGame("-- -- X -5 -- -- -- -- -- --");
            Assert.Equal(20, game.Result);
        }

        [Fact]
        public void TestOneStrikeWithBonusPointsAtFirstAndSecondTry()
        {
            BowlingGame game = new BowlingGame("-- -- X 35 -- -- -- -- -- --");
            Assert.Equal(26, game.Result);
        }

        [Fact]
        public void TestSpareAndAfterStrike()
        {
            BowlingGame game = new BowlingGame("-- 8/ X 35 -- -- -- -- -- --");
            Assert.Equal(46, game.Result);
        }

        [Fact]
        public void TestStrikeAndAfterSpare()
        {
            BowlingGame game = new BowlingGame("-- -- X 3/ 6- -- -- -- -- --");
            Assert.Equal(42, game.Result);
        }

        [Fact]
        public void TestTripleStrike()
        {
            BowlingGame game = new BowlingGame("-- -- X X X -- -- -- -- --");
            Assert.Equal(60, game.Result);
        }

        [Fact]
        public void TestTripleStrikeAndSomePoints()
        {
            BowlingGame game = new BowlingGame("-- -- X X X 63 -- -- -- --");
            Assert.Equal(84, game.Result);
        }

        [Fact]
        public void TestLastFrame()
        {
            BowlingGame game = new BowlingGame("-- -- -- -- -- -- -- -- -- 8/3");
            Assert.Equal(16, game.Result);
        }

        [Fact]
        public void TestLastFrameNoBonusBall()
        {
            BowlingGame game = new BowlingGame("-- -- -- -- -- -- -- -- -- 81");
            Assert.Equal(9, game.Result);
        }

        [Fact]
        public void TestLastFrameStrike()
        {
            BowlingGame game = new BowlingGame("-- -- -- -- -- -- -- -- -- X33");
            Assert.Equal(16, game.Result);
        }

        [Fact]
        public void TestLastFrameWithStrikeBefore()
        {
            BowlingGame game = new BowlingGame("-- -- -- -- -- -- -- -- X 8/3");
            Assert.Equal(36, game.Result);
        }

        [Fact]
        public void TestStandardGame()
        {
            BowlingGame game = new BowlingGame("6/ 4/ X -5 -- -/ 32 7- X 54");
            Assert.Equal(107, game.Result);
        }

        [Fact]
        public void TestProGame()
        {
            BowlingGame game = new BowlingGame("03 X X X X X X 9/ 9- XX8");
            Assert.Equal(228, game.Result);
        }
    }
}
