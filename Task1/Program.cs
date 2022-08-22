string No = "Нет.";
string Yes = "Да, ";

//Функция для проверки числа на простоту
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

//Функция для получения ближайшего следующего простого числа
int GetNextSimpleNumber(int number) 
{
    do
    {
        number++;
    }
    while (!IsSimpleNumber(number));

    return number;
}

//Функция для получения первого простого делителя числа
int GetFirstSimpleDivisor(int number) 
{
    int divisor = 2;
    while (number % divisor != 0)
    {
        divisor = GetNextSimpleNumber(divisor);
    }

    return divisor;
}


//Функция для проверки числа на разложение в три последовательных простых делителя 
string GetSimpleDivisors1(int number)
{
    if(number == 1)
    {
        return No;
    }
    else
    {
        int firstDivisor = GetFirstSimpleDivisor(number);
        if (firstDivisor == number)
        {
            return No;
        }
        else
        {
            int secondDivisor = GetNextSimpleNumber(firstDivisor);
            int thirdDivisor = GetNextSimpleNumber(secondDivisor);
            if (number % secondDivisor == 0 &&
                number % thirdDivisor == 0 &&
                firstDivisor * secondDivisor * thirdDivisor == number)
            {
                return Yes + $"{firstDivisor} * {secondDivisor} * {thirdDivisor} = {number}";
            }
            else
            {
                return No;
            }
        }
    }
}

//Функция для проверки числа на разложение в count последовательных простых делителя 
string GetSimpleDivisors2(int number, int divisor, int count)
{
    if (number % divisor == 0)
    {
        if (count > 1)
        {
            string response = GetSimpleDivisors2(number / divisor, GetNextSimpleNumber(divisor), count - 1);
            return response == No ? response : $"{divisor} * {response}";
        }
        else
        {
            return number == divisor ? $"{divisor}" : No;
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

    //Проверка числа на разложение в 3 последовательных простых делителя первым способом
    Console.WriteLine($"Ответ - {GetSimpleDivisors1(number)}");

    //Проверка числа на разложение в 3 последовательных простых делителя вторым более универсальным способом
    string divisors = (number == 1) ? No : GetSimpleDivisors2(number, GetFirstSimpleDivisor(number), 3);
    Console.WriteLine($"Ответ - " + (divisors != No ? Yes + $"{divisors} = {number}": divisors) + "\n");
}



