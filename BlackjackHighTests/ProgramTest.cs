using System.Reflection;

namespace BlackjackHighTests
{
    public class ProgramTest
    {
        private static string InvokeBlackjackHighest(string[] hand)
        {
            var blackjackType = typeof(BlackjackHigh.Blackjack);
            var method = blackjackType.GetMethod("BlackjackHighest", BindingFlags.NonPublic | BindingFlags.Static);
            return (string)method.Invoke(null, [hand]);
        }

        [Theory]
        [InlineData(new string[] { "ace", "eight", "ace" }, "below ace")]
        [InlineData(new string[] { "ace", "nine", "ace" }, "blackjack ace")]
        [InlineData(new string[] { "two", "three", "ace", "king" }, "below king")]
        [InlineData(new string[] { "king", "four", "ten" }, "above king")]
        [InlineData(new string[] { "ten", "jack" }, "below jack")]
        [InlineData(new string[] { "ace", "queen" }, "blackjack ace")]
        [InlineData(new string[] { "ace", "eight", "ace", "ace" }, "blackjack ace")]
        [InlineData(new string[] { "ace", "eight", "king", "ace" }, "below king")]
        [InlineData(new string[] { "ace", "eight", "king", "ace", "ace" }, "blackjack king")]
        [InlineData(new string[] { "five", "six" }, "below six")]
        public void BlackjackHighest_ValidHands_ReturnsExpected(string[] hand, string expected)
        {
            var result = InvokeBlackjackHighest(hand);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void BlackjackHighest_InvalidCard_ThrowsArgumentException()
        {
            var ex = Assert.Throws<TargetInvocationException>(() => InvokeBlackjackHighest(["ten", "invalidcard"]));
            Assert.IsType<ArgumentException>(ex.InnerException);
            Assert.Contains("invalid card in hand", ex.InnerException.Message);
        }

        [Fact]
        public void BlackjackHighest_EmptyHand_ThrowsArgumentException()
        {
            var ex = Assert.Throws<TargetInvocationException>(() => InvokeBlackjackHighest([]));
            Assert.IsType<ArgumentException>(ex.InnerException);
            Assert.Contains("hand cannot be null or empty", ex.InnerException.Message);
        }

        [Fact]
        public void BlackjackHighest_NullHand_ThrowsArgumentException()
        {
            var ex = Assert.Throws<TargetInvocationException>(() => InvokeBlackjackHighest(null));
            Assert.IsType<ArgumentException>(ex.InnerException);
            Assert.Contains("hand cannot be null or empty", ex.InnerException.Message);
        }
    }
}