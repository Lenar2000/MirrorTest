using Mirror;
using UnityEngine;

public static class ItemSerializer
{
    public static void WriteItem(this NetworkWriter writer, Item value)
    {
        writer.WriteString(value.name);
    }

    public static Item ReadItem(this NetworkReader reader)
    {
        var name = reader.ReadString();

        return Object.Instantiate(Resources.Load<Item>(name));
    }
}
