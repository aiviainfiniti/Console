using System.Linq;

namespace BlackjackHigh
{
    public class Blackjack
    {
        private static string BlackjackHighest(string[] hand)
        {
            if (hand == null || hand.Length == 0)
            {
                throw new ArgumentException("hand cannot be null or empty", nameof(hand));
            }

            int highest = -1;
            string highCard = "";
            int total = 0;
            bool aceFound = false;

            List<string> cards = ["ace", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "jack", "queen", "king"];
            List<int> values = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10];

            foreach (string h in hand)
            {

                // Find the index of the card in the cards array
                int cardIx = cards.IndexOf(h);
                if (cardIx == -1)
                {
                    throw new ArgumentException($"invalid card in hand '{h}'", nameof(hand));
                }
                else
                {
                    total += values[cardIx];
                    if (cardIx > highest)
                    {
                        highest = cardIx;
                        highCard = cards[cardIx];
                    }
                    if (cardIx == 0)
                    {
                        aceFound = true;
                    }
                }
            }

            if (aceFound && total <= 11)
            {
                total += 10;
                highCard = "ace";
            }

            return (total < 21 ? "below " : total > 21 ? "above " : "blackjack ") + highCard;
        }
        static void Main(string[] args)
        {
            try
            {
                string[] input = ["ace", "eight", "ace"]; // Total 1 + 8 + 1 = 10. Ace becomes 11, total 19. Highest is "ace".
                Console.WriteLine($"[\"ace\", \"eight\", \"ace\"] -> {BlackjackHighest(input)}"); // Expected: below ace

                input = ["ace", "nine", "ace"]; // Total 1 + 9 + 1 = 11. Ace becomes 11, total 21. Highest is "ace".
                Console.WriteLine($"[\"ace\", \"nine\", \"ace\"] -> {BlackjackHighest(input)}"); // Expected: blackjack ace

                input = ["two", "three", "ace", "king"]; // Total 2 + 3 + 1 + 10 = 16. Ace becomes 11, total 26. Highest is "king".
                Console.WriteLine($"[\"two\", \"three\", \"ace\", \"king\"] -> {BlackjackHighest(input)}"); // Expected: above king

                input = ["king", "four", "ten"]; // Total 10 + 4 + 10 = 24. Highest is "king".
                Console.WriteLine($"[\"king\", \"four\", \"ten\"] -> {BlackjackHighest(input)}"); // Expected: above king

                input = ["ten", "jack"]; // Total 10 + 10 = 20. Highest is "jack".
                Console.WriteLine($"[\"ten\", \"jack\"] -> {BlackjackHighest(input)}"); // Expected: below jack

                input = ["ace", "queen"]; // Total 1 + 10 = 11. Ace becomes 11, total 21. Highest is "ace".
                Console.WriteLine($"[\"ace\", \"queen\"] -> {BlackjackHighest(input)}"); // Expected: blackjack ace

                input = ["five", "six"]; // Total 5 + 6 = 11. Highest is "six".
                Console.WriteLine($"[\"five\", \"six\"] -> {BlackjackHighest(input)}"); // Expected: below six

                // Test invalid card
                input = ["ten", "invalidcard"];
                Console.WriteLine($"[\"ten\", \"invalidcard\"] -> {BlackjackHighest(input)}"); // Expected: invalid card in hand 'invalidcard'

                // Test empty hand
                input = [];
                Console.WriteLine($"[] -> {BlackjackHighest(input)}"); // Expected: hand cannot be null or empty

                // Test null hand
                string[]? nullHand = null;
                Console.WriteLine($"null -> {BlackjackHighest(nullHand!)}"); // Expected: hand cannot be null or empty
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"An invalid Argument was passed: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}