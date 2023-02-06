namespace PixelGame.Inventory
{
    public enum ItemType 
    {
        Sword,
        Healt,
        Coin,
        Key,
    }

    public class ItemModel
    {
        public ItemType ItemType;
        public int Amount;
    }
}
