public class Maze
{
    private readonly Dictionary<(int, int), bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<(int, int), bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    /// <summary>
    /// Move left if allowed.
    /// </summary>
    public void MoveLeft()
    {
        if (!_mazeMap.TryGetValue((_currX, _currY), out var directions) || !directions[0])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        _currX -= 1;
    }

    /// <summary>
    /// Move right if allowed.
    /// </summary>
    public void MoveRight()
    {
        if (!_mazeMap.TryGetValue((_currX, _currY), out var directions) || !directions[1])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        _currX += 1;
    }

    /// <summary>
    /// Move up if allowed.
    /// </summary>
    public void MoveUp()
    {
        if (!_mazeMap.TryGetValue((_currX, _currY), out var directions) || !directions[2])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        _currY -= 1;
    }

    /// <summary>
    /// Move down if allowed.
    /// </summary>
    public void MoveDown()
    {
        if (!_mazeMap.TryGetValue((_currX, _currY), out var directions) || !directions[3])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        _currY += 1;
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}
