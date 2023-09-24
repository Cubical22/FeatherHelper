local connection = {}
connection.name = "FeatherHelper/ConnectionDisplay"
connection.depth = 6000
connection.justification = {0.5,0.5}
connection.texture = "entities/FeatherHelper/connection"
connection.placements = {
    {
        name = "default",
        data = {
            brotherCount = 1
        }
    },
    {
        name = "triple",
        data = {
            brotherCount = 2
        }
    },
}

return connection