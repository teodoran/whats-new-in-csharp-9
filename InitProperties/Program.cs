using System;

var newStatus = new Status
{
    Name = StatusName.New,
    CreatedAt = DateTime.Now,
};

var inProgressStatus = new Status
{
    Name = StatusName.InProgress,
    AssignedTo = User.Someone,
    AssignedAt = DateTime.Now,
};

var completedStatus = new Status
{
    Name = StatusName.Completed,
    CompletedAt = DateTime.Now,
};

// Whoops! This wasn't intended.
completedStatus.Name = StatusName.InProgress;

Console.WriteLine("We're all good 👍");

class Status
{
    public StatusName Name { get; set; } // Hmm, maybe we can use init here.
    public DateTime CreatedAt { get; set; }
    public User AssignedTo { get; set; }
    public DateTime AssignedAt { get; set; }
    public DateTime CompletedAt { get; set; }
}

enum StatusName
{
    New,
    InProgress,
    Completed,
}

enum User
{
    Someone,
    SomeoneElse,
}
