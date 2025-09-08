using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using CsharpStudy.Asynchronous.Entities;
using NUnit.Framework;

namespace CsharpStudy.Asynchronous.Tests;

[TestFixture]
[TestOf(typeof(Program))]
public class ProgramTest
{
    Parrot parrot;
    Crow crow;
    Sparrow sparrow;
    
    CancellationTokenSource cts;
    CancellationToken token;
    
    [SetUp]
    public void SetUp()
    {
        parrot = new Parrot();
        crow = new Crow();
        sparrow = new Sparrow();
        
        cts = new CancellationTokenSource();
        token = cts.Token;
    }

    [Test]
    public async Task FINISH_TASKS_BEFORE_13000MILLISECONDS()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        var tasks = new List<Task<int>>
        {
            parrot.CallsAsync(), crow.CallsAsync(), sparrow.CallsAsync()
        };
        await Task.WhenAll(tasks);
        stopwatch.Stop();
        
        Assert.That(stopwatch.ElapsedMilliseconds, Is.LessThanOrEqualTo(13000));
    }
    
    [Test]
    public void TASKS_WERE_CANCELLED_AT_4998MS()
    {
        var tasks = new List<Task<int>>
        {
            parrot.CallsAsync(), crow.CallsAsync(), sparrow.CallsAsync(),
            Bird.ProvideTimeoutWithToken(token)
        };
        
        cts.CancelAfter(4998); // Tasks were cancelled

        Assert.ThrowsAsync<TaskCanceledException>(async () => await Task.WhenAll(tasks));
    }
    
    [Test]
    public void TASKS_WERE_TIMEDOUT_AFTER_5000MS()
    {
        var tasks = new List<Task<int>>
        {
            parrot.CallsAsync(), crow.CallsAsync(), sparrow.CallsAsync(),
            Bird.ProvideTimeoutWithToken(token) // throw timeout after 5000ms
        };

        Assert.ThrowsAsync<TimeoutException>(async () => await Task.WhenAll(tasks));
    }
}