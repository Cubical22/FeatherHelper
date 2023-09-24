local Barrier = {}

Barrier.name = "FeatherHelper/FeatherBarrier"
Barrier.depth = 5000
Barrier.fillColor = {0,0,0}
Barrier.borderColor = {1,0,0}
Barrier.nodeLineRenderType = "line"
Barrier.nodeLimits = {0,1}
Barrier.placements = {
    name = "default",
    data = {
        width = 8,
        height = 8
    }
}

return Barrier