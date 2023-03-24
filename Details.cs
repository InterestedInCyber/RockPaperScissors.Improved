namespace RockPaperScissors.Improved;

public class Details
{
    private readonly Func<string> _inputHandler;
    private readonly Action<string> _outputHandler;
    private readonly Action<string> _spacedMessage;

    public Details(Func<string> inputHandler, Action<string> outputHandler, Action<string> spacedMessage)
    {
        _inputHandler = inputHandler;
        _outputHandler = outputHandler;
        _spacedMessage = spacedMessage;
    }

    public void AskForChoice()
    {
        _outputHandler("Welcome to Rock Paper Scissors");
        _spacedMessage("");
        
        Choice();

        void Choice()
        {
            while (true)
            {
                string[] rockPaperOrScissors = { "Rock", "Paper", "Scissors" };
                var pick = new Random();
                var pickIndex = pick.Next(rockPaperOrScissors.Length);
                var randomPick = rockPaperOrScissors[pickIndex];
                
                _outputHandler("Pick Your Poison (Rock, Paper or Scissors) : ");
                var userChoice = _inputHandler();

                switch (userChoice)
                {
                    case "":
                        Choice();
                        break;
                    case "clear" or "Clear":
                        Console.Clear();
                        break;
                    case "q" or "Q":
                        Environment.Exit(1);
                        break;
                    default:
                        if (userChoice == randomPick)
                        {
                            var samePick = $"You see both of you picking {userChoice} is BORING! Pick something else.";

                                foreach (var letter in samePick)
                                {
                                    Console.Write(letter);
                                    Thread.Sleep(50);

                                    if (letter == '!')
                                    {
                                        Thread.Sleep(400);
                                    }
                                }

                                _spacedMessage("");
                                Choice();
                        }

                        if (userChoice is "Rock" or "rock" && randomPick is "Scissors" ||
                            userChoice is "Paper" or "paper" && randomPick is "Rock" ||
                            userChoice is "Scissors" or "scissors" && randomPick is "Paper")
                        {
                            var userBeatCpu = $"{userChoice} does in fact beat {randomPick}. Congratulations";
                            
                            foreach (var letter in userBeatCpu)
                            {
                                Console.Write(letter);
                                Thread.Sleep(50);

                                if (letter == '.')
                                {
                                    Thread.Sleep(400);
                                }
                            }

                            _spacedMessage("");
                            Choice();
                        }

                        if (userChoice is not "Rock" or "Paper" or "Scissors")
                        {
                            Choice();
                        }

                        var cpuBeatsUser = $"You know, {randomPick} beats {userChoice} right?";
                        
                        foreach (var letter in cpuBeatsUser)
                        {
                            Console.Write(letter);
                            Thread.Sleep(50);

                            if (letter == ',')
                            {
                                Thread.Sleep(200);
                            }
                        }

                        _spacedMessage("");
                        break;
                }
            }
        }
    }
}