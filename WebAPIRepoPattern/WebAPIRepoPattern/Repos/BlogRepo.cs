using WebAPIRepoPattern.Models;

namespace WebAPIRepoPattern.Repos
{
    public class BlogRepo : IBlog
    {
        private readonly static List<Blog> _blogs = Populate();

        private static List<Blog> Populate()
        {
            var result = new List<Blog>()
           {
               new Blog()
               {Id=1,Title="Repository Pattern",Description="A design Pattern that mediates data access and business logic",
               LastUpdated=new DateTime()},
                new Blog()
               {Id=2,Title="Api Gateway",Description="Acts as reverse proxy, ",
               LastUpdated=new DateTime()},
                 new Blog()
               {Id=3,Title="Microservices",Description="Collection of multiple service",
               LastUpdated=new DateTime(day:25,month:02,year:2012)},
                  new Blog()
               {Id=4,Title="Docker",Description="to conterize you app",
               LastUpdated=new DateTime(day:12,month:07,year:2023)},
           };
            return result;
        }

        public int Delete(int id)
        {
            var delBlog=_blogs.SingleOrDefault(b => b.Id == id);
            if (delBlog != null)
            {
                _blogs.Remove(delBlog);
            }
            return delBlog?.Id ?? 0;
        }

        public List<Blog> GetAll()
        {
            return _blogs;
        }

        public Blog GetById(int id)
        {
            return _blogs.FirstOrDefault(b => b.Id == id);
        }
    }
}
