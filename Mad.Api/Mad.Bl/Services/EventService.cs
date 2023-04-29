using Mad.Data.Entities;

namespace Mad.Bl.Services
{
    public class EventService
    {
        public Event CreateEvent(string name)
        {
            var ev = new Event();
            ev.Name = name;

            return ev;
        }
    }
}
