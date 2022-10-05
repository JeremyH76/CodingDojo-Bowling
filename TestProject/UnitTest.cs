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
    }
}
