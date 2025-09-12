using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Model_Repo.Datasource;
using Model_Repo.Interfaces;
using Model_Repo.Models;
using Model_Repo.Repositiories;
using NUnit.Framework;

namespace Model_Repo.Test.Interfaces;

[TestFixture]
[TestOf(typeof(IInventoryRepository))]
public class InventoryRepositoryTest
{
    private IDataSource<Item> _dataSource;
    private IInventoryRepository _repository;
    
    [SetUp]
    protected void Setup()
    {
        List<Item> items =
        [
            new Item(1, "Sword", 1),
            new Item(2, "Shield", 4),
        ];
        
        _dataSource = new MockItemDataSource();
        _dataSource.SaveAllAsync(items);
        _repository = new InventoryRepository(_dataSource, 4, 20);
    }
    
    [Test]
    [DisplayName("인벤토리 초기화 및 로드")]
    public async Task METHOD_1()
    {
        //when
        List<Item> items = await _repository.GetItemsAsync();
    
        //then
        Assert.True(items.Exists(it => it.Name.Equals("Sword")));
        Assert.True(items.Exists(it => it.Name.Equals("Shield")));
    }

    [Test]
    [DisplayName("새로운 아이템 추가 => 성공")]
    public async Task METHOD_2()
    {
        //given
        var addItem = new Item(3, "Potion", 3);
        
        //when
        await _repository.AddItemAsync(addItem);
        var items = await _repository.GetItemsAsync();
        
        //then
        Assert.True(items.Exists(it => it.Name.Equals("Potion")));
        Assert.True(items.Count == 3);
    }

    [Test]
    [DisplayName("기존 아이템 개수 증가 => 성공")]
    public async Task METHOD_3()
    {
        //given
        var addItem = new Item(1, "Sword", 1);
        
        //when
        await _repository.AddItemAsync(addItem);
        var items = await _repository.GetItemsAsync();
        var sword = items.First(it => it.Name.Equals("Sword"));

        //then
        Assert.True(sword.Count == 2);
    }

    [Test]
    [DisplayName("새로운 아이템 추가 => 실패 - maxSlot초과")]
    public async Task METHOD_4()
    {
        //given
        List<Item> items =
        [
            new Item(1, "Sword", 1),
            new Item(2, "Shield", 4),
        ];
        
        _dataSource = new MockItemDataSource();
        await _dataSource.SaveAllAsync(items);
        _repository = new InventoryRepository(_dataSource, 2, 20);
        var mouse = new Item(5, "Mouse", 2);
        
        //when
        var result = await _repository.AddItemAsync(mouse);
        var resultItems = await _repository.GetItemsAsync();
        
        Assert.False(result);
        Assert.False(resultItems.Exists(it => it.Name.Equals("Mouse")));
    }
    
    [Test]
    [DisplayName("새로운 아이템 추가 => 실패 - maxStack")]
    public async Task METHOD_5()
    {
        //given
        List<Item> items =
        [
            new Item(1, "Sword", 1),
            new Item(2, "Shield", 4),
        ];
        
        _dataSource = new MockItemDataSource();
        await _dataSource.SaveAllAsync(items);
        _repository = new InventoryRepository(_dataSource, 2, 5);
        var shield = new Item(2, "Shield", 2);
        
        //when
        var result = await _repository.AddItemAsync(shield);
        var resultItems = await _repository.GetItemsAsync();
        var shieldCount = resultItems.First(it => it.Name.Equals("Shield")).Count;

        Assert.False(result);
        Assert.True(shieldCount == 4);
    }
}