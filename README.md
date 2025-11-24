# 2025-02 Game Programming Practice 3

Computer Science Department, Zolboo Tumendemberel, 24110177

## Added features

* Mouse current position movement
  + Movement through swiping / mouse dragging felt awful to control, so changed the control scheme to follow the current position of the mouse/screen rather than swiping.
* Added kill counter

![image](/Images/image.png)

* Added death sound effect for when enemies die
* For every 10 kills, the wave "power" increases and more enemies spawn. 
* Balanced attack speed scaling by scaling with flat increase that affects attack percentage
* Added an enemy variant which spawns less frequently than the regular but has more health.
  + This enemy in turn will spawn more and more frequently the more waves the player plays.

![image](/Images/image%20copy.png)

* HP added to the player. When the enemy passes the line in front of the player, the player loses HP.
  + When a new wave begins, player is healed to full HP.
* After killing 15 enemies, a new wave begins, and the spawn rate for stronger enemy increases, enemy spawn rate increases
* Made the map look like a fantasy land

![image](/Images/image%20copy%202.png)

## Thoughts and reflections

* Overall, object-oriented programming feels a bit sluggish, and annoying to code without referencing other projects written by people who have already done the work before. Coming up with my own code was very slow.
* Game dev as a whole feels like it is very time consuming. And 3D development feels especially more time consuming as positioning and even navigating the 3D environment feels less intuitive than 2D space.
  + Generally, these projects should've been done much earlier, and with more time put into it. Would've liked to started work on this earlier.
