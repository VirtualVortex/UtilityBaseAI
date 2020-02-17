## Utility Based AI for FPS Enemy AI 


<a href={{ page.AboutMe.md }}>{{ page.title }}</a>


In this project I will be creating an arfecaft using an AI technique called Utility base AI for the enemy AI in an FPS game.

## UML Diagram of the Arefact

## Research

## Video

## Development

<b>6/2/20</b> - Starting Point
<ul style="list-style-type:none;">
  <li>I began by planning out what kind of buckets would be required for the AI as well as what values the AI would monitor/used 
          for utility calculations. I cloned a copy of an old FPS shooter I created which the AI would use as its enviroment. After that I            started to making the prototype base classes for both the buckets and the actions that the AI would use. These classes would              have their own names and utility so that the system can find and call the methods with ease.
  </li>
</ul>
          
<b>7/2/20</b> - Begin using factory patterns
<ul style="list-style-type:none;">
  <li>Due to there being a lot of buckets and actions being created by the AI and each of them being a seprate class it would mean losts         of components would be attached to the AI's prefabs. To counteract this I used a Factory pattern which is a type of programming             pattern that would create instances of the bucket and actions classes and then call said functions when need be.
  </li>
</ul>

<b>10/2/2020</b> - Calling action methods in bucket content child classes
<ul style="list-style-type:none;">
  <li>With most of the Bucket classes having action classes to use (via factory patterns) I began testing to see if the methods in the child action and bucket classes could be called, and work without causing errors. 
  </li>
</ul>

## Argument
Present claim
evidence to support and refute claim
pros and cons
experimental evidence
consider alternatives
justofy your decision based on evidence
