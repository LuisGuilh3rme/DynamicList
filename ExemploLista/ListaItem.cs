using System.Runtime.Intrinsics.X86;

namespace ExemploLista
{
    internal class ListItem
    {
        public Item Begin { get; set; }
        public Item End { get; set; }

        public ListItem()
        {
            Begin = null;
            End = null;
        }

        public bool IsEmpty()
        {
            // Retorna se a lista está vazia
            return Begin == null;
        }

        public void Insert(Item item)
        {
            // inicia a lista caso não haja nenhum item
            if (IsEmpty())
            {
                Begin = item;
                End = item;
                return;
            }

            // insere o valor no inicio da lista
            if (item.Value <= Begin.Value)
            {
                item.Next = Begin;
                Begin = item;
                return;
            }

            // insere o valor no fim da lista
            if (item.Value >= End.Value)
            {
                End.Next = item;
                End = item;
                return;
            }

            // insere o valor no meio da lista
            Item aux = Begin;

            while (aux != null)
            {
                // Verifica se o valor do item está entre o valor do objeto atual e o próximo
                if (aux.Value <= item.Value && aux.Next.Value >= item.Value)
                {
                    // Realiza troca de endereços
                    item.Next = aux.Next;
                    aux.Next = item;
                    return;
                }

                aux = aux.Next;
            }
        }

        public void Remove(int value)
        {
            if (IsEmpty())
            {
                Console.WriteLine("A lista está vazia");
                return;
            }
            
            // Verifica se há somente um valor na lista
            if (Begin == End)
            {
                if (Begin.Value == value)
                {
                    Clear();
                    return;
                }
            }

            // Remove o valor do inicio da lista
            if (value == Begin.Value)
            {
                Begin = Begin.Next;
            }


            // Remove valor do fim ou meio da lista
            Item aux = Begin;

            while (aux.Next != null)
            {
                // Verifica se já é o fim da lista e retira o objeto caso encontrado
                if (aux.Next.Value == value && aux.Next.Next == null)
                {
                    End = aux;
                    aux.Next = null;
                    return;
                }

                // Retira o objeto que está no meio da lista
                if (aux.Next.Value == value)
                {
                    aux.Next = aux.Next.Next;
                }

                aux = aux.Next;
            }
        }

        public void Clear()
        {
            Begin = null;
            End = null;
        }

        public bool Find(int value)
        {
            if (IsEmpty()) return false;

            Item aux = Begin;

            // Verifica se existe um item pesquisado dentro da lista
            while (aux != null)
            {
                if (aux.Value == value) return true;
                aux = aux.Next;
            }

            return false;
        }


        public void Print()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Lista vazia");
                return;
            }

            Item aux = Begin;

            Console.WriteLine("Valores adicionados: ");
            while (aux != null) 
            {
                Console.Write(" {0}", aux.Value);
                aux = aux.Next;
            }
        }
    }
}
