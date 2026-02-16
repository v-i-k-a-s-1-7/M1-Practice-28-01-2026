using System;
using System.Collections.Generic;
using System.Linq;


public class CartConsolidation
{
    
    public Dictionary<string,int> Quantity(
        List<(string sku ,int qty)> scans){
        
         Dictionary<string,int> skuQty = new Dictionary<string,int>();
         
         foreach(var item in scans){
        // in tuples we have to use name fields no index will  work
            if(item.qty <=0){
                continue;
            }
            if(!skuQty.ContainsKey(item.sku)){
                skuQty[item.sku] = item.qty;
                continue;
            }
            skuQty[item.sku] += item.qty;
        }
        
        return skuQty;
    }
    
    public static void Main(string[] args)
    {
       
        List<(string sku , int qty)> scans = new List<(string sku, int qty)>
            {
                ("A101", 2),
                ("B205", 1),
                ("A101", 3),
                ("C111", -1)
            };
            
         Dictionary<string,int> skuQty = new Dictionary<string,int>();
         
         CartConsolidation cart = new CartConsolidation();
         skuQty = cart.Quantity(scans);
         
         Console.Write("{ ");
         Console.Write(string.Join(", ", skuQty.Select(
             x=> $"{x.Key} : {x.Value}")));
         Console.Write(" }");
        
    }
}