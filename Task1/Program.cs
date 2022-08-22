string No = "Нет.";

bool IsSimpleNumber(int number)
{
    if (number == 1)
    {
        return false;
    }
    else
    {
        for (int i = 2; i < number; i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }
    }

    return true;
}

int GetNextSimpleNumber(int number)
{
    do
    {
        number++;
    }
    while (!IsSimpleNumber(number));

    return number;
}


int GetFirstSimpleDivisor(int number)
{
    int divisor = 2;
    while (number % divisor != 0)
    {
        divisor = GetNextSimpleNumber(divisor);
    }

    return divisor;
}


string GetSimpleDivisors1(int number)
{
    if(number == 1)
    {
        return No;
    }
    else
    {
        int firstDevisor = GetFirstSimpleDivisor(number);
        if (firstDevisor == number)
        {
            return No;
        }
        else
        {
            int secondDevisor = GetNextSimpleNumber(firstDevisor);
            int thirdDevisor = GetNextSimpleNumber(secondDevisor);
            if (number % secondDevisor == 0 &&
                number % thirdDevisor == 0 &&
                firstDevisor * secondDevisor * thirdDevisor == number)
            {
                return $"Да, {firstDevisor} * {secondDevisor} * {thirdDevisor} = {number}";
            }
            else
            {
                return No;
            }
        }
    }
}

string GetSimpleDivisors2(int number, int devisor, int count)
{
    if (number % devisor == 0)
    {
        if (count > 1)
        {
            string response = GetSimpleDivisors2(number / devisor, GetNextSimpleNumber(devisor), count - 1);
            return response == No ? response : $"{devisor} * {response}";
        }
        else
        {
            return number == devisor ? $"{devisor}" : No;
        }
    }
    else
    {
        return No;
    }
}

while (true)
{
    Console.Write("Введенное число - ");
    int number;

    while (!int.TryParse(Console.ReadLine(), out number) || number <= 0)
    {
        Console.WriteLine("Ошибка ввода! Введите целое натуральное число!");
        Console.Write("Введенное число - ");
    }

    Console.WriteLine($"Ответ - {GetSimpleDivisors1(number)}");
    string divisors = (number==1) ? No : GetSimpleDivisors2(number, GetFirstSimpleDivisor(number), 3);
    Console.WriteLine($"Ответ - " + (divisors != No ? $"Да, {divisors} = {number}": divisors) + "\n");
}



