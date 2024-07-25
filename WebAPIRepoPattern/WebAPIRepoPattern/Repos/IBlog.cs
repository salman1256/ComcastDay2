using WebAPIRepoPattern.Models;

namespace WebAPIRepoPattern.Repos
{
    public interface IBlog
    {
        List<Blog> GetAll();
        Blog GetById(int id);
        int Delete(int id);

    }
}
