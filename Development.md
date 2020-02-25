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
