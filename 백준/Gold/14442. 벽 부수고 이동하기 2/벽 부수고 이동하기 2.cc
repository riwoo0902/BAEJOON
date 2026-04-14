#include <iostream>
#include <vector>
#include <queue>
#include <string>

using namespace std;

struct Point
{
    int state;
    int cost;

    Point() : state(0), cost(-1) {}
    Point(int s) : state(s), cost(-1) {}
};

struct Node
{
    int x, y, z;
};

int main()
{
    ios::sync_with_stdio(false);
    cin.tie(nullptr);

    int n, m, k;
    cin >> n >> m >> k;

    vector<vector<vector<Point>>> map(n, vector<vector<Point>>(m, vector<Point>(k + 1)));

    for (int i = 0; i < n; i++)
    {
        string input2;
        cin >> input2;
        for (int j = 0; j < m; j++)
        {
            for (int z = 0; z <= k; z++)
            {
                map[i][j][z] = Point(input2[j] - '0');
            }
        }
    }

    int dx[4] = { 1, -1, 0, 0 };
    int dy[4] = { 0, 0, 1, -1 };

    queue<Node> q;
    q.push({ 0, 0, 0 });
    map[0][0][0].cost = 0;

    int targetX = n - 1;
    int targetY = m - 1;
    int answer = -1;

    while (!q.empty())
    {
        Node cur = q.front();
        q.pop();

        Point& currentPoint = map[cur.x][cur.y][cur.z];

        if (cur.x == targetX && cur.y == targetY)
        {
            answer = currentPoint.cost + 1;
            break;
        }

        for (int dir = 0; dir < 4; dir++)
        {
            int nx = cur.x + dx[dir];
            int ny = cur.y + dy[dir];
            int nz = cur.z;

            if (nx < 0 || nx >= n || ny < 0 || ny >= m)
                continue;

            Point& point = map[nx][ny][nz];

            if (point.cost != -1)
                continue;

            if (point.state == 0)
            {
                point.cost = currentPoint.cost + 1;
                q.push({ nx, ny, nz });
            }
            else if (nz < k)
            {
                if (map[nx][ny][nz + 1].cost == -1)
                {
                    map[nx][ny][nz + 1].cost = currentPoint.cost + 1;
                    q.push({ nx, ny, nz + 1 });
                }
            }
        }
    }

    cout << answer << '\n';
    return 0;
}