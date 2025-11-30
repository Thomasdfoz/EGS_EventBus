using EventBusCore;

namespace EventBusCore.Samples
{
    public interface IEventSample : IEvent
    {
        string Sample2 { get; }
    }

    public sealed class EventSample : IEvent
    {
      
        public readonly string Sample;
        public EventSample(string sample) => Sample = sample;

    }

    public sealed class EventSample2 : IEventSample
    {
      
        public string Sample2 => "teste 2";

        public readonly string Sample;
        public EventSample2(string sample) => Sample = sample;

    }

}
