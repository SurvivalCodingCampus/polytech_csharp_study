using CsharpStudy._2hakgi.Assignment.Model_Repository.Data.DataSources;

namespace CsharpStudy._2hakgi.Assignment.Model_Repository;

public class Program
{
    static async Task Main(string[] args)
    {
        // testCase(1)
        InventoryRepository inventory 
            = new InventoryRepository(new MockItemDataSource(), 20, 20);
    }
}