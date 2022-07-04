//Exemplo de threads sendo executadas em paralelo.

async Task FazerCafe()
{
    //Task.Run cria uma nova thread.
    //Sem await, assim que a task finalizar, a thread irá seguir o fluxo até a conclusão sem aguardar
    // o término das demais threads mesmo com o método Wait().
    await Task.Run(() =>
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"1 - Fazendo café...");
            Thread.Sleep(1000);
        }
    });

    Console.WriteLine("Café pronto!" + Environment.NewLine);
}

async Task FritarOvos()
{
    await Task.Run(() =>
    {
        for (int i = 0; i < 15; i++)
        {
            Console.WriteLine($"2 - Fritando ovos...");
            Thread.Sleep(1000);
        }
    });

    Console.WriteLine("Ovos pronto!" + Environment.NewLine);
}


async Task TostarPao()
{
    await Task.Run(() =>
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"3 - Tostando pão...");
            Thread.Sleep(1000);
        }
    });

    Console.WriteLine("Pão tostado pronto!" + Environment.NewLine);
}

var threadFazerCafe = FazerCafe();
var threadFritandoOvos = FritarOvos();
var threadTostarPao = TostarPao();

//O método Wait() faz a task da thread aguardar a conclusão das demais tasks.
threadFazerCafe.Wait();
threadFritandoOvos.Wait();
threadTostarPao.Wait();

Console.WriteLine("Café, pão e ovos fritos na mesa!!!");
Console.ReadKey();