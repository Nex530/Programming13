using System.Xml;

namespace Programming13_1
{
    internal class Program
    {

        //
        class Pizza
        {
            private string name;
        }
        enum typeDough
        {
            white, wholegrain
        }
        enum typeBaked
        {
            crunchy, chewy, home_made
        }
        class Dough
        {
            private typeDough typeDough;
            private typeBaked typeBaked;
            private int grams;

            public Dough (string inputTypeDough, string inputTypeBaked, int inputGrams)
            {
                setGrams(inputGrams);
                setTypeBaked(inputTypeBaked);
                setTypeDough(inputTypeDough);
            }

            public double getAllCalories ()
            {
                double modTypeDough = 1;
                double modTypeBaked = 1;
                switch (typeDough)
                {
                    case typeDough.white:
                        modTypeDough = 1.5;
                        break;
                    case typeDough.wholegrain:
                        break;
                }
                switch (typeBaked)
                {
                    case typeBaked.crunchy:
                        modTypeBaked = 0.9;
                        break;
                    case typeBaked.chewy:
                        modTypeBaked = 1.1;
                        break;
                    case typeBaked.home_made:
                        break;
                }
                return (2 * grams ) * modTypeDough * modTypeBaked;
            }

            private void setTypeDough(string strTypeDough)
            {
                switch (strTypeDough)
                {
                    case "white":
                        this.typeDough = typeDough.white;
                        break;
                    case "wholegrain":
                        this.typeDough = typeDough.wholegrain;
                        break;
                    default:
                        Console.WriteLine("Incorrect type of dough.");
                        break;
                }
            }
            private void setTypeBaked(string strTypeBaked)
            {
                switch (strTypeBaked)
                {
                    case "crunchy":
                        this.typeBaked = typeBaked.crunchy;
                        break;
                    case "chewy":
                        this.typeBaked = typeBaked.chewy;
                        break;
                    case "home_made":
                        this.typeBaked = typeBaked.home_made;
                        break;
                    default:
                        Console.WriteLine("Incorrect type of baking method.");
                        break;
                }
            }

            private void setGrams(int grams)
            {
                if (1 <= grams && grams <= 200)
                {
                    this.grams = grams;
                }
                else
                {
                    Console.WriteLine("Dough weight should be in the range [1 - 200].");
                }
            }

        }

        static void Main(string[] args)
        {
            //primeri ot faila
            Dough dough0 = new Dough("white", "chewy", 100);
            Console.WriteLine(dough0.getAllCalories());
            Dough dough1 = new Dough("Tip500", "chewy", 100);
            Dough dough2 = new Dough("white", "chewy", 240);



        }
    }
}
