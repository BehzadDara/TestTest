List<List<string>> lists =
    [
        ["x", "y", "z", "x", "w", "d"],
        ["x", "y", "a", "b", "c", "d"],
        ["q", "d", "y", "b", "r", "y"],
    ];

var removedRepeats = RemoveListRepeats(lists);

var finalResult = FindMutual(removedRepeats);
Console.WriteLine(string.Join(", ", finalResult));

static List<string> FindMutual(List<List<string>> lists)
{
    List<string> linearList = [];
    foreach (var list in lists)
    {
        linearList.AddRange(list);
    }

    return ReturnRepeats(linearList, lists.Count);
}

static List<List<string>> RemoveListRepeats(List<List<string>> lists)
{
    List<List<string>> result = [];

    foreach (var list in lists)
    {
        result.Add(RemoveRepeats(list));
    }

    return result;
}

static List<string> RemoveRepeats(List<string> list)
{
    var tmp = list.GroupBy(x => x);
    return tmp.Where(x => x.Count() == 1).Select(x => x.Key).ToList();
}

static List<string> ReturnRepeats(List<string> list, int count)
{
    var tmp = list.GroupBy(x => x);
    return tmp.Where(x => x.Count() == count).Select(x => x.Key).ToList();
}