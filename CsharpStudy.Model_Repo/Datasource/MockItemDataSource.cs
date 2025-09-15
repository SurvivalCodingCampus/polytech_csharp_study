using Model_Repo.Interfaces;
using Model_Repo.Models;

namespace Model_Repo.Datasource;

public class MockItemDataSource : IDataSource<Item>
{
    private List<Item> _resource = [];
    public async Task<List<Item>> LoadAllAsync() => [.._resource];
    public async Task SaveAllAsync(List<Item> list) => _resource = [..list];
    
}