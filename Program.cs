using System;
//using System.Text.Json;
//using System.Text.Json.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;


namespace JSONtest
{
    public class User
    {
        [JsonProperty("id")]
        public int Id {get;set;}
        [JsonProperty("username")]
        public string Username {get;set;}
        [JsonIgnore]
        [JsonProperty("password")]
        public string Password {get;set;}
        public Profile Profile {get;set;}
        public List<Articles> articles {get;set;} = new List<Articles>();

    }

    public class Profile
    {
        [JsonProperty("id")]
        public int Id {get;set;}
        [JsonProperty("full_name")]
        public string Fullname {get;set;}
        [JsonProperty("birthday")]
        public DateTime Birthday {get;set;}
        [JsonProperty("phones")]
        public string[] Phones {get;set;} = {};

    }

    public class Articles
    {
        [JsonProperty("id")]
        public int id {get;set;}
        [JsonProperty("title")]
        public string title {get;set;}
        [JsonProperty("published_at")]
        public DateTime published_at {get;set;}
    }
    class Program
    {
        static void Main(string[] args)
        {
            
             string json = @"[{
                                ""id"": 323,
                                ""username"": ""rinood30"",
                                ""profile"": {
                                ""full_name"": ""Shabrina Fauzan"",
                                ""birthday"": ""1988-10-30"",
                                ""phones"": [
                                    ""08133473821"",
                                    ""082539163912"",
                                ],
                                },
                                ""articles"": [
                                {
                                    ""id"": 3,
                                    ""title"": ""Tips Berbagi Makanan"",
                                    ""published_at"": ""2019-01-03T16:00:00""
                                },
                                {
                                    ""id"": 7,
                                    ""title"": ""Cara Membakar Ikan"",
                                    ""published_at"": ""2019-01-07T14:00:00""
                                }
                                ]
                            },
                            {
                                ""id"": 201,
                                ""username"": ""norisa"",
                                ""profile"": {
                                ""full_name"": ""Noor Annisa"",
                                ""birthday"": ""1986-08-14"",
                                ""phones"": [],
                                },
                                ""articles"": [
                                {
                                    ""id"": 82,
                                    ""title"": ""Cara Membuat Kue Kering"",
                                    ""published_at"": ""2019-10-08T11:00:00""
                                },
                                {
                                    ""id"": 91,
                                    ""title"": ""Cara Membuat Brownies"",
                                    ""published_at"": ""2019-11-11T13:00:00""
                                },
                                {
                                    ""id"": 31,
                                    ""title"": ""Cara Membuat Brownies"",
                                    ""published_at"": ""2019-11-11T13:00:00""
                                }
                                ]
                            },
                            {
                                ""id"": 42,
                                ""username"": ""karina"",
                                ""profile"": {
                                ""full_name"": ""Karina Triandini"",
                                ""birthday"": ""1986-04-14"",
                                ""phones"": [
                                    ""06133929341""
                                ],
                                },
                                ""articles"": []
                            },
                            {
                                ""id"": 201,
                                ""username"": ""icha"",
                                ""profile"": {
                                ""full_name"": ""Annisa Rachmawaty"",
                                ""birthday"": ""1987-12-30"",
                                ""phones"": [],
                                },
                                ""articles"": [
                                {
                                    ""id"": 39,
                                    ""title"": ""Tips Berbelanja Bulan Tua"",
                                    ""published_at"": ""2019-04-06T07:00:00""
                                },
                                {
                                    ""id"": 43,
                                    ""title"": ""Cara Memilih Permainan di Steam"",
                                    ""published_at"": ""2019-06-11T05:00:00""
                                },
                                {
                                    ""id"": 58,
                                    ""title"": ""Cara Membuat Brownies"",
                                    ""published_at"": ""2019-09-12T04:00:00""
                                }
                                ]
                            }]";
    
           
           var list = JsonConvert.DeserializeObject<List<User>>(json);
           
           Console.WriteLine("================Find users who doesn't have any phone numbers.====================");
           foreach(var item in list)
           {   
               if((item.Profile.Phones).Length == 0)
               {
                 Console.WriteLine(item.Username);
               }      
           }
           Console.WriteLine("====================Find users who have articles=======================");
           foreach(var item in list)
           {   
                if((item.articles).Count > 0)
                {
                    Console.WriteLine(item.Username);
                }
           }
           Console.WriteLine("================Find users who have Annis on their name====================");
           foreach(var item in list)
           {
               if((item.Profile.Fullname).Contains("Annis") == true)
               {
                   Console.WriteLine(item.Username);
               }
           }
           Console.WriteLine("================Find users who are born on 1986====================");
           foreach(var item in list)
           {
               if((item.Profile.Birthday).Year == 1986)
               {
                   Console.WriteLine(item.Username);
               }
           }
           Console.WriteLine("================Find users who have articles on year 2020.====================");
           foreach(var item in list)
           {
               foreach(var x in item.articles)
               {
                if((x.published_at).Year == 2020)
                {
                    Console.WriteLine(item.Username);
                }
               }
           }

           Console.WriteLine("================Find articles that contain tips on the title..====================");
           foreach(var item in list)
           {
               foreach(var x in item.articles)
               {
                if((x.title).Contains("Tips"))
                {
                    Console.WriteLine(item.Username + " " + x.title);
                }
               }
           }

        //    Console.WriteLine("================Find articles that contain tips on the title..====================");
        //    foreach(var item in list)
        //    {
        //        foreach(var x in item.articles)
        //        {
        //         if((x.published_at) > 2019 ) 
        //         {
        //             Console.WriteLine(item.Username + " " + x.title);
        //         }
        //        }
        //    }

        //    foreach(var item in list)
        //    {
        //        if((item.Profile.Birthday).Year == 1986)
        //        {
        //            Console.WriteLine(item.Username);
        //        }
        //    }






           
        }
    }
}
