namespace Palindrome
{
    class PalindromeCheck
    {
        private static string StringChallenge(string str)
        {
            // Remove non-alphanumeric characters and convert to lowercase
            str = new string([.. str.Where(c => char.IsLetterOrDigit(c))]).ToLower();
            return str == new string([.. str.Reverse()]) ? "true" : "false";
        }

        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                Console.WriteLine(StringChallenge(args[0]));
            }
            else
            {
                Console.WriteLine("Please input a string argument.");
                Console.ReadLine();
            }
            
        }
    }
    
}