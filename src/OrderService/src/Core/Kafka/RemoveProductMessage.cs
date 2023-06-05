namespace Core.Kafka;

public class RemoveProductMessage
{
    public int Id { get; set; }

    public RemoveProductMessage(int id)
    {
        Id = id;
    }
}