using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MementoZadatak
{
    public class Equipment
    {
        public string Name { get; set; }

        public Equipment(string name)
        {
            Name = name;
        }
    }

    public class CarConfigurator
    {
        public string Model { get; private set; }
        private List<Equipment> additionalEquipment = new List<Equipment>();

        public void AddExtra(Equipment package)
        {
            additionalEquipment.Add(package);
        }

        public void Remove(Equipment package)
        {
            additionalEquipment.Remove(package);
        }

        public void Rollback(CarConfiguration configuration)
        {
            Model = configuration.GetModel();
            additionalEquipment.Clear();
            additionalEquipment.AddRange(configuration.GetPackages());
        }

        public CarConfiguration Store()
        {
            return new CarConfiguration(Model, additionalEquipment);
        }

        public List<Equipment> GetAdditionalEquipment()
        {
            return new List<Equipment>(additionalEquipment);
        }
    }

    public class CarConfiguration
    {
        private string model;
        private List<Equipment> additionalEquipment;

        public CarConfiguration(string model, List<Equipment> additionalEquipment)
        {
            this.model = model;
            this.additionalEquipment = new List<Equipment>(additionalEquipment);
        }

        public string GetModel()
        {
            return model;
        }

        public List<Equipment> GetPackages()
        {
            return new List<Equipment>(additionalEquipment);
        }
    }

    public class ConfigurationManager
    {
        private List<CarConfiguration> configurations = new List<CarConfiguration>();

        public void AddConfiguration(CarConfiguration configuration)
        {
            configurations.Add(configuration);
        }

        public void DeleteConfiguration(CarConfiguration configuration)
        {
            configurations.Remove(configuration);
        }

        public CarConfiguration GetConfiguration(int index)
        {
            return configurations[index];
        }
    }

    class Program
    {
        static void Main()
        {
            CarConfigurator configurator = new CarConfigurator();
            ConfigurationManager manager = new ConfigurationManager();

            configurator.Model = "Sedan";
            configurator.AddExtra(new Equipment("Leather Seats"));
            configurator.AddExtra(new Equipment("Sunroof"));

            CarConfiguration config1 = configurator.Store();
            manager.AddConfiguration(config1);

            configurator.Model = "SUV";
            configurator.Remove(new Equipment("Sunroof"));
            configurator.AddExtra(new Equipment("Off-Road Package"));

            CarConfiguration config2 = configurator.Store();
            manager.AddConfiguration(config2);

            configurator.Rollback(manager.GetConfiguration(0));

            Console.WriteLine($"Current Model: {configurator.Model}");
            Console.WriteLine("Current Additional Equipment:");
            foreach (var equipment in configurator.GetAdditionalEquipment())
            {
                Console.WriteLine(equipment.Name);
            }
        }
    }
}