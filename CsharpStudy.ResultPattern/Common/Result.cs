namespace CsharpStudy.ResultPattern.Common;

public abstract record Result
    {
    private Result() { }
    public sealed record Success : Result;
    public sealed record Failure(Error Error) : Result;

    public static Result Ok() => new Success();
    public static Result Fail(Error e) => new Failure(e);
}
