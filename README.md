# MadBoxTest

Time spent: 5h

Most difficult parts:
* Level generation: using linear paths forced the player to suddently change rotation, instead of changing it smoothly using splines.
* Creating a smooth camera following effect, specially addapted to rapid changes in the rotation of the player.

Parts I think could be better:
* The implementation of the structure of the game loop in the game instance, because there is code about the player and the level that could be abstracted further, making it easier to create new levels or game modes.
* Player death: a better death effect could be used, such as using ragdolls in a humanoid character, or adding a stronger impulse force when colliding with obstacles.

Potential improvements:
* Implement different types of obstacles.
* Improve the level generation method, using splines instead of linear paths, or spawning the waypoints automatically instead of manually.
* Add additional players controlled by an AI: moving forward, stopping if they find an obstacle and avoiding it.

The game includes an apk that can be player on Android devices under the path "builds/test.apk"
I think that the game is very similar to the reference, except that the level only includes linear paths instead of curved paths.
