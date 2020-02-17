<a href="https://virtualvortex.github.io/UtilityBaseAI/AboutMe">AboutMe</a>

## Utility Based AI for FPS Enemy AI 

In this project I will be creating an arfecaft using an AI technique called Utility Base Systems for the enemy AI in an FPS game.

## UML Diagram of the Arefact

![](PlaceholderUMLDiagram.png)

## Research

Utility Based Systems is an AI technique with relative options that it can use to solve its current problem. It makes its decisions based on utilities (scores) that are provided by possibly picking the action with the highest utility. There are different ways to calculate utility, by using functions such as Step, Linear or Sigmoid, where the utility of the actions varies on the input value. Dual Utility is where each action is stored in a hierarchy or ‘bucket’ that’s relative to the action. For example, a health bucket could contain actions such as ‘use syringe’ which has a score of 10 and ‘use Bandage’ with a score of 5. Each bucket has a weight, which are used in the AI’s decision making, the bucket with the greater weight will have higher priority over the other buckets. The weight of the buckets can be randomised, or the weight can change depending on the situation and the AI compares a random number it generates to the weights, picking the bucket with the closest one (Graham 2020). 

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

<b>17/2/2020</b> - Calculating scores and weights and basic desicion making
<ul style="list-style-type:none;">
  <li>In each bucket content class I've added a calculate score function that will look at specific parts of the enviroment and calculate a number. the same has been done for the bucket classes however theur use Linear and Quadratic equations to calculate their values. These numbers are then compared to one another, the largest number is picked and the correct method is called.
  </li>
</ul>

## Argument
Present claim
evidence to support and refute claim
pros and cons
experimental evidence
consider alternatives
justofy your decision based on evidence

# Bibliography
GRAHAM, David “. 2020. 'An Introduction to Utility Theory'. In Anonymous Game AI Pro 360. (1st edn). CRC Press, 67-80. 
