using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Assignment4.Helpers;


namespace Assignment4.Animals
{   
    public class FoodItem
    {
        private List<string> ingredients = new List<string>();
        public List<string> Ingredients        
        {
            get
            {
                return ingredients;
            } 
            set
            {
                ingredients = value;
            }

        }
        private static int startId = 1000;
        private int id;
        public int Id
        {
            get
            {
                return id;
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
            startId = startId += 1;
            id = startId;
        }
        ~FoodItem()
        {
            this.id = 0;
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
                strIngredients += ingredients[i] + appendString;
            }
            string strOut = string.Format("{0, -15} {1, 6}",
                name + ":", strIngredients);
            return strOut;
        }
    }
}
