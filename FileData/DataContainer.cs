using Shared;

namespace FileData;

public class DataContainer
{
    //read the data from the file and load into these two collections
    public ICollection<User> Users { get; set; }
    public ICollection<Post> Posts { get; set; }
}