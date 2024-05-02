using FlowerWop.Models;

namespace FlowerWop.Brokers.Storage
{
    internal interface IStorageBroker
    {
        Flower ReadFlower(int id);
        Flower[] GetAllFlowers();
        Flower AddFlower(Flower flower);
        Flower Update(int id, Flower flower);
        bool Delete(int id);
    }
}
