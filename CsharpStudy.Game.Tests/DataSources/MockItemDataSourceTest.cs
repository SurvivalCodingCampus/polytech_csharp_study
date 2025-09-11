using System.Collections.Generic;
using Asynchronous;
using Asynchronous.DataSources;
using NUnit.Framework;

namespace CsharpStudy.Game.Tests.DataSources;

[TestFixture]
[TestOf(typeof(MockItemDataSource))]
public class MockItemDataSourceTest
{

    [Test]
    public void 인벤토리_초기화_및_로드()
    {
        var mockItemDataSource = new MockItemDataSource();
        
        IItemDataSource itemDataSource = mockItemDataSource; //비동기 초기화 및 로드
        

    }
    [Test]
    public void 새로운_아이템_추가_성공()
    {
        var mockItemDataSource = new MockItemDataSource();
        
    }
    [Test]
    public void 기존_아이템_개수_증가_성공()
    {
        var mockItemDataSource = new MockItemDataSource();
        
    }
    [Test]
    public void 새로운_아이템_추가_실패_maxSlot_초과()
    {
        var mockItemDataSource = new MockItemDataSource();
        
    }
    [Test]
    public void 아이템_개수_증가_실패_maxStack_초과()
    {
        var mockItemDataSource = new MockItemDataSource();
        
    }
}