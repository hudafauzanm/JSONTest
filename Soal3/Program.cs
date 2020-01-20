using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;



namespace Soal3
{
    public class Inventory 
    {
        [JsonProperty ("inventory_id")]
        public int inventory_id {get;set;}
        [JsonProperty ("name")]
        public string name {get;set;}
        [JsonProperty ("type")]
        public string type {get;set;}
        [JsonProperty ("tags")]
        public string[] tags {get;set;}
        [JsonProperty ("purchased_at")]
        public long purchased_at {get;set;}  

        public Placement placement {get;set;}   
    }

    public class Placement
    {
        public int room_id {get;set;}
        public string name {get;set;}
    }


    class Program
    {
        static void Main(string[] args)
        {
            string json = @"[
                {
                    ""inventory_id"": 9382,
                    ""name"": ""Brown Chair"",
                    ""type"": ""furniture"",
                    ""tags"": [
                    ""chair"",
                    ""furniture"",
                    ""brown""
                    ],
                    ""purchased_at"": 1579190471,
                    ""placement"": {
                    ""room_id"": 3,
                    ""name"": ""Sangkuriang""
                    }
                },
                {
                    ""inventory_id"": 9380,
                    ""name"": ""Big Desk"",
                    ""type"": ""furniture"",
                    ""tags"": [
                    ""desk"",
                    ""furniture"",
                    ""brown""
                    ],
                    ""purchased_at"": 1579190642,
                    ""placement"": {
                    ""room_id"": 3,
                    ""name"": ""Sangkuriang""
                    }
                },
                {
                    ""inventory_id"": 2932,
                    ""name"": ""LG Monitor 50 inch"",
                    ""type"": ""electronic"",
                    ""tags"": [
                    ""monitor""
                    ],
                    ""purchased_at"": 1579017842,
                    ""placement"": {
                    ""room_id"": 3,
                    ""name"": ""Sangkuriang""
                    }
                },
                {
                    ""inventory_id"": 232,
                    ""name"": ""Sharp Pendingin Ruangan 2PK"",
                    ""type"": ""electronic"",
                    ""tags"": [
                    ""ac""
                    ],
                    ""purchased_at"": 1578931442,
                    ""placement"": {
                    ""room_id"": 5,
                    ""name"": ""Dhanapala""
                    }
                },
                {
                    ""inventory_id"": 9382,
                    ""name"": ""Alat Makan"",
                    ""type"": ""tableware"",
                    ""tags"": [
                    ""spoon"",
                    ""fork"",
                    ""tableware""
                    ],
                    ""purchased_at"": 1578672242,
                    ""placement"": {
                    ""room_id"": 10,
                    ""name"": ""Rajawali""
                    }
                }
                ]";

                var list = JsonConvert.DeserializeObject<List<Inventory>>(json);
                
                Console.WriteLine("=====================Find total item in Sangkuriang room.=====================");
                int i = 0;
                foreach(var inv in list)
                {
                    if(inv.placement.name == "Sangkuriang")
                    {
                        i++;
                    }
                }
                Console.WriteLine("Jumlah item : "+i);
                Console.WriteLine("========================Find all electronic devices.=====================");
                foreach(var inv in list)
                {
                    if(inv.type == "electronic")
                    {
                      Console.WriteLine(inv.name);  
                    }
                }

                Console.WriteLine("==========================Find all furnitures.=====================");
                foreach(var inv in list)
                {
                    if(inv.type == "furniture")
                    {
                      Console.WriteLine(inv.name);  
                    }
                }


                Console.WriteLine("==========================Find all items was purchased at 16 Januari 2020.=====================");
                foreach(var inv in list)
                {
                    System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                    dateTime = dateTime.AddSeconds(inv.purchased_at).ToLocalTime();
                    string iDate = "1/16/2020";
                    DateTime oDate = Convert.ToDateTime(iDate);

                    //Console.WriteLine(oDate);

                    //Console.WriteLine(dateTime);

                    var x = dateTime.CompareTo(oDate);
                    if(x == 1)
                    {
                        Console.WriteLine(inv.name);
                    }
                }

                Console.WriteLine("======================Find all items with brown color.======================");
                //string color = "brown";
                foreach(var inv in list)
                {
                    foreach(var x in inv.tags)
                    {
                        if(x == "brown")
                        {
                            Console.WriteLine(inv.name);
                        }
                    }
                }
        }
    }
}
