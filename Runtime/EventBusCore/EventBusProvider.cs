namespace EventBusCore.Services
{
    public static class EventBusProvider
    {
        private static IEventBus _bus;

        public static IEventBus Bus
        {
            get
            {
                if (_bus == null)
                    _bus = new EventBus();

                return _bus;
            }
        }
    }
}
