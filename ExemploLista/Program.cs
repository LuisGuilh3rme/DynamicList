using ExemploLista;

// Lista simplesmente encadeada
ListItem listItem = new ListItem();

int opc = 0;
do
{
    Console.Clear();
    Console.WriteLine("1 - Adicionar valores a lista");
    Console.WriteLine("2 - Remover valores da lista");
    Console.WriteLine("3 - Exibir lista");
    Console.WriteLine("4 - Limpar lista");
    Console.WriteLine("5 - Sair");
    Console.Write("Escolha uma opção: ");
    int.TryParse(Console.ReadLine(), out opc);
    Menu(opc);
} while (opc != 5);

void Menu(int opc)
{
    Console.Clear();
    switch(opc) 
    {
        case 1:
            Console.WriteLine("Quantos itens serão adicionados?");
            int quantity = int.Parse(Console.ReadLine());
            AddItems(quantity);
            break;
        case 2:
            RemoveItem();
            break;
        case 3: 
            listItem.Print();
            Console.WriteLine("\n\nAperte qualquer tecla para sair");
            Console.ReadKey();
            break;
        case 4: listItem.Clear(); break;
        case 5: break;
        default:
            Console.WriteLine("Valor inválido, tente novamente!");
            Console.WriteLine("\n\nAperte qualquer tecla para sair");
            Console.ReadKey();
            break;
    }
}

void AddItems (int quantity)
{
    Console.WriteLine("Caso inválido, valor será substituido por zero");
    for (int i = 0; i < quantity; i++)
    {
        Console.Write("Insira o valor {0}: ", i + 1);
        int.TryParse(Console.ReadLine(), out int value);

        listItem.Insert(new Item(value));
    }
}

void RemoveItem()
{
    Console.Write("Insira o valor a ser removido: ");
    int value = int.Parse(Console.ReadLine());

    if (!listItem.Find(value))
    {
        Console.WriteLine("Valor não encontrado");
        Console.WriteLine("\n\nAperte qualquer tecla para sair");
        Console.ReadKey();
        return;
    }

    listItem.Remove(value);
}