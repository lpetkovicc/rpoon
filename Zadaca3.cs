namespace ApstraktnaTvornica
{
    
    public interface ITV
    {
        void UseInterface();
    }

    
    public interface IDisplay
    {
        void UseInterface();
    }

   
    public class DellTV : ITV
    {
        public void UseInterface()
        {

        }
        
          
        
    }


    public class SamsungTV : ITV
    {
        public void UseInterface()
        {
           
        }
    }

    
    public class DellDisplay : IDisplay
    {
        public void UseInterface()
        {
           
        }
    }


    public class SamsungDisplay : IDisplay
    {
        public void UseInterface()
        {
           
        }
    }

   
    public interface ITVMonitorFactory
    {
        ITV CreateTV();
        IDisplay CreateDisplay();
    }

   
    public class DellFactory : ITVMonitorFactory
    {
        public ITV CreateTV()
        {
            return new DellTV();
        }

        public IDisplay CreateDisplay()
        {
            return new DellDisplay();
        }
    }

   
    public class SamsungFactory : ITVMonitorFactory
    {
        public ITV CreateTV()
        {
            return new SamsungTV();
        }

        public IDisplay CreateDisplay()
        {
            return new SamsungDisplay();
        }
    }

    public class TechStore
    {
        private ITV tv;
        private IDisplay display;

        public TechStore(ITVMonitorFactory factory)
        {
            tv = factory.CreateTV();
            display = factory.CreateDisplay();
        }

        public void SellTV()
        {
            tv.UseInterface();
        }

        public void SellDisplay()
        {
            display.UseInterface();
        }
    }
}

//SOLID načela koja slijedimo ovdje su OCP i SRP. 
// lako dodavanje novih marki bez mijenjanja postojećeg koda, a svaka klasa ima jednu odgovornost 