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

/*
 * Status is active if:
 * - Isn't complete.
 * - Has been created last month.
 * - Isn't assigned to someone else.
 * - Is in progress right now.
 */
bool IsActive(IStatus status) => status switch
{
    Complete => false,
    New n => n.CreatedAt > DateTime.Now.AddMonths(-1),
    InProgress { AssignedTo: User.SomeoneElse } => false,
    InProgress p when p.AssignedAt <= DateTime.Now => true,
    InProgress => false,
    _ => throw new ArgumentOutOfRangeException(),
};

char AsEmoji(bool b) => b ? '✅' : '❎';

IStatus status = new Complete(DateTime.Now);
Console.WriteLine($"Is a complete status active? {AsEmoji(IsActive(status))}");

status = new New(DateTime.Now);
Console.WriteLine($"Is a new status created now active? {AsEmoji(IsActive(status))}");

status = new New(DateTime.Now.AddMonths(-3));
Console.WriteLine($"Is a new status created 3 months ago active? {AsEmoji(IsActive(status))}");

status = new InProgress(User.Someone, DateTime.Now);
Console.WriteLine($"Is a in progress status assigned to someone active? {AsEmoji(IsActive(status))}");

status = new InProgress(User.SomeoneElse, DateTime.Now);
Console.WriteLine($"Is a in progress status assigned to someone else active? {AsEmoji(IsActive(status))}");

status = new InProgress(User.Someone, DateTime.Now.AddDays(3));
Console.WriteLine($"Is a in progress status assigned in the future active? {AsEmoji(IsActive(status))}");

record New(DateTime CreatedAt) : IStatus;

record Complete(DateTime CompletedAt) : IStatus;

record InProgress(User AssignedTo, DateTime AssignedAt) : IStatus;

interface IStatus {};

enum User
{
    Someone,
    SomeoneElse,
}
