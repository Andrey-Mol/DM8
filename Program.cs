using System;
public class Program
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("Введите слово: ");

            if (RecognizingAutomaton.IsWord(Console.ReadLine()))
                Console.WriteLine("Слово\n");
            else
                Console.WriteLine("Не слово\n");

        }
    }
}
public class RecognizingAutomaton
{
    private enum States
    {
        Start,
        D,
        Error,
        Final
    }

    private static readonly char[] alphabet = { 'a', 'b', 'c', 'd' };

    private static readonly int[,] matrix = new int[,]
    {
        {0, 1, 2, 3},
        {2, 3, 2, 3},
        {0, 1, 2, 3},
        {1, 1, 2, 3}
    };

    private static States Transition(States currentState, char input)
    {
        int inputIndex = Array.IndexOf(alphabet, input);
        if (inputIndex == -1)
        {
            Console.WriteLine("такой буквы не может быть в алфавите!");
            return States.Error;
        }

        return (States)matrix[inputIndex, (int)currentState];
    }

    public static bool IsWord(string word)
    {
        States state = States.Start;

        foreach (char letter in word)
        {
            state = Transition(state, letter);
            Console.WriteLine($"Буква: {letter}; Состояние: {state}");

            if (state == States.Error)
                break;
        }

        return state == States.Final;
    }
}