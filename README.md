<a href="https://virtualvortex.github.io/UtilityBaseAI/AboutMe">AboutMe</a> <a href="https://virtualvortex.github.io/UtilityBaseAI/Development">Development</a>

## Utility Based AI for FPS Enemy AI 

In this project I will be creating an artefact using an AI technique called Utility Base Systems for the enemy AI in an FPS game. The AI will be able to move towards the player, try to shoot the player, Take cover, self heal, use heal stations and flank the player   

## Poster

You can download my poster about the artefact here: <a href="COMP250 Poster (1).pdf" Download >Poster</a>

## UML Diagram of the Arefact

![UML Diagram](COMP250UMLdiagram.jpg)

## Research

Utility Based AI is an AI technique with relative options that it can use to solve its current problem. It makes its decisions based on utilities (scores) that are provided by picking the action with the highest utility. There are different ways to calculate utility, by using functions such as Step, Linear or Sigmoid, where the utility of the actions varies on the input value. Dual Utility Reasoning is a technique that uses both Utility based AI techniques and combines them. Each action is stored in a hierarchy or ‘bucket’ that’s relative to the action. For example, a health bucket could contain actions such as ‘use syringe’ which has a score of 10 and ‘use Bandage’ with a score of 5, scores are also refered to as weights. Each bucket has a weight sometimes called ranks, which are used in the AI’s decision making, the bucket with the greater weight will have higher priority over the other buckets. The weight of the buckets can be randomised, or the weight can change depending on the situation and the AI compares a random number it generates to the weights, picking the bucket with the closest one (Graham 2020). Instead of picking the hightest utility it will pick the lowest utility due to how it calculate the score and weights.  

## Video

<video src="2020-02-24 09-20-56.mp4" poster="AIScreenshot.jpg" width="520" height="400" controls preload></video>

The video is place holder

## Argument

I Decided to use Utility Based AI due to it allowing the enemy AI to remain entertaining and less predictable when re-playing the game, which is phenomenon that occurs on most games. Michelle, who also aimed to take care of the same problem by researching a different AI techniqe, used examples such as the Big Daddys from Bioshock and the Striders from Half Life, stating that "come the end of the game and you’re often ploughing through computerised enemies with ease – the bots are no longer the insurmountable challenge they were when you first saw them." (McPartland 2013). In addition, it has been stated that Utility Based Systems if done right could potentially make decisions for parts of the game that the AI designer may not have considered.   

The advantages of using Utility Based AI is that it can be used for complexted behaviour and be used as an alternative to behaviour trees if the developers are unable to implement them(Kylotan 2018). 

A disadvantage using Utility Based AI is that a lot of time and testing is required to make the AI entertaining for the player. This is because how the utility is calulated may need to be changed. In addition, the numbers that the AI uses to calculate the utilities may need to be changed as well. The other disadvantage with Utility Based AI is that though the AI may make calculations and use them to make decisions, it isn't Machine learning. By this I mean it could work no differently then FSM or behaviour trees do in an enviroment, which had occasionally been the case when working with the AI.

Behaviour trees or reinforcement learning could be used as an alternative for the AI as it can be argued that Utility Based AI is a combination of both techniques. Behaviour trees consist of tasks that you can assign to run depending on the state of the enviroment(Rasmussen 2016). 


Reinforcement learning allows designers to create enemy AI with different characteristics, this is done by training the AI with in real time by either changing the enviroment or values in the AI. This type of AI technique makes testing and altering the AI faster and more accessible compared to Utility Based AI. That being said the AI will not change in the game itself, only during the development of the game (McPartland 2013). 


Present claim

evidence to support and refute claim

pros and cons

experimental evidence

consider alternatives

justofy your decision based on evidence


# Bibliography
GRAHAM, David “. 2020. 'An Introduction to Utility Theory'. In Anonymous Game AI Pro 360. (1st edn). CRC Press, 67-80. 

RASMUSSEN, Jakob. 27/04/16. 'Are Behavior Trees a Thing of the Past?'. Available at: https://www.gamasutra.com/blogs/JakobRasmussen/20160427/271188/Are_Behavior_Trees_a_Thing_of_the_Past.php. [Accessed Feb 28,]. 

Kylotan. 2018. 'The Total Beginner's Guide to Game AI'. Available at: https://gamedev.net/tutorials/programming/artificial-intelligence/the-total-beginners-guide-to-game-ai-r4942. [Accessed Mar 7,].

DILL, Kevin. 2015. Game AI Pro 2: Collected Wisdom of Game AI Professionals. CRC Press.

MCPARTLAND, Michelle. 2013. 'Beaten by Bots – Training AI for First-Person Shooter Games'. Available at: http://theconversation.com/beaten-by-bots-training-ai-for-first-person-shooter-games-11176. [Accessed Mar 7,].
