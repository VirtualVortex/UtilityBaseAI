<a href="https://virtualvortex.github.io/UtilityBaseAI/">Home</a>

## Development

<b>6/2/20</b> - Starting Point
<ul style="list-style-type:none;">
  <li>I began by planning out what kind of buckets would be required for the AI as well as what values the AI would monitor and use 
          for utility calculations. I cloned a copy of an old FPS shooter I created which the AI would use as its enviroment. After that I            started to make the prototype base classes for both the buckets and the actions that the AI would use. These classes would              have their own names and utility so that the system could find and call the methods with ease.
  </li>
</ul>
          
<b>7/2/20</b> - Begin using factory patterns
<ul style="list-style-type:none;">
  <li>Due to there being a lot of buckets and actions being created by the AI and each of them being a seprate class it would mean losts         of components would be attached to the AI's prefabs. To counteract this I used a Factory pattern which is a type of programming             pattern that would create instances of the bucket and actions classes and then call said functions when need be.
  </li>
</ul>

<b>10/2/2020</b> - Calling action methods in bucket content child classes
<ul style="list-style-type:none;">
  <li>With most of the Bucket classes having action classes to use (via factory patterns) I began testing to see if the methods in the child classes and bucket classes could be called, and work without causing errors. 
  </li>
</ul>

<b>17/2/2020</b> - Calculating scores and weights and basic desicion making
<ul style="list-style-type:none;">
  <li>In each bucket content class I've added a calculate score function that will look at specific parts of the enviroment and calculate a number. The same has been done for the bucket classes however they use Linear and Quadratic equations to calculate their values. These numbers are then compared to one another, the largest number is picked and the correct method is called.
  </li>
</ul>

<b>21/2/2020</b> - changing to real time decision making
<ul style="list-style-type:none;">
  <li>I've changed a part of the code so that instead of it making a decision every 3 seconds it will make a decision every 0.25 seconds. This is to stop the frame rate from dropping but quick enought for the player to not notice any delays. The AI switches between decisions based on the smallest weight it finds in (roughlty) real time. To prevent the system from constantly jumping between actions it will add a bonus to the action's score.  
  </li>
</ul>

<b>12/3/2020</b> - Improving decision making and Adding UI
<ul style="list-style-type:none;">
  <li>Using System.Linq I was able to get the AI to find the smallest score/weight or the nearest score/weight to a random number it generated a lot faster then it used to. This surprisingly allowed it to occasionally pick different actions instead of it's default ones when, which occured when looking for the smallest utility. One problem that did occur however, was that when finding the nearest number to a random number, the frame rate would drop at times, possibly due to the amount of numbers being generated at a given time. In addition, when it decides to use  health station it does have to wait for it to say that it has completed the task. This is to prevent it from calling the action multiple times and thus prevent it from actually reaching the health station.
    
I also added UI to show the scores or every bucket and actions as well that bucket and action it picks when making a decision. This was so that I could anticipate what was going to happen.
  </li>
</ul>

<b>23/3/2020</b> - Multiple AIs
<ul style="list-style-type:none;">
  <li>I have made changes to the bucket and actions classes so that multiple enemy AIs can use and thus make the game feel more like a First Person Shooter (FPS). Each AI's movement and damage dealt frequency was set to a random number at the start to allow for different behaviours. This showed promise, but the AIs would make undesired decisions at times, that didn't fit the specific changes to the enviroment. 
  </li>
</ul>

<b>25/3/2020</b> - Grenade Throwing and changes to move to player action
<ul style="list-style-type:none;">
  <li>I added in another action that allows enemy to throw two grenades when at a specific distance. This is intended to make the player move more often around the level. At the moment, the action is picked more frequenctly when the actions are picked randomly compared to when it pickes the actions with the smallest score. The AI's 'Move to player, action was changed by removing the AI's health from the equation that calculate the scores. This resulted in an increase of it moving to the player, but would still pick other actions in the movement bucket from time to time.
  </li>
</ul>

<b>29/3/2020</b> - AI movement and thowing grenades
<ul style="list-style-type:none;">
  <li>The AI's throw grenade action has been changed to only throw onw greande at a time in order to prevent killing the player too easily. In addition, the Ai's movement frequency will decrease over time now instead of just when they're standing still, this is to ensure that they move more often when their actions are being picked randomly and so that the player can't kill them too quickly. 
  </li>
</ul>
