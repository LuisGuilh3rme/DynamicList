namespace ExemploLista
{
    internal class Item
    {
        public int Value { get; set; }
        public Item Next { get; set; }

        public Item(int value) {
            Value = value;
            
        }
    }
}
