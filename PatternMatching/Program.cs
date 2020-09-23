using System;
using System.Linq;

var statuses = new IStatus[]
{
    new New(DateTime.MinValue),
    new InProgress(User.Someone, DateTime.Now),
    new InProgress(User.SomeoneElse, DateTime.Now),
    new InProgress(User.Someone, DateTime.Now),
    new Complete(DateTime.MaxValue),
};

// To be or not to be
var noOfInProgressStatuses = statuses.Count(status => status is InProgress);

Console.WriteLine($"No of InProgress statuses is {noOfInProgressStatuses}");

var noOfStatusesOtherThanInProgress = statuses.Count(status => status is not InProgress);

Console.WriteLine($"No statuses other than InProgress is {noOfStatusesOtherThanInProgress}");

// Let's get to the matching!
bool Test(IStatus status) => status switch
{
    New => true,
    InProgress => true,
    Complete => false,
    _ => throw new ArgumentOutOfRangeException(),
};

var test = Test(statuses.First());

record New(DateTime CreatedAt) : IStatus;

record Complete(DateTime CompletedAt) : IStatus;

record InProgress(User AssignedTo, DateTime AssignedAt) : IStatus;

interface IStatus {};

enum User
{
    Someone,
    SomeoneElse,
}
