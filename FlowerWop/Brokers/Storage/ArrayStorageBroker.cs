using FlowerWop.Models;

namespace FlowerWop.Brokers.Storage
{
    internal class ArrayStorageBroker : IStorageBroker
    {
        public Flower[] Flowers { get; set; } = new Flower[10];

        public ArrayStorageBroker()
        {
            Flowers[0] = new Flower()
            {
                Id = 1,
                Name = "Rose",
                Color = "Red",
                Cost = 10000,
                Discreption = "This flower is beautiful and tall"
            };

            Flowers[1] = new Flower()
            {
                Id = 2,
                Name = "Tulp",
                Color = "Red",
                Cost = 15000,
                Discreption = "This flower is beautiful and tall"
            };
        }

        public Flower AddFlower(Flower flower)
        {
            for (int itaration = 0; itaration < Flowers.Length; itaration++)
            {
                if (Flowers[itaration] is null)
                {
                    Flowers[itaration] = new Flower()
                    {
                        Id = flower.Id,
                        Name = flower.Name,
                        Color = flower.Color,
                        Cost = flower.Cost,
                        Discreption = flower.Discreption
                    };
                    return flower;
                }
            }

            return new Flower();
        }

        public bool Delete(int id)
        {
            for (int itaration = 0; itaration < Flowers.Length; itaration++)
            {
                if (Flowers[itaration] is not null)
                {
                    if (Flowers[itaration].Id == id)
                    {
                        Flowers[itaration] = new Flower();
                        return true;
                    }
                }
            }

            return false;
        }

        public Flower[] GetAllFlowers() => this.Flowers;

        public Flower ReadFlower(int id)
        {
            for (int itaration = 0; itaration < Flowers.Length; itaration++)
            {
                if (Flowers[itaration] is not null)
                {
                    if (Flowers[itaration].Id == id)
                    {
                        return Flowers[itaration];
                    }
                }
            }

            return new Flower();
        }

        public Flower Update(Flower flower)
        {
            for (int itaration = 0; itaration < Flowers.Length; itaration++)
            {
                if (Flowers[itaration] is not null)
                {
                    if (Flowers[itaration].Id == flower.Id)
                    {
                        Flowers[itaration] = new Flower()
                        {
                            Name = flower.Name,
                            Color = flower.Color,
                            Cost = flower.Cost,
                            Discreption = flower.Discreption
                        };
                        return flower;
                    }
                }
            }

            return new Flower();
        }
    }
}
