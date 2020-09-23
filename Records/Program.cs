using System;

// Regular old objects.
var newStatus = new New(createdAt: DateTime.MinValue);
var otherNew = new New(createdAt: DateTime.MinValue);

Console.WriteLine($"I wish we were equal... {newStatus == otherNew}");

// Records does structural equality.
var completeStatus = new Complete(DateTime.MaxValue);
var otherComplete = new Complete(DateTime.MaxValue);

Console.WriteLine($"We're actually equal 🙌 {completeStatus == otherComplete}");

// We can even have positional records.
var inProgress = new InProgress(User.Someone, DateTime.Now);

// Positional records will deconstruct out of the box.
var (assignedTo, assignedAt) = inProgress;
Console.WriteLine($"I Guess we're assigned at {assignedAt}");

// We can create new records from old ones.
var inProgressUtc = inProgress with { AssignedAt = DateTime.UtcNow };
Console.WriteLine($"And now we should be assigned at {inProgressUtc.AssignedAt}");

class New : IStatus
{
    public DateTime CreatedAt { get; }

    public New(DateTime createdAt) => CreatedAt = createdAt;
}

// Regular record
record Complete : IStatus
{
    public DateTime CompletedAt { get; }

    public Complete(DateTime completedAt) => CompletedAt = completedAt;
}

// Positional record
record InProgress(User AssignedTo, DateTime AssignedAt) : IStatus;

interface IStatus { }

enum User
{
    Someone,
    SomeoneElse,
}
