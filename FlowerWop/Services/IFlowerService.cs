using FlowerWop.Brokers.Logging;
using FlowerWop.Brokers.Storage;
using FlowerWop.Models;

namespace FlowerWop.Services
{
    internal interface IFlowerService
    {
        Flower[] ReadAllFlowers();
        Flower GetFlower(int id);
        Flower CreateFlower(Flower flower);
        Flower ModifyFlower(int id,Flower flower);
        bool RemoveFlower(int id);
    }
}
