namespace methodology
{
    public abstract class Handler
    {
        Handler? successor = null;

        public Handler(Handler? handler)
        {
            this.successor = handler;
        }

        public virtual int numberByKeyboard()
        {
            if (successor != null)
            {
                return successor.numberByKeyboard();
            }
            else
            {
                return 0;
            }
        }
        public virtual string stringByKeyboard()
        {
            if (successor != null)
            {
                return successor.stringByKeyboard();
            }
            else
            {
                return "0";
            }
        }
        public virtual double doubleByKeyboard()
        {
            if (successor != null)
            {
                return successor.doubleByKeyboard();
            }
            else
            {
                return 0;
            }
        }
        public virtual int IntegerRandomNumber(int max, int min = 0)
        {
            if (successor != null)
            {
                return successor.IntegerRandomNumber(max,min);
            }
            else
            {
                return 0;
            }
        }
        public virtual double DecimalRandomNumber(int max, int Decimals = 2)
        {
            if (successor != null)
            {
                return successor.DecimalRandomNumber(max,Decimals);
            }
            else
            {
                return 0;
            }
        }
        public virtual string stringRandom(int amountChar)
        {
            if (successor != null)
            {
                return successor.stringRandom(amountChar);
            }
            else
            {
                return"0";
            }
        }
        public virtual string RandomName()
        {
            if (successor != null)
            {
                return successor.RandomName();
            }
            else
            {
                return"0";
            }
        }
        public virtual void loadNames()
        {
            if (successor != null)
            {
                successor.loadNames();
            }

        }
    public virtual double numeroDesdeArchivo(double max)
        {
            if (successor != null)
                return successor.numeroDesdeArchivo(max);
            else
                return 0;
        }

        public virtual string stringDesdeArchivo(int cant)
        {
            if (successor != null)
                return successor.stringDesdeArchivo(cant);
            else
                return "0";
        }
    }
}