Console.BackgroundColor = ConsoleColor.White;
Console.ForegroundColor = ConsoleColor.Black;

Console.Clear();

Console.WriteLine();


Console.WriteLine("Gerador de CPF");

Console.WriteLine();
Console.WriteLine();
Console.WriteLine();


Console.WriteLine("Digite A Sigla do estado do CPF que será gerado:");

Console.WriteLine();

string regionString = Console.ReadLine();

int randomNumbers;
int region;

bool stateExist = true;

string generatedCPF = Generate();

Console.WriteLine();

if (stateExist)
{
    Console.WriteLine();

    Console.WriteLine("CPF Gerado:");

    Console.WriteLine();
}

Console.WriteLine(generatedCPF);

Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();

Console.WriteLine("Pressione qualquer tecla para sair");

Console.ReadKey();

string Generate()
{
    Random rand = new Random();
    randomNumbers = rand.Next(10000000, 99999999);
    region = CheckRegion();
    if (region == -1)
    {
        stateExist = false;

        return "Esse estado não existe!";
    }
    string verifyDigits = VerifyDigits();

    string cpf = randomNumbers.ToString() + region + verifyDigits;

    string formattedCPF = cpf.Insert(3, ".").Insert(7, ".").Insert(11, "-"); // Formatação do CPF

    return formattedCPF;
}

int CheckRegion()
{
    int region = -1;

    regionString = regionString.ToUpper();

    switch (regionString)
    {
        case "DF":
        case "GO":
        case "MT":
        case "MS":
        case "TO":
            region = 1;
            break;

        case "PA":
        case "AM":
        case "AC":
        case "AP":
        case "RO":
        case "RR":
            region = 2;
            break;

        case "CE":
        case "MA":
        case "PI":
            region = 3;
            break;

        case "PE":
        case "RN":
        case "PB":
        case "AL":
            region = 4;
            break;

        case "BA":
        case "SE":
            region = 5;
            break;

        case "MG":
            region = 6;
            break;

        case "RJ":
        case "ES":
            region = 7;
            break;

        case "SP":
            region = 8;
            break;

        case "PR":
        case "SC":
            region = 9;
            break;

        case "RS":
            region = 0;
            break;
    }

    return region;
}

string VerifyDigits()
{
    string verifyDigits = "00";

    int verifyDigit1;
    int verifyDigit2;

    List<int> numbersList = new List<int>();

    // Adiciona os números do CPF e a região à lista
    foreach (char c in randomNumbers.ToString())
    {
        numbersList.Add(c - '0'); // Converte char para int
    }
    numbersList.Add(region);

    int total1 = 0;
    for (int i = 0; i < 9; i++) // Para calcular o primeiro dígito verificador
    {
        total1 += numbersList[i] * (10 - i);
    }

    int remnant1 = total1 % 11;
    verifyDigit1 = (remnant1 < 2) ? 0 : 11 - remnant1;
    numbersList.Add(verifyDigit1); // Adiciona o primeiro dígito verificador

    int total2 = 0;
    for (int i = 0; i < 10; i++) // Para calcular o segundo dígito verificador
    {
        total2 += numbersList[i] * (11 - i);
    }

    int remnant2 = total2 % 11;
    verifyDigit2 = (remnant2 < 2) ? 0 : 11 - remnant2;

    verifyDigits = verifyDigit1.ToString() + verifyDigit2.ToString();

    return verifyDigits;
}