namespace DekoraterExtraZadatak
{
    public interface ISoup
    {
        void MakeSoup();
    }

    public class BasicSoup : ISoup
    {
        public void MakeSoup()
        {
            Console.WriteLine("Basic Soup");
        }
    }

    public class SoupDecorator : ISoup
    {
        protected ISoup _soup;

        public SoupDecorator(ISoup soup)
        {
            _soup = soup;
        }

        public virtual void MakeSoup()
        {
            _soup.MakeSoup();
        }
    }

    public class NoodlesDecorator : SoupDecorator
    {
        public NoodlesDecorator(ISoup soup) : base(soup) { }

        public override void MakeSoup()
        {
            base.MakeSoup();
            AddNoodles();
        }

        private void AddNoodles()
        {
            Console.WriteLine("Add Noodles");
        }
    }

    public class BeefDecorator : SoupDecorator
    {
        public BeefDecorator(ISoup soup) : base(soup) { }

        public override void MakeSoup()
        {
            base.MakeSoup();
            AddBeef();
        }

        private void AddBeef()
        {
            Console.WriteLine("Add Beef");
        }
    }

    public class MushroomDecorator : SoupDecorator
    {
        public MushroomDecorator(ISoup soup) : base(soup) { }

        public override void MakeSoup()
        {
            base.MakeSoup();
            AddMushrooms();
        }

        private void AddMushrooms()
        {
            Console.WriteLine("Add Mushrooms");
        }
    }

    public class WaterDecorator : SoupDecorator
    {
        public WaterDecorator(ISoup soup) : base(soup) { }

        public override void MakeSoup()
        {
            base.MakeSoup();
            AddWater();
        }

        private void AddWater()
        {
            Console.WriteLine("Add Water");
        }
    }

    public static class ClientCode
    {
        public static void Run()
        {
            ISoup basicSoup = new BasicSoup();
            ISoup noodlesSoup = new NoodlesDecorator(basicSoup);
            ISoup beefNoodlesSoup = new BeefDecorator(noodlesSoup);
            ISoup mushroomBeefNoodlesSoup = new MushroomDecorator(beefNoodlesSoup);
            ISoup finalSoup = new WaterDecorator(mushroomBeefNoodlesSoup);

            finalSoup.MakeSoup();
        }
    }
}
