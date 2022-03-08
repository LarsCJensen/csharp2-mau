using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Animals
{
    public class FoodItem
    {
        private ListManager<string> ingredients = new ListManager<string>();
        public ListManager<string> Ingredients
        {
            get
            {
                return ingredients;
            }
        }
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if(value != null)
                {
                    name = value;
                }
            }
        }
        public FoodItem()
        {

        }

        public override string ToString()
        {
            string strIngredients = "";
            for(int i = 0; i < ingredients.Count; i++)
            {
                string appendString = ", ";
                if(i == ingredients.Count -1)
                {
                    appendString = "";
                }
                strIngredients += ingredients.GetAt(i) + appendString;
            }
            string strOut = string.Format("{0, -15} {1, 6}",
                name + ":", strIngredients);
            return strOut;
        }
    }
}
