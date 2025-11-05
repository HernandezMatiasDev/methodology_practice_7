namespace methodology
{
    public static class HandlerFactory
    {
        private static Handler? _chainInstance;

        public static Handler GetChain()
        {
            if (_chainInstance == null)
            {

                Handler random = RandomDataGeneratorHandler.GetInstance(null);
                Handler file = LectorDeArchivos.GetInstance(random);
                Handler keyboard = DataReaderHandler.GetInstance(file);
                _chainInstance = keyboard;
            }
            
            return _chainInstance;
        }
    }
}