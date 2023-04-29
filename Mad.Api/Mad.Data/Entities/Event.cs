namespace Mad.Data.Entities
{
    public class Event
    {
        public Event()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}