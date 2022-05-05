using Application.DTOs.Account;
using FluentValidation.Results;

namespace Application.Core;

public class Result<T>
{
    public bool IsSuccess { get; set; }
    public bool? IsAuthorized { get; set; }
    public T Value { get; set; }
    public string Error { get; set; }

    public static Result<T> Success(T value) =>
        new() {IsSuccess = true, Value = value};

    public static Result<T> Failure(string error) =>
        new() {IsSuccess = false, Error = error};

    public static Result<T> Failure(ValidationResult validationResult) =>
        new() {IsSuccess = false, Error = string.Join(", ", validationResult.Errors)};

    public static Result<T> Authorized(T value) =>
        new() {IsAuthorized = true, Value = value};
    public static Result<T> Unauthorized(string error) =>
        new() {IsAuthorized = false, Error = error};
}