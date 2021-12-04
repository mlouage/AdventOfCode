namespace AOC._2021.Days;

public class Day04
{
    public int Part1(string numbersInput, string[] input)
    {
        var (numbers, cardsData) = CreateCardData(numbersInput, input);
        var cards = CreateCards(cardsData);

        var breakOut = false;

        foreach (var number in numbers)
        {
            foreach (var card in cards)
            {
                card.Check(number);

                if (card.HasWon())
                {
                    breakOut = true;
                    break;
                }
            }

            if (breakOut)
            {
                break;
            }
        }

        var winningCard = cards.First(c => c.Won);

        return winningCard.Calculate();
    }

    public int Part2(string numbersInput, string[] input)
    {

        var (numbers, cardsData) = CreateCardData(numbersInput, input);

        var cards = CreateCards(cardsData);

        foreach (var number in numbers)
        {
            foreach (var card in cards)
            {
                card.Check(number);

                if (card.HasWon())
                {
                   if (!cards.Any(card => !card.Won))
                   {
                        return card.Calculate();
                   }
                }
            }            
        }

        return 0;
    }

    private static (string[], List<IEnumerable<string>>) CreateCardData(string numbersInput, string[] input)
    {
        var numbers = numbersInput.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        var cardsData = new List<IEnumerable<string>>();
        var cardData = new List<string>();

        foreach (var line in input)
        {
            if (line == string.Empty)
            {
                cardsData.Add(cardData);
                cardData = new List<string>();
                continue;
            }

            cardData.Add(line);
        }

        cardsData.Add(cardData);

        return (numbers, cardsData);
    }

    private static List<Card> CreateCards(List<IEnumerable<string>>? cardsData)
    {
        var cards = new List<Card>();

        foreach (var items in cardsData)
        {
            var card = new Card();
            card.Create(items);
            cards.Add(card);
        }

        return cards;
    }
}

public class Card
{
    private const int MatrixSize = 5;
    private const string Mark = "X";
    private string[,] _matrix = new string[MatrixSize, MatrixSize];
    private int _drawnNumber = 1;

    public bool Won = false;

    public void Create(IEnumerable<string> data)
    {
        for (var i = 0; i <= data.Count() - 1; i++)
        {
            var row = data.ElementAt(i);
            var numbers = row.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            for (var j = 0; j <= numbers.Length - 1; j++)
            {
                _matrix[i, j] = numbers[j];
            }
        }
    }

    public void Check(string number)
    {
        _drawnNumber = int.Parse(number);

        for (int i = 0; i <= MatrixSize - 1; i++)
        {
            for (int j = 0; j <= MatrixSize - 1; j++)
            {
                if (_matrix[i, j] == number)
                {
                    _matrix[i, j] = Mark;
                }
            }
        }
    }

    public bool HasWon()
    {
        for (int i = 0; i <= MatrixSize - 1; i++)
        {
            if (CheckRow(_matrix, i))
            {
                Won = true;
                return true;
            }

            if (CheckColumn(_matrix, i))
            {
                Won = true;
                return true;
            }
        }

        return false;
    }

    public int Calculate()
    {
        var sum = 0;

        for (int i = 0; i <= MatrixSize - 1; i++)
        {
            for (int j = 0; j <= MatrixSize - 1; j++)
            {
                var number = _matrix[i, j];

                if (number == Mark)
                {
                    continue;
                }

                sum += int.Parse(number);
            }
        }

        return sum * _drawnNumber;
    }

    private static bool CheckColumn(string[,] matrix, int columnNumber)
    {
        return Enumerable.Range(0, matrix.GetLength(0))
            .Select(x => matrix[x, columnNumber])
            .All(x => x == Mark);
    }

    private static bool CheckRow(string[,] matrix, int rowNumber)
    {
        return Enumerable.Range(0, matrix.GetLength(1))
            .Select(x => matrix[rowNumber, x])
            .All(x => x == Mark);
    }
}