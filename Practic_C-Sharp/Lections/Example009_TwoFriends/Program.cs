int count = 0;
double distance = 10000;
int firsftFriendSpeed = 1;
int secondFriendSpeed = 2;
int dogSpeed = 5;
int friend = 2;
double time = 0;

while (distance > 10)
    if (friend == 1)
    {
        time = distance / (firsftFriendSpeed + dogSpeed);
        friend = 2;
        distance = distance - (firsftFriendSpeed + secondFriendSpeed) * time;
        count++;
        Console.WriteLine(distance);
    }
    else
    {
        time = distance / (secondFriendSpeed + dogSpeed);
        friend = 1;
        distance = distance - (firsftFriendSpeed + secondFriendSpeed) * time;
        count++;
        Console.WriteLine(distance);
    }
Console.WriteLine(count);