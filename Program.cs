namespace Hangman
{
    class Program
    {
        public static string[] words = {"ant", "baboon", "badger", "bat", "bear", "beaver", "camel",
        "cat", "clam", "cobra", "cougar", "coyote", "crow", "deer",
        "dog", "donkey", "duck", "eagle", "ferret", "fox", "frog", "goat",
        "goose", "hawk", "lion", "lizard", "llama", "mole", "monkey", "moose",
        "mouse", "mule", "newt", "otter", "owl", "panda", "parrot", "pigeon", 
        "python", "rabbit", "ram", "rat", "raven","rhino", "salmon", "seal",
        "shark", "sheep", "skunk", "sloth", "snake", "spider", "stork", "swan",
        "tiger", "toad", "trout", "turkey", "turtle", "weasel", "whale", "wolf",
        "wombat", "zebra"};

        public static string[] gallows = {"+---+\n" +
        "|   |\n" +
        "    |\n" +
        "    |\n" +
        "    |\n" +
        "    |\n" +
        "=========\n",

        "+---+\n" +
        "|   |\n" +
        "O   |\n" +
        "    |\n" +
        "    |\n" +
        "    |\n" +
        "=========\n",

        "+---+\n" +
        "|   |\n" +
        "O   |\n" +
        "|   |\n" +
        "    |\n" +
        "    |\n" +
        "=========\n",

        " +---+\n" +
        " |   |\n" +
        " O   |\n" +
        "/|   |\n" +
        "     |\n" +
        "     |\n" +
        " =========\n",

        " +---+\n" +
        " |   |\n" +
        " O   |\n" +
        "/|\\  |\n" +
        "     |\n" +
        "     |\n" +
        " =========\n",

        " +---+\n" +
        " |   |\n" +
        " O   |\n" +
        "/|\\  |\n" +
        "/    |\n" +
        "     |\n" +
        " =========\n",

        " +---+\n" +
        " |   |\n" +
        " O   |\n" +
        "/|\\  |\n" + 
        "/ \\  |\n" +
        "     |\n" +
        " =========\n"};

        private static int numOfGuesses;
        private static Random rnd = new Random();
        private static int index;
        private static char[] word = {};
        private static List<char> guessedChar = new List<char>();

        public static void Main(string[] args)
        {
            init();

            while(numOfGuesses < 6)
            {
                display(numOfGuesses);
                Console.Write("Guess:\t");
                char guess;
                char.TryParse(Console.ReadLine(), out guess);

                if (!guessedChar.Contains(guess))
                {
                    guessedChar.Add(guess);

                    if (word.Contains(guess))
                    {
                        if (checkWin(word, guessedChar.ToArray()))
                        {
                            display(numOfGuesses);
                            Console.WriteLine("GOOD WORK!");
                            break;
                        }
                    }
                    else 
                    {
                        numOfGuesses++;
                        if (numOfGuesses >= 6) Console.WriteLine($"\nRIP!\n\nThe word was '{printArr(word)}'\n");
                    }
                }
            }
        }

        private static void init()
        {
            numOfGuesses = 0;
            index = rnd.Next(words.Count());
            word = words[index].ToCharArray();
            guessedChar = new List<char>();
        }

        private static void display(int i)
        {
            Console.WriteLine($"\n{gallows[i]}\n");
            Console.WriteLine($"Word:\t{displayWord(word, guessedChar.ToArray())}\n");
            Console.WriteLine($"Misses:\t{displayMisses(word, guessedChar.ToArray())}\n");
        }

        private static string displayWord(char[] word, char[] guesses)
        {
            string output = "";

            foreach (char letter in word)
            {
                output += (guesses.Contains(letter)) ? letter+" " : "_ "; 
            }

            return output;
        }

        private static string displayMisses(char[] word, char[] guesses)
        {
            string output = "";

            foreach (char letter in guesses)
            {
                output += (!word.Contains(letter)) ? letter : ""; 
            }

            return output;
        }

        private static bool checkWin(char[] word, char[] guesses)
        {
            foreach (char c in word)
            {   
                if (!guesses.Contains(c)) return false;
            }

            return true;
        }

        private static string printArr(char[] arr)
        {
            string output = "";

            foreach (char c in arr)
            {
                output += c;
            }

            return output;
        }
    }
}