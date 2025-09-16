namespace CsharpStudy.ResultPattern.Common;

public record Error(
    SubwayError Kind,
    string Message,
    Exception? Exception = null
    );