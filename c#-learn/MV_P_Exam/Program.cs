using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml;
using System.IO;

namespace MV_P_Exam
{
    class Article
    {
        public int ArticleId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public Article(int ari, int ci, string name, int pr)
        {
            ArticleId = ari;
            CategoryId = ci;
            Name = name;
            Price = pr;
        }
        public override string ToString() 
        {
            return $"Article id: {ArticleId}, Category id: {CategoryId}, Name: {Name}, Price: {Price}\n";
        }
    }
    class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int Discount { get; set; }
        public Category(int ci, string name, int d)
        {
            CategoryId = ci;
            CategoryName = name;
            Discount = d;
        }
        public override string ToString()
        {
            return $"Category id: {CategoryId}, Name: {CategoryName}, Discount: {Discount}\n";
        }
    }
    class SharedArticle
    {
        public int ArticleId { get; set; }
        public int Count { get; set; }
        public SharedArticle(int ari, int c)
        {
            ArticleId = ari;
            Count = c;
        }
        public override string ToString()
        {
            return $"Article id: {ArticleId}, Count: {Count}\n";
        }
    }
    class Program
    {
        static List<Article> getXMLArticles(Stream xmlstr)
        {
            var elements = XElement.Load(xmlstr);

            List<Article> list_of_articles = new List<Article>();
            foreach (var article in elements.Elements())
            {
                list_of_articles.Add(new Article((int)article.Attribute("id"), (int)article.Element("CategoryId"), (string)article.Element("Name"), (int)article.Element("Price")));
            }
            return list_of_articles;
        }
        static List<Category> getXMLCategories(Stream xmlstr)
        {
            var elements = XElement.Load(xmlstr);

            List<Category> list_of_categories = new List<Category>();
            foreach (var category in elements.Elements())
            {
                list_of_categories.Add(new Category((int)category.Attribute("id"), (string)category.Element("Name"), (int)category.Element("Discount")));
            }
            return list_of_categories;
        }
        static List<SharedArticle> getXMLSharedArticles(Stream xmlstr)
        {
            var elements = XElement.Load(xmlstr);

            List<SharedArticle> list_of_shared_articles = new List<SharedArticle>();
            foreach (var sharedArticle in elements.Elements())
            {
                list_of_shared_articles.Add(new SharedArticle((int)sharedArticle.Element("ArticleId"), (int)sharedArticle.Element("Count")));
            }
            return list_of_shared_articles;
        }
        static void Main(string[] args)
        {
            string articlesPath = @"C:\c#_learn_lnu\MV_P_Exam\Article.xml";
            List<Article> articles = new List<Article>();
            using (FileStream fs_articles = new FileStream(articlesPath, FileMode.Open))
            {
                articles = getXMLArticles(fs_articles);
            }

            string categoryPath = @"C:\c#_learn_lnu\MV_P_Exam\Category.xml";
            List<Category> categories = new List<Category>();
            using (FileStream fs_categories = new FileStream(categoryPath, FileMode.Open))
            {
                categories = getXMLCategories(fs_categories);
            }

            string sharedArticlesPath = @"C:\c#_learn_lnu\MV_P_Exam\SharedArticle.xml";
            List<SharedArticle> sharedArticles = new List<SharedArticle>();
            using (FileStream fs_shared_articles = new FileStream(sharedArticlesPath, FileMode.Open))
            {
                sharedArticles = getXMLSharedArticles(fs_shared_articles);
            }

            Console.WriteLine("==== Articles ====");
            foreach (var article in articles)
            {
                Console.WriteLine(article);
            }
            Console.WriteLine("");

            Console.WriteLine("==== Categories ====");
            foreach (var category in categories)
            {
                Console.WriteLine(category);
            }
            Console.WriteLine("");

            Console.WriteLine("==== Shared Articles ====");
            foreach (var sharedArticle in sharedArticles)
            {
                Console.WriteLine(sharedArticle);
            }
            Console.WriteLine("");

            var data = from sa in sharedArticles
                          join a in articles on sa.ArticleId equals a.ArticleId
                          join c in categories on a.CategoryId equals c.CategoryId
                          select new
                          {
                              sa.ArticleId,
                              sa.Count,
                              a.Price,
                              a.Name,
                              c.Discount,
                              c.CategoryName
                          };

            Console.WriteLine("==== all data ====");
            foreach (var el in data)
                Console.WriteLine(
                    "ArticleId: {0}, " +
                    "Count: {1}, " +
                    "Price: {2}, " +
                    "ArticleName: {3}, " +
                    "Discount: {4}, " +
                    "CategoryName: {5} \n",
                    el.ArticleId, el.Count, el.Price, el.Name, el.Discount, el.CategoryName
                );

            Console.WriteLine("==== Task 1 ====");
            var articleCount = from el in data
                                group el by new { el.Name, el.Count } into res
                                select new
                                {
                                    name = res.Key.Name,
                                    count = res.Key.Count
                                };

            string path = @"C:\c#_learn_lnu\MV_P_Exam\task1.csv";
            using (StreamWriter file = new StreamWriter(path, false))
            {
                file.WriteLine("Name,Count");
                foreach (var item in articleCount.OrderBy(x => x.name))
                {
                    Console.WriteLine($"{item.name},{item.count}");
                    file.WriteLine($"{item.name},{item.count}");
                }
            }

            Console.WriteLine("==== Task 3 ====");
            var categoriesList = from el in data
                        group el by new { el.CategoryName, el.Price, el.Count } into res
                        select new
                        {
                            catName = res.Key.CategoryName,
                            sum = res.Sum(x => x.Price * x.Count)
                        };
        }
    }
}
