using FlowerWop.Brokers.Logging;
using FlowerWop.Brokers.Storage;
using FlowerWop.Models;

namespace FlowerWop.Services
{
    internal class FlowerService : IFlowerService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public FlowerService()
        {
            this.storageBroker = new ArrayStorageBroker();
            this.loggingBroker = new LoggingBroker();
        }

        public Flower CreateFlower(Flower flower)
        {
            return flower is null
                ? InvalidCreateFlower()
                : ValidationAndCreateFlower(flower);
        }
        public Flower GetFlower(int id)
        {
            return id is 0
                ? InvalidGetFlowerById()
                : ValidationAndGetFlower(id);

        }

        public Flower ModifyFlower(int id, Flower flower)
        {
            return flower is null
                ? InvalidModifyFlower()
                : ValidationAndModifyFlower(id, flower);
        }

        public Flower[] ReadAllFlowers()
        {
            var flowers = this.storageBroker.GetAllFlowers();

            if (flowers.Length is 0)
            {
                this.loggingBroker.LogError("Not exist Information!");
                return flowers;
            }
            else
            {
                foreach (var flowerItem in flowers)
                {
                    if (flowerItem is not null)
                    {
                        this.loggingBroker.LogInformation(
                                $"Id: {flowerItem.Id}\n" +
                                $"Name: {flowerItem.Name}\n" +
                                $"Discreption: {flowerItem.Discreption}\n" +
                                $"Color: {flowerItem.Color}\n" +
                                $"Cost: {flowerItem.Cost}");
                    }
                }
            }
            return flowers;
        }

        public bool RemoveFlower(int id)
        {
            return id is 0
                    ? InvalidRemoveFlowerById()
                    : ValidationAndRemoveFlower(id);
        }

        private Flower ValidationAndCreateFlower(Flower flower)
        {
            if (flower.Id is 0
                || String.IsNullOrWhiteSpace(flower.Name)
                || String.IsNullOrWhiteSpace(flower.Color)
                || flower.Cost is 0)
            {
                this.loggingBroker.LogError("The information you want to send is incomplete.");
                return new Flower();
            }
            else
            {
                var flowerInfo = this.storageBroker.AddFlower(flower);
                if (flowerInfo is null)
                {
                    this.loggingBroker.LogError("Not Added flower.");
                    return new Flower();
                }
                else
                {
                    this.loggingBroker.LogInformation("Flower is added.");
                    return flowerInfo;
                }
            }
        }

        private Flower InvalidCreateFlower()
        {
            this.loggingBroker.LogError("The information is not fully loaded.");
            return new Flower();
        }

        private Flower ValidationAndModifyFlower(int id, Flower flower)
        {
            if (id is 0
                || flower.Id is 0
                || String.IsNullOrWhiteSpace(flower.Name)
                || String.IsNullOrWhiteSpace(flower.Color)
                || flower.Cost is 0)
            {
                this.loggingBroker.LogError("The data is invalid.");
                return new Flower();
            }
            else
            {
                var flowers = this.storageBroker.Update(id, flower);
                if (flowers is null)
                {
                    this.loggingBroker.LogError("Not Update!");
                    return new Flower();
                }
                else
                {
                    this.loggingBroker.LogInformation("Flower is updated!");
                    return flowers;
                }
            }
        }

        private Flower InvalidModifyFlower()
        {
            this.loggingBroker.LogError("The information is not fully loaded.");
            return new Flower();
        }

        private bool ValidationAndRemoveFlower(int id)
        {
            bool isDelete = this.storageBroker.Delete(id);

            if (isDelete is true)
            {
                this.loggingBroker.LogInformation("The information in the id has been deleted.");
                return true;
            }
            else
            {
                this.loggingBroker.LogError("Id is Not Found.");
                return false;
            }
        }

        private bool InvalidRemoveFlowerById()
        {
            this.loggingBroker.LogError("Invlid id.");
            return false;
        }

        private Flower ValidationAndGetFlower(int id)
        {
            Flower flowers = this.storageBroker.ReadFlower(id);
            Flower isFlower = this.storageBroker.ReadFlower(id);
            if (isFlower is not null)
            {
                this.loggingBroker.LogInformation("Success.");
                return isFlower;
            }
            else
            {
                this.loggingBroker.LogError("No data found for this id.");
                return new Flower();
            }
        }

        private Flower InvalidGetFlowerById()
        {
            this.loggingBroker.LogError("Invlid id.");
            return new Flower();
        }
    }
}
